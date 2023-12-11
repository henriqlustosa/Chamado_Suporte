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
        }
    }

    private void carregaGrid()
    {
        var lista = new List<listaGrid>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[ocorrencia],[dataHoraAbertura] 
  FROM [chamado_suporte].[dbo].[aberturaChamado] where statusChamado= 0 order by id ASC";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    listaGrid l = new listaGrid();
                    l.id = dr.GetInt32(0);
                    l.cac = dr.IsDBNull(1) ? null : dr.GetString(1);
                    l.nomeContato = dr.IsDBNull(2) ? null : dr.GetString(2);
                    l.setor = dr.IsDBNull(3) ? null : dr.GetString(3);
                    l.ramal = dr.IsDBNull(4) ? null : dr.GetString(4);
                    l.titulo = dr.IsDBNull(5) ? null : dr.GetString(5);
                     string ocorrenciaTelao = dr.IsDBNull(6) ? null : dr.GetString(6);

                    if (ocorrenciaTelao.Length >= 30 )
                    {
                        l.ocorrencia = ocorrenciaTelao.Substring(0, 30);
                       // l.ocorrencia += l.ocorrencia + " (->)"; recebe e soma com o que já tem, fazer isso para extrato do chamado
                        l.ocorrencia = l.ocorrencia + " .....";
                    }
                    else
                    {
                        l.ocorrencia = ocorrenciaTelao;
                    }               

                    DateTime dtHora = dr.GetDateTime(7);
                    l.dt_hora = Convert.ToString(dtHora).Substring(0,16);
                    //DateTime dt2Horas = DateTime.Now.AddHours(2);
                    //DateTime dt4Horas = DateTime.Now.AddHours(4);
                    DateTime dt2Horas = dtHora.AddHours(2);
                    DateTime dt4Horas = dtHora.AddHours(4);

                    DateTime dtAtual = DateTime.Now;

                    DateTime dtMinutoSom = dtHora.AddMilliseconds(10000);

                    if (dt2Horas > dtAtual)
                    {
                        l.statusCor = "0";
                        if (dtMinutoSom>=dtAtual)
                        {
                            playSimpleSound();
                            l.statusCor = "10";
                        }
                    }
                    else if (dt2Horas < dtAtual && dtAtual < dt4Horas )
                    {
                        l.statusCor = "1";
                    }
                    else
                    {
                        l.statusCor = "2";
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
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "statusCor")) == "1")
            {
                e.Row.BackColor = Color.Yellow;
                // e.Row.Font.Size = 46;
                //playSimpleSound(); // se quiser deixar o som aqui pa um alerta pode 
                //string NomePacienteMudaStatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "nm_paciente"));
                //string NumeroSala = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "sala"));
                //ConsultaPacienteDAO.MudaStatusDoPaciente(NomePacienteMudaStatus, NumeroSala);

            }
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "statusCor")) == "2")
            {
                e.Row.BackColor = Color.Red;

            }

            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "statusCor")) == "10")
            {
                e.Row.BackColor = Color.GreenYellow;

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
            Response.Write("<embed height='0' width='0' src='som/ChamadoSuporte.mp3'/>");

        }
        catch (Exception ex)
        {
            string erro = ex.Message;
        }

    }
}