using Application.DTOs;
using Application.Features;
using Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolRepository _rolesRepository;
        private RolFeatures _rolFeatures;

        public RolesController(IRolRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
            _rolFeatures = new RolFeatures();
        }

        public async Task<IActionResult> Index()
        {
            List<RolDTO> roles = await _rolesRepository.GetRoles();
            var nRoles = _rolFeatures.Count(roles);

            return Ok(nRoles);
            //return View(roles);
        }
    }
}
