using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using dbdCriptografia3DES;
using System.Xml;
using System.Diagnostics;


namespace ATM
{
    public static class RotinasGlobais
    {
        //public static clsWebServices WServises;
        public static Criptografia3DES tripleDES;
        static public string NmArqSaque;
        static public string NmArqDadosApp;
        static public string NmArqPendencias;
        static public bool NovoPacote = false;
        //static private Button botaoClicado;

        public static void Inicia()
        {
            tripleDES = new Criptografia3DES();
            //WServises = new clsWebServices();
            //if (DadosGlobais.URLServivos != "")
            //{
            //    Log.GravaLogNivel1(1, "Iniciado troca de URL dos serviços");

            //    string urlAntiga = WServises.Url;
            //    string novaUrl = RotinasGlobais.Descriptografar(DadosGlobais.URLServivos);

            //    if (DadosGlobais.LoginServivos != null && DadosGlobais.LoginServivos != "")
            //        WServises.LoginUrl = RotinasGlobais.Descriptografar(DadosGlobais.LoginServivos);
            //    else
            //        WServises.LoginUrl = null;

            //    if (DadosGlobais.PasswordServivos != null && DadosGlobais.PasswordServivos != "")
            //        WServises.PasswordUrl = RotinasGlobais.Descriptografar(DadosGlobais.PasswordServivos);
            //    else
            //        WServises.PasswordUrl = null;

            //    if (novaUrl != "")
            //    {
            //        try
            //        {
            //            WServises.Url = novaUrl;
            //            Log.GravaLogNivel1(1, "URL serviços alterada");
            //        }
            //        catch (Exception ex)
            //        {
            //            Log.GravaLogNivel1(1, "Alterando URLServiços Erro: " + ex.Message);
            //            WServises.Url = urlAntiga;
            //            Log.GravaLogNivel1(1, "URL antiga mantida");
            //        }
            //    }

            //    SincronizaBIN();
            //}

            //NmArqSaque = System.IO.Path.Combine(Environment.CurrentDirectory, @"C:\ATM\Log\Saques.log");
            //NmArqDadosApp = @"C:\ATM\Log\DadosApp.xml";
            //NmArqPendencias = @"C:\ATM\Log\Pendencias.Log";
        }

        //static void SincronizaBIN()
        //{
        //    if (!RotinasGlobais.BuscaBINCartao())
        //    {
        //        System.Threading.Thread.Sleep(60000);

        //        SincronizaBIN();
        //    }

        //}

        //public static void PerformClick2(Button button, Image img2)
        //{
        //    Storyboard storyboard = new Storyboard();

        //    button.Foreground = (Brush)Application.Current.MainWindow.FindResource("CorNormal");
        //    botaoClicado = null;
        //    botaoClicado = button;

        //    DoubleAnimation HideImg2 = new DoubleAnimation();
        //    HideImg2.AutoReverse = true;
        //    HideImg2.Duration = TimeSpan.FromMilliseconds(100);
        //    HideImg2.From = 0;
        //    HideImg2.To = 100;
        //    HideImg2.Completed += new EventHandler(HideImg2_Completed);

        //    storyboard.Children.Add(HideImg2);

        //    Storyboard.SetTargetProperty(HideImg2, new PropertyPath("Opacity"));
        //    Storyboard.SetTarget(HideImg2, img2);

        //    storyboard.Begin();

        //}

        //static void HideImg2_Completed(object sender, EventArgs e)
        //{
        //    botaoClicado.Foreground = (Brush)Application.Current.MainWindow.FindResource("CorSelecionado");
        //}

        //public static void AjustaPosicaoBotoes(Button button1, Button button2, Button button3, Button button4, Button button5,
        //    Button button6, Button button7, Button button8)
        //{
        //    if (button1 != null) button1.Margin = new Thickness(DadosGlobais.LeftBotao1, DadosGlobais.TopBotao1, 0, 0);
        //    if (button2 != null) button2.Margin = new Thickness(DadosGlobais.LeftBotao2, DadosGlobais.TopBotao2, 0, 0);
        //    if (button3 != null) button3.Margin = new Thickness(DadosGlobais.LeftBotao3, DadosGlobais.TopBotao3, 0, 0);
        //    if (button4 != null) button4.Margin = new Thickness(DadosGlobais.LeftBotao4, DadosGlobais.TopBotao4, 0, 0);
        //    if (button5 != null) button5.Margin = new Thickness(DadosGlobais.LeftBotao5, DadosGlobais.TopBotao5, 0, 0);
        //    if (button6 != null) button6.Margin = new Thickness(DadosGlobais.LeftBotao6, DadosGlobais.TopBotao6, 0, 0);
        //    if (button7 != null) button7.Margin = new Thickness(DadosGlobais.LeftBotao7, DadosGlobais.TopBotao7, 0, 0);
        //    if (button8 != null) button8.Margin = new Thickness(DadosGlobais.LeftBotao8, DadosGlobais.TopBotao8, 0, 0);
        //}

        //public static void AjustaPosicaoBotoesCrednosso(Button button1, Button button2, Button button3, Button button4, Button button5,
        //    Button button6, Button button7, Button button8)
        //{
        //    if (button1 != null) { Canvas.SetTop(button1, 258); Canvas.SetLeft(button1, 50); }
        //    if (button2 != null) { Canvas.SetTop(button2, 258); Canvas.SetLeft(button2, 525); }
        //    if (button3 != null) { Canvas.SetTop(button3, 388); Canvas.SetLeft(button3, 50); }
        //    if (button4 != null) { Canvas.SetTop(button4, 388); Canvas.SetLeft(button4, 525); }
        //    if (button5 != null) { Canvas.SetTop(button5, 518); Canvas.SetLeft(button5, 50); }
        //    if (button6 != null) { Canvas.SetTop(button6, 518); Canvas.SetLeft(button6, 525); }
        //    if (button7 != null) { Canvas.SetTop(button7, 648); Canvas.SetLeft(button7, 50); }
        //    if (button8 != null) { Canvas.SetTop(button8, 648); Canvas.SetLeft(button8, 525); }
        //}

        //public static void AjustaPosicaoBotoesBradesco(Button button1, Button button2, Button button3, Button button4, Button button5,
        //    Button button6, Button button7, Button button8)
        //{
        //    if (button1 != null) { Canvas.SetTop(button1, 152); Canvas.SetLeft(button1, 5); }
        //    if (button2 != null) { Canvas.SetTop(button2, 282); Canvas.SetLeft(button2, 5); }
        //    if (button3 != null) { Canvas.SetTop(button3, 412); Canvas.SetLeft(button3, 5); }
        //    if (button4 != null) { Canvas.SetTop(button4, 542); Canvas.SetLeft(button4, 5); }
        //    if (button5 != null) { Canvas.SetTop(button5, 152); Canvas.SetLeft(button5, 505); }
        //    if (button6 != null) { Canvas.SetTop(button6, 282); Canvas.SetLeft(button6, 505); }
        //    if (button7 != null) { Canvas.SetTop(button7, 412); Canvas.SetLeft(button7, 505); }
        //    if (button8 != null) { Canvas.SetTop(button8, 542); Canvas.SetLeft(button8, 505); }
        //}

        //public static void AjustaPosicaoTitulo(Label label1, Label label2, Label ouvidoria)
        //{
        //    if (label1 != null)
        //    {
        //        label1.Margin = new Thickness(DadosGlobais.LeftTitulo, DadosGlobais.TopTitulo, 0, 0);
        //        label1.FontFamily = new FontFamily("Verdana");
        //        label1.FontSize = 24.0;
        //        label1.Foreground = Brushes.White;
        //    }
        //    if (label2 != null)
        //    {
        //        label2.Margin = new Thickness(DadosGlobais.LeftTitulo + 2, DadosGlobais.TopTitulo + 2, 0, 0);
        //        label2.FontFamily = new FontFamily("Verdana");
        //        label2.FontSize = 24.0;
        //    }
        //    if (ouvidoria != null) ouvidoria.Margin = new Thickness(0, DadosGlobais.TopTitulo, 0, 0);
        //    if (label2 != null) label2.Visibility = Visibility.Hidden;
        //}


