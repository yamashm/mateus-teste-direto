using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Mateus_Direto.Models
{
    public class ModeloEntradaRecolhimento
    {
        public int nu_terminal { get; set; }
        public string nu_os { get; set; }
        public string dt_atendimento { get; set; }
        public string dt_envio { get; set; }
        public int qtd_cedulas_cassete_A { get; set; }
        public decimal valor_cedulas_cassete_A { get; set; }
        public int qtd_cedulas_cassete_B { get; set; }
        public decimal valor_cedulas_cassete_B { get; set; }
        public int qtd_cedulas_cassete_C { get; set; }
        public decimal valor_cedulas_cassete_C { get; set; }
        public int qtd_cedulas_cassete_D { get; set; }
        public decimal valor_cedulas_cassete_D { get; set; }
        public int qtd_total_rejeicao { get; set; }
        public decimal valor_total_rejeicao { get; set; }
    }
}
