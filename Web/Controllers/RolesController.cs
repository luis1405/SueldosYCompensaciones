using Application.DTOs;
using Application.Features;
using Application.Features.Interfaces;
using Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolRepository _rolesRepository;
        private readonly IRolFeatures _rolFeatures;

        public RolesController(IRolRepository rolesRepository, IRolFeatures rolFeatures)
        {
            _rolesRepository = rolesRepository;
            _rolFeatures = rolFeatures;
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
