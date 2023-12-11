using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChamadosDAOrel
/// </summary>
public class ChamadosDAOrel
{


    public static int TotalDeChamados(string anoPesquisa)
    {

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            int totalChamados = 0;
            try
            {
                string strQuery = "";

                strQuery = @"select count(*) FROM [chamado_suporte].[dbo].[aberturaChamado]
                             where  statusChamado=2 and DATENAME(YEAR, dataHoraSolucao)='" + anoPesquisa + "'";

                com.Open();

                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                if (dr.Read())
                {
                    totalChamados = dr.GetInt32(0);
                }
                com.Close();

            }
            catch (Exception ex)
            {
                string erro = ex.Message;

            }
            return totalChamados;
        }

    }

    public static List<ListaGridRelatorio> MostraTotalChamadosPorMes(string anoPesquisa)
    {

        var lista = new List<ListaGridRelatorio>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                //modo Antigo que Funciona com o nome do mes sem ser em ordem alfabetica
                //string strQuery = @" select  DATENAME(month, dataHoraSolucao)as mes,count(*) as total  
                //                 FROM [chamado_suporte].[dbo].[aberturaChamado]
                //           where statusChamado=2 group by DATENAME(month, dataHoraSolucao) order by total desc";

                string strQuery = @"  select  MONTH (dataHoraSolucao)as mes,count(*) as total  
                                 FROM [chamado_suporte].[dbo].[aberturaChamado]
                           where statusChamado=2 and DATENAME(YEAR, dataHoraSolucao)='"+anoPesquisa+"' group by MONTH(dataHoraSolucao) ORDER BY mes";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    ListaGridRelatorio l = new ListaGridRelatorio();

                  int m = dr.GetInt32(0);
                    if (m==1)
                    {
                        l.MES = "Janeiro";
                    }
                    else if (m==2)
                    {
                        l.MES = "Fevereiro";
                    }
                    else if (m == 3)
                    {
                        l.MES = "Março";
                    }
                    else if (m == 4)
                    {
                        l.MES = "Abril";
                    }
                    else if (m == 5)
                    {
                        l.MES = "Maio";
                    }
                    else if (m == 6)
                    {
                        l.MES = "Junho";
                    }
                    else if (m == 7)
                    {
                        l.MES = "Julho";
                    }
                    else if (m == 8)
                    {
                        l.MES = "Agosto";
                    }
                    else if (m == 9)
                    {
                        l.MES = "Setembro";
                    }
                    else if (m == 10)
                    {
                        l.MES = "Outubro";
                    }
                    else if (m == 11)
                    {
                        l.MES = "Novembro";
                    }
                    else if (m == 12)
                    {
                        l.MES = "Dezembro";
                    }
                    l.TOTAL = Convert.ToString(dr.GetInt32(1));                 
                   
                    lista.Add(l);
                }
                com.Close();
            }
            catch (Exception ex)
            {

                string erro = ex.Message;
            }
            return lista;
        }
    }

    public static List<ListaGridRelatorio> MostraTotalChamadosPorSetor(string anoPesquisa)
    {

        var lista = new List<ListaGridRelatorio>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"select  setor,count(*) as total  FROM [chamado_suporte].[dbo].[aberturaChamado]
 where statusChamado=2 and DATENAME(YEAR, dataHoraSolucao)='" + anoPesquisa + "' group by setor order by total desc";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    ListaGridRelatorio l = new ListaGridRelatorio();

                    l.SETOR = dr.IsDBNull(0) ? null : dr.GetString(0);
                    l.TOTAL = Convert.ToString(dr.GetInt32(1));

                    lista.Add(l);
                }
                com.Close();
            }
            catch (Exception ex)
            {

                string erro = ex.Message;
            }
            return lista;
        }
    }
    
    public static List<ListaGridRelatorio> MostraTotalChamadosPorTitulo(string anoPesquisa)
    {

        var lista = new List<ListaGridRelatorio>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"select  titulo,count(*) as total  FROM [chamado_suporte].[dbo].[aberturaChamado]
 where statusChamado=2 and DATENAME(YEAR, dataHoraSolucao)='" + anoPesquisa + "' group by titulo order by total desc";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    ListaGridRelatorio l = new ListaGridRelatorio();

                    l.TITULO = dr.IsDBNull(0) ? null : dr.GetString(0);
                    l.TOTAL = Convert.ToString(dr.GetInt32(1));

                    lista.Add(l);
                }
                com.Close();
            }
            catch (Exception ex)
            {

                string erro = ex.Message;
            }
            return lista;
        }
    }

    public static List<ListaGridGeralExcel> RelatorioGeralExcel(string dtAmericanaI, string dtAmericanaF)
    {

        var lista = new List<ListaGridGeralExcel>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                strQuery = @" SELECT [id],[cac],[nomeContato],[setor],[ramal],[titulo],[ocorrencia],[nomeTecnico]
      ,[dataHoraAbertura],[solucao],[dataHoraSolucao],[extratoDoChamado],[numeroSerieOuTag]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where statusChamado=2 and
  CONVERT(DATE, dataHoraSolucao, 103) BETWEEN CONVERT(DATE, '" + dtAmericanaI + "', 103) AND CONVERT(DATE,'" + dtAmericanaF + "', 103)";

                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    ListaGridGeralExcel l = new ListaGridGeralExcel();

                    l.id = dr.GetInt32(0);
                    l.cac= dr.IsDBNull(1) ? null : dr.GetString(1);
                    l.nomeContato = dr.IsDBNull(2) ? null : dr.GetString(2);
                    l.setor = dr.IsDBNull(3) ? null : dr.GetString(3);
                    l.ramal = dr.IsDBNull(4) ? null : dr.GetString(4);
                    l.titulo = dr.IsDBNull(5) ? null : dr.GetString(5);
                    l.ocorrencia = dr.IsDBNull(6) ? null : dr.GetString(6);
                    l.nomeTecnico = dr.IsDBNull(7) ? null : dr.GetString(7);
                    DateTime dt1 =  dr.GetDateTime(8);
                    l.dt_Hr_Ini = dt1.ToString();
                    // l.HoraDtChamado = dr.IsDBNull(8) ? null : dr.GetString(8);
                    l.solucao = dr.IsDBNull(9) ? null : dr.GetString(9);
                    DateTime dt2 = dr.GetDateTime(10);
                    l.dt_Hr_Fim = dt2.ToString();
                    //l.dt_hora = dr.IsDBNull(10) ? null : dr.GetString(10);
                    l.extratoChamado = dr.IsDBNull(11) ? null : dr.GetString(11);
                    l.extratoChamado = l.extratoChamado.Replace("\n", ">>>>");
                    l.tagNserie = dr.IsDBNull(12) ? null : dr.GetString(12);
                    
                  

                    lista.Add(l);
                }
                com.Close();
            }
            catch (Exception ex)
            {

                string erro = ex.Message;
            }
            return lista;
        }
    }
}