using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Mateus_Direto.Models
{
    public class ModeloEntradaPagamentoBancario
    {
        public int nu_terminal { get; set; }
        public string nu_cartao { get; set; }
        public string id_identificacao_positiva { get; set; }
        public string nu_cod_barras { get; set; }
        public string dt_vencimento { get; set; }
        public decimal vl_documento { get; set; }
        public string dt_pagamento { get; set; }
        public decimal vl_pagamento { get; set; }
        public string tx_identificacao_pagamento { get; set; }
    }
}