        //public static void PrimeiroCampo()
        //{
        //    // MoveFocus takes a TraversalRequest as its argument. 
        //    TraversalRequest request = new TraversalRequest(FocusNavigationDirection.First);
        //    // Gets the element with keyboard focus.
        //    UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;
        //    // Change keyboard focus.
        //    if (elementWithFocus != null) { elementWithFocus.MoveFocus(request); }
        //}

        //public static void ProximoCampo()
        //{
        //    // MoveFocus takes a TraversalRequest as its argument. 
        //    TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
        //    // Gets the element with keyboard focus.
        //    UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;
        //    // Change keyboard focus.
        //    if (elementWithFocus != null)
        //    {
        //        //elementWithFocus.
        //        elementWithFocus.MoveFocus(request);
        //    }
        //}

        //public static void VoltaCampo()
        //{
        //    // MoveFocus takes a TraversalRequest as its argument. 
        //    //TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Up);
        //    TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Previous);
        //    //request.Wrapped = true;
        //    // Gets the element with keyboard focus.
        //    UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;
        //    // Change keyboard focus.
        //    if (elementWithFocus != null)
        //    {
        //        elementWithFocus.MoveFocus(request);
        //        UIElement NewElementWithFocus = Keyboard.FocusedElement as UIElement;
        //        // se atingiu um botão é por q esta dando a volta na tela e não deixa
        //        if (NewElementWithFocus.GetType() == typeof(Button))
        //        {
        //            TraversalRequest request2 = new TraversalRequest(FocusNavigationDirection.First);
        //            elementWithFocus.MoveFocus(request2);
        //        }

        //    }
        //}

        //public static void LimpaCampo()
        //{
        //    UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;

        //    if (elementWithFocus != null && elementWithFocus.GetType() == typeof(TextBox))
        //    {
        //        TextBox tx = (TextBox)elementWithFocus;
        //        tx.Text = "";
        //    }
        //    else if (elementWithFocus != null && elementWithFocus.GetType() == typeof(PasswordBox))
        //    {
        //        PasswordBox pb = (PasswordBox)elementWithFocus;
        //        pb.Password = "";
        //    }
        //    else if (elementWithFocus != null && elementWithFocus.GetType() == typeof(MaskedTextBox))
        //    {
        //        MaskedTextBox mtb = (MaskedTextBox)elementWithFocus;
        //        mtb.Text = "";
        //    }

        //}

        //public static bool VerificaSenha(string SenhaCriptografada, string SenhaPIN)
        //{
        //    string[] retorno = new string[3];

        //    retorno = tripleDES.Crypto(SenhaCriptografada, Criptografia3DES.modeCrypto.DECRYPT_MODE, "110e8a6b946936c9280c6e3561bbbfb3");

        //    if (retorno[0] == "0")
        //    {
        //        if (SenhaPIN == retorno[1])
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        Log.GravaLogNivel1(1, "Erro na rotina de criptografia. Retorno=" + retorno[0]);
        //        return false;
        //    }
        //}

        public static string Criptografar(string valor)
        {
            string[] retorno = new string[3];

            //retorno = tripleDES.Crypto(valor, Criptografia3DES.modeCrypto.ENCRYPT_MODE, "110e8a6b946936c9280c6e3561bbbfb3");
            retorno = tripleDES.Crypto(valor, Criptografia3DES.modeCrypto.ENCRYPT_MODE, "110e8a6b946936c9280c6e3561bbbfb3");

            if (retorno[0] == "0")
            {
                return retorno[1];
            }
            else
            {
                //Log.GravaLogNivel1(1, "Erro na rotina de criptografia. Retorno=" + retorno[0]);
                return "";
            }
        }

        public static string Descriptografar(string valor)
        {
            string[] retorno = new string[3];

            retorno = tripleDES.Crypto(valor, Criptografia3DES.modeCrypto.DECRYPT_MODE, "110e8a6b946936c9280c6e3561bbbfb3");

            if (retorno[0] == "0")
            {
                return retorno[1];
            }
            else
            {
                //Log.GravaLogNivel1(1, "Erro na rotina de criptografia. Retorno=" + retorno[0]);
                return "";
            }
        }

        //public static int VerificaAutenticacaoOffLine(string senha_digitada)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    int retorno = 1;
        //    try
        //    {
        //        foreach (string str in Directory.GetFiles(@"C:\ATM\Tarefas"))
        //        {
        //            FileInfo fi = new FileInfo(str);

        //            if (fi.Name.Substring(0, 2).Equals("OS"))
        //            {
        //                doc.Load(str);

        //                string raiz = doc.DocumentElement.Name;

        //                string ds_trilha_cartao = doc.SelectSingleNode(raiz + "/ds_trilha_cartao").InnerText;
        //                string ds_senha = doc.SelectSingleNode(raiz + "/ds_senha").InnerText;
        //                string ds_senha_contingencia = doc.SelectSingleNode(raiz + "/ds_senha_contingencia").InnerText;

        //                if (ds_trilha_cartao.Equals(DadosCliente.nro_trilha2))
        //                {
        //                    if (ds_senha.Equals(senha_digitada) || ds_senha_contingencia.Equals(senha_digitada))
        //                        retorno = 0;
        //                    else
        //                        retorno = 2;
        //                }


        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.GravaLogNivel1(1, "VerificaAutenticacaoOffLine Erro: " + ex.Message);
        //    }

        //    return retorno;
        //}

        /// <summary>
        /// verifica os digitada
        /// retona se 0 -> OS OK
        /// 1 -> OS não encontrada
        /// 2 -> Os encontrada mas não autorizada para o usuário trilha_2
        /// 3 -> Erro na pesquisa
        /// </summary>
        /// <returns></returns>
        //public static int VerificaOS(string numeroOS, out string id_tarefa, out string ds_os, out string ds_nome_operador)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    int retorno = 1;
        //    id_tarefa = "";
        //    ds_os = "";
        //    ds_nome_operador = "";
        //    try
        //    {
        //        foreach (string str in Directory.GetFiles(@"C:\ATM\Tarefas"))
        //        {
        //            FileInfo fi = new FileInfo(str);

        //            if (fi.Name.Substring(0, 2).Equals("OS"))
        //            {
        //                doc.Load(str);

        //                string raiz = doc.DocumentElement.Name;

        //                string ds_trilha_cartao = doc.SelectSingleNode(raiz + "/ds_trilha_cartao").InnerText;
        //                string nu_os = doc.SelectSingleNode(raiz + "/nu_os").InnerText;

        //                if (nu_os.Trim().Equals(numeroOS))
        //                {
        //                    if (ds_trilha_cartao.Equals(DadosCliente.nro_trilha2))
        //                    {
        //                        retorno = 0;
        //                        id_tarefa = doc.SelectSingleNode(raiz + "/id_tarefa").InnerText;
        //                        ds_os = doc.SelectSingleNode(raiz + "/ds_os").InnerText;
        //                        ds_nome_operador = doc.SelectSingleNode(raiz + "/ds_nome_operador").InnerText;
        //                    }
        //                    else
        //                        retorno = 2;

        //                    return retorno;
        //                }

        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno = 3;
        //        Log.GravaLogNivel1(1, "VerificaOS Erro: " + ex.Message);
        //    }


        //    return retorno;
        //}

        ///// <summary>
        ///// Verifica na OS se existe Recolhimento a ser realizado
        ///// </summary>
        ///// <param name="numeroOS"></param>
        ///// <returns></returns>
        //public static string VerificaRecolhimento(string numeroOS)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    string retorno = "";
        //    try
        //    {
        //        //Varre diretório a procura de Recolhimento
        //        foreach (string str in Directory.GetFiles(@"C:\ATM\Tarefas"))
        //        {
        //            FileInfo fi = new FileInfo(str);

