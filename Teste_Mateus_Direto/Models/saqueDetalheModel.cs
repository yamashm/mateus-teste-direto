using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Mateus_Direto.Models
{
    public class ModeloEntradaSaqueDetalhe
    {
        public int nu_terminal { get; set; }
        public string nu_cartao { get; set; }
        public decimal vl_saque { get; set; }
        public int qt_parcelas { get; set; }
        public decimal vl_parcela { get; set; }
    }
}
