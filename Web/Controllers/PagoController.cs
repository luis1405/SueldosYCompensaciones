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
            List<EntregaDTO> entregas = _entregasRepository.GetAllEntregas().Result;
            if(entregas != null)
                return View(entregas);
            return View();  
        }

        //[HttpGet("{empleado:int}/{mes:int}")]
        //[HttpGet]
        [Route("/pago/detalle/{empleado}/{mes}")]
        public async Task<ActionResult> Detalle(int empleado, int mes)
        {

            EmpleadoDTO resultEmpleado = await _empleadoRepository.GetEmpleado(empleado);
            EntregaDTO resultEntregas = await _entregasRepository.GetEntregas(empleado, mes);
            SueldoYCompensacionDTO resultSyC = await _SyCRepository.GetSueldoYCompensacion(resultEmpleado.IdRol);

            PagoDTO pagoDto = new PagoDTO(resultEmpleado, resultEntregas, resultSyC);

            pagoDto.ImpuestosAplicables = _impuestoRepository.GetTotalImpuestos(pagoDto.SueldoBruto).Result;

            return View(pagoDto);
        }
    }
}