        //            if (fi.Name.Substring(0, 3).Equals("REC"))
        //            {
        //                doc.Load(str);

        //                string raiz = doc.DocumentElement.Name;
        //                string nu_os = doc.SelectSingleNode(raiz + "/nu_os").InnerText;

        //                if (nu_os.Trim().Equals(numeroOS))
        //                {
        //                    retorno = doc.InnerXml;

        //                    try
        //                    {
        //                        File.Delete(str);
        //                    }
        //                    catch
        //                    {
        //                        Log.GravaLogNivel1(1, "VerificaRecolhimento não foi possível deletar Recolhimento: " + nu_os);
        //                    }

        //                    return retorno;
        //                }

        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.GravaLogNivel1(1, "VerificaRecolhimento Erro: " + ex.Message);
        //    }

        //    return retorno;
        //}



        ///// <summary>
        ///// Verifica na OS se existe Suprimento a ser realizado
        ///// </summary>
        ///// <param name="numeroOS"></param>
        ///// <returns></returns>
        //public static string VerificaSuprimento(string numeroOS, bool deleta)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    string retorno = "";
        //    try
        //    {
        //        //Varre diretório a procura de Suprimento
        //        foreach (string str in Directory.GetFiles(@"C:\ATM\Tarefas"))
        //        {
        //            FileInfo fi = new FileInfo(str);

        //            if (fi.Name.Substring(0, 3).Equals("SUP"))
        //            {
        //                doc.Load(str);

        //                string raiz = doc.DocumentElement.Name;

        //                string nu_os = doc.SelectSingleNode(raiz + "/nu_os").InnerText;

        //                if (nu_os.Trim().Equals(numeroOS))
        //                {
        //                    retorno = doc.InnerXml;

        //                    if (deleta)
        //                    {
        //                        try
        //                        {
        //                            File.Delete(str);
        //                        }
        //                        catch
        //                        {
        //                            Log.GravaLogNivel1(1, "VerificaSuprimento não foi possível deletar Suprimento: " + nu_os);
        //                        }
        //                    }

        //                    return retorno;
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.GravaLogNivel1(1, "VerificaSuprimento Erro: " + ex.Message);
        //    }

        //    return retorno;
        //}

        //public static bool BuscaAtualizaSado()
        //{
        //    int cd_retorno = 0;
        //    string ds_retorno;
        //    string valor_nominal_cedula_a; string qtd_cedulas_cassete_a; string qtd_cedulas_rejeitadas_a;
        //    string valor_nominal_cedula_b; string qtd_cedulas_cassete_b; string qtd_cedulas_rejeitadas_b;
        //    string valor_nominal_cedula_c; string qtd_cedulas_cassete_c; string qtd_cedulas_rejeitadas_c;
        //    string valor_nominal_cedula_d; string qtd_cedulas_cassete_d; string qtd_cedulas_rejeitadas_d;

        //    WServises.SaldoCedula(DadosGlobais.NumeroATM, out cd_retorno, out ds_retorno,
        //        out valor_nominal_cedula_a, out qtd_cedulas_cassete_a, out qtd_cedulas_rejeitadas_a,
        //        out valor_nominal_cedula_b, out qtd_cedulas_cassete_b, out qtd_cedulas_rejeitadas_b,
        //        out valor_nominal_cedula_c, out qtd_cedulas_cassete_c, out qtd_cedulas_rejeitadas_c,
        //        out valor_nominal_cedula_d, out qtd_cedulas_cassete_d, out qtd_cedulas_rejeitadas_d);

        //    if (cd_retorno == 0)
        //    {
        //        if (DadosGlobais.IniciaDISP)
        //        {

        //            WosaDISP.ValorK7[0] = (int)double.Parse(valor_nominal_cedula_a);
        //            WosaDISP.ValorK7[1] = (int)double.Parse(valor_nominal_cedula_b);
        //            WosaDISP.ValorK7[2] = (int)double.Parse(valor_nominal_cedula_c);
        //            WosaDISP.ValorK7[3] = (int)double.Parse(valor_nominal_cedula_d);
        //            WosaDISP.QtdK7[0] = int.Parse(qtd_cedulas_cassete_a);
        //            WosaDISP.QtdK7[1] = int.Parse(qtd_cedulas_cassete_b);
        //            WosaDISP.QtdK7[2] = int.Parse(qtd_cedulas_cassete_c);
        //            WosaDISP.QtdK7[3] = int.Parse(qtd_cedulas_cassete_d);
        //        }

        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //public static bool BuscaBINCartao()
        //{
        //    int cd_retorno = 0;
        //    string ds_retorno;
        //    string ds_atm;
        //    string ds_iniciapinpad;
        //    string ds_habilitapinpad;
        //    string ds_ipsonda;
        //    int nr_portasonda;
        //    int nr_temposonda;
        //    string listaBin;

        //    WServises.BinCartao(DadosGlobais.NumeroATM, out cd_retorno, out ds_retorno, out ds_atm, out ds_iniciapinpad, out ds_habilitapinpad, out ds_ipsonda, out nr_portasonda, out nr_temposonda, out listaBin);

        //    if (cd_retorno == 0)
        //    {
        //        DadosGlobais.BINEMV = listaBin.Split(';');
        //        DadosGlobais.TituloATM = ds_atm;
        //        DadosGlobais.IniciaPIN = ds_iniciapinpad.Equals("True");
        //        DadosGlobais.PINHabilitaEPP = ds_habilitapinpad.Equals("True");
        //        DadosGlobais.IPSonda = ds_ipsonda;
        //        DadosGlobais.PortaSonda = nr_portasonda;
        //        DadosGlobais.TempoSonda = nr_temposonda;
        //        DadosGlobais.IniciaDadosBin = true;

        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //static public void GravaArqSaque(string nu_cartao_pam, string Valor)
        //{
        //    try
        //    {
        //        System.IO.File.AppendAllText(NmArqSaque, System.DateTime.Now.ToString("dd/MM HH:mm") + " " + string.Format("{0,9}", nu_cartao_pam) + " " + string.Format("{0,8}", Valor) + "\r\n");
        //    }
        //    catch { }
        //}

        ///// <summary>
        ///// Registra pendência a ser executada posteriormente na aplicação.
        ///// Tipos de pendências:
        ///// 1 - Confirma Saque |
        ///// 2 - ConcluirTarefas |
        ///// 3 - Recolhimento |
        ///// 4 - Suprimento |
        ///// </summary>
        ///// <param name="content"></param>
        //public static void RegistraPendencia(string content)
        //{
        //    //Dividir a pendencia e parâmetros por pipe "|"

        //    try
        //    {
        //        System.IO.File.AppendAllText(NmArqPendencias, content + "\n");
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.GravaLogNivel1(1, "RegistraPendencia: Erro " + ex.Message);
        //    }

        //}

        //public static bool ExistePendencia()
        //{
        //    bool retorno = true;
        //    try
        //    {
        //        if (File.Exists(DadosGlobais.PacotePath))
        //        {
        //            NovoPacote = true;
        //            return retorno;
        //        }

        //        List<string> MatrizLinhas = new List<string>(File.ReadAllLines(NmArqPendencias));
        //        if ((MatrizLinhas.Count == 0) || (MatrizLinhas.Count > 0 && MatrizLinhas[0].Trim().Equals(string.Empty)))
        //            retorno = false;

        //    }
        //    catch
        //    {
        //        retorno = false;
        //    }

        //    if(DadosGlobais.Sitef_Habilita)
        //    { 
        //        if (DadosGlobais.VerificaPendenciaBradesco || retorno)
        //            VerificaPendeciaCliSitef();

