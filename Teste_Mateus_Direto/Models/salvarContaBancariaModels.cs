using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Mateus_Direto.Models
{
    public class ModeloEntradaSalvarContaBancaria
    {
        public int nu_terminal { get; set; }
        public string nu_cartao { get; set; }
        public int cd_contabancaria { get; set; }
        public int cd_banco { get; set; }
        public int cd_agencia { get; set; }
        public string dg_agencia { get; set; }
        public int cd_contacorrente { get; set; }
        public string dg_contacorrente { get; set; }
        public int tp_conta { get; set; }
        public string fg_ativo { get; set; }
    }
}
