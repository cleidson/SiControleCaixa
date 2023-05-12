using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiControleCaixa.ApplicationCore.DTO.Transacao
{
    public class FluxoCaixaConsolidadoDto
    {
        public string? Data { get; set; }
        public double? TotalEntradas { get; set; }
        public double? TotalSaidas { get; set; }
        public double? TotalConsolidado { get; set; }
    }
}