        //        if (DadosGlobais.Cupons != null)
        //        {
        //            if (DadosGlobais.Cupons.Count() > 0)
        //                retorno = true;

        //            //Log.GravaLogNivel1(1, "Existe Pendencia - Qtd: " + DadosGlobais.Cupons.Count);
        //            //Log.GravaLogNivel1(1, "Existe Pendencia - Retorno: " + (retorno ? "1" : "0"));
        //        }
        //    }

        //    return retorno;
        //}

        //public static bool ExisteTarefas()
        //{
        //    int cd_retorno;
        //    string ds_retorno;
        //    DataSet dtConteudo;
        //    bool comunicou = RotinasGlobais.WServises.VerificaTarefas(DadosGlobais.NumeroATM, "V", out cd_retorno, out ds_retorno, out dtConteudo);

        //    if (cd_retorno != 0 && comunicou)
        //    {
        //        //Não existe tarefas para este terminal preciso limpar as OS existente.
        //        LimpaOS();
        //    }

        //    return cd_retorno == 0;
        //}

        //private static void LimpaOS()
        //{
        //    try
        //    {
        //        foreach (string file in Directory.GetFiles(@"C:\ATM\Tarefas"))
        //        {
        //            try
        //            {
        //                File.Delete(file);
        //            }
        //            catch
        //            {
        //                Log.GravaLogNivel1(1, "LimpaOS não foi possível deletar Arquivo: " + file);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.GravaLogNivel1(1, "LimpaOS não foi possível deletar OS: " + ex.Message);
        //    }


        //}

        //public static void ResolvePendencia(bool ResolveQuedaEnergia)
        //{
        //    List<string> MatrizLinhas;
        //    string[] Campos;
        //    bool recolhimentoPendente = false;
        //    try
        //    {
        //        if (NovoPacote)
        //        {
        //            if (ChamaPacote())
        //            {
        //                Application.Current.MainWindow.Close();
        //                return;
        //            }

        //        }

        //        //Pega linhas
        //        MatrizLinhas = new List<string>(File.ReadAllLines(NmArqPendencias));
        //        if (MatrizLinhas.Count == 0)
        //        {
        //            if(DadosGlobais.Sitef_Habilita)
        //                if (DadosGlobais.Cupons != null && DadosGlobais.Cupons.Count() > 0)
        //                {
        //                    ResolverPendenciaCliSitef();
        //                    Log.GravaLogNivel1(1, "ResolvePendencia: Existe pendencia Bradesco");
        //                }
        //            return;
        //        }

        //        for (int i = 0; i < MatrizLinhas.Count; i++)
        //        {
        //            Campos = MatrizLinhas[i].Split('|');

        //            if (Campos != null)
        //            {
        //                Log.GravaLogNivel1(1, "Pagando pendência tipo: " + Campos[0].ToString());

        //                switch (Campos[0].ToString())
        //                {
        //                    case "1": // ConfirmaSaque

        //                        if (ResolveQuedaEnergia)
        //                        {
        //                            MatrizLinhas.RemoveAt(i);
        //                            i--;
        //                        }
        //                        else
        //                        {
        //                            int[] NotasDispensadas = new int[4];
        //                            int[] Rejeitadas = new int[4];
        //                            int nrRejectComplete = 0;

        //                            if (Campos.Length == 15)
        //                            {
        //                                NotasDispensadas[0] = int.Parse(Campos[6].ToString());
        //                                NotasDispensadas[1] = int.Parse(Campos[7].ToString());
        //                                NotasDispensadas[2] = int.Parse(Campos[8].ToString());
        //                                NotasDispensadas[3] = int.Parse(Campos[9].ToString());
        //                                Rejeitadas[0] = int.Parse(Campos[10].ToString());
        //                                Rejeitadas[1] = int.Parse(Campos[11].ToString());
        //                                Rejeitadas[2] = int.Parse(Campos[12].ToString());
        //                                Rejeitadas[3] = int.Parse(Campos[13].ToString());
        //                                nrRejectComplete = int.Parse(Campos[14].ToString());

        //                                if (ConfirmaSaquePendencia(Campos[1], Campos[2], Campos[3], Campos[4], int.Parse(Campos[5]), NotasDispensadas, Rejeitadas, nrRejectComplete))
        //                                {
        //                                    MatrizLinhas.RemoveAt(i);
        //                                    i--;
        //                                }
        //                            }
        //                        }
        //                        break;
        //                    case "2"://ConcluirTarefas
        //                        if (ConcluirTarefasPendencia(Campos[1], Campos[2], Campos[3]))
        //                        {
        //                            MatrizLinhas.RemoveAt(i);
        //                            i--;
        //                        }
        //                        break;
        //                    case "3"://Recolhimento                             
        //                        if (RecolhimentoPendencia(Campos[1], Campos[2], Campos[3], Campos[4], Campos[5], Campos[6], Campos[7], Campos[8], Campos[9], Campos[10], Campos[11], Campos[12], Campos[13], Campos[14]))
        //                        {
        //                            MatrizLinhas.RemoveAt(i);
        //                            i--;
        //                        }
        //                        else
        //                            recolhimentoPendente = true;
        //                        break;
        //                    case "4"://Suprimento
        //                        if (recolhimentoPendente == false)
        //                        {
        //                            if (SuprimentoPendencia(Campos[1], Campos[2], Campos[3], Campos[4], Campos[5], Campos[6], Campos[7], Campos[8], Campos[9], Campos[10], Campos[11], Campos[12]))
        //                            {
        //                                MatrizLinhas.RemoveAt(i);
        //                                i--;
        //                            }
        //                        }
        //                        else
        //                            Log.GravaLogNivel1(1, "Não vai tentar suprir, pois o recolhimento não foi concretizado.");
        //                        break;
        //                    case "RESET":
        //                        MatrizLinhas.RemoveAt(i);
        //                        File.WriteAllLines(NmArqPendencias, MatrizLinhas.ToArray());
        //                        ResetATM();
        //                        return;
        //                    case "ATUALIZAR_APP":
        //                        MatrizLinhas.RemoveAt(i);
        //                        File.WriteAllLines(NmArqPendencias, MatrizLinhas.ToArray());
        //                        AtualizarAPP(Campos[1]);
        //                        return;
        //                    case "RESET_APP":
        //                        MatrizLinhas.RemoveAt(i);
        //                        File.WriteAllLines(NmArqPendencias, MatrizLinhas.ToArray());
        //                        ResetAPP();
        //                        return;
        //                    default:
        //                        break;

        //                }

        //            }
        //        }
        //        //Reescreve deixando o que ficou pendente.
        //        File.WriteAllLines(NmArqPendencias, MatrizLinhas.ToArray());
        //    }
        //    catch (System.Exception e)
        //    {
        //        Log.GravaLogNivel1(1, "ResolvePendencia: Erro " + e.Message);
        //    }

        //    //Log.GravaLogNivel1(1, "Resolve Pendencia - Qtd: " + DadosGlobais.Cupons.Count);

        //    if(DadosGlobais.Sitef_Habilita)
        //        if (DadosGlobais.Cupons != null && DadosGlobais.Cupons.Count() > 0)
        //        {
        //            ResolverPendenciaCliSitef();
        //            Log.GravaLogNivel1(1, "ResolvePendencia: Existe pendencia Bradesco");
        //        }
        //}

        //private static void ResolverPendenciaCliSitef()
        //{
        //    //Log.GravaLogNivel1(1, "Resolver Pendencia - Qtd: " + DadosGlobais.Cupons.Count);
        //    foreach (DadosSiTEF DadosSitef in DadosGlobais.Cupons)
        //        try
        //        {
        //            int retorno = CliSitef6.ConfiguraIntSiTefInterativoEx(DadosGlobais.Sitef_IP, DadosGlobais.SiTef_Empresa, DadosGlobais.SiTef_Terminal, "", DadosGlobais.SiTef_Parametros_Adicionais);

