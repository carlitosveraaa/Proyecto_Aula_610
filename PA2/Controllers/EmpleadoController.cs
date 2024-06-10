using Microsoft.AspNetCore.Mvc;
using PA2.Models;
using PA2.datos;
using PA2.servicos;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

namespace PA2.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EmpleadoController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult empleados()
        {
            return View();
        }

        public IActionResult Login_empleados()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login_empleados(string cdempleado, string clave, string correo)
        {
            empleadodts empleado = bdempleado.validar(cdempleado, utilidadservicio.ConvertirSHA256(clave));
            if (empleado != null)
            {
                if (empleado.confirmado)
                {
                    return RedirectToAction("empleados", "Empleado");
                }
                else
                {
                    ViewBag.Mensaje = $"Falta confirmar su cuenta. Se le envió un correo a {correo}";
                    return View();
                }
            }
            else
            {
                ViewBag.Mensaje = "No se encontraron coincidencias con esas credenciales";
                return View();
            }
        }

        public IActionResult reg_emp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult reg_emp(empleadodts empleado)
        {
            if (empleado.clave != empleado.confirmarClave)
            {
                ViewBag.nombre = empleado.nombre;
                ViewBag.correo = empleado.correo;
                ViewBag.Mensaje = "Las contraseñas no coinciden";
                return View();
            }

            if (bdempleado.obtener(empleado.correo, empleado.clave) == null)
            {
                empleado.clave = utilidadservicio.ConvertirSHA256(empleado.clave);
                empleado.token = utilidadservicio.generartoken();
                empleado.restablecer = false;
                empleado.confirmado = false;

                bool respuesta = bdempleado.registrar(empleado);
                if (respuesta)
                {
                    try
                    {
                        string path = Path.Combine(_hostingEnvironment.ContentRootPath, "Plantilla", "confirmar.html");
                        string content = System.IO.File.ReadAllText(path);

                        string url = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Empleado/confirmar_emp?token=" + empleado.token;
                        string htmlBody = string.Format(content, empleado.nombre, url);

                        correodts correodts = new correodts
                        {
                            para = empleado.correo,
                            asunto = "Correo confirmación",
                            contenido = htmlBody
                        };

                        bool enviado = correoservicio.enviar(correodts);
                        if (enviado)
                        {
                            ViewBag.creado = true;
                            ViewBag.Mensaje = $"Su cuenta ha sido creada. Hemos enviado un mensaje al correo {empleado.correo} para confirmar su cuenta";
                        }
                        else
                        {
                            ViewBag.Mensaje = "Su cuenta ha sido creada, pero no se pudo enviar el correo de confirmación.";
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = $"Error al procesar la plantilla de correo: {ex.Message}";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "No fue posible crear su cuenta";
                }
            }
            else
            {
                ViewBag.Mensaje = "El correo ya se encuentra registrado";
            }

            return View();
        }
        public IActionResult confirmar_emp(string token)
        {
            bool confirmacionExitosa = bdempleado.confirmar(token);
            ViewBag.respuesta = confirmacionExitosa;
            return View();
        }

        public IActionResult baja_emp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult baja_emp(string cdempleado, string nombre)
        {
            if (string.IsNullOrEmpty(cdempleado) || string.IsNullOrEmpty(nombre))
            {
                ViewBag.Mensaje = "Por favor, complete todos los campos.";
                return View();
            }

            bool respuesta = bdempleado.eliminar(cdempleado, nombre);
            if (respuesta)
            {
                ViewBag.Mensaje = "El empleado ha sido dado de baja exitosamente.";
            }
            else
            {
                ViewBag.Mensaje = "No se pudo dar de baja al empleado. Verifique los datos ingresados.";
            }

            return View();
        }

    }
}