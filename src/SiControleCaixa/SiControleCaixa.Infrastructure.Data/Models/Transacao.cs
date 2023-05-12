using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiControleCaixa.Infrastructure.Data.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public int TipoTransacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataTransacao { get; set; }

    }
}
