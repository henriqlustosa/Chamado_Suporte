using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChamadosDAO
/// </summary>
public class ChamadosDAO
{
    //Grava o chamado inicial
    public static void GravaChamados(ListaGrid listaChamado)
    {
        try
        {
            DateTime dtatual = DateTime.Now;
            string dtCadastroChamado = dtatual.ToString().Substring(0, 16);
            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
            {
                try
                {
                    string strQuery = @"INSERT INTO [dbo].[aberturaChamado]
           ([cac]
           ,[nomeContato]
           ,[setor]
           ,[ramal]           
           ,[titulo]
           ,[ocorrencia]          
           ,[statusChamado]
           ,[dataHoraAbertura]
           ,[extratoDoChamado])
     VALUES
           (@cac,@nomeContato,@setor,@ramal,@titulo,@ocorrencia,@statusChamado,@dataHoraAbertura,@extratoDoChamado)";
                    SqlCommand commd = new SqlCommand(strQuery, com);
                    commd.Parameters.Add("@cac", SqlDbType.VarChar).Value = "HSPMCAC" + listaChamado.cac;
                    commd.Parameters.Add("@nomeContato", SqlDbType.VarChar).Value = listaChamado.nomeContato;
                    commd.Parameters.Add("@setor", SqlDbType.VarChar).Value = listaChamado.setor;
                    commd.Parameters.Add("@ramal", SqlDbType.VarChar).Value = listaChamado.ramal;
                    commd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = listaChamado.titulo;
                    commd.Parameters.Add("@ocorrencia", SqlDbType.VarChar).Value = listaChamado.ocorrencia;
                    commd.Parameters.Add("@statusChamado", SqlDbType.VarChar).Value = "0";
                    commd.Parameters.Add("@dataHoraAbertura", SqlDbType.DateTime).Value = dtatual;
                    commd.Parameters.Add("@extratoDoChamado", SqlDbType.VarChar).Value = "-> Criado por " + listaChamado.nomeTecnico + " em: " + dtCadastroChamado + " Ocorrência: " + listaChamado.ocorrencia + "\n";

                    commd.CommandText = strQuery;
                    com.Open();
                    commd.ExecuteNonQuery();
                    com.Close();
                }
                catch (Exception ex)
                {
                    string erro = ex.Message;
                    throw;
                }

            }
        }
        catch (Exception)
        {

            throw;
        }


    }
    public static List<ListaGrid> MostraChamadosNaTelaStatus0()
    {

        var lista = new List<ListaGrid>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT * FROM [chamado_suporte].[dbo].[aberturaChamado] where (statusChamado='0' or statusChamado='11' or statusChamado='12') order by statusChamado,id ASC";
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
                    l.ocorrencia = dr.IsDBNull(6) ? null : dr.GetString(6);
                    l.nomeTecnico = dr.IsDBNull(7) ? null : dr.GetString(7);
                    int status = dr.GetInt32(8);
                    l.statusDochamado = status.ToString();
                    if (l.statusDochamado == "11")
                    {
                        l.statusDochamado = "P/ NOTURNO";
                    }
                    else if (l.statusDochamado == "12")
                    {
                        l.statusDochamado = "P/ DIURNO";

                    }
                    else
                    {
                        l.statusDochamado = "AGUARDANDO";
                    }

                    //l.dt_hora = dr.IsDBNull(9) ? null : dr.GetString(9);
                    l.solucao = dr.IsDBNull(10) ? null : dr.GetString(10);
                    l.extratoChamado = dr.IsDBNull(12) ? null : dr.GetString(12);
                    l.tagNserie = dr.IsDBNull(13) ? null : dr.GetString(13);
                    l.IpDeQuemCadastrou = dr.IsDBNull(14) ? null : dr.GetString(14);
                    l.SolucaoPFuncionarioVer = dr.IsDBNull(15) ? null : dr.GetString(15);


                    // l.ocorrencia = dr.IsDBNull(6) ? null : dr.GetString(6);
                    DateTime dtHora = dr.GetDateTime(9);
                    l.dt_hora = Convert.ToString(dtHora).Substring(0, 16);
                    lista.Add(l);
                }
                com.Close();

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
            return lista;

        }


    }

    public static ListaGrid CarregaChamadoParaSerAtendido(int Id)
    {
        ListaGrid l = new ListaGrid();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[ocorrencia],[dataHoraAbertura],[solucao],[extratoDoChamado],[numeroSerieOuTag],[statusChamado]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where id = " + Id + "";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                if (dr.Read())
                {

                    l.id = dr.GetInt32(0);
                    l.cac = dr.IsDBNull(1) ? null : dr.GetString(1);
                    l.nomeContato = dr.IsDBNull(2) ? null : dr.GetString(2);
                    l.setor = dr.IsDBNull(3) ? null : dr.GetString(3);
                    l.ramal = dr.IsDBNull(4) ? null : dr.GetString(4);
                    l.titulo = dr.IsDBNull(5) ? null : dr.GetString(5);
                    l.ocorrencia = dr.IsDBNull(6) ? null : dr.GetString(6);
                    DateTime dtHora = dr.GetDateTime(7);
                    string dtSub = Convert.ToString(dtHora);
                    l.HoraDtChamado = dtSub.Substring(0, 16);

                    // txtSolucao.Text = dr.IsDBNull(8) ? null : dr.GetString(8);
                    l.extratoChamado = dr.IsDBNull(9) ? null : dr.GetString(9);
                    l.tagNserie = dr.IsDBNull(10) ? null : dr.GetString(10);
                    int statusChamado = dr.GetInt32(11);
                    l.statusDochamado = Convert.ToString(statusChamado);
                    //ddlTituloAlterar.SelectedValue = txtTitulo.Text;              
                }

                com.Close();

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
            return l;

        }

    }

    public static void FinalizarChamados(ListaGrid Lchamados)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            DateTime dtatual = DateTime.Now;
            string dtCadastroChamado = dtatual.ToString().Substring(0, 16);
            try
            {
                string strQuery1 = @"SELECT [extratoDoChamado] FROM [chamado_suporte].[dbo].[aberturaChamado] where id = " + Lchamados.id + "";
                com.Open();
                SqlCommand commd1 = new SqlCommand(strQuery1, com);
                SqlDataReader dr1 = commd1.ExecuteReader();
                if (dr1.Read())
                {
                    Lchamados.extratoChamado = dr1.IsDBNull(0) ? null : dr1.GetString(0);
                }
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            try
            {
                string strQuery = @"UPDATE [dbo].[aberturaChamado]
                SET [solucao]=@sulucao,
                   [dataHoraSolucao]=@dthrSolucao,
                [statusChamado]=@statusChamado,
                [nomeTecnico]=@nomeTecnico,
                [extratoDoChamado]=@extratoDoChamado,
                [solucaoPfuncionarioVer]=@solucaoPfuncionarioVer,
                [titulo]=@titulo,
                [cac]=@cac,
                [setor] =@setor,
                [nomeContato] =@nomeContato,
                [ramal] =@ramal
                 where   id=" + Lchamados.id + "";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@sulucao", SqlDbType.NVarChar).Value = (object)Lchamados.solucao ?? DBNull.Value; //Caso a variavel seja nula   
                commd.Parameters.Add("@dthrSolucao", SqlDbType.DateTime).Value = dtatual;
                commd.Parameters.Add("@statusChamado", SqlDbType.Int).Value = 2;
                commd.Parameters.Add("@nomeTecnico", SqlDbType.NVarChar).Value = (object)Lchamados.nomeTecnico ?? DBNull.Value; //Caso a variavel seja nula   
                commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = Lchamados.extratoChamado += "Id Chamado (" + Lchamados.id + ")-> Finalizado por: " + Lchamados.nomeTecnico + " em: " + dtCadastroChamado + " Solução: " + Lchamados.solucao + "\n";
                commd.Parameters.Add("@solucaoPfuncionarioVer", SqlDbType.NVarChar).Value = (object)Lchamados.SolucaoPFuncionarioVer ?? DBNull.Value; //Caso a variavel seja nula   
                commd.Parameters.Add("@titulo", SqlDbType.NVarChar).Value = (object)Lchamados.tituloAlterar ?? DBNull.Value; //Caso a variavel seja nula   
                commd.Parameters.Add("@cac", SqlDbType.NVarChar).Value = (object)Lchamados.cac ?? DBNull.Value; //Caso a variavel seja nula   
                commd.Parameters.Add("@setor", SqlDbType.NVarChar).Value = (object)Lchamados.setor ?? DBNull.Value; //Caso a variavel seja nula   
                commd.Parameters.Add("@nomeContato", SqlDbType.NVarChar).Value = (object)Lchamados.nomeContato ?? DBNull.Value; //Caso a variavel seja nula   
                commd.Parameters.Add("@ramal", SqlDbType.NVarChar).Value = (object)Lchamados.ramal ?? DBNull.Value; //Caso a variavel seja nula   

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception Ex)
            {

                string erro = Ex.Message;
            }

        }



    }

    public static void ChamarUpdateEmAtendimentoChamado(ListaGrid Lchamados)
    {
        DateTime dtatual = DateTime.Now;
        string dtCadastroChamado = dtatual.ToString().Substring(0, 16);
        int StatusIntChamado = Convert.ToInt32(Lchamados.statusDochamado);
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))

        {
            try
            {
                string strQuery1 = @"SELECT [extratoDoChamado] FROM [chamado_suporte].[dbo].[aberturaChamado] where id = " + Lchamados.id + "";
                com.Open();
                SqlCommand commd1 = new SqlCommand(strQuery1, com);
                SqlDataReader dr1 = commd1.ExecuteReader();
                if (dr1.Read())
                {
                    Lchamados.extratoChamado = dr1.IsDBNull(0) ? null : dr1.GetString(0);
                }
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            try
            {
                string strQuery = @"UPDATE [dbo].[aberturaChamado]
                   SET 
                [statusChamado]=@statusChamado,
                [solucao]=@solucao,
                [nomeTecnico]=@nomeTecnico,
                [extratoDoChamado]=@extratoDoChamado,
                [numeroSerieOuTag]=@numeroSerieOuTag,
                [cac]=@cac
                    where   id=" + Lchamados.id + "";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@statusChamado", SqlDbType.Int).Value = StatusIntChamado; // status em espera
                commd.Parameters.Add("@solucao", SqlDbType.NVarChar).Value = (object)Lchamados.solucao ?? DBNull.Value; //Caso a variavel seja nula 
                commd.Parameters.Add("@nomeTecnico", SqlDbType.NVarChar).Value = (object)Lchamados.nomeTecnico ?? DBNull.Value; //Caso a variavel seja nula  

                if (Lchamados.tagNserie.Length > 2)
                {
                    commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = Lchamados.extratoChamado += "Id Chamado (" + Lchamados.id + ")-> Colocado em espera por: " + Lchamados.nomeTecnico + " em: " + dtCadastroChamado + "Tag ou N-serie (" + Lchamados.tagNserie + ") Solução: " + Lchamados.solucao + "\n";
                }
                else
                {
                    commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = Lchamados.extratoChamado += "Id Chamado (" + Lchamados.id + ")-> Colocado em espera por: " + Lchamados.nomeTecnico + " em: " + dtCadastroChamado + " Solução: " + Lchamados.solucao + "\n";
                }
                commd.Parameters.Add("@numeroSerieOuTag", SqlDbType.NVarChar).Value = (object)Lchamados.tagNserie ?? DBNull.Value; //Caso a variavel seja nula 
                commd.Parameters.Add("@cac", SqlDbType.NVarChar).Value = (object)Lchamados.cac ?? DBNull.Value; //Caso a variavel seja nula   

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }

        }

    }

    public static void EncaminharChamadoTelaAtendimento(ListaGrid Lchamados)

    {
        DateTime dtatual = DateTime.Now;
        string dtCadastroChamado = dtatual.ToString().Substring(0, 16);
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery1 = @"SELECT [extratoDoChamado] FROM [chamado_suporte].[dbo].[aberturaChamado] where id = " + Lchamados.id + "";
                com.Open();
                SqlCommand commd1 = new SqlCommand(strQuery1, com);
                SqlDataReader dr1 = commd1.ExecuteReader();
                if (dr1.Read())
                {
                    Lchamados.extratoChamado = dr1.IsDBNull(0) ? null : dr1.GetString(0);
                }
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }

            try
            {
                string strQuery = @"UPDATE [dbo].[aberturaChamado]
                                           SET 
                                        [statusChamado]=@statusChamado,
                                        [solucao]=@solucao,
                                        [nomeTecnico]=@nomeTecnico,
                                        [extratoDoChamado]=@extratoDoChamado,
                                        [cac]=@cac
                                            where   id=" + Lchamados.id + "";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@statusChamado", SqlDbType.Int).Value = 1; // status em espera
                commd.Parameters.Add("@solucao", SqlDbType.NVarChar).Value = (object)Lchamados.solucao ?? DBNull.Value; //Caso a variavel seja nula 
                commd.Parameters.Add("@nomeTecnico", SqlDbType.NVarChar).Value = (object)Lchamados.nomeTecnicoRecebeChamado ?? DBNull.Value; //Caso a variavel seja nula   
                commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = Lchamados.extratoChamado += "Id Chamado (" + Lchamados.id + ")-> Encaminhado por: " + Lchamados.nomeTecnico + " em: " + dtCadastroChamado + " Solução: " + Lchamados.solucao + "\n";
                commd.Parameters.Add("@cac", SqlDbType.NVarChar).Value = (object)Lchamados.cac ?? DBNull.Value; //Caso a variavel seja nula   

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();

            }
            catch (Exception ex)
            {

                string erro = ex.Message;
            }

        }


    }

    public static void AtualizarTituloDoChamado(ListaGrid Lchamados)

    {
        DateTime dtatual = DateTime.Now;
        string dtCadastroChamado = dtatual.ToString().Substring(0, 16);
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))

        {
            try
            {
                string strQuery1 = @"SELECT [extratoDoChamado] FROM [chamado_suporte].[dbo].[aberturaChamado] where id = " + Lchamados.id + "";
                com.Open();
                SqlCommand commd1 = new SqlCommand(strQuery1, com);
                SqlDataReader dr1 = commd1.ExecuteReader();
                if (dr1.Read())
                {
                    Lchamados.extratoChamado = dr1.IsDBNull(0) ? null : dr1.GetString(0);
                }
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }

            try
            {
                string strQuery = @"UPDATE [dbo].[aberturaChamado]
                                   SET 
                                [statusChamado]=@statusChamado,
                                [nomeTecnico]=@nomeTecnico,
                                [extratoDoChamado]=@extratoDoChamado,
                                [titulo]=@titulo,
                                [cac]=@cac
                                 where   id=" + Lchamados.id + "";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@statusChamado", SqlDbType.Int).Value = 0;
                commd.Parameters.Add("@nomeTecnico", SqlDbType.NVarChar).Value = (object)Lchamados.nomeTecnico ?? DBNull.Value; //Caso a variavel seja nula   
                commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = Lchamados.extratoChamado += "Id Chamado (" + Lchamados.id + ")-> Reclassificado por: " + Lchamados.nomeTecnico + " em: " + dtCadastroChamado + " Solução: " + Lchamados.solucao + "\n";
                commd.Parameters.Add("@titulo", SqlDbType.NVarChar).Value = (object)Lchamados.tituloAlterar ?? DBNull.Value; //Caso a variavel seja nula   
                commd.Parameters.Add("@cac", SqlDbType.NVarChar).Value = (object)Lchamados.cac ?? DBNull.Value; //Caso a variavel seja nula   


                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }


        }


    }

    public static string CarregaQtoChamadosEuTenho(string NomeDoTecnico)

    {
        string TotalDeChamadosIndividual = "";
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT count(*)
  FROM [chamado_suporte].[dbo].[aberturaChamado] 
  where nomeTecnico='" + NomeDoTecnico + "' and (statusChamado!=0 and statusChamado!=2)";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    TotalDeChamadosIndividual = dr.GetInt32(0).ToString();
                }

                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            return TotalDeChamadosIndividual;
        }

    }

   

    public static void AtualizaStatusChamado(ListaGrid Lchamados)
    {
        DateTime dtatual = DateTime.Now;
        string dtCadastroChamado = dtatual.ToString().Substring(0, 16);
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {

            try
            {
                string strQuery1 = @"SELECT [extratoDoChamado] FROM [chamado_suporte].[dbo].[aberturaChamado] where id = " + Lchamados.id + "";
                com.Open();
                SqlCommand commd1 = new SqlCommand(strQuery1, com);
                SqlDataReader dr1 = commd1.ExecuteReader();
                if (dr1.Read())
                {
                    Lchamados.extratoChamado = dr1.IsDBNull(0) ? null : dr1.GetString(0);
                }
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }


            try
            {
                string strQuery = @"UPDATE [dbo].[aberturaChamado]
                   SET 
                [statusChamado]=@statusChamado,
                [extratoDoChamado]=@extratoDoChamado,
                [nomeTecnico]=@nomeTecnico
                    where   id=" + Lchamados.id + "";

                SqlCommand commd = new SqlCommand(strQuery, com);
                //Atendido/puxado por:
                commd.Parameters.Add("@statusChamado", SqlDbType.Int).Value = Convert.ToInt32(Lchamados.statusDochamado);
                if (Lchamados.extratoChamado.Length > 4)
                {
                    commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = Lchamados.extratoChamado += "Id Chamado (" + Lchamados.id + ")-> " + Lchamados.ChamadoAtendidoPuxadoReaberto + " " + Lchamados.nomeTecnico + " em: " + dtCadastroChamado + "\n";

                }
                commd.Parameters.Add("@nomeTecnico", SqlDbType.NVarChar).Value = Lchamados.nomeTecnico;

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();


            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }

        }
    }

    public static List<ListaGrid> MostraChamadosEmEsperaGeral()
    {
        var lista = new List<ListaGrid>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[solucao],[nomeTecnico],[statusChamado],[extratoDoChamado]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where (statusChamado != 0 and statusChamado != 2) order by nomeTecnico ASC";
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
                    // l.ocorrencia = dr.IsDBNull(6) ? null : dr.GetString(6);
                    DateTime dtHora = dr.GetDateTime(6);
                    l.dt_hora = Convert.ToString(dtHora).Substring(0, 16);
                    l.solucao = dr.IsDBNull(7) ? null : dr.GetString(7);
                    l.nomeTecnico = dr.IsDBNull(8) ? null : dr.GetString(8);
                    int nStatus = dr.GetInt32(9);

                    if (nStatus == 5)
                    {
                        l.statusDochamado = "No Local";
                    }
                    else if (nStatus == 6)
                    {
                        l.statusDochamado = "Chamado DELL";
                    }
                    else if (nStatus == 7)
                    {
                        l.statusDochamado = "Chamado IMPR";
                    }
                    else
                    {
                        l.statusDochamado = "Outros";

                    }
                    l.extratoChamado = dr.IsDBNull(10) ? null : dr.GetString(10);
                    // LabelExtratoChamado.Text = l.extratoChamado;

                    lista.Add(l);
                }
                com.Close();

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
            return lista;
        }
    }


    public static List<ListaGrid> MostraChamadosEmEsperaDoTecnicoLogado(string NomeDoTecnico)
    {
        var lista = new List<ListaGrid>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[solucao],[nomeTecnico],[statusChamado],[extratoDoChamado]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where nomeTecnico ='" + NomeDoTecnico + "' and (statusChamado != 0 and statusChamado != 2) order by id ASC";
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
                    // l.ocorrencia = dr.IsDBNull(6) ? null : dr.GetString(6);
                    DateTime dtHora = dr.GetDateTime(6);
                    l.dt_hora = Convert.ToString(dtHora).Substring(0, 16);
                    l.solucao = dr.IsDBNull(7) ? null : dr.GetString(7);
                    l.nomeTecnico = dr.IsDBNull(8) ? null : dr.GetString(8);
                    int nStatus = dr.GetInt32(9);

                    if (nStatus == 5)
                    {
                        l.statusDochamado = "No Local";
                    }
                    else if (nStatus == 6)
                    {
                        l.statusDochamado = "Chamado DELL";
                    }
                    else if (nStatus == 7)
                    {
                        l.statusDochamado = "Chamado IMPR";
                    }
                    else
                    {
                        l.statusDochamado = "Outros";

                    }
                    l.extratoChamado = dr.IsDBNull(10) ? null : dr.GetString(10);
                    // LabelExtratoChamado.Text = l.extratoChamado; 

                    lista.Add(l);
                }
                com.Close();

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
            return lista;
        }
    }

    public static List<ListaGrid> MostraChamadosFinalizadosDoTecnicoLogado(string NomeDotecnico)
    {
        var lista = new List<ListaGrid>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[solucao]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where nomeTecnico = '" + NomeDotecnico + "' and statusChamado = 2 order by id DESC";
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
                    // l.ocorrencia = dr.IsDBNull(6) ? null : dr.GetString(6);
                    DateTime dtHora = dr.GetDateTime(6);
                    l.dt_hora = Convert.ToString(dtHora).Substring(0, 16);
                    l.solucao = dr.IsDBNull(7) ? null : dr.GetString(7);

                    lista.Add(l);
                    // LabelExtratoChamado.Text = l.extratoChamado;
                }
                com.Close();

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
            return lista;



        }


    }

    public static List<ListaGrid> MostraChamadosNaTelaChamadosExternos()
    {
        var lista = new List<ListaGrid>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[solucao],[nomeTecnico],[statusChamado],[numeroSerieOuTag],[extratoDoChamado] 
  FROM [chamado_suporte].[dbo].[aberturaChamado] where (statusChamado = 6 or statusChamado = 7) order by id ASC";
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
                    // l.ocorrencia = dr.IsDBNull(6) ? null : dr.GetString(6);
                    DateTime dtHora = dr.GetDateTime(6);
                    l.dt_hora = Convert.ToString(dtHora).Substring(0, 16);
                    l.solucao = dr.IsDBNull(7) ? null : dr.GetString(7);
                    l.nomeTecnico = dr.IsDBNull(8) ? null : dr.GetString(8);
                    int nStatus = dr.GetInt32(9);

                    if (nStatus == 5)
                    {
                        l.statusDochamado = "No Local";
                    }
                    else if (nStatus == 6)
                    {
                        l.statusDochamado = "Chamado DELL";
                    }
                    else if (nStatus == 7)
                    {
                        l.statusDochamado = "Chamado IMPR";
                    }
                    else
                    {
                        l.statusDochamado = "Outros";

                    }
                    l.tagNserie = dr.IsDBNull(10) ? null : dr.GetString(10);
                    l.extratoChamado = dr.IsDBNull(11) ? null : dr.GetString(11);
                    // LabelExtratoChamado.Text = l.extratoChamado;

                    lista.Add(l);
                }
                com.Close();

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
            return lista;

        }


    }

    public static List<ListaGrid> MostraChamadosNaTelaChamadosManutencaoLocal()
    {
        var lista = new List<ListaGrid>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[solucao],[nomeTecnico],[statusChamado],[extratoDoChamado] 
  FROM [chamado_suporte].[dbo].[aberturaChamado] where statusChamado = 8 order by id ASC";
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
                    // l.ocorrencia = dr.IsDBNull(6) ? null : dr.GetString(6);
                    DateTime dtHora = dr.GetDateTime(6);
                    l.dt_hora = Convert.ToString(dtHora).Substring(0, 16);
                    l.solucao = dr.IsDBNull(7) ? null : dr.GetString(7);
                    l.nomeTecnico = dr.IsDBNull(8) ? null : dr.GetString(8);
                    int nStatus = dr.GetInt32(9);
                    if (nStatus == 8)
                    {
                        l.statusDochamado = "Manutenção Local";
                    }
                    l.extratoChamado = dr.IsDBNull(10) ? null : dr.GetString(10);
                    // LabelExtratoChamado.Text = l.extratoChamado;

                    lista.Add(l);
                }
                com.Close();

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
            return lista;

        }


    }


    //Seleciona imagem

    public static string MostraImagem(int idImagem, string tipo)
    {
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            string img = "";
            try
            {
                con.Open();
                string query = "SELECT [img_chamado] FROM[chamado_suporte].[dbo].[ImgChamado] where id_chamado = " + idImagem + " and descricao='" + tipo + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idImagem);

                byte[] imagemBytes = (byte[])cmd.ExecuteScalar();

                if (imagemBytes != null && imagemBytes.Length > 0)
                {
                    // Converta os bytes da imagem em uma URL de dados para exibição na imagem
                    string base64String = Convert.ToBase64String(imagemBytes);
                    img = "data:image/jpeg;base64," + base64String; //imgChamado.ImageUrl
                }
                //else
                //{
                //    // Caso não haja imagem no banco de dados, você pode definir uma imagem padrão ou fazer algo apropriado aqui
                //    imgChamado.ImageUrl = "imagem_padrao.jpg"; // Substitua pelo caminho da imagem padrão desejada
                //}
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                // Trate os erros adequadamente
            }
            //if (tipo == "Abertura" && img != "")
            //{
            //    LabelImagemTituloAbertura.Visible = true;
            //}
            //else if (tipo == "Fechamento" && img != "")
            //{
            //    LabelImagemTituloFechamanto.Visible = true;
            //}
            return img;
        }
    }

    public static bool verificaTituloExiste(string titulo)

    {

        bool valido;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            string strquerySelect;
            strquerySelect = @"SELECT [NomeTipoChamado] FROM [chamado_suporte].[dbo].[TipoChamado]
  where NomeTipoChamado='" + titulo + "'";
            SqlCommand commd = new SqlCommand(strquerySelect, com);
            com.Open();
            SqlDataReader dr = commd.ExecuteReader();
            valido = dr.Read();
            com.Close();
        }
        return valido;
    }

}