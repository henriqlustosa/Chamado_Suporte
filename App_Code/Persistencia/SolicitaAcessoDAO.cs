using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SolicitaAcessoDAO
/// </summary>
/// 
public class SolicitaAcessoDAO
{
    public static int pegaID_BancoDeDados(DateTime dt, int rf)
    {
        // string a = DateTime.Now.ToString();
        //// string xx = String.Join("", System.Text.RegularExpressions.Regex.Split(a, @"[^\d]"));
        // Int64 idChamadoDtHrs = Convert.ToInt64(String.Join("", System.Text.RegularExpressions.Regex.Split(a, @"[^\d]")));
        int idChamadoDtHrs = 0;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                SqlCommand comm = com.CreateCommand();
                //string strQuery = @"select MAX(id_chamado) FROM [SolicitaAcesso].[dbo].[Solicitante_Dados]";
                string strQuery = @"select id_chamado   FROM [SolicitaAcesso].[dbo].[Solicitante_Dados]
	where CONVERT(date,dataSolicitacao,103) ='" + dt + "' and rf =" + rf + "";
                comm.CommandText = strQuery;
                com.Open();
                SqlDataReader dr1 = comm.ExecuteReader();
                while (dr1.Read())
                {
                    idChamadoDtHrs = dr1.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            return idChamadoDtHrs;
        }

    }

