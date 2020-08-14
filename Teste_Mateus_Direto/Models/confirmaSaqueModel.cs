using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Mateus_Direto.Models
{
    class ModeloEntradaConfirmaSaque
    {
        public int nu_terminal { get; set; }
        public string nu_cartao { get; set; }
        public string nu_NSUATM { get; set; }
        public string nu_NSUHOST { get; set; }
        public byte st_saque { get; set; }
        public int qt_casseteA { get; set; }
        public int qt_casseteB { get; set; }
        public int qt_casseteC { get; set; }
        public int qt_casseteD { get; set; }
        public int qt_rej_casseteA { get; set; }
        public int qt_rej_casseteB { get; set; }
        public int qt_rej_casseteC { get; set; }
        public int qt_rej_casseteD { get; set; }
        public int nr_reject_complete { get; set; }
    }
}
