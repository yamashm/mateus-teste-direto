using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Mateus_Direto.Models
{
    public class ModeloEntradaConsultaLancamento
    {
        public int nu_terminal { get; set; }
        public string nu_cartao { get; set; }
        public int tp_consulta { get; set; }
        public string dt_inicial { get; set; }
        public string dt_final { get; set; }
    }
}