    public static void GravaDadosCoordenador(DadosCoordenador Dados)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[Coordenador_Dados]
           ([nome_Coordenador]
           ,[rf_Coordenador]
           ,[login_Coordenador]
           ,[e_mail_Coordenador]
           ,[ramal_Coordenador]
           ,[ramal_2_Coordenador]
           ,[setor_Coordenador])"
     + " VALUES (@nome_Coordenador,@rf_Coordenador,@login_Coordenador,@e_mail_Coordenador,@ramal_Coordenador,@ramal_2_Coordenador,@setor_Coordenador)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@nome_Coordenador", SqlDbType.VarChar).Value = Dados.NomeCoordenador;
                commd.Parameters.Add("@rf_Coordenador", SqlDbType.Int).Value = Dados.RF_Coordenador;
                commd.Parameters.Add("@login_Coordenador", SqlDbType.VarChar).Value = Dados.loginCoordenador;
                commd.Parameters.Add("@e_mail_Coordenador", SqlDbType.VarChar).Value = Dados.eMail;
                commd.Parameters.Add("@ramal_Coordenador", SqlDbType.VarChar).Value = Dados.ramal1;
                commd.Parameters.Add("@ramal_2_Coordenador", SqlDbType.VarChar).Value = Dados.ramal2;
                commd.Parameters.Add("@setor_Coordenador", SqlDbType.VarChar).Value = Dados.setorCoordenador;
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

    public static List<DadosCoordenador> GetListaCoordenadoresCadastrados()
    {
        var lista = new List<DadosCoordenador>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();

            string sqlConsulta = @"SELECT * FROM [SolicitaAcesso].[dbo].[Coordenador_Dados] order by nome_Coordenador";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    DadosCoordenador d = new DadosCoordenador();
                    d.id = dr1.GetInt32(0);
                    d.NomeCoordenador = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.RF_Coordenador = dr1.GetInt32(2);
                    d.loginCoordenador = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.eMail = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.ramal1 = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    d.ramal2 = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    d.setorCoordenador = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    lista.Add(d);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return lista;
        }
    }

    public static void ExcluiCadastroCoordenador(int id)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            string strquerySelect;
            strquerySelect = @"DELETE FROM [dbo].[Coordenador_Dados] WHERE id=" + id + "";
            SqlCommand commd = new SqlCommand(strquerySelect, com);
            com.Open();
            SqlDataReader dr = commd.ExecuteReader();
            com.Close();
        }
    }

    public static DadosCoordenador GetDadosDosCoordenadoresPaginaSolicita(string login)
    {
        DadosCoordenador d = new DadosCoordenador();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();

            string sqlConsulta = @"SELECT [id],[nome_Coordenador],[ramal_Coordenador],[ramal_2_Coordenador],[setor_Coordenador],[e_mail_Coordenador] 
     FROM [SolicitaAcesso].[dbo].[Coordenador_Dados] where login_Coordenador='" + login + "'";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.id = dr1.GetInt32(0);
                    d.NomeCoordenador = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.ramal1 = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.ramal2 = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.setorCoordenador = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.eMail = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    //public static bool GravaDadosSolicitacao(DadosSolicitacao Dados)
    //{
    //    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
    //    {
    //        bool existeSolicitacao = GetSolicitacao(Dados.RF_Funcionario);
    //        Dados.msg_JaTemSolicitacaoAberta = existeSolicitacao;

    //        if (existeSolicitacao == false)
    //        {
    //            try
    //            {
    //                string strQuery = @"INSERT INTO [dbo].[Solicitante_Dados]
    //       ([nome_funcionario]
    //       ,[rf]
    //       ,[login]
    //       ,[cargo]
    //       ,[ramal]
    //       ,[lotacao]
    //       ,[dataSolicitacao]
    //       ,[solicitante]           
    //       ,[ativa_Solicitacao]
    //       ,[email_coordenador])"
    //     + " VALUES (@nome_funcionario,@rf,@login,@cargo,@ramal,@lotacao,@dataSolicitacao,@solicitante,@ativa_Solicitacao,@email_coordenador)";

    //                SqlCommand commd = new SqlCommand(strQuery, com);
    //                commd.Parameters.Add("@nome_funcionario", SqlDbType.VarChar).Value = Dados.NomeFuncionario;
    //                commd.Parameters.Add("@rf", SqlDbType.Int).Value = Dados.RF_Funcionario;
    //                commd.Parameters.Add("@login", SqlDbType.VarChar).Value = Dados.login;
    //                commd.Parameters.Add("@cargo", SqlDbType.VarChar).Value = Dados.cargoFuncionario;
    //                commd.Parameters.Add("@ramal", SqlDbType.VarChar).Value = Dados.ramal1;
    //                commd.Parameters.Add("@lotacao", SqlDbType.VarChar).Value = Dados.lotacao;
    //                commd.Parameters.Add("@dataSolicitacao", SqlDbType.DateTime).Value = Dados.dtSolicitacao;
    //                commd.Parameters.Add("@solicitante", SqlDbType.VarChar).Value = Dados.NomeSolicitante_Coordenador;
    //                commd.Parameters.Add("@ativa_Solicitacao", SqlDbType.VarChar).Value = "S";
    //                commd.Parameters.Add("@email_coordenador", SqlDbType.VarChar).Value = Dados.eMail = Dados.eMail;

    //                commd.CommandText = strQuery;
    //                com.Open();
    //                commd.ExecuteNonQuery();
    //                com.Close();
    //            }
    //            catch (Exception ex)
    //            {
    //                string erro = ex.Message;
    //            }
    //            return Dados.msg_JaTemSolicitacaoAberta;
    //        }
    //        else
    //        {
    //            return Dados.msg_JaTemSolicitacaoAberta;
    //        }
    //    }
    //}

    private static bool GetSolicitacao(int rF_Funcionario)
    {
        bool valido;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            string strquerySelect;
            strquerySelect = @"SELECT * FROM [SolicitaAcesso].[dbo].[Solicitante_Dados]
  where rf=" + rF_Funcionario + " and ativa_Solicitacao ='S'";

            SqlCommand commd = new SqlCommand(strquerySelect, com);
            com.Open();
            SqlDataReader dr = commd.ExecuteReader();

            valido = dr.Read();
            com.Close();
        }

        return valido;
    }

    //public static void GravaDadosRedeCorporativa(DadosRedeCoorporativa Dados)
    //{
    //    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
    //    {
    //        try
    //        {
    //            string strQuery = @"INSERT INTO [dbo].[RedeCorporativa]
    //       ([id_chamado_rede_corporativa]
    //       ,[redeCorperativa]
    //       ,[emailCorporativo]
    //       ,[caixaDepartamental]
    //       ,[pastaRede]
    //       ,[pastaEspecifica]
    //       ,[status_RedeCorporativa])"
    // + " VALUES (@id_chamado_rede_corporativa,@redeCorperativa,@emailCorporativo,@caixaDepartamental,@pastaRede,@pastaEspecifica,@status_RedeCorporativa)";

    //            SqlCommand commd = new SqlCommand(strQuery, com);
    //            commd.Parameters.Add("@id_chamado_rede_corporativa", SqlDbType.Int).Value = Dados.id_chamado_rede_corporativa;
    //            commd.Parameters.Add("@redeCorperativa", SqlDbType.VarChar).Value = Dados.redeCorporativa;
    //            commd.Parameters.Add("@emailCorporativo", SqlDbType.VarChar).Value = Dados.emailCorporativo;
    //            commd.Parameters.Add("@caixaDepartamental", SqlDbType.VarChar).Value = Dados.caixaDepartamental;
    //            commd.Parameters.Add("@pastaRede", SqlDbType.VarChar).Value = Dados.pastaDeRede;
    //            commd.Parameters.Add("@pastaEspecifica", SqlDbType.VarChar).Value = Dados.PastaEspecifica;
    //            commd.Parameters.Add("@status_RedeCorporativa", SqlDbType.VarChar).Value = Dados.status_redeCoorporativa;
    //            commd.CommandText = strQuery;
    //            com.Open();
    //            commd.ExecuteNonQuery();
    //            com.Close();


    //            //             string strQuery2 = @"UPDATE [dbo].[Setores_Solicitados]
    //            //SET [RedeCorporativa]='S' WHERE Id_Solicitacoes_setores=" + Dados.id_chamado_rede_corporativa + "";

    //            //             SqlCommand commd2 = new SqlCommand(strQuery2, com);
    //            //             commd2.CommandText = strQuery2;
    //            //             com.Open();
    //            //             commd2.ExecuteNonQuery();
    //            //             com.Close();

    //        }

    //        catch (Exception ex)
    //        {
    //            string erro = ex.Message;
    //        }
    //    }
    //}

    //public static void GravaDadosSGH(DadosSGH Dados)
    //{
    //    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
    //    {
    //        try
    //        {
    //            string strQuery = @"INSERT INTO [dbo].[Sgh]
    //       ([id_chamado_sgh]
    //       ,[Amb]
    //       ,[Amb_Desc]
    //       ,[CenCir]
    //       ,[CenCir_Desc]
    //       ,[Internacao]
    //       ,[Internacao_Desc]
    //       ,[Ps]
    //       ,[Ps_Desc]
    //       ,[status_Sgh])"
    // + " VALUES (@id_chamado_sgh,@Amb,@Amb_Desc,@CenCir,@CenCir_Desc,@Internacao,@Internacao_Desc,@Ps,@Ps_Desc,@status_Sgh)";

    //            SqlCommand commd = new SqlCommand(strQuery, com);
    //            commd.Parameters.Add("@id_chamado_sgh", SqlDbType.Int).Value = Dados.id_chamado_SGH;
    //            commd.Parameters.Add("@Amb", SqlDbType.VarChar).Value = Dados.Amb;
    //            commd.Parameters.Add("@Amb_Desc", SqlDbType.VarChar).Value = Dados.Amb_Desc;
    //            commd.Parameters.Add("@CenCir", SqlDbType.VarChar).Value = Dados.CenCir;
    //            commd.Parameters.Add("@CenCir_Desc", SqlDbType.VarChar).Value = Dados.CenCir_Desc;
    //            commd.Parameters.Add("@Internacao", SqlDbType.VarChar).Value = Dados.Internacao;
    //            commd.Parameters.Add("@Internacao_Desc", SqlDbType.VarChar).Value = Dados.Internacao_Desc;
    //            commd.Parameters.Add("@Ps", SqlDbType.VarChar).Value = Dados.PS;
    //            commd.Parameters.Add("@Ps_Desc", SqlDbType.VarChar).Value = Dados.PS_Desc;
    //            commd.Parameters.Add("@status_Sgh", SqlDbType.VarChar).Value = Dados.status_SGH;
    //            commd.CommandText = strQuery;
    //            com.Open();
    //            commd.ExecuteNonQuery();
    //            com.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            string erro = ex.Message;
    //        }
    //    }
    //}

    //public static void GravaDadosSImproc(DadosSimproc Dados)
    //{
    //    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
    //    {
    //        try
    //        {
    //            string strQuery = @"INSERT INTO [dbo].[Simproc]
    //       ([id_chamdo_simproc]
    //       ,[cod_Unidade]
    //       ,[cpf_simproc]
    //       ,[rg_simproc]
    //       ,[dataAdmissao]
    //       ,[status_Simproc])"
    // + " VALUES (@id_chamdo_simproc,@cod_Unidade,@cpf_simproc,@rg_simproc,@dataAdmissao,@status_Simproc)";

    //            SqlCommand commd = new SqlCommand(strQuery, com);
    //            commd.Parameters.Add("@id_chamdo_simproc", SqlDbType.Int).Value = Dados.id_chamado_Simproc;
    //            commd.Parameters.Add("@cod_Unidade", SqlDbType.VarChar).Value = Dados.CodigoUnidade_Simproc;
    //            commd.Parameters.Add("@cpf_simproc", SqlDbType.VarChar).Value = Dados.cpf_simproc;
    //            commd.Parameters.Add("@rg_simproc", SqlDbType.VarChar).Value = Dados.rg_simproc;
    //            commd.Parameters.Add("@dataAdmissao", SqlDbType.VarChar).Value = Dados.dataAdmissao;
    //            commd.Parameters.Add("@status_Simproc", SqlDbType.VarChar).Value = Dados.status_Simproc;

    //            commd.CommandText = strQuery;
    //            com.Open();
    //            commd.ExecuteNonQuery();
    //            com.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            string erro = ex.Message;
    //        }
    //    }
    //}

    //public static void GravaDadosGrafica(DadosGrafica Dados)
    //{
    //    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
    //    {
    //        try
    //        {
    //            string strQuery = @"INSERT INTO [dbo].[Grafica]
    //       ([id_chamado_grafica]           
    //       ,[setor_solicitado_Grafica]
    //       ,[N_centro_custo_grafica]
    //       ,[cpf_grafica]
    //       ,[cota_grafica]
    //       ,[status_grafica])    
    //         VALUES (@id_chamado_grafica,@setor_solicitado_Grafica,@N_centro_custo_grafica,@cpf_grafica,@cota_grafica,@status_grafica)";

    //            SqlCommand commd = new SqlCommand(strQuery, com);
    //            commd.Parameters.Add("@id_chamado_grafica", SqlDbType.Int).Value = Dados.id_chamado_grafica;
    //            commd.Parameters.Add("@setor_solicitado_Grafica", SqlDbType.VarChar).Value = Dados.setor_solicitado_Grafica;
    //            commd.Parameters.Add("@N_centro_custo_grafica", SqlDbType.VarChar).Value = Dados.N_centro_custo_grafica;
    //            commd.Parameters.Add("@cpf_grafica", SqlDbType.VarChar).Value = Dados.cpf_grafica;
    //            commd.Parameters.Add("@cota_grafica", SqlDbType.VarChar).Value = Dados.cota_grafica;
    //            commd.Parameters.Add("@status_grafica", SqlDbType.VarChar).Value = Dados.status_grafica;

    //            commd.CommandText = strQuery;
    //            com.Open();
    //            commd.ExecuteNonQuery();
    //            com.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            string erro = ex.Message;
    //        }
    //    }
    //}

    //public static void GravaDadosOSmanutencao(DadosOsManutencao Dados)
    //{
    //    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
    //    {
    //        try
    //        {
    //            string strQuery = @"INSERT INTO [dbo].[OsManutencao]
    //       ([id_chamado_manutencao]       
    //       ,[N_centro_custos]
    //       ,[cpf_manutencao]
    //       ,[status_os_manutencao])
    //       VALUES (@id_chamado_manutencao,@N_centro_custos,@cpf_manutencao,@status_os_manutencao)";

    //            SqlCommand commd = new SqlCommand(strQuery, com);
    //            commd.Parameters.Add("@id_chamado_manutencao", SqlDbType.Int).Value = Dados.id_chamado_OSmanutencao;
    //            commd.Parameters.Add("@N_centro_custos", SqlDbType.VarChar).Value = Dados.N_centro_custos;
    //            commd.Parameters.Add("@cpf_manutencao", SqlDbType.VarChar).Value = Dados.cpf_manutencao;
    //            commd.Parameters.Add("@status_os_manutencao", SqlDbType.VarChar).Value = Dados.status_os_manutencao;

    //            commd.CommandText = strQuery;
    //            com.Open();
    //            commd.ExecuteNonQuery();
    //            com.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            string erro = ex.Message;
    //        }
    //    }
    //}

    //public static void GravaDadosSei(DadosSei Dados)
    //{
    //    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
    //    {
    //        try
    //        {
    //            string strQuery = @"INSERT INTO [dbo].[Sei]
    //       ([id_chamado_Sei]
    //       ,[siglasUnidades1]
    //       ,[siglasUnidades2]
    //       ,[siglasUnidades3]
    //       ,[siglasUnidades4]
    //       ,[status_Sei])
    //       VALUES (@id_chamado_Sei,@siglasUnidades1,@siglasUnidades2,@siglasUnidades3,@siglasUnidades4,@status_Sei)";

    //            SqlCommand commd = new SqlCommand(strQuery, com);
    //            commd.Parameters.Add("@id_chamado_Sei", SqlDbType.Int).Value = Dados.id_chamado_Sei;
    //            commd.Parameters.Add("@siglasUnidades1", SqlDbType.VarChar).Value = Dados.siglasUnidades1;
    //            commd.Parameters.Add("@siglasUnidades2", SqlDbType.VarChar).Value = Dados.siglasUnidades2;
    //            commd.Parameters.Add("@siglasUnidades3", SqlDbType.VarChar).Value = Dados.siglasUnidades3;
    //            commd.Parameters.Add("@siglasUnidades4", SqlDbType.VarChar).Value = Dados.siglasUnidades4;
    //            commd.Parameters.Add("@status_Sei", SqlDbType.VarChar).Value = Dados.status_Sei;


    //            commd.CommandText = strQuery;
    //            com.Open();
    //            commd.ExecuteNonQuery();
    //            com.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            string erro = ex.Message;
    //        }
    //    }
    //}

    public static void GravaSolicitacoes_setores(int Id_chamado)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[Setores_Solicitados]
           ([Id_Solicitacoes_setores]) VALUES (@Id_Solicitacoes_setores)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@Id_Solicitacoes_setores", SqlDbType.Int).Value = Id_chamado;
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

    public static void GravaSolicitacoes_setores_Update(int Id_chamado, string nomeCampo)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"UPDATE [dbo].[Setores_Solicitados]
   SET [" + nomeCampo + "]='S' WHERE Id_Solicitacoes_setores=" + Id_chamado + "";

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
        }
    }

    public static List<DadosSolicitacoesSetores> MostraSolicitacoesNaTelaStatus()
    {

        var lista = new List<DadosSolicitacoesSetores>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            try
            {
                string strQuery = @"SELECT [id_chamado],[nome_funcionario],[rf],[login],[cargo],[ramal],[dataSolicitacao]
      ,[RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei],[SigaSaude]  FROM [SolicitaAcesso].[dbo].[Vw_MostraSetoresSolicitados] where ativa_Solicitacao='S'";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    DadosSolicitacoesSetores l = new DadosSolicitacoesSetores();

                    l.id_Solicitacao = dr.GetInt32(0);
                    l.Nome_funcionario = dr.IsDBNull(1) ? null : dr.GetString(1);
                    l.rf_funcionario = dr.IsDBNull(2) ? null : dr.GetString(2);
                    l.login_do_funcionario = dr.IsDBNull(3) ? null : dr.GetString(3);
                    l.Cargo_Funcionario = dr.IsDBNull(4) ? null : dr.GetString(4);
                    l.Ramal = dr.IsDBNull(5) ? null : dr.GetString(5);
                    DateTime dt = dr.GetDateTime(6);
                    l.dataSolicitacao = dt.ToShortDateString();
                    l.RedeCorporativa = dr.IsDBNull(7) ? null : dr.GetString(7);
                    l.SGH = dr.IsDBNull(8) ? null : dr.GetString(8);
                    l.Simproc = dr.IsDBNull(9) ? null : dr.GetString(9);
                    l.Grafica = dr.IsDBNull(10) ? null : dr.GetString(10);
                    l.OS_manutencao = dr.IsDBNull(11) ? null : dr.GetString(11);
                    l.Sei = dr.IsDBNull(12) ? null : dr.GetString(12);
                    l.Siga_saude = dr.IsDBNull(13) ? null : dr.GetString(13);

                    if (l.RedeCorporativa == "S")
                    {
                        l.SetoresConcatenados = "( Rede corporativa ) ";
                    }
                    if (l.SGH == "S")
                    {
                        l.SetoresConcatenados += "( SGH ) ";
                    }
                    if (l.Simproc == "S")
                    {
                        l.SetoresConcatenados += "( Simproc ) ";
                    }
                    if (l.Grafica == "S")
                    {
                        l.SetoresConcatenados += "( Grafica ) ";
                    }
                    if (l.OS_manutencao == "S")
                    {
                        l.SetoresConcatenados += "( OS manutenção ) ";
                    }
                    if (l.Sei == "S")
                    {
                        l.SetoresConcatenados += "( Sei ) ";
                    }
                    if (l.Siga_saude == "S")
                    {
                        l.SetoresConcatenados += "( Siga-Saúde ) ";
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
            return lista;
        }

    }

    public static List<DadosSolicitacoesSetores> MostraSolicitacoesNaTelaStatusRemover()
    {

        var lista = new List<DadosSolicitacoesSetores>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            try
            {
                string strQuery = @"SELECT [id_chamado],[nome_funcionario],[rf],[login],[cargo],[ramal],[dataSolicitacao]
      ,[RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei],[SigaSaude]  FROM [SolicitaAcesso].[dbo].[Vw_MostraSetoresSolicitados] where (RedeCorporativa='E' or SGH='E' or Simproc='E' or Grafica='E' or OS_manutencao='E' or Sei='E' or SigaSaude='E')";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    DadosSolicitacoesSetores l = new DadosSolicitacoesSetores();
                    l.id_Solicitacao = dr.GetInt32(0);
                    l.Nome_funcionario = dr.IsDBNull(1) ? null : dr.GetString(1);
                    l.rf_funcionario = dr.IsDBNull(2) ? null : dr.GetString(2);
                    l.login_do_funcionario = dr.IsDBNull(3) ? null : dr.GetString(3);
                    l.Cargo_Funcionario = dr.IsDBNull(4) ? null : dr.GetString(4);
                    l.Ramal = dr.IsDBNull(5) ? null : dr.GetString(5);
                    DateTime dt = dr.GetDateTime(6);
                    l.dataSolicitacao = dt.ToShortDateString();
                    l.RedeCorporativa = dr.IsDBNull(7) ? null : dr.GetString(7);
                    l.SGH = dr.IsDBNull(8) ? null : dr.GetString(8);
                    l.Simproc = dr.IsDBNull(9) ? null : dr.GetString(9);
                    l.Grafica = dr.IsDBNull(10) ? null : dr.GetString(10);
                    l.OS_manutencao = dr.IsDBNull(11) ? null : dr.GetString(11);
                    l.Sei = dr.IsDBNull(12) ? null : dr.GetString(12);
                    l.Siga_saude = dr.IsDBNull(13) ? null : dr.GetString(13);

                    if (l.RedeCorporativa == "E")
                    {
                        l.SetoresConcatenados = "( Rede corporativa ) ";
                    }
                    if (l.SGH == "E")
                    {
                        l.SetoresConcatenados += "( SGH ) ";
                    }
                    if (l.Simproc == "E")
                    {
                        l.SetoresConcatenados += "( Simproc ) ";
                    }
                    if (l.Grafica == "E")
                    {
                        l.SetoresConcatenados += "( Grafica ) ";
                    }
                    if (l.OS_manutencao == "E")
                    {
                        l.SetoresConcatenados += "( OS manutenção ) ";
                    }
                    if (l.Sei == "E")
                    {
                        l.SetoresConcatenados += "( Sei ) ";
                    }
                    if (l.Siga_saude == "E")
                    {
                        l.SetoresConcatenados += "( Siga-Saúde ) ";
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
            return lista;
        }

    }

    public static DadosSolicitacao GetDadosDaSolitacaoParaAtender(int idChamado)
    {
        DadosSolicitacao d = new DadosSolicitacao();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT *
  FROM [SolicitaAcesso].[dbo].[Solicitante_Dados] where id_chamado=" + idChamado + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.id_chamado_ = dr1.GetInt32(0);
                    d.NomeFuncionario = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.RF_Funcionario = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.login = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.cargoFuncionario = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.ramal1 = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    d.lotacao = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    d.dtSolicitacao = dr1.GetDateTime(7);
                    d.NomeSolicitante_Coordenador = dr1.IsDBNull(8) ? "" : dr1.GetString(8);
                    d.eMail = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    d.ramalFuncionario = dr1.IsDBNull(11) ? "" : dr1.GetString(11);
                    d.NomeEmpresaHSPM_Terceiros = dr1.IsDBNull(13) ? "" : dr1.GetString(13);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return d;
        }
    }

    //
    public static DadosSetoresSolicitados_S GetSetoresCom_S(int idChamado)
    {
        DadosSetoresSolicitados_S d = new DadosSetoresSolicitados_S();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei],[SigaSaude],[DadosSolicitadosSGH]
  FROM [SolicitaAcesso].[dbo].[Vw_MostraSetoresSolicitados] where id_chamado=" + idChamado + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.RedeCorporativa = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.SGH = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.Simproc = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.Grafica = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.OS_manutencao = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.Sei = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    d.Siga_Saude = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    d.DadosSolicitadosSGH = dr1.IsDBNull(7) ? "" : dr1.GetString(7);// criar esse campo no banco
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return d;
        }
    }

    public static void Atualiza_Extrato(int Id_chamado, string Extrato)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string extratoInicial = GetDadosExtratoAcesso(Id_chamado);
                string extratoFinal = extratoInicial + Extrato;
                string strQuery = @"UPDATE [dbo].[Extrato_SolicitaAcesso]
   SET [extrato_solicitaAcesso]=@extrato_solicitaAcesso WHERE id_chamado_Extrato=" + Id_chamado + "";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@extrato_solicitaAcesso", SqlDbType.NVarChar).Value = (object)extratoFinal ?? DBNull.Value; //Caso a variavel seja nula  
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

    public static void Atualiza_Solicitacoes_setores_Update(int Id_chamado, string nomeCampo, string statusNovo, int n)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"UPDATE [dbo].[Setores_Solicitados]
   SET [" + nomeCampo + "]='"+ statusNovo + "', [TotalSetoresAbriChamado] = [TotalSetoresAbriChamado]-"+n+"  WHERE Id_Solicitacoes_setores=" + Id_chamado + "";

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
        }
    }

    //verifica se Total Setor AbriChamado é Zero

    public static int VerificaTotalAbrirChamado(int Nsolicitacao)
    {
        int Total = 0;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                SqlCommand comm = com.CreateCommand();
                string strQuery = @"SELECT [TotalSetoresAbriChamado] FROM [SolicitaAcesso].[dbo].[Setores_Solicitados]
  where Id_Solicitacoes_setores=" + Nsolicitacao + "";
                comm.CommandText = strQuery;
                com.Open();
                SqlDataReader dr1 = comm.ExecuteReader();
                while (dr1.Read())
                {
                    Total = dr1.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            return Total;
        }

    }

    //Abre Chamado Automaticamente
    public static void GravaChamadoAutomaticamente(ListaGrid listaChamado)
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
                    commd.Parameters.Add("@cac", SqlDbType.VarChar).Value = "HSPM00000 ";
                    commd.Parameters.Add("@nomeContato", SqlDbType.VarChar).Value = listaChamado.nomeContato;
                    commd.Parameters.Add("@setor", SqlDbType.VarChar).Value = "Informatica";
                    commd.Parameters.Add("@ramal", SqlDbType.VarChar).Value = listaChamado.ramal;
                    commd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = "Retornar ao Funcionário";
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



    public static void Atualiza_Solicitante_dados_status(int Id_chamado)
    {

        bool result = VerificaSetoresComStatusSolitacaoEmAberto(Id_chamado);

        if (result == false)
        {
            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
            {
                try
                {
                    string strQuery = @"UPDATE [dbo].[Solicitante_Dados]
   SET ativa_Solicitacao ='C' WHERE id_chamado=" + Id_chamado + "";

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
            }
        }

    }

    public static bool VerificaSetoresComStatusSolitacaoEmAberto(int idChamado)
    {
        bool existe;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            try
            {
                string strQuery = @"SELECT [id_chamado],[nome_funcionario],[rf],[login],[cargo],[ramal],[dataSolicitacao]
      ,[RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei]  FROM [SolicitaAcesso].[dbo].[Vw_MostraSetoresSolicitados] where id_chamado=" + idChamado + " and ativa_Solicitacao='S' " +
     "and (RedeCorporativa='S' or SGH='S' or Simproc='S' or Grafica='S' or OS_manutencao='S' or Sei='S' )";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();

                existe = dr.Read();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }

        }
        return existe;
    }

    public static DadosRedeCoorporativa GetDadosRedeCorporativaSolicitacao(int id)
    {
        DadosRedeCoorporativa d = new DadosRedeCoorporativa();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();

            string sqlConsulta = @"SELECT [redeCorperativa] ,[emailCorporativo] ,[caixaDepartamental],[caixaDepartamental_descricao],[pastaRede]
             ,[pastaEspecifica],[redeCorperativaNovoDerp],[redeCorperativaNovoPasta]
  FROM [SolicitaAcesso].[dbo].[RedeCorporativa] where id_chamado_rede_corporativa=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.redeCorporativa = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.emailCorporativo = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.caixaDepartamental = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.caixaDepartamental_Descricao = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.pastaDeRede = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.PastaEspecifica = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    d.redeCorperativaNovoDerp = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    d.redeCorperativaNovoPasta = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    d.status_redeCoorporativa = VerificaStatusDaSolicitacao(id, "RedeCorporativa");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    public static string VerificaStatusDaSolicitacao(int idChamado, string Campo)
    {
        string statusSolicitacao = "";
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            try
            {
                string strQuery = @"SELECT " + Campo + " FROM [SolicitaAcesso].[dbo].[Vw_MostraSetoresSolicitados]" +
                    " where id_chamado=" + idChamado + " ";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();

                if (dr.Read())
                {
                    statusSolicitacao = dr.IsDBNull(0) ? "" : dr.GetString(0);
                }

                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }

        }
        return statusSolicitacao;
    }

    public static DadosSGH GetDadosSGH(int id)
    {
        DadosSGH d = new DadosSGH();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();

            string sqlConsulta = @"SELECT [Amb],[Amb_Desc],[CenCir],[CenCir_Desc],[Internacao],[Internacao_Desc],[Ps],[Ps_Desc]     
  FROM [SolicitaAcesso].[dbo].[Sgh] where id_chamado_sgh=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.Amb = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.Amb_Desc = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.CenCir = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.CenCir_Desc = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.Internacao = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.Internacao_Desc = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    d.PS = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    d.PS_Desc = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    d.status_SGH = VerificaStatusDaSolicitacao(id, "SGH");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    public static DadosSimproc GetDadosSimproc(int id)
    {
        DadosSimproc d = new DadosSimproc();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [cod_Unidade],[cpf_simproc],[rg_simproc],[dataAdmissao]   
  FROM [SolicitaAcesso].[dbo].[Simproc] where id_chamdo_simproc=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.CodigoUnidade_Simproc = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.cpf_simproc = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.rg_simproc = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.dataAdmissao = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.status_Simproc = VerificaStatusDaSolicitacao(id, "Simproc");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    public static DadosGrafica GetDadosGrafica(int id)
    {
        DadosGrafica d = new DadosGrafica();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [N_centro_custo_grafica],[N_centro_custo_grafica_antigo],[cpf_grafica]   
  FROM [SolicitaAcesso].[dbo].[Grafica] where id_chamado_grafica=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.N_centro_custo_grafica = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.N_centro_custo_grafica_antigo = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.cpf_grafica = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.status_grafica = VerificaStatusDaSolicitacao(id, "Grafica");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    //public static DadosOsManutencao GetDadosOsManutencao(int id)
    //{
    //    DadosOsManutencao d = new DadosOsManutencao();
    //    //var lista = new DadosCoordenador();
    //    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
    //    {
    //        SqlCommand cmm = com.CreateCommand();
    //        string sqlConsulta = @"SELECT [N_centro_custos],[cpf_manutencao] FROM [SolicitaAcesso].[dbo].[OsManutencao] where id_chamado_manutencao=" + id + "";
    //        cmm.CommandText = sqlConsulta;
    //        try
    //        {
    //            com.Open();
    //            SqlDataReader dr1 = cmm.ExecuteReader();
    //            while (dr1.Read())
    //            {
    //                d.N_centro_custos = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
    //                d.cpf_manutencao = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
    //                d.status_os_manutencao = VerificaStatusDaSolicitacao(id, "OS_manutencao");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string error = ex.Message;
    //        }

    //    }
    //    return d;
    //}
    public static DadosOsManutencao GetDadosOsManutencao(int id)
    {
        DadosOsManutencao d = new DadosOsManutencao();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [N_centro_custos_Novo],[N_centro_custos_Antigo],[cpf_manutencao] FROM [SolicitaAcesso].[dbo].[OsManutencao] where id_chamado_manutencao=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.N_centro_custos_novo = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.N_centro_custos_antigo = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.cpf_manutencao = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.status_os_manutencao = VerificaStatusDaSolicitacao(id, "OS_manutencao");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    public static DadosSei GetDadosSEI(int id)
    {
        DadosSei d = new DadosSei();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [siglasUnidades1],[siglasUnidades2],[siglasUnidades3],[siglasUnidades4] FROM [SolicitaAcesso].[dbo].[Sei] 
             where id_chamado_Sei=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.siglasUnidades1 = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.siglasUnidades2 = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.siglasUnidades3 = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.siglasUnidades4 = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.status_Sei = VerificaStatusDaSolicitacao(id, "Sei");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    public static DadosSigaSaude GetDadosSigaSaude(int id)
    {
        DadosSigaSaude d = new DadosSigaSaude();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [dtNascSiga],[nomeDaMaeSiga],[CRM_siga],[cpfSiga],[RG_siga],[UF_Siga],[dtEmisaoRG_Siga]
      ,[orgao_RG_Siga],[nomeDaRuaSiga],[NumeroDaRuaSiga],[bairoSiga],[CepSiga],[ModuloAcessarSiga],[ObsSiga]     
  FROM [SolicitaAcesso].[dbo].[SigaSaude] 
             where id_chamado_siga_saude=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.dtNascSiga = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.nomeDaMaeSiga = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.CRM_siga = dr1.GetInt32(2);
                    d.cpfSiga = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.RG_siga = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.UF_Siga = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    d.dtEmisaoRG_Siga = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    d.orgao_RG_Siga = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    d.nomeDaRuaSiga = dr1.IsDBNull(8) ? "" : dr1.GetString(8);
                    d.NumeroDaRuaSiga = dr1.GetInt32(9);
                    d.bairoSiga = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    d.CepSiga = dr1.IsDBNull(11) ? "" : dr1.GetString(11);
                    d.ModuloAcessarSiga = dr1.IsDBNull(12) ? "" : dr1.GetString(12);
                    d.ObsSiga = dr1.IsDBNull(13) ? "" : dr1.GetString(13);
                    d.status_SigaSaude = VerificaStatusDaSolicitacao(id, "SigaSaude");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    public static String GetDadosExtratoAcesso(int id)
    {
        string extratoAcesso = "";
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [extrato_solicitaAcesso] FROM [SolicitaAcesso].[dbo].[Extrato_SolicitaAcesso] 
             where id_chamado_Extrato=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    extratoAcesso = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return extratoAcesso;
    }

    public static List<DadosSolicitacoesSetores> MostraSolicitacoesVisualizar()
    {

        var lista = new List<DadosSolicitacoesSetores>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            try
            {
                string strQuery = @"SELECT [nome_Coordenador],[nome_funcionario],[rf],[login],[dataSolicitacao],[Id_Solicitacoes_setores],
     [RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei],[SigaSaude]
 FROM [SolicitaAcesso].[dbo].[Vw_MinhasSolicitacoes] order by Id_Solicitacoes_setores desc ";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    DadosSolicitacoesSetores l = new DadosSolicitacoesSetores();

                    l.nomeSoliciatante = dr.IsDBNull(0) ? null : dr.GetString(0);
                    l.Nome_funcionario = dr.IsDBNull(1) ? null : dr.GetString(1);
                    l.rf_funcionario = dr.IsDBNull(2) ? null : dr.GetString(2);
                    l.login_do_funcionario = dr.IsDBNull(3) ? null : dr.GetString(3);
                    DateTime dt = dr.GetDateTime(4);
                    l.dataSolicitacao = dt.ToShortDateString();
                    l.id_Solicitacao = dr.GetInt32(5);
                    l.RedeCorporativa = dr.IsDBNull(6) ? null : dr.GetString(6);
                    l.SGH = dr.IsDBNull(7) ? null : dr.GetString(7);
                    l.Simproc = dr.IsDBNull(8) ? null : dr.GetString(8);
                    l.Grafica = dr.IsDBNull(9) ? null : dr.GetString(9);
                    l.OS_manutencao = dr.IsDBNull(10) ? null : dr.GetString(10);
                    l.Sei = dr.IsDBNull(11) ? null : dr.GetString(11);

                    if (l.RedeCorporativa == "S" || l.RedeCorporativa == "C")
                    {
                        l.SetoresConcatenados = "( Rede corporativa ) ";
                    }
                    if (l.SGH == "S" || l.SGH == "C")
                    {
                        l.SetoresConcatenados += "( SGH ) ";
                    }
                    if (l.Simproc == "S" || l.Simproc == "C")
                    {
                        l.SetoresConcatenados += "( Simproc ) ";
                    }
                    if (l.Grafica == "S" || l.Grafica == "C")
                    {
                        l.SetoresConcatenados += "( Grafica ) ";
                    }
                    if (l.OS_manutencao == "S" || l.OS_manutencao == "C")
                    {
                        l.SetoresConcatenados += "( OS manutenção ) ";
                    }
                    if (l.Sei == "S" || l.Sei == "C")
                    {
                        l.SetoresConcatenados += "( Sei ) ";
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
            return lista;

        }

    }

    public static string CarregaQtoDeSolicitacoesEmAberto()

    {
        string TotalDeSolicitacoes = "";
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT COUNT (*)
  FROM [SolicitaAcesso].[dbo].[Setores_Solicitados] where TotalSetoresAbriChamado >0";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    TotalDeSolicitacoes = dr.GetInt32(0).ToString();
                }

                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            return TotalDeSolicitacoes;
        }

    }

    public static string CarregaQtoDeSolicitacoesRemoverPermissao()

    {
        string TotalDeSolicitacoes = "";
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"  SELECT COUNT (*)
  FROM [SolicitaAcesso].[dbo].[Setores_Solicitados] where (RedeCorporativa='E' or SGH='E' or Simproc='E' or Grafica='E' or OS_manutencao='E' or Sei='E' or SigaSaude='E')";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    TotalDeSolicitacoes = dr.GetInt32(0).ToString();
                }

                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            return TotalDeSolicitacoes;
        }

    }
    public static string CarregaQtoDeSolicitacoesPorSetores()

    {
        int rede = 0; int sgh = 0; int simproc = 0; int grafica = 0; int osManu = 0; int sei = 0; int sigaS = 0;
        string TotalDeSolicitacoesPorSetores = "";
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao]
      ,[Sei],[SigaSaude] FROM [SolicitaAcesso].[dbo].[Setores_Solicitados]
        where TotalSetoresAbriChamado>0";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    string RedeC = dr.GetString(0);
                    string SGH = dr.GetString(1);
                    string Simproc = dr.GetString(2);
                    string Grafica = dr.GetString(3);
                    string OS_manutencao = dr.GetString(4);
                    string Sei = dr.GetString(5);
                    string SigaSaude = dr.GetString(6);
                    if (RedeC == "S")
                    {
                        rede++;
                    }
                    if (SGH == "S")
                    {
                        sgh++;
                    }
                    if (Simproc == "S")
                    {
                        simproc++;
                    }
                    if (Grafica == "S")
                    {
                        grafica++;
                    }
                    if (OS_manutencao == "S")
                    {
                        osManu++;
                    }
                    if (Sei == "S")
                    {
                        sei++;
                    }
                    if (SigaSaude == "S")
                    {
                        sigaS++;
                    }

                }
                if (rede > 0)
                {
                    TotalDeSolicitacoesPorSetores = "Rede Corp.(" + rede.ToString() + ") / ";
                }
                if (sgh > 0)
                {
                    TotalDeSolicitacoesPorSetores += "SGH(" + sgh.ToString() + ") / ";
                }
                if (simproc > 0)
                {
                    TotalDeSolicitacoesPorSetores += "Simproc(" + simproc.ToString() + ") / ";
                }
                if (grafica > 0)
                {
                    TotalDeSolicitacoesPorSetores += "Grafica(" + grafica.ToString() + ") / ";
                }
                if (osManu > 0)
                {
                    TotalDeSolicitacoesPorSetores += "OS Manutenção(" + osManu.ToString() + ") / ";
                }
                if (sei > 0)
                {
                    TotalDeSolicitacoesPorSetores += "SEI(" + sei.ToString() + ") / ";
                }
                if (sigaS > 0)
                {
                    TotalDeSolicitacoesPorSetores += "Siga Saúde(" + sigaS.ToString() + ")";
                }
                // TotalDeSolicitacoesPorSetores = "Rede Corp.(" + rede.ToString() + ") - SGH(" + sgh.ToString() + ") - Simproc(" + simproc.ToString() + ") - Grafica(" + grafica.ToString() + ") - OS Manutenção(" + osManu.ToString() + ") - SEI(" + sei.ToString() + ") - Siga Saúde(" + sigaS + ")";
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            return TotalDeSolicitacoesPorSetores;
        }

    }
    public static DadosCompSGH GetDadosSGH_Comp(int id)
    {
        DadosCompSGH d = new DadosCompSGH();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [dtNasci_dadosComp]
      ,[nomeMae_dadosComp],[crm_dadosComp],[cpf_dadosComp],[rg_dadosComp]
  FROM [SolicitaAcesso].[dbo].[DadosCompSGH] 
             where Id_Chamado_dadosComp=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.dtNasci_dadosComp = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.nomeMae_dadosComp = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.crm_dadosComp = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.cpf_dadosComp = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.rg_dadosComp = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.status_dadosComp = VerificaStatusDaSolicitacao(id, "DadosSolicitadosSGH");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }
}