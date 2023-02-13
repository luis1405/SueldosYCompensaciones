using Application.DTOs;
using Application.Features.Interfaces;
using Infraestructure.Interfaces;
using Infraestructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PagoController : Controller
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IEntregaRepository _entregasRepository;
        private readonly ISueldoYCompensacionRepository _SyCRepository;
        private readonly IImpuestoRepository _impuestoRepository;
        private readonly IPagoFeatures _pagoFeatures;

        public PagoController(IEmpleadoRepository empleadoRepository, IEntregaRepository entregasRepository
                            , ISueldoYCompensacionRepository syCRepository, IImpuestoRepository impuestoRepository, IPagoFeatures pagoFeatures)
        {
            _empleadoRepository = empleadoRepository;
            _entregasRepository = entregasRepository;
            _SyCRepository = syCRepository;
            _impuestoRepository = impuestoRepository;
            _pagoFeatures = pagoFeatures;
        }
        public ActionResult Index()
        {

            return Ok("Pagos");
        }

        //[HttpGet("{empleado:int}/{mes:int}")]
        //[HttpGet]
        [Route("/pago/{empleado}/{mes}")]
        public async Task<ActionResult> Index(int empleado, int mes)
        {
            EmpleadoDTO resultEmpleado = await _empleadoRepository.GetEmpleado(empleado);
            EntregaDTO resultEntregas = await _entregasRepository.GetEntregas(empleado, mes);
            SueldoYCompensacionDTO resultSyC = await _SyCRepository.GetSueldoYCompensacion(resultEmpleado.IdRol);

            decimal salarioAntesImpuesto = _pagoFeatures.PagoAntesImpuestos(resultEntregas, resultSyC);
            var porcentajeImpuestosAplicables = _impuestoRepository.GetTotalImpuestos(salarioAntesImpuesto).Result;

            decimal salarioDespuesImpuestos = salarioAntesImpuesto - ((salarioAntesImpuesto * porcentajeImpuestosAplicables) / 100);


            return Ok(salarioDespuesImpuestos);
        }
    }
}
