using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiControleCaixa.ApplicationCore.DTO.Transacao
{
    public class TransacaoDto
    {
        public int Id { get; set; }
        public int TipoTransacao { get; set; }
        public decimal Valor { get; set; }
        public string? DataTransacao { get; set; }

    }
}
