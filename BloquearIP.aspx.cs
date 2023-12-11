using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BloquearIP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            mostraIPbloqueados();
        }
    }

    private void mostraIPbloqueados()
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);

                strQuery = @"SELECT [id],[ip] FROM [chamado_suporte].[dbo].[BloquearIP] order by ip";
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("ID IP", System.Type.GetType("System.String"));
                dt.Columns.Add("IP Bloqueado", System.Type.GetType("System.String"));

                while (dr.Read())
                {
                    string ID = dr.GetInt32(0).ToString();
                    string nomeIP = dr.GetString(1);
                    dt.Rows.Add(new String[] { ID, nomeIP });
                }
                com.Close();
                GridViewIPbloqueado.DataSource = dt;
                GridViewIPbloqueado.DataBind();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }

        }
    }

    protected void BtnBloquearIP_Click(object sender, EventArgs e)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[BloquearIP]
           ([ip]
           ,[bloqueado])
     VALUES
           (@ip,@bloqueado)";
                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@bloqueado", SqlDbType.Char).Value = "1";
                commd.Parameters.Add("@ip", SqlDbType.VarChar).Value = txtIP.Text;

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;

            }
            mostraIPbloqueados();
        }
        limpaCampos();
    }

    private void limpaCampos()
    {
        txtIP.Text = "";
        txtIpExcluir.Text = "";
    }

    //[WebMethod]

    //public static string[] getIP(string prefixo)
    //{
    //    List<string> clientes = new List<string>();
    //    using (SqlConnection conn = new SqlConnection())
    //    {
    //        conn.ConnectionString = ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ConnectionString;
    //        using (SqlCommand cmd = new SqlCommand())
    //        {

    //            cmd.CommandText = "SELECT TOP (20) [id],[ip] FROM [chamado_suporte].[dbo].[BloquearIP] where ip LIKE '%' + @Texto +'%' group by ip";
    //            cmd.Parameters.AddWithValue("@Texto", prefixo);
    //            cmd.Connection = conn;
    //            conn.Open();
    //            using (SqlDataReader sdr = cmd.ExecuteReader())
    //            {
    //                while (sdr.Read())
    //                {
    //                    clientes.Add(string.Format("{0}", sdr["setor"]));
    //                }
    //            }
    //            conn.Close();
    //        }
    //    }
    //    return clientes.ToArray();
    //}


    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                int idExcluir = Convert.ToInt32(txtIpExcluir.Text);
                string strQuery = @"DELETE FROM[dbo].[BloquearIP]
    WHERE id= " + idExcluir + " ";
                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;

            }
            mostraIPbloqueados();
        }
        limpaCampos();
    }
}