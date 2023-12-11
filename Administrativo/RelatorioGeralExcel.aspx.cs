using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

        GridViewRelGeralExcel.DataSource = ChamadosDAOrel.RelatorioGeralExcel(dtAmericanaI, dtAmericanaF);
        GridViewRelGeralExcel.DataBind();
        GerarExcel();
    }

    //protected void btnExcel_Click(object sender, EventArgs e)
    //{
    //    GerarExcel();
    //}

    public override void VerifyRenderingInServerForm(Control control) { }
    private void GerarExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        //string attachment = "attachment; filename=contatos.xls";
        string FileName = "RelatorioChamadosPorSetor";// DateTime.Now + ".xls";//arrumar
        string dia = Convert.ToString(DateTime.Now.Day);
        string mes = Convert.ToString(DateTime.Now.Month);
        string ano = Convert.ToString(DateTime.Now.Year);
        string hr = Convert.ToString(DateTime.Now.Hour);
        string min = Convert.ToString(DateTime.Now.Minute);
        string seg = Convert.ToString(DateTime.Now.Second);
        string DtCompleta = dia + "_" + mes + "_" + ano + "_" + hr + "_" + min + "_" + seg;
        // StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.GetEncoding("iso-8859-1"));
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + "_" + DtCompleta + ".xls");
        GridViewRelGeralExcel.GridLines = GridLines.Both;
        GridViewRelGeralExcel.HeaderStyle.Font.Bold = true;
        GridViewRelGeralExcel.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }

    
}