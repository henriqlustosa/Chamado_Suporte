using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Media;
using System.Configuration;

public partial class telaoChamado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            carregaGrid();
            carregaSolicitacoes();
        }
        cont1hr = 0;
    }
    public int cont1hr { get; set; }

    private void carregaSolicitacoes()
    {
        labelTotalSolicitacoesPorSetor.Text = SolicitaAcessoDAO.CarregaQtoDeSolicitacoesPorSetores();
    }

    private void carregaGrid()
    {
        var lista = new List<ListaGrid>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[ocorrencia],[dataHoraAbertura],[statusChamado],[nomeTecnico] 
  FROM [chamado_suporte].[dbo].[aberturaChamado] where statusChamado= 0 or statusChamado=1 or statusChamado= 5 or statusChamado= 11 or statusChamado= 12 order by CASE  statusChamado WHEN 0 THEN 0 WHEN 12 THEN 1 WHEN 11 THEN 2 WHEN 1 THEN 3 WHEN 5 THEN 4 end ";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    ListaGrid l = new ListaGrid();
                    l.id = dr.GetInt32(0);
                    l.cac = dr.IsDBNull(1) ? null : dr.GetString(1);
                    l.nomeContato = dr.IsDBNull(2) ? null : dr.GetString(2);
                    l.setor = dr.IsDBNull(3) ? null : dr.GetString(3);
                    l.ramal = dr.IsDBNull(4) ? null : dr.GetString(4);
                    l.titulo = dr.IsDBNull(5) ? null : dr.GetString(5);
                    string ocorrenciaTelao = dr.IsDBNull(6) ? null : dr.GetString(6);

                    if (ocorrenciaTelao.Length >= 18)
                    {
                        l.ocorrencia = ocorrenciaTelao.Substring(0, 18);
                        // l.ocorrencia += l.ocorrencia + " (->)"; recebe e soma com o que já tem, fazer isso para extrato do chamado
                        l.ocorrencia = l.ocorrencia + "....";
                    }
                    else
                    {
                        l.ocorrencia = ocorrenciaTelao;
                    }

                    DateTime dtHora = dr.GetDateTime(7);
                    l.dt_hora = Convert.ToString(dtHora).Substring(0, 16);
                    //DateTime dt2Horas = DateTime.Now.AddHours(2);
                    //DateTime dt4Horas = DateTime.Now.AddHours(4);
                    DateTime dt2Horas = dtHora.AddHours(2);
                    DateTime dt4Horas = dtHora.AddHours(4);

                    DateTime dtAtual = DateTime.Now;


                    DateTime dtMinutoSom = dtHora.AddMilliseconds(29000);
                    int statuCor = dr.GetInt32(8);
                    l.nomeTecnico = dr.IsDBNull(9) ? null : dr.GetString(9);

                    l.statusCor = statuCor.ToString();

                    if (l.statusCor == "1" || l.statusCor == "5")
                    {
                        l.statusDochamadoTelao = "EM ATEND >> " + l.nomeTecnico + "";
                    }
                    else
                    {
                        if (l.statusCor != "11" && l.statusCor != "12")
                        {
                            l.statusDochamadoTelao = "AGUARDANDO";
                            if (dt2Horas > dtAtual)
                            {
                                l.statusCor = "0";
                                if (dtMinutoSom >= dtAtual)
                                {
                                    playSimpleSound();
                                    l.statusCor = "10";

                                }
                            }
                            else if (dt2Horas < dtAtual && dtAtual < dt4Horas)
                            {
                                l.statusCor = "3";
                                l.statusDochamadoTelao = "+ DE 2 HORAS";
                            }
                            else if (dt4Horas < dtAtual)
                            {
                                l.statusCor = "2";
                                l.statusDochamadoTelao = "+ DE 4 HORAS";
                            }
                        }
                        else
                        {
                            if (l.statusCor == "11")
                            {
                                l.statusDochamadoTelao = "P/ NOTURNO";
                            }
                            else if (l.statusCor == "12")
                            {
                                l.statusDochamadoTelao = "P/ DIURNO";

                            }
                        }
                    }

                    if (l.statusCor != "1" && l.statusCor != "5" && l.statusCor != "11" && l.statusCor != "12")
                    {
                       
                        if (dt2Horas.AddHours(-1) < dtAtual && dtAtual < dt2Horas.AddHours(-1).AddMinutes(1))
                        {

                            cont1hr++;
                            if (cont1hr == 1)
                            {
                                playSimpleSound1hrEspera();
                            }
                            
                        }

                        if (dt2Horas < dtAtual && dtAtual < dt2Horas.AddMinutes(1))
                        {
                            cont1hr++;
                            if (cont1hr == 1)
                            {
                                playSimpleSoundAmarelo();
                            }
                        }
                        else if (dt4Horas < dtAtual && dtAtual < dt4Horas.AddMinutes(1))
                        {
                            cont1hr++;
                            if (cont1hr == 1)
                            {
                                playSimpleSoundVermelho();
                            }
                        }
                    }

                    lista.Add(l);
                }
                com.Close();


            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
            GridViewChamados.DataSource = lista;
            GridViewChamados.DataBind();
        }


    }

    protected void GridViewChamados_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if ((Convert.ToString(DataBinder.Eval(e.Row.DataItem, "statusCor")) == "1") || (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "statusCor")) == "5"))
            {
                e.Row.BackColor = Color.Wheat;
                e.Row.ForeColor = Color.Black;
            }
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "statusCor")) == "3")
            {
                e.Row.BackColor = Color.LemonChiffon;
                //  e.Row.BackColor = Color.LightYellow;
                // e.Row.Font.Size = 46;
                //playSimpleSound(); // se quiser deixar o som aqui pa um alerta pode 
                //string NomePacienteMudaStatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "nm_paciente"));
                //string NumeroSala = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "sala"));
                //ConsultaPacienteDAO.MudaStatusDoPaciente(NomePacienteMudaStatus, NumeroSala);

            }
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "statusCor")) == "2")
            {
                // e.Row.BackColor = Color.Red;
                e.Row.BackColor = Color.Tomato;
            }

            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "statusCor")) == "10")
            {
                e.Row.BackColor = Color.GreenYellow;

            }
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "statusCor")) == "11")
            {
                e.Row.BackColor = Color.Thistle;
                e.Row.ForeColor = Color.Black;
            }
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "statusCor")) == "12")
            {
                e.Row.BackColor = Color.LightCyan;
                e.Row.ForeColor = Color.Black;

            }
        }
        catch (Exception ex)
        {
            string erro = ex.Message;
        }
    }

    private void playSimpleSound()
    {
        // string audio = ConfigurationManager.AppSettings["SoundToCallPanel"];
        try
        {
            Response.Write("<embed height='0' width='0' src='../som/ChamadoSuporte.mp3'/>");
        }
        catch (Exception ex)
        {
            string erro = ex.Message;
        }

    }
    private void playSimpleSoundAmarelo()
    {
        // string audio = ConfigurationManager.AppSettings["SoundToCallPanel"];
        try
        {
            Response.Write("<embed height='0' width='0' src='../som/chamadoAmarelo.mp3'/>");
        }
        catch (Exception ex)
        {
            string erro = ex.Message;
        }

    }

    private void playSimpleSoundVermelho()
    {
        // string audio = ConfigurationManager.AppSettings["SoundToCallPanel"];
        try
        {
            Response.Write("<embed height='0' width='0' src='../som/chamadoVermelho.mp3'/>");
        }
        catch (Exception ex)
        {
            string erro = ex.Message;
        }

    }

    //chamado com 1 hora em espera chamado1horaEmespera
    private void playSimpleSound1hrEspera()
    {
        // string audio = ConfigurationManager.AppSettings["SoundToCallPanel"];
        try
        {
            Response.Write("<embed height='0' width='0' src='../som/chamado1horaEmespera.mp3'/>");
        }
        catch (Exception ex)
        {
            string erro = ex.Message;
        }

    }
}