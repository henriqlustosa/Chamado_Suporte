using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrativo_Relatorios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        string dataInicio = txtDtInicio.Text;
        string ano = dataInicio.Substring(6, 4);
        string mes = dataInicio.Substring(3, 2);
        string dia = dataInicio.Substring(0, 2);
        string dtAmericanaI = dia + "/" + mes + "/" + ano;
        // DateTime dtInicio = Convert.ToDateTime(dtAmericanaI);

        string dataFim = txtDtFim.Text;
        string anoF = dataFim.Substring(6, 4);
        string mesF = dataFim.Substring(3, 2);
        string diaF = dataFim.Substring(0, 2);
        string dtAmericanaF = diaF + "/" + mesF + "/" + anoF;

        GridViewRelUsuario.DataSource = carregaDados(dtAmericanaI, dtAmericanaF);

    }


    private DataTable carregaDados(string dtAmericanaI, string dtAmericanaF)
    {
        DataTable dt = new DataTable();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))

        {
            //DateTime dtInicioF = Convert.ToDateTime(dtAmericanaF);
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @" SELECT nomeTecnico as Tecnico, count (id) as total    
  FROM [chamado_suporte].[dbo].[aberturaChamado] where
  CONVERT(DATE, dataHoraSolucao, 103) BETWEEN CONVERT(DATE, '" + dtAmericanaI + "', 103) AND CONVERT(DATE,'" + dtAmericanaF + "', 103)  group by nomeTecnico order by total desc ";


                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();

                #region DataTable
                dt.Columns.Add("Técnico" , System.Type.GetType("System.String"));
                dt.Columns.Add("Chamados atendidos", System.Type.GetType("System.String"));

                int total = 0;
                #endregion

                while (dr.Read())
                {
                    string usuario = dr.IsDBNull(0) ? null : dr.GetString(0);
                    total += dr.GetInt32(1);
                    string Quantidade = Convert.ToString(dr.GetInt32(1));
                    dt.Rows.Add(new String[] { usuario, Quantidade });
                }

                com.Close();
                GridViewRelUsuario.DataSource = dt;
                GridViewRelUsuario.DataBind();
                LabelTotalCodificados.Text = Convert.ToString(total);


            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert(' MSG ERRO do SISTEMA " + erro + "!');", true);

            }
            return dt;
        }
    }
    public override void VerifyRenderingInServerForm(Control control) { }
}