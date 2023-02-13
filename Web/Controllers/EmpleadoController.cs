using Application.DTOs;
using Infraestructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IRolRepository _rolRepository;

        public EmpleadoController(IEmpleadoRepository empleadoRepository, IRolRepository rolRepository)
        {
            _empleadoRepository = empleadoRepository;
            _rolRepository = rolRepository;
        }

        // GET: EmpleadoController
        public ActionResult Index()
        {
            List<RolDTO> roles = _rolRepository.GetRoles().Result;
            var rolesBag = roles.Select(r => new { 
                IdRol = r.IdRol, Descripcion = r.Descripcion 
            }).ToList().AsEnumerable();
            ViewBag.ListRoles = rolesBag;
            return View();
        }

        // POST: EmpleadoController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(EmpleadoDTO empleado)
        {
            try
            {
                List<RolDTO> roles = _rolRepository.GetRoles().Result;
                var rolesBag = roles.Select(r => new {
                    IdRol = r.IdRol,
                    Descripcion = r.Descripcion
                }).ToList();
                ViewBag.ListRoles = rolesBag;
                var result = _empleadoRepository.Save(empleado).Result;
                if(result == 0)
                    return View(empleado);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View(empleado);
            }
        }
    }
}
