using Application.DTOs;
using Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PruebaController : Controller
    {
        private readonly IEntregaRepository _repository;

        public PruebaController(IEntregaRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{empleado}/{mes}")]
        public async Task<IActionResult> Index(int empleado,int mes)
        {
            EntregaDTO result = await _repository.GetEntregas(empleado, mes);
            return Ok(result);
        }
        public async Task<IActionResult> Crear()
        {
            EntregaDTO newEntrega = new EntregaDTO()
            {
                IdEmpleado = 1,
                IdMes = 1,
                CantidadEntregas = 6

            };
            await _repository.Save(newEntrega);
            return Ok();
        }
    }
}
