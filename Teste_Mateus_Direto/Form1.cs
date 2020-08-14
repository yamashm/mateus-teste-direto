using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teste_Mateus_Direto.Models;

namespace Teste_Mateus_Direto
{
    public partial class Form1 : Form
    {
        CultureInfo _provider = CultureInfo.InvariantCulture;

        public Form1()
        {
            InitializeComponent();

            ATM.RotinasGlobais.Inicia();
        }

        private void EscreveRetornoLog(string mensagem)
        {
            txbLog.AppendText(mensagem);
            txbLog.AppendText("\r\n");
            txbLog.ScrollToCaret();
        }

        private string ChamaApi(string ip, string conteudoData, string metodo, string tipo)
        {
            EscreveRetornoLog(">>>>>>>>>>>> " + metodo + " <<<<<<<<<<<<<");

            EscreveRetornoLog(">>>>>>>>>>>> Request ");
            EscreveRetornoLog(JsonPrettify(conteudoData));

            WebClient wc = new WebClient();
            wc.UseDefaultCredentials = true;
            wc.Dispose();

            wc.Headers[HttpRequestHeader.Authorization] = "Bearer Token_Content";
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            byte[] result = wc.UploadData(ip + metodo, tipo, System.Text.Encoding.UTF8.GetBytes(conteudoData));
            string responsebody = System.Text.Encoding.UTF8.GetString(result);

            EscreveRetornoLog(">>>>>>>>>>>> Response ");
            EscreveRetornoLog(JsonPrettify(responsebody));

            EscreveRetornoLog("----------------------------------------------");

            return responsebody;
        }

        public string JsonPrettify(string json)
        {
            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Newtonsoft.Json.Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }

        private void btnChamaBin_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaBin entrada = new ModeloEntradaBin();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "bin", "POST");

