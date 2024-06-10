using Microsoft.AspNetCore.Mvc;
using PA2.Models;
using PA2.datos;
using PA2.servicos;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.AspNetCore.Http.Extensions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace PA2.Controllers
{
    public class InicioController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public InicioController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correo, string clave)
        {
            usuariodts usuario = dbusuario.validar(correo, utilidadservicio.ConvertirSHA256(clave));
            if (usuario != null)
            {
                if (usuario.confirmado)
                {
                    return RedirectToAction("Index", "Home");
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


        public IActionResult registrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult registrar(usuariodts usuario)
        {
            if (usuario.clave != usuario.confirmarClave)
            {
                ViewBag.nombre = usuario.nombre;
                ViewBag.correo = usuario.correo;
                ViewBag.Mensaje = "Las contraseñas no coinciden";
                return View();
            }

            if (dbusuario.obtener(usuario.correo, usuario.clave) == null)
            {
                usuario.clave = utilidadservicio.ConvertirSHA256(usuario.clave);
                usuario.token = utilidadservicio.generartoken();
                usuario.restablecer = false;
                usuario.confirmado = false;

                bool respuesta = dbusuario.registrar(usuario);
                if (respuesta)
                {
                    string path = Path.Combine(_hostingEnvironment.ContentRootPath, "Plantilla", "confirmar.html");
                    string content = System.IO.File.ReadAllText(path);

                    string url = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Inicio/confirmar?token=" + usuario.token;
                    string htmlBody = string.Format(content, usuario.nombre, url);

                    correodts Correodts = new correodts();
                    {
                        Correodts.para = usuario.correo;
                        Correodts.asunto = "Correo confirmación";
                        Correodts.contenido = htmlBody;
                    }

                    bool enviado = correoservicio.enviar(Correodts);
                    ViewBag.creado = true;
                    ViewBag.Mensaje = $"Su cuenta ha sido creada. Hemos enviado un mensaje al correo {usuario.correo} para confirmar su cuenta";
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


        public IActionResult confirmar(string token)
        {
            bool confirmacionExitosa = dbusuario.confirmar(token);

            ViewBag.respuesta = confirmacionExitosa;
            return View();
        }


        public IActionResult restablecer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult restablecer(string correo, string clave, string token)
        {
            usuariodts usuario = dbusuario.obtener(correo, clave); 
            ViewBag.correo = correo;
            if (usuario != null)
            {
                bool respuesta = dbusuario.restableceractualizar(1, usuario.clave, usuario.token);

                if (respuesta)
                {
                    string path = Path.Combine(_hostingEnvironment.ContentRootPath, "Plantilla", "restablecer.html");
                    string content = System.IO.File.ReadAllText(path);

                    string url = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Inicio/actualizar?token=" + usuario.token;
                    string htmlBody = string.Format(content, usuario.nombre, url);

                    correodts Correodts = new correodts();
                    {
                        Correodts.para = correo;
                        Correodts.asunto = "Restablecer cuenta";
                        Correodts.contenido = htmlBody;
                    }

                    bool enviado = correoservicio.enviar(Correodts);
                    ViewBag.restablecido = true;
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo restablecer la cuenta";
                }

            }
            else
            {
                ViewBag.Mensaje = "No se encontraron coincidencias con el correo";
            }
            return View();
        }


        public IActionResult actualizar(string token)
        {
            ViewBag.token = token;
            return View();
        }
        [HttpPost]
        public IActionResult actualizar(string token, string clave, string confirmarClave)
        {
            ViewBag.token = token;
            if (clave != confirmarClave)
            {
                ViewBag.Mensaje = "Las contraseñas no coinciden";
                return View();
            }
            bool respuesta = dbusuario.restableceractualizar(0, utilidadservicio.ConvertirSHA256(clave), token);

            if (respuesta)
            {
                ViewBag.restablecido = true;
            }
            else
            {
                ViewBag.Mensaje = "No se pudo actualizar";
            }
            return View();
        }

        public IActionResult contacto()
        {
            return View();
        }

    }
}
