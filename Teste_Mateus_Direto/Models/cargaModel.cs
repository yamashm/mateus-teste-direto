using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Mateus_Direto.Models
{
    public class ModeloEntradaCarga
    {
        public int nu_terminal { get; set; }
        public string nu_cartao { get; set; }
        public string nu_NSUATM { get; set; }
        public string tp_cassete { get; set; }
        public int tp_carga { get; set; }
        public decimal vl_carga { get; set; }
        public int moedas { get; set; }
    }

    public class ModeloSaidaCarga
    {
        public int nrRetorno { get; set; }
        public string txRetorno { get; set; }
        public int nu_NSUHOST { get; set; }
    }
}
