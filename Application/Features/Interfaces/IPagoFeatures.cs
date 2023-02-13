using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interfaces
{
    public interface IPagoFeatures
    {
        decimal PagoAntesImpuestos(EntregaDTO entregas, SueldoYCompensacionDTO resultSyC);
        //decimal PagoDespuesImpuestos(decimal sueldo, decimal impuesto);
    }
}