        //            //Log.GravaLogNivel1(1, "Resolver Pendencia - Retorno: " + retorno);
        //            if (retorno == 0)
        //            {
        //                short Confirma = 0;

        //                int cd_retorno = ConfirmaSaquePendenciaBradesco(DadosGlobais.NumeroATM, null, null, DadosSitef.TxCupomFiscal, -1, null, null, -1);

        //                //Log.GravaLogNivel1(1, "Resolvendo Pendencia Cupom: " + DadosSitef.TxCupomFiscal);

        //                //Log.GravaLogNivel1(1, "Resolvendo Pendencia Cupom - Retorno WSATM: " + cd_retorno);

        //                if (cd_retorno == 2 || cd_retorno == -1)
        //                    continue;

        //                if (cd_retorno == 0)
        //                    Confirma = 1;

        //                //Log.GravaLogNivel1(1, "Resolvendo Pendencia Cupom - Confirma: " + Confirma);

        //                CliSitef6.FinalizaFuncaoSiTefInterativo(Confirma, DadosSitef.TxCupomFiscal, DadosSitef.TxData, DadosSitef.TxHora, "");
        //            }

        //        }
        //        catch (System.Exception e)
        //        {
        //            Log.GravaLogNivel1(1, "ResolverPendeciaCliSitef: Erro " + e.Message);
        //        }
        //        finally
        //        {
        //            DadosGlobais.DadosSiTEF = null;
        //        }

        //    DadosGlobais.Cupons = new List<DadosSiTEF>();

        //}

        //public static void VerificaPendeciaCliSitef()
        //{
        //    try
        //    {
        //        int retorno = CliSitef6.ConfiguraIntSiTefInterativoEx(DadosGlobais.Sitef_IP, DadosGlobais.SiTef_Empresa, DadosGlobais.SiTef_Terminal, "", DadosGlobais.SiTef_Parametros_Adicionais);
        //        if (retorno == 0)
        //        {
        //            DadosGlobais.DadosSiTEF = new DadosSiTEF();

        //            DadosGlobais.DadosSiTEF.TxCupomFiscal = RotinasGlobais.MontaNSU();

        //            DadosGlobais.DadosSiTEF.TxData = DateTime.Now.ToString("yyyyMMdd");

        //            DadosGlobais.DadosSiTEF.TxHora = DateTime.Now.ToString("HHmmss");

        //            DadosGlobais.Cupons = new List<DadosSiTEF>();

        //            DadosSiTEF DadosSitef = new DadosSiTEF();

        //            retorno = CliSitef6.IniciaFuncaoSiTefInterativo(130, "", DadosGlobais.DadosSiTEF.TxCupomFiscal, DadosGlobais.DadosSiTEF.TxData, DadosGlobais.DadosSiTEF.TxHora, DadosGlobais.SiTef_Funcao_Operador, DadosGlobais.SiTef_Funcao_Porta_Pinpad);

        //            if (retorno == 10000)
        //            {
        //                try
        //                {
        //                    int Comando = 0; int TipoCampo = 0; short TamMin = 0; short TamMax = 0; int Continua = 0;

        //                    byte[] bytes = new byte[20000];
        //                    int tamanho = bytes.Length;
        //                    do
        //                    {
        //                        retorno = CliSitef6.ContinuaFuncaoSiTefInterativo(ref Comando, ref TipoCampo, ref TamMin, ref TamMax, bytes, bytes.Length, Continua);

        //                        String TxBuffer = System.Text.Encoding.ASCII.GetString(bytes).Replace(Convert.ToChar(0x0).ToString(), "").Trim();

        //                        Log.GravaLogNivel1(1, "TipoCampo: " + TipoCampo);

        //                        Log.GravaLogNivel1(1, "Buffer: " + TxBuffer);

        //                        if (TipoCampo == 160)
        //                        {
        //                            DadosSitef = new DadosSiTEF();
        //                            DadosSitef.TxCupomFiscal = TxBuffer;
        //                            Log.GravaLogNivel1(1, "Pendencia Cupom: " + TxBuffer);
        //                            // DadosGlobais.Cupons.Add(TxBuffer);
        //                        }
        //                        else if (TipoCampo == 163)
        //                        {
        //                            DadosSitef.TxData = TxBuffer;
        //                        }
        //                        else if (TipoCampo == 164)
        //                        {
        //                            DadosSitef.TxHora = TxBuffer;
        //                            DadosGlobais.Cupons.Add(DadosSitef);
        //                        }

        //                        bytes = new byte[20000];

        //                        Comando = 0;
        //                    }
        //                    while (retorno == 10000);
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }
        //        }

        //    }
        //    catch (System.Exception e)
        //    {
        //        Log.GravaLogNivel1(1, "VerificaPendeciaCliSitef: Erro " + e.Message);
        //    }
        //    finally
        //    {
        //        DadosGlobais.DadosSiTEF = null;
        //        DadosGlobais.VerificaPendenciaBradesco = false;
        //    }
        //}

        //private static bool ChamaPacote()
        //{
        //    try
        //    {
        //        if (!File.Exists(DadosGlobais.PacotePath))
        //            return false;

        //        Process p = new Process();
        //        p.StartInfo.FileName = DadosGlobais.PacotePath;
        //        p.StartInfo.UseShellExecute = true;
        //        p.Start();
        //        Log.GravaLogNivel1(1, "ChamaPacote: inicializado.");
        //        return true;
        //    }
        //    catch (Exception erro)
        //    {
        //        Log.GravaLogNivel1(1, "ChamaPacote: Erro " + erro.Message);
        //        return false;
        //    }

        //}

        //private static bool ConfirmaSaquePendencia(string nro_ATM, string nu_card_pam, string nu_NSUHOST, string nu_NSUATM, int st_saque, int[] qtdNotasDispensadas, int[] qtdNotasRejeitadas, int nrRejectComplete)
        //{
        //    int cd_retorno = 1;
        //    string ds_retorno = "";
        //    string vl_saldo_atualizado = "";
        //    try
        //    {
        //        RotinasGlobais.WServises.ConfirmaSaque(nro_ATM, nu_card_pam, nu_NSUHOST, nu_NSUATM, st_saque,
        //            qtdNotasDispensadas[0], qtdNotasDispensadas[1], qtdNotasDispensadas[2], qtdNotasDispensadas[3],
        //            qtdNotasRejeitadas[0], qtdNotasRejeitadas[1], qtdNotasRejeitadas[2], qtdNotasRejeitadas[3], nrRejectComplete,
        //            out cd_retorno, out ds_retorno, out vl_saldo_atualizado);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.GravaLogNivel1(1, "AtualizaSaldoPendencia: Erro " + ex.Message);
        //    }

        //    return cd_retorno == 0;
        //}

        //private static int ConfirmaSaquePendenciaBradesco(string nro_ATM, string nu_card_pam, string nu_NSUHOST, string nu_NSUATM, int st_saque, int[] qtdNotasDispensadas, int[] qtdNotasRejeitadas, int nrRejectComplete)
        //{
        //    int cd_retorno = 1;
        //    string ds_retorno = "";
        //    string vl_saldo_atualizado = "";
        //    try
        //    {
        //        RotinasGlobais.WServises.ConfirmaSaque(nro_ATM, nu_card_pam, nu_NSUHOST, nu_NSUATM, st_saque,
        //            0, 0, 0, 0,
        //            0, 0, 0, 0, nrRejectComplete,
        //            out cd_retorno, out ds_retorno, out vl_saldo_atualizado);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.GravaLogNivel1(1, "AtualizaSaldoPendencia: Erro " + ex.Message);
        //        cd_retorno = -1;
        //    }

        //    return cd_retorno;
        //}

        //private static bool ConcluirTarefasPendencia(string id_tarefa, string tp_atendimento, string data_atendimento)
        //{
        //    int cd_retorno = 1;
        //    string ds_retorno = "";

