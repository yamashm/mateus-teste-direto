using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Mateus_Direto.Models
{
    public class ModeloEntradaBin
    {
        public int nu_terminal { get; set; }
    }

    public class ModeloSaidaBin
    {
        public int nrRetorno { get; set; }
        public string txRetorno { get; set; }
        public string ds_atm { get; set; }
        public string ds_iniciapinpad { get; set; }
        public string ds_habilitapinpad { get; set; }
        public string ds_habilitasaquebradesco { get; set; }
        public string ds_habilitasaquesemcartao { get; set; } 
        public string ds_habilitaleitorcartao { get; set; }
        public string ds_habilitaextratomateuscard { get; set; }
        public string ds_ipsonda { get; set; }
        public int nr_portasonda { get; set; }
        public int nr_temposonda { get; set; }
        public List<bin> listaBin { get; set; }
    }

    public class bin
    {
        public int cd_bin { get; set; }
    }
}
