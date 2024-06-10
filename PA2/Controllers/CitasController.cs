using Microsoft.AspNetCore.Mvc;
using PA2.Models;
using PA2.datos;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Linq;

namespace PA2.Controllers
{
    public class CitasController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CitasController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult citas()
        {
            return View();
        }

        public IActionResult crearCita()
        {
            return View();
        }

        [HttpPost]
        public IActionResult crearCita(string nombre, string apellido, DateTime fecha, string hora)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || fecha == default(DateTime) || string.IsNullOrEmpty(hora))
            {
                ViewBag.Mensaje = "Todos los campos son obligatorios.";
                return View();
            }

            string horaSeleccionada = fecha.ToShortDateString() + " " + hora;
            if (!DateTime.TryParse(horaSeleccionada, out DateTime horaCita))
            {
                ViewBag.Mensaje = "La hora seleccionada no es válida.";
                return View();
            }

            if (CitaExisteEnHora(fecha, hora))
            {
                ViewBag.Mensaje = "La hora seleccionada ya está ocupada. Por favor, elige otro horario.";
                return View();
            }

            Citas cita = new Citas
            {
                Nombre = nombre,
                Apellido = apellido,
                Fecha = fecha,
                Hora = hora,
                Ocupado = true
            };

            bool respuesta = dbcitas.Registrar(cita);
            if (respuesta)
            {
                ViewBag.Mensaje = "Cita creada exitosamente.";
                ViewBag.Reservado = true;
            }
            else
            {
                ViewBag.Mensaje = "No se pudo crear la cita. Inténtelo de nuevo.";
            }

            return View();
        }

        private bool CitaExisteEnHora(DateTime fecha, string hora)
        {
            var citas = dbcitas.ObtenerCitas(); 
            return citas.Any(c => c.Fecha.Date == fecha.Date && c.Hora == hora && c.Ocupado);
        }

        public IActionResult bajaCita()
        {
            return View();
        }

        [HttpPost]
        public IActionResult bajaCita(string idCita)
        {
            if (string.IsNullOrEmpty(idCita))
            {
                ViewBag.Mensaje = "Por favor, complete todos los campos.";
                return View();
            }

            if (!int.TryParse(idCita, out int idCitaInt))
            {
                ViewBag.Mensaje = "El ID de la cita no es válido.";
                return View();
            }

            bool respuesta = dbcitas.Eliminar(idCitaInt);
            if (respuesta)
            {
                ViewBag.Mensaje = "La cita ha sido dada de baja exitosamente.";
            }
            else
            {
                ViewBag.Mensaje = "No se pudo dar de baja la cita. Verifique los datos ingresados.";
            }

            return View();
        }
    }
}