        //    try
        //    {
        //        RotinasGlobais.WServises.ConcluirTarefas(int.Parse(id_tarefa), tp_atendimento, data_atendimento, out cd_retorno, out ds_retorno);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.GravaLogNivel1(1, "ConcluirTarefasPendencia: Erro " + ex.Message);
        //    }

        //    return cd_retorno == 0;
        //}

        //private static bool RecolhimentoPendencia(string nro_ATM, string nu_os, string dt_atendimento, string dt_envio,
        //       string qtd_cedulas_cassete_a, string valor_nominal_cedula_a,
        //       string qtd_cedulas_cassete_b, string valor_nominal_cedula_b,
        //       string qtd_cedulas_cassete_c, string valor_nominal_cedula_c,
        //       string qtd_cedulas_cassete_d, string valor_nominal_cedula_d,
        //       string qtd_total_rejeicao, string valor_total_rejeicao)
        //{
        //    int cd_retorno = 1;
        //    string ds_retorno = "";
        //    string data_envio = DateTime.Now.ToString("ddMMyyyyHHmmss");
        //    try
        //    {
        //        RotinasGlobais.WServises.Recolhimento(nro_ATM, int.Parse(nu_os), dt_atendimento, data_envio,
        //                int.Parse(qtd_cedulas_cassete_a), double.Parse(valor_nominal_cedula_a),
        //                int.Parse(qtd_cedulas_cassete_b), double.Parse(valor_nominal_cedula_b),
        //                int.Parse(qtd_cedulas_cassete_c), double.Parse(valor_nominal_cedula_c),
        //                int.Parse(qtd_cedulas_cassete_d), double.Parse(valor_nominal_cedula_d),
        //                int.Parse(qtd_total_rejeicao), double.Parse(valor_total_rejeicao), out cd_retorno, out ds_retorno);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.GravaLogNivel1(1, "RecolhimentoPendencia: Erro " + ex.Message);
        //    }

        //    return cd_retorno == 0;
        //}

        //private static bool SuprimentoPendencia(string nro_ATM, string nu_os, string dt_atendimento, string dt_envio,
        //   string qtd_cedulas_cassete_a, string valor_nominal_cedula_a,
        //   string qtd_cedulas_cassete_b, string valor_nominal_cedula_b,
        //   string qtd_cedulas_cassete_c, string valor_nominal_cedula_c,
        //   string qtd_cedulas_cassete_d, string valor_nominal_cedula_d)
        //{
        //    int cd_retorno = 1;
        //    string ds_retorno = "";
        //    string data_envio = DateTime.Now.ToString("ddMMyyyyHHmmss");
        //    try
        //    {
        //        RotinasGlobais.WServises.Suprimento(nro_ATM, int.Parse(nu_os), dt_atendimento, data_envio,
        //                int.Parse(qtd_cedulas_cassete_a), double.Parse(valor_nominal_cedula_a),
        //                int.Parse(qtd_cedulas_cassete_b), double.Parse(valor_nominal_cedula_b),
        //                int.Parse(qtd_cedulas_cassete_c), double.Parse(valor_nominal_cedula_c),
        //                int.Parse(qtd_cedulas_cassete_d), double.Parse(valor_nominal_cedula_d), out cd_retorno, out ds_retorno);

        //        if (cd_retorno == 0)
        //        {
        //            RotinasGlobais.BuscaAtualizaSado();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.GravaLogNivel1(1, "SuprimentoPendencia: Erro " + ex.Message);
        //    }

        //    return cd_retorno == 0;
        //}

        //private static void ResetATM()
        //{
        //    try
        //    {
        //        Log.GravaLogNivel1(1, "ResetATM: inicializado.");
        //        System.Diagnostics.Process.Start(@"c:\confpcp\shutdown", "/R /T:5 'RESET EQUIPAMENTO' /Y /C /L");
        //    }
        //    catch (Exception erro)
        //    {
        //        Log.GravaLogNivel1(1, "ResetATM: Erro " + erro.Message);
        //    }

        //    Log.GravaLogNivel1(1, "Fechando aplicação");
        //    Application.Current.MainWindow.Close();

        //}

        //public static void ResetAPP()
        //{
        //    try
        //    {
        //        Log.GravaLogNivel1(1, "ResetAPP: inicializado.");

        //        Log.GravaLogNivel1(1, "Fechando aplicação para reiniciar");
        //        Application.Current.Shutdown();
        //    }
        //    catch (Exception erro)
        //    {
        //        Log.GravaLogNivel1(1, "ResetAPP: Erro " + erro.Message);
        //    }
        //}

        ///// <summary>
        ///// Atualiza dados em XML, caso ocorra a queda da aplicação
        ///// Tipo: 1-> QtdSaques 2-> Ultima Transação 3-> EstadoATM 4-> EstadoK7
        ///// </summary>
        ///// <param name="tipo"></param>
        //public static void AtualizaDadosApp(int tipo)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    DateTime data;

        //    try
        //    {
        //        if (!File.Exists(NmArqDadosApp))
        //        {
        //            CriarArquivoDadosXML();
        //        }

        //        doc.Load(NmArqDadosApp);

        //        switch (tipo)
        //        {
        //            case 1:
        //                //Atualiza contagem de saques por dia
        //                data = DateTime.Parse(doc.SelectSingleNode("dadosApp/saque/dt_saque").InnerText != "" ? doc.SelectSingleNode("dadosApp/saque/dt_saque").InnerText : default(DateTime).ToString());

        //                if (data.Equals(default(DateTime)) || data.Date.Equals(DateTime.Now.Date))
        //                {
        //                    doc.SelectSingleNode("dadosApp/saque/qt_saque").InnerText = (int.Parse(doc.SelectSingleNode("dadosApp/saque/qt_saque").InnerText) + 1).ToString();
        //                    doc.SelectSingleNode("dadosApp/saque/dt_saque").InnerText = DateTime.Now.ToString();
        //                }
        //                else
        //                {
        //                    doc.SelectSingleNode("dadosApp/saque/qt_saque").InnerText = "1";
        //                    doc.SelectSingleNode("dadosApp/saque/dt_saque").InnerText = DateTime.Now.ToString();
        //                }
        //                break;
        //            case 2:
        //                //Atualiza ultima tranzação
        //                doc.SelectSingleNode("dadosApp/transacao/dt_transacao").InnerText = DateTime.Now.ToString();
        //                break;
        //            case 3:
        //                doc.SelectSingleNode("dadosApp/EstadoATM/cd_estado").InnerText = DadosGlobais.ATM_Disponivel ? "1" : "0";
        //                doc.SelectSingleNode("dadosApp/EstadoATM/ds_estado").InnerText = DadosGlobais.Mensagem_Indisponibilidade;
        //                break;
        //            case 4:
        //                for (int i = 0; i < 4; i++)
        //                {
        //                    doc.SelectSingleNode("dadosApp/EstadoK7/k7_" + (i == 0 ? "A" : i == 1 ? "B" : i == 2 ? "C" : "D")).InnerText = WosaDISP.TarefaK7Disponivel[i].ToString();
        //                }
        //                break;
        //        }

        //        doc.Save(NmArqDadosApp);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Log.GravaLogNivel1(1, "AtualizaDadosApp: Erro " + ex.Message);
        //    }

        //}

        //public static void ObtemDadosApp()
        //{
        //    XmlDocument doc = new XmlDocument();
        //    DateTime data;

        //    try
        //    {
        //        if (!File.Exists(NmArqDadosApp))
        //        {
        //            CriarArquivoDadosXML();
        //        }

        //        doc.Load(NmArqDadosApp);

        //        data = DateTime.Parse(doc.SelectSingleNode("dadosApp/saque/dt_saque").InnerText != "" ? doc.SelectSingleNode("dadosApp/saque/dt_saque").InnerText : default(DateTime).ToString());

        //        if (data.Date.Equals(DateTime.Now.Date))
        //        {
        //            DadosGlobais.QuantidadeSaques = int.Parse(doc.SelectSingleNode("dadosApp/saque/qt_saque").InnerText);
        //        }
        //        else
        //            DadosGlobais.QuantidadeSaques = 0;

        //        DadosGlobais.DataHoraUltimoSaque = DateTime.Parse(doc.SelectSingleNode("dadosApp/saque/dt_saque").InnerText != "" ? doc.SelectSingleNode("dadosApp/saque/dt_saque").InnerText : default(DateTime).ToString());

        //        DadosGlobais.DataHoraUltimaTransacao = DateTime.Parse(doc.SelectSingleNode("dadosApp/transacao/dt_transacao").InnerText != "" ? doc.SelectSingleNode("dadosApp/transacao/dt_transacao").InnerText : default(DateTime).ToString());

        //        DadosGlobais.ATM_Disponivel = doc.SelectSingleNode("dadosApp/EstadoATM/cd_estado").InnerText == "1" ? true : false;
        //        DadosGlobais.Mensagem_Indisponibilidade = doc.SelectSingleNode("dadosApp/EstadoATM/ds_estado").InnerText;

        //        for (int i = 0; i < 4; i++)
        //        {
        //            WosaDISP.TarefaK7Disponivel[i] = int.Parse(doc.SelectSingleNode("dadosApp/EstadoK7/k7_" + (i == 0 ? "A" : i == 1 ? "B" : i == 2 ? "C" : "D")).InnerText);
        //        }

        //    }
        //    catch (System.Exception ex)
        //    {
        //        Log.GravaLogNivel1(1, "ObtemDadosApp: Erro " + ex.Message);

        //        try
        //        {
        //            if (File.Exists(NmArqDadosApp))
        //            {
        //                File.Delete(NmArqDadosApp);
        //                CriarArquivoDadosXML();
        //            }
        //        }
        //        catch
        //        { }
        //    }

        //}

        //private static void CriarArquivoDadosXML()
        //{
        //    XmlDocument doc = new XmlDocument();

        //    try
        //    {
        //        XmlNode raiz = doc.CreateElement("dadosApp");
        //        doc.AppendChild(raiz);

        //        /*Saque Data e quantidade*/
        //        XmlNode bloco1 = doc.CreateElement("saque");
        //        XmlNode DataSaque = doc.CreateElement("dt_saque");
        //        XmlNode QtdSaque = doc.CreateElement("qt_saque");
        //        DataSaque.InnerText = "";
        //        QtdSaque.InnerText = "0";
        //        bloco1.AppendChild(DataSaque);
        //        bloco1.AppendChild(QtdSaque);
        //        /*Fim do Saque*/

        //        /*Ultima Transação*/
        //        XmlNode bloco2 = doc.CreateElement("transacao");
        //        XmlNode DataUltimaTrasacao = doc.CreateElement("dt_transacao");
        //        DataUltimaTrasacao.InnerText = "";
        //        bloco2.AppendChild(DataUltimaTrasacao);
        //        /*Fim ultima transação*/

        //        /*Estado ATM*/
        //        XmlNode bloco3 = doc.CreateElement("EstadoATM");
        //        XmlNode cd_estado = doc.CreateElement("cd_estado");
        //        cd_estado.InnerText = "1"; //Habilitado
        //        XmlNode ds_estado = doc.CreateElement("ds_estado");
        //        ds_estado.InnerText = "";
        //        bloco3.AppendChild(cd_estado);
        //        bloco3.AppendChild(ds_estado);
        //        /*Fim Estado ATM*/

        //        /*Estado K7*/
        //        XmlNode bloco4 = doc.CreateElement("EstadoK7");

        //        for (int i = 0; i < 4; i++)
        //        {
        //            XmlNode cd_k7 = doc.CreateElement("k7_" + (i == 0 ? "A" : i == 1 ? "B" : i == 2 ? "C" : "D"));
        //            cd_k7.InnerText = "1"; //Habilitado
        //            bloco4.AppendChild(cd_k7);
        //        }

        //        /*Fim Estado K7*/

        //        doc.SelectSingleNode("/dadosApp").AppendChild(bloco1);

        //        doc.SelectSingleNode("/dadosApp").AppendChild(bloco2);

        //        doc.SelectSingleNode("/dadosApp").AppendChild(bloco3);

        //        doc.SelectSingleNode("/dadosApp").AppendChild(bloco4);

        //        doc.Save(NmArqDadosApp);


        //    }
        //    catch (System.Exception ex)
        //    {
        //        Log.GravaLogNivel1(1, "CriarArquivoDadosXML: Erro " + ex.Message);
        //    }

        //}

        //public static string TrocaPontoValor(string Valor)
        //{
        //    string ValorAux = "0,00";
        //    try
        //    {
        //        ValorAux = string.Format("{0:N}", double.Parse(Valor) / 100);
        //    }
        //    catch (Exception e)
        //    {
        //        Log.GravaLogNivel1(1, "Erro formatando valor: " + Valor + " - " + e.Message);
        //    }
        //    return ValorAux;
        //}

        ///// <summary>
        ///// Formata texto para utilização na impressora, 
        ///// centralizando e quebrando a linha a cada 48 posições.
        ///// </summary>
        ///// <param name="Texto"></param>
        ///// <param name="Centralizar"></param>
        ///// <returns></returns>
        //public static string FormataTexto(string Texto, bool Centralizar)
        //{
        //    return CPUtils.FormataTexto(Texto, Centralizar);
        //}

        //public static string CalculaModulo10(string pstrNumero)
        //{
        //    return CPUtils.CalculaModulo10(pstrNumero);
        //}

        //public static string CalculaModulo11(string pstrNumero)
        //{
        //    return CPUtils.CalculaModulo11(pstrNumero);
        //}

        //public static bool ConsistirBarrasTarifas(string mstrCodigoBarras, out double mstrValor)
        //{
        //    mstrValor = 0;
        //    return CPUtils.ConsistirBarrasTarifas(mstrCodigoBarras, out mstrValor);
        //}

        //public static string CalculaBlocoTarifas(string mstrCodigoBarras, int moeda)
        //{
        //    return CPUtils.CalculaBlocoTarifas(mstrCodigoBarras, moeda);
        //}

        //public static bool ConsistirBarrasTitulos(string strCodigoBarrasAux, string Digito)
        //{
        //    return CPUtils.ConsistirBarrasTitulos(strCodigoBarrasAux, Digito);
        //}

        //public static void AvancaLista(ListBox listBox1)
        //{
        //    if (listBox1.SelectedIndex > 0)
        //    {
        //        listBox1.SelectedIndex = listBox1.SelectedIndex - 1;
        //        listBox1.ScrollIntoView(listBox1.SelectedItem);
        //    }
        //}

        //public static void VoltaLista(ListBox listBox1)
        //{
        //    if (listBox1.SelectedIndex < (listBox1.Items.Count - 1))
        //    {
        //        listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
        //        listBox1.ScrollIntoView(listBox1.SelectedItem);

        //    }
        //}

        //public static void AvancaLista(DataGrid listBox1)
        //{
        //    if (listBox1.SelectedIndex > 0)
        //    {
        //        listBox1.SelectedIndex = listBox1.SelectedIndex - 1;
        //        listBox1.ScrollIntoView(listBox1.SelectedItem);
        //    }
        //}

        //public static void VoltaLista(DataGrid listBox1)
        //{
        //    if (listBox1.SelectedIndex < (listBox1.Items.Count - 1))
        //    {
        //        listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
        //        listBox1.ScrollIntoView(listBox1.SelectedItem);

        //    }
        //}

        //public static int DescobreValorMaximoSaque(bool SaqueDebito)
        //{
        //    int ValorAux = 0;
        //    try
        //    {
        //        List<Cassete> cassetes = new List<Cassete>();

        //        for (int i = 0; i < 4; i++)
        //        {
        //            if (WosaDISP.K7Disponivel[i] == 1 && WosaDISP.QtdK7[i] > 0)
        //            {
        //                Cassete cassete = new Cassete();
        //                cassete.ValorK7 = WosaDISP.ValorK7[i];
        //                cassete.QtdK7 = WosaDISP.QtdK7[i];
        //                cassetes.Add(cassete);
        //            }
        //        }

        //        cassetes = cassetes.OrderByDescending(c => c.ValorK7).ToList();

        //        int qtCedulasMax = 30; // Limite de trinta cedulas por saque
        //        int qtCedulas = 0;

        //        foreach (Cassete aux in cassetes)
        //        {
        //            int qtCedulasCassete = Math.Min((qtCedulasMax - qtCedulas), aux.QtdK7);
        //            qtCedulas += qtCedulasCassete;
        //            ValorAux += (qtCedulasCassete * aux.ValorK7);

        //            if (qtCedulas >= qtCedulasMax)
        //                break;
        //        }

        //        //ValorAux = ValorAux * 30; // Limite de trinta cedulas por saque


        //        if (ValorAux > DadosCliente.vl_limite_saque_horario)
        //        {
        //            ValorAux = (int)(DadosCliente.vl_limite_saque_horario);
        //        }

        //        if (SaqueDebito)
        //        {
        //            if (ValorAux > DadosCliente.vl_Saldo_Disponivel)
        //            {
        //                ValorAux = (int)DadosCliente.vl_Saldo_Disponivel;
        //            }
        //        }
        //        else
        //        {
        //            if (ValorAux > DadosCliente.vl_Limite_Credito)
        //            {
        //                ValorAux = (int)DadosCliente.vl_Limite_Credito;
        //            }
        //        }

        //        int ValorMaximo = 0;
        //        qtCedulas = 0;

        //        foreach (Cassete aux in cassetes)
        //        {
        //            int qtCedulasCassete = 0;

        //            if ((ValorAux / aux.ValorK7) > 0)
        //            {
        //                qtCedulasCassete = Math.Min(qtCedulasMax - qtCedulas, Math.Min(((int)(ValorAux / aux.ValorK7)), aux.QtdK7));
        //                qtCedulas += qtCedulasCassete;
        //                ValorAux -= (qtCedulasCassete * aux.ValorK7);
        //                ValorMaximo += (qtCedulasCassete * aux.ValorK7);
        //            }

        //            if (qtCedulas >= qtCedulasMax)
        //                break;
        //        }

        //        ValorAux = ValorMaximo;

        //    }
        //    catch (Exception ee)
        //    {
        //        Log.GravaLogNivel1(1, "DescobreValorMaximoSaque: Erro " + ee.Message);
        //    }
        //    return ValorAux;
        //}

        //public static string MontaNSU()
        //{
        //    return DadosGlobais.NumeroATM.ToString().PadLeft(8, '0') + DateTime.Now.ToString("ddMMyyHHmmss");
        //}

        //public static void RealizaLogout()
        //{
        //    int cd_retorno;
        //    string ds_retorno;

        //    WServises.Logout(DadosGlobais.NumeroATM, DadosCliente.nro_cartao_pam_encrypatado, out cd_retorno, out ds_retorno);

        //    if (cd_retorno == 0)
        //        Log.GravaLogNivel1(1, "Logout efetuado.");
        //    else
        //        Log.GravaLogNivel1(1, "Logout erro: " + ds_retorno);

        //}

        //static public string MontaCabecalho(string titulo, string terminal, string Cliente)
        //{
        //    string Linhas = "";
        //    Linhas += "------------------------------------------------" + "\n";
        //    Linhas += FormataTexto("CARTAO CREDNOSSO", true);
        //    Linhas += FormataTexto("Terminal: " + terminal.PadLeft(10, '0') + " Data: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), true);
        //    Linhas += FormataTexto(titulo, true);
        //    Linhas += "\n";
        //    if (Cliente != "")
        //        Linhas += "Cliente....: " + Cliente + "\n";
        //    return Linhas;
        //}

        //static public string MontaRodape(string ds_mensagem_1, string ds_mensagem_2, string ds_mensagem_3)
        //{
        //    string Linhas = "";
        //    Linhas = ds_mensagem_1 != string.Empty ? FormataTexto(ds_mensagem_1, true) : "";
        //    Linhas += ds_mensagem_2 != string.Empty ? FormataTexto(ds_mensagem_2, true) : "";
        //    Linhas += ds_mensagem_2 != string.Empty ? FormataTexto(ds_mensagem_3, true) : "";
        //    Linhas += "------------------------------------------------" + "\n";

        //    return Linhas;
        //}

        //private static void AtualizarAPP(string ds_Base64Aplicacao)
        //{
        //    try
        //    {
        //        Log.GravaLogNivel1(1, "Atualizar_Sistema: inicializado.");

        //        byte[] by_Aplicacao = Convert.FromBase64String(ds_Base64Aplicacao);

        //        string dirpath = @"C:\espelho\";

        //        string dirpathpacotetemp = @"C:\espelho\Pacote_Temp\";

        //        DirectoryInfo di = new DirectoryInfo(dirpath);

        //        DirectoryInfo diTemp = new DirectoryInfo(dirpathpacotetemp);

        //        foreach (DirectoryInfo aux in di.GetDirectories("*"))
        //            aux.Delete(true);

        //        foreach (FileInfo aux in di.GetFiles("*"))
        //            aux.Delete();

        //        if (SaveData(@"C:\espelho\Pacote_Temp.zip", by_Aplicacao))
        //        {
        //            foreach (FileInfo aux in di.GetFiles("*.zip"))
        //            {
        //                ExtractZipFile(aux.FullName, null, dirpath);
        //                aux.Delete();
        //            }

        //            foreach (FileInfo auxTmp in diTemp.GetFiles("instala.bat.new"))
        //                auxTmp.MoveTo(dirpathpacotetemp + "\\instala.bat");
        //        }

        //    }
        //    catch (Exception erro)
        //    {
        //        Log.GravaLogNivel1(1, "Atualizar_Sistema: Erro " + erro.Message);
        //    }
        //}

        //public static bool SaveData(string FileName, byte[] Data)
        //{
        //    BinaryWriter Writer = null;
        //    try
        //    {
        //        Writer = new BinaryWriter(File.OpenWrite(FileName));
        //        Writer.Write(Data);
        //        Writer.Flush();
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        if (Writer != null)
        //            Writer.Close();
        //    }

        //    return true;
        //}

        //public static void ExtractZipFile(string archiveFilenameIn, string password, string outFolder)
        //{
        //    ZipFile zf = null;
        //    try
        //    {
        //        FileStream fs = File.OpenRead(archiveFilenameIn);
        //        zf = new ZipFile(fs);
        //        if (!String.IsNullOrEmpty(password))
        //            zf.Password = password;
        //        foreach (ZipEntry zipEntry in zf)
        //        {
        //            if (!zipEntry.IsFile)
        //                continue;
        //            String entryFileName = zipEntry.Name;

        //            byte[] buffer = new byte[4096];
        //            Stream zipStream = zf.GetInputStream(zipEntry);

        //            String fullZipToPath = Path.Combine(outFolder, entryFileName);
        //            string directoryName = Path.GetDirectoryName(fullZipToPath);
        //            if (directoryName.Length > 0)
        //                Directory.CreateDirectory(directoryName);

        //            using (FileStream streamWriter = File.Create(fullZipToPath))
        //                StreamUtils.Copy(zipStream, streamWriter, buffer);
        //        }
        //    }
        //    finally
        //    {
        //        if (zf != null)
        //        {
        //            zf.IsStreamOwner = true;
        //            zf.Close();
        //        }
        //    }
        //}

    }
}


class Cassete
{
    public int ValorK7 { get; set; }

    public int QtdK7 { get; set; }
}