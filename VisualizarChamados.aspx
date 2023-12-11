<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VisualizarChamados.aspx.cs" Inherits="VisualizarChamados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
        <br />
        <h2 class="text-center">
            <i>Visualizar Chamado</i></h2>
        <br />
        <asp:Label ID="LabelID" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="LabelTagNserie" runat="server" class="font-weight-bold" Text=""></asp:Label>
        <div class="row">
            <div class="col-2">
                Cac:
                <asp:TextBox ID="txtCac" runat="server" class="form-control" Text="HSPMCAC"
                    ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-2">
                Setor:
                <asp:TextBox ID="txtSetor" runat="server" class="form-control" ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-2">
                Nome contato:
                <asp:TextBox ID="txtNomeContato" runat="server" class="form-control" ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-2">
                Ramal:
                <asp:TextBox ID="txtRamal" runat="server" class="form-control" ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-2">
                Chamado aberto em:
                <asp:TextBox ID="txtHoraDtChamado" runat="server" class="form-control" ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>

            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                Titulo:
                <asp:TextBox ID="txtTitulo" runat="server" class="form-control" ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-8">
                Ocorrência:
                <asp:TextBox ID="txtOcorrencia" runat="server" class="form-control" TextMode="MultiLine"
                     ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
        </div>        
        <div class="row">
            <div class="col-10">
                Solução:
                <asp:TextBox ID="txtSolucao" runat="server" ReadOnly="True" class="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <br /> 
        <div class="row">

            <div class="col-10">
                Movimentação do Chamado até o momento:
                <asp:TextBox ID="txtExtratoChamado" runat="server" class="form-control" TextMode="MultiLine" ReadOnly="True" BackColor="#F2F2F2" Height="174px"></asp:TextBox>
            </div>
        </div>
        <br />
          <div class="row">
            <div class="col-2">
            </div>
            <asp:Button ID="btnVoltar" runat="server" class="btn btn-success"
                Text="Voltar" OnClick="btnVoltar_Click" />
        </div>

    </div>

</asp:Content>

