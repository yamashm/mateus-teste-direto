using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Mateus_Direto.Models
{
    public class ModeloEntradaVerificarTarefas
    {
        public int nu_terminal { get; set; }
    }

    public class ModeloSaidaVerificarTarefas
    {
        public int nrRetorno { get; set; }
        public string txRetorno { get; set; }
        public List<Tarefa> tarefa {get;set;}
    }

    public class Tarefa
    {
        public Int32 id_tarefa { get; set; }
        public Int32 cd_tarefa { get; set; }
        public String cd_estado { get; set; }
        public String ds_estado { get; set; }
        public List<OS> listaEstruturaOS { get; set; }
        public String nu_os { get; set; }
        public List<RecolhimentoSuprimento> listaEstruturaRecolhimentoSuprimento { get; set; }
        public List<EstadoK7> listaEstadoK7 { get; set; }
    }

    public class OS
    {
        public String ds_os { get; set; }
        public String ds_nome_operador { get; set; }
        public String ds_senha { get; set; }
        public String ds_trilha_cartao { get; set; }
    }

    public class RecolhimentoSuprimento
    {
        public String cd_k7 { get; set; }
        public Int32 qt_k7 { get; set; }
        public Int32 vl_k7 { get; set; }
    }

    public class EstadoK7
    {
        public String cd_k7 { get; set; }
        public Int32 cd_estado { get; set; }
    }
}
