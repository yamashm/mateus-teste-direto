using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Mateus_Direto.Models
{
    public class ModeloEntradaTransferir
    {
        public int nu_terminal { get; set; }
        public string nu_cartao { get; set; }
        public string id_identificacao_positiva { get; set; }
        public int cd_tipoconta { get; set; }
        public int cd_banco { get; set; }
        public int cd_agencia { get; set; }
        public string dg_agencia { get; set; }
        public int cd_contacorrente { get; set; }
        public string dg_contacorrente { get; set; }
        public decimal vl_transferencia { get; set; }
        public string dt_transferencia { get; set; }

    }
}