                ModeloSaidaBin saida = JsonConvert.DeserializeObject<ModeloSaidaBin>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaCarga_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaCarga entrada = new ModeloEntradaCarga();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));
                entrada.nu_NSUATM = txbCarga_nu_NSUATM.Text;
                entrada.tp_cassete = txbCarga_tp_cassete.Text;
                entrada.tp_carga = int.Parse(txbCarga_tp_carga.Text);
                entrada.vl_carga = decimal.Parse(txbCarga_vl_carga.Text);
                entrada.moedas = int.Parse(txbCarga_moedas.Text);

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "carga", "POST");

                ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaConfirmaCarga_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaConfirmarCarga entrada = new ModeloEntradaConfirmarCarga();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));
                entrada.nu_NSUATM = txbCarga_nu_NSUATM.Text;
                entrada.nu_NSUHOST = int.Parse(txbConfirmaCarga_nu_NSUHOST.Text);

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "confirmarCarga", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaComprovanteOS_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaComprovanteOS entrada = new ModeloEntradaComprovanteOS();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_os = int.Parse(txbComprovanteOS_nu_os.Text);
               
                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "comprovanteOS", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaVerificarTarefas_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaVerificarTarefas entrada = new ModeloEntradaVerificarTarefas();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "verificarTarefas", "POST");

                ModeloSaidaVerificarTarefas saida = JsonConvert.DeserializeObject<ModeloSaidaVerificarTarefas>(responsebody);

                if(saida.nrRetorno == 0)
                {
                    cbbConcluirTarefas_id_tarefa.Items.Clear();

                    foreach(Tarefa t in saida.tarefa)
                    {
                        cbbConcluirTarefas_id_tarefa.Items.Add(t.id_tarefa);

                        if(t.nu_os != null)
                        {
                            cbbTarefas_nu_os.Items.Add(t.nu_os);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaConcluirTarefas_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaConcluirTarefas entrada = new ModeloEntradaConcluirTarefas();

                entrada.id_tarefa = int.Parse(cbbConcluirTarefas_id_tarefa.SelectedItem.ToString());
                entrada.tp_atendimento = cbbConcluirTarefas_tp_atendimento.SelectedItem.ToString(); 
                entrada.dt_atendimento = txbTarefas_dt_atendimento.Text;

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "concluirTarefas", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaSaqueConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaSaqueConsulta entrada = new ModeloEntradaSaqueConsulta();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));
                entrada.vl_saque = decimal.Parse(txbSaque_vl_saque.Text);
                entrada.qt_parcelas = int.Parse(txbSaque_qt_parcelas.Text);

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "saqueConsulta", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaSaqueCredito_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaSaqueCredito entrada = new ModeloEntradaSaqueCredito();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));
                entrada.vl_saque = decimal.Parse(txbSaque_vl_saque.Text);
                entrada.qt_parcelas = int.Parse(txbSaque_qt_parcelas.Text);

                entrada.id_identificacao_positiva = ATM.RotinasGlobais.Criptografar(txb_id_identificacao_positiva.Text);
                entrada.nu_NSUATM = txbSaque_nu_NSUATM.Text;
                entrada.vl_parcela = decimal.Parse(txbSaque_vl_parcela.Text);

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "saqueCredito", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaSaqueDebito_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaSaqueDebito entrada = new ModeloEntradaSaqueDebito();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));
                entrada.vl_saque = decimal.Parse(txbSaque_vl_saque.Text);

                entrada.id_identificacao_positiva = ATM.RotinasGlobais.Criptografar(txb_id_identificacao_positiva.Text);
                entrada.nu_NSUATM = txbSaque_nu_NSUATM.Text;

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "saqueDebito", "POST");

                ModeloSaidaSaqueDebito saida = JsonConvert.DeserializeObject<ModeloSaidaSaqueDebito>(responsebody);

                if(saida.nrRetorno == 0)
                {
                    txbSaque_nu_NSUHOST.Text = saida.nu_NSUHOST;
                }
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaSaqueDetalhe_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaSaqueDetalhe entrada = new ModeloEntradaSaqueDetalhe();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));
                entrada.vl_saque = decimal.Parse(txbSaque_vl_saque.Text);

                entrada.qt_parcelas = int.Parse(txbSaque_qt_parcelas.Text);
                entrada.vl_parcela = decimal.Parse(txbSaque_vl_parcela.Text);

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "saqueDetalhe", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaConfirmaSaque_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaConfirmaSaque entrada = new ModeloEntradaConfirmaSaque();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));
                entrada.nu_NSUATM = txbSaque_nu_NSUATM.Text;
                entrada.nu_NSUHOST = txbSaque_nu_NSUHOST.Text;

                entrada.qt_casseteA = int.Parse(txbSaque_qt_casseteA.Text);
                entrada.qt_casseteB = int.Parse(txbSaque_qt_casseteB.Text);
                entrada.qt_casseteC = int.Parse(txbSaque_qt_casseteC.Text);
                entrada.qt_casseteD = int.Parse(txbSaque_qt_casseteD.Text);

                entrada.qt_rej_casseteA = int.Parse(txbSaque_qt_rej_casseteA.Text);
                entrada.qt_rej_casseteB = int.Parse(txbSaque_qt_rej_casseteB.Text);
                entrada.qt_rej_casseteC = int.Parse(txbSaque_qt_rej_casseteC.Text);
                entrada.qt_rej_casseteD = int.Parse(txbSaque_qt_rej_casseteD.Text);

                entrada.nr_reject_complete = int.Parse(txbSaque_nr_reject_complete.Text);

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "confirmaSaque", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaConsultaLancamento_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaConsultaLancamento entrada = new ModeloEntradaConsultaLancamento();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));
                entrada.tp_consulta = int.Parse(txbLancamentos_tp_consulta.Text);
                entrada.dt_inicial = txbLancamentos_dt_inicial.Text;
                entrada.dt_final = txbLancamentos_dt_final.Text;

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "consultaLancamento", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaListarBancos_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaBin entrada = new ModeloEntradaBin();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "listarBancos", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaListarContas_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaListarContas entrada = new ModeloEntradaListarContas();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "listarContas", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaLogin entrada = new ModeloEntradaLogin();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_trilha2 = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text);
                entrada.nu_senha = ATM.RotinasGlobais.Criptografar(txbAutenticacao_nu_senha.Text);
                entrada.id_Teclado_EPP = int.Parse(txbAutenticacao_id_Teclado_EPP.Text);
                entrada.cd_PIN_KCV = txbAutenticacao_cd_PIN_KCV.Text;

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "login", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaLogout_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaLogout entrada = new ModeloEntradaLogout();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "logout", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaPagamentoBancario_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaPagamentoBancario entrada = new ModeloEntradaPagamentoBancario();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao= ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));
                entrada.id_identificacao_positiva = txb_id_identificacao_positiva.Text;
                entrada.nu_cod_barras = txbPagamentos_nu_cod_barras.Text;
                entrada.dt_vencimento = txbPagamentos_dt_vencimento.Text;
                entrada.vl_documento = decimal.Parse(txbPagamentos_vl_documento.Text);
                entrada.dt_pagamento = txbPagamentos_dt_pagamento.Text;
                entrada.vl_pagamento = decimal.Parse(txbPagamentos_vl_pagamento.Text);
                entrada.tx_identificacao_pagamento = txbPagamentos_tx_identificacao_pagamento.Text;

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "pagamentoBancario", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaPessoaFisicaCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntredaPessoaFisicaCadastrar entrada = new ModeloEntredaPessoaFisicaCadastrar();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cpf = txbCadastros_nu_cpf.Text;
                entrada.tx_nome = txbCadastros_tx_nome.Text;
                entrada.dt_nascimento = txbCadastros_dt_nascimento.Text;
                entrada.tp_sexo = txbCadastros_tp_sexo.Text;
                entrada.tx_senha = txbCadastros_tx_senha.Text;

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "pessoaFisicaCadastrar", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaSalvarContaBancaria_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaSalvarContaBancaria entrada = new ModeloEntradaSalvarContaBancaria();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));

                entrada.cd_contabancaria = int.Parse(txbSalvar_cd_contabancaria.Text);
                entrada.cd_banco = int.Parse(txbSalvar_cd_banco.Text);
                entrada.cd_agencia = int.Parse(txbSalvar_cd_agencia.Text);
                entrada.dg_agencia = txbSalvar_dg_agencia.Text;
                entrada.cd_contacorrente = int.Parse(txbSalvar_cd_contacorrente.Text);
                entrada.dg_contacorrente = txbSalvar_dg_contacorrente.Text;
                entrada.tp_conta = int.Parse(txbSalvar_tp_conta.Text);
                entrada.fg_ativo = txbSalvar_fg_ativo.Text;

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "salvarContaBancaria", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaTransferir_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaTransferir entrada = new ModeloEntradaTransferir();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));

                entrada.cd_tipoconta = int.Parse(txbTransferencias_cd_tipoconta.Text);
                entrada.cd_banco = int.Parse(txbTransferencias_cd_banco.Text);
                entrada.cd_agencia = int.Parse(txbTransferencias_cd_agencia.Text);
                entrada.dg_agencia = txbTransferencias_dg_agencia.Text;
                entrada.cd_contacorrente = int.Parse(txbTransferencias_cd_contacorrente.Text);
                entrada.dg_contacorrente = txbTransferencias_dg_contacorrente.Text;
                entrada.vl_transferencia = decimal.Parse(txbTransferencias_vl_transferencia.Text);
                entrada.dt_transferencia = txbTransferencias_dt_transferencia.Text;

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "transferir", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaRecolhimento_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaRecolhimento entrada = new ModeloEntradaRecolhimento();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.dt_atendimento = txbTarefas_dt_atendimento.Text;
                entrada.nu_os = (cbbTarefas_nu_os.SelectedItem.ToString());
                entrada.dt_envio = txbTarefas_dt_envio.Text;

                entrada.qtd_cedulas_cassete_A = int.Parse(txbTarefas_qtd_cedulas_cassete_a.Text);
                entrada.valor_cedulas_cassete_A = decimal.Parse(txbTarefas_valor_cedula_cassete_a.Text, _provider);
                entrada.qtd_cedulas_cassete_B = int.Parse(txbTarefas_qtd_cedulas_cassete_b.Text);
                entrada.valor_cedulas_cassete_B = decimal.Parse(txbTarefas_valor_cedula_cassete_b.Text, _provider);
                entrada.qtd_cedulas_cassete_C = int.Parse(txbTarefas_qtd_cedulas_cassete_c.Text);
                entrada.valor_cedulas_cassete_C = decimal.Parse(txbTarefas_valor_cedula_cassete_c.Text, _provider);
                entrada.qtd_cedulas_cassete_D = int.Parse(txbTarefas_qtd_cedulas_cassete_d.Text);
                entrada.valor_cedulas_cassete_D = decimal.Parse(txbTarefas_valor_cedula_cassete_d.Text, _provider);

                entrada.qtd_total_rejeicao = int.Parse(txbTarefas_qtd_total_rejeicao.Text);
                entrada.valor_total_rejeicao = decimal.Parse(txbTarefas_valor_total_rejeicao.Text, _provider);

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "recolhimento", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaRecolhimentoTotem_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaRecolhimentoTotem entrada = new ModeloEntradaRecolhimentoTotem();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.nu_cartao = ATM.RotinasGlobais.Criptografar(txb_nu_cartao.Text.Substring(0, txb_nu_cartao.Text.IndexOf('=')));

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "recolhimentoTotem", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaSaldoCedulas_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaBin entrada = new ModeloEntradaBin();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "saldoCedulas", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }

        private void btnChamaSuprimento_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloEntradaSuprimento entrada = new ModeloEntradaSuprimento();

                entrada.nu_terminal = int.Parse(txb_nu_terminal.Text);
                entrada.dt_atendimento = txbTarefas_dt_atendimento.Text;
                entrada.nu_os = (cbbTarefas_nu_os.SelectedItem.ToString());
                entrada.dt_envio = txbTarefas_dt_envio.Text;

                entrada.qtd_cedulas_cassete_A = int.Parse(txbTarefas_qtd_cedulas_cassete_a.Text);
                entrada.valor_cedulas_cassete_A = decimal.Parse(txbTarefas_valor_cedula_cassete_a.Text, _provider);
                entrada.qtd_cedulas_cassete_B = int.Parse(txbTarefas_qtd_cedulas_cassete_b.Text);
                entrada.valor_cedulas_cassete_B = decimal.Parse(txbTarefas_valor_cedula_cassete_b.Text, _provider);
                entrada.qtd_cedulas_cassete_C = int.Parse(txbTarefas_qtd_cedulas_cassete_c.Text);
                entrada.valor_cedulas_cassete_C = decimal.Parse(txbTarefas_valor_cedula_cassete_c.Text, _provider);
                entrada.qtd_cedulas_cassete_D = int.Parse(txbTarefas_qtd_cedulas_cassete_d.Text);
                entrada.valor_cedulas_cassete_D = decimal.Parse(txbTarefas_valor_cedula_cassete_d.Text, _provider);

                string conteudoData = JsonConvert.SerializeObject(entrada);

                string responsebody = ChamaApi(txb_URLServivos.Text, conteudoData, "suprimento", "POST");

                //ModeloSaidaCarga saida = JsonConvert.DeserializeObject<ModeloSaidaCarga>(responsebody);
            }
            catch (Exception ex)
            {
                EscreveRetornoLog(ex.Message);
            }
        }
    }
    
}
