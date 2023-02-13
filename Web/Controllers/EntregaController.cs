using Application.DTOs;
using Infraestructure.Interfaces;
using Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EntregaController : Controller
    {
        private readonly IEntregaRepository _entregaRepository;
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IRolRepository _rolRepository;

        public EntregaController(IEntregaRepository entregaRepository, IEmpleadoRepository empleadoRepository, IRolRepository rolRepository)
        {
            _entregaRepository = entregaRepository;
            _empleadoRepository = empleadoRepository;
            _rolRepository = rolRepository;
        }

        public ActionResult Index()
        {
            List<EmpleadoDTO> empleados = _empleadoRepository.GetEmpleados().Result;
            var empleadosBag = empleados.Select(r => new {
                IdEmpleado = r.IdEmpleado,
                Nombre = r.Nombre
            }).ToList();
            ViewBag.ListEmpleados = empleadosBag;

            var listMeses = new[] { 
                new { IdMes = 1, Descripcion = "Enero" }, 
                new { IdMes = 2, Descripcion = "Febrero" },
                new { IdMes = 3, Descripcion = "Marzo" },
                new { IdMes = 4, Descripcion = "Abril" },
                new { IdMes = 5, Descripcion = "Mayo" },
                new { IdMes = 6, Descripcion = "Junio" },
                new { IdMes = 7, Descripcion = "Julio" },
                new { IdMes = 8, Descripcion = "Agosto" },
                new { IdMes = 9, Descripcion = "Septiembre" },
                new { IdMes = 10, Descripcion = "Octubre" },
                new { IdMes = 11, Descripcion = "Noviembre" },
                new { IdMes = 12, Descripcion = "Diciembre" },
            }.ToList();

            ViewBag.ListMeses = listMeses;

            return View();
        }

        // POST: EmpleadoController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(EntregaDTO entrega)
        {
            try
            {
                List<EmpleadoDTO> empleados = _empleadoRepository.GetEmpleados().Result;
                var empleadosBag = empleados.Select(r => new {
                    IdEmpleado = r.IdEmpleado,
                    Nombre = r.Nombre
                }).ToList();
                ViewBag.ListEmpleados = empleadosBag;

                var listMeses = new[] {
                    new { IdMes = 1, Descripcion = "Enero" },
                    new { IdMes = 2, Descripcion = "Febrero" },
                    new { IdMes = 3, Descripcion = "Marzo" },
                    new { IdMes = 4, Descripcion = "Abril" },
                    new { IdMes = 5, Descripcion = "Mayo" },
                    new { IdMes = 6, Descripcion = "Junio" },
                    new { IdMes = 7, Descripcion = "Julio" },
                    new { IdMes = 8, Descripcion = "Agosto" },
                    new { IdMes = 9, Descripcion = "Septiembre" },
                    new { IdMes = 10, Descripcion = "Octubre" },
                    new { IdMes = 11, Descripcion = "Noviembre" },
                    new { IdMes = 12, Descripcion = "Diciembre" },
                }.ToList();

                ViewBag.ListMeses = listMeses;


                var result = _entregaRepository.Save(entrega).Result;
                if (result == 0)
                    return View(entrega);
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View(entrega);
            }
        }
    }
}
