<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="emAtendimento.aspx.cs" Inherits="emAtendimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        input {
            text-align: left;
        }
    </style>

    <script type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript" src="js/jquery.mask.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <script type="text/javascript">
            function mostra3() {

                var div = document.getElementById('EncaminharExterno');

                if (div.style.display == 'none') {
                    div.style.display = 'block';

                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>


        <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
        <br />
        <h2 class="text-center">
            <i>Em Atendimento</i></h2>
        <br />
        <asp:Label ID="LabelID" runat="server" Text="Label" Visible="False"></asp:Label>
        <div class="row">
            <div class="col-2">
                Cac:
                <asp:TextBox ID="txtCac" runat="server" class="form-control" required Text="HSPMCAC"
                    ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-2">
                Setor:
                <asp:TextBox ID="txtSetor" runat="server" class="form-control" required ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-2">
                Nome contato:
                <asp:TextBox ID="txtNomeContato" runat="server" class="form-control" required ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-2">
                Ramal:
                <asp:TextBox ID="txtRamal" runat="server" class="form-control" required ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-2">
                Chamado aberto em:
                <asp:TextBox ID="txtHoraDtChamado" runat="server" class="form-control" required ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>

            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                Titulo:
                <asp:TextBox ID="txtTitulo" runat="server" class="form-control" required ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-8">
                Ocorrência:
                <asp:TextBox ID="txtOcorrencia" runat="server" class="form-control" required TextMode="MultiLine"
                    MaxLength="500" ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-10">
                Solução:
                <asp:TextBox ID="txtSolucao" runat="server" class="form-control" required TextMode="MultiLine"
                    MaxLength="500"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <%-- <div class="col-1">
            </div>--%>
            <div class="col-2">
                <input id="btnFinalizarC" type="button" value="Finalizar" onclick="finaliza_chamado()" class="btn btn-success" />
            </div>

            <div class="col-2">

                <input id="btnEmEspera1" type="button" value="Em espera" onclick="mostra3()" class="btn btn-info" />
            </div>
            <%-- <div class="col-2">
                <asp:button id="btnRetornar" runat="server" class="btn btn-warning" text="Reclassificar" onclick="btnRetornar_Click" />
            </div>--%>
            <div class="col-2">
                <input id="btnRetornar" type="button" value="Reclassificar" onclick="reclassificar()" class="btn btn-warning" />
            </div>


            <%--</div>--%>

            <div class="col-1.5">
                <asp:Button ID="btnEncaminhar" runat="server" class="btn btn-secondary" Text="Encaminhar" OnClick="btnEncaminhar_Click" />

            </div>
            <div class="col-2">

                <asp:DropDownList ID="DdlEncaminharParaTecnico" runat="server" class="form-control" DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="UserName"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:chamado_suporteConnectionString %>" SelectCommand="SELECT [UserName] FROM [vw_aspnet_Users] ORDER BY [UserName]"></asp:SqlDataSource>
            </div>

        </div>
        <br />
        <div id="EncaminharExterno" style='display: none;'>
            <div class="row" id="RbStatus">
                <div class="col-2">
                    <asp:RadioButton ID="RbtAtendimentoLocal" runat="server" GroupName="Status" Text="&ensp;Atendimento Local" Checked="True" />
                </div>
                <div class="col-2">
                    <asp:RadioButton ID="RbtDell" runat="server" GroupName="Status" Text="&ensp;Externo DELL" />
                </div>
                <div class="col-2">
                    <asp:RadioButton ID="RbtImpressora" runat="server" GroupName="Status" Text="&ensp;Externo Impressora" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-3">
                    <asp:Label ID="Label1" runat="server" Text="Infome a TAG / Nº de serie:"></asp:Label>
                    <asp:TextBox ID="txtTagNserie" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-1">
                    <asp:Label ID="Label2" runat="server" Text="&ensp;&ensp;"></asp:Label>
                    <asp:Button ID="btnEmEspera" runat="server" class="btn btn-info" Text="Cadastar" OnClick="btnEmEspera_Click" />
                </div>
            </div>
        </div>

        <div id="FinalizarChamado" style='display: none;'>
            <div class="row">
                <div class="col-4">
                    Solução:
                <%--<asp:TextBox ID="txtTitulo" runat="server" class="form-control" required></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlTipoSolucao" runat="server" class="form-control" DataSourceID="SqlDataSource3" DataTextField="nomeSolucao" DataValueField="nomeSolucao"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:chamado_suporteConnectionString %>" SelectCommand="SELECT [nomeSolucao] FROM [padraoSolucao] ORDER BY [nomeSolucao]"></asp:SqlDataSource>

                </div>
                <div class="col-1">
                    <asp:Label ID="Label4" runat="server" Text="&ensp;&ensp;&ensp;"></asp:Label>
                    <asp:Button ID="btnFinalizar" runat="server" class="btn btn-success"
                        Text="Finalizar" OnClick="btnFinalizar_Click" />
                </div>
            </div>
        </div>

        <div id="Re-classificar" style='display: none;'>
            <div class="row">
                <div class="col-4">
                    Titulo:
                <%--<asp:TextBox ID="txtTitulo" runat="server" class="form-control" required></asp:TextBox>--%>
                    <asp:DropDownList runat="server" class="form-control" ID="ddlTitulo" DataSourceID="SqlDataSource2" DataTextField="NomeTipoChamado" DataValueField="NomeTipoChamado"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:chamado_suporteConnectionString %>" SelectCommand="SELECT [NomeTipoChamado] FROM [TipoChamado] ORDER BY [NomeTipoChamado]"></asp:SqlDataSource>
                </div>
                <div class="col-1">
                    <asp:Label ID="Label3" runat="server" Text="&ensp;&ensp;"></asp:Label>
                    <asp:Button ID="btnAtualizar" runat="server" class="btn btn-success" Text="Atualizar" OnClick="btnAtualizar_Click" />
                </div>
            </div>
        </div>
        <br />
        <div class="row">

            <div class="col-10">
                Movimentação do Chamado até o momento:
                <asp:TextBox ID="txtExtratoChamado" runat="server" class="form-control" required TextMode="MultiLine" ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
        </div>
        <script type="text/javascript">
            function reclassificar() {

                var div = document.getElementById('Re-classificar');

                if (div.style.display == 'none') {
                    div.style.display = 'block';

                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>

        <script type="text/javascript">
            function finaliza_chamado() {

                var div = document.getElementById('FinalizarChamado');

                if (div.style.display == 'none') {
                    div.style.display = 'block';

                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>
    </div>
</asp:Content>
