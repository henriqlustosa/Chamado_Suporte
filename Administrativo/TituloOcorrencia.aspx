<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TituloOcorrencia.aspx.cs" Inherits="Administrativo_Setores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/setores.css" rel="stylesheet" />
    <link href="../css/alinharbtn.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <h3 class="title-content">Cadastrar Ocorrência</h3>

        <div class="div-setores">
            <div class="row">
                <div class="col-1"></div>
                <div class="col-5 div-btnbloquear">
                    <span class="fw-bold">Digite o nome do título da ocorrência:</span>
                    <asp:TextBox ID="txtAddTituloOcorrencia" runat="server" class="form-control " MaxLength="60"></asp:TextBox>
                </div>

                <div class="col-1 div-btnbloquear">
                    <asp:Button ID="CadastrarItuloOcorrencia" runat="server" class="btn-cadastrar div-input" Text="Cadastrar" OnClick="CadastrarItuloOcorrencia_Click" />
                </div>
                <div class="col-1"></div>
                <div class="col-2">
                    <span class="fw-bold">ID:</span>
                    <asp:TextBox ID="txtID" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-1 div-btnbloquear">
                    <asp:Button ID="btnExcluir" runat="server" class="btn-excluir div-input" Text="Excluir" OnClick="btnExcluir_Click" />
                </div>
                <div class="col-1"></div>
            </div>
        </div>
        <br />
        <br />
        <div class="div-list">
            <asp:Label CssClass="fw-bold" ID="Label1" runat="server" Text="Lista em ordem alfabética dos setores cadastrados:"></asp:Label>
            <br />
            <asp:GridView ID="GridViewTituloOcorrencia" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" RowStyle-HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="#3b7b92" ForeColor="#ffffff" HorizontalAlign="Center" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="#29336b" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                <PagerStyle BackColor="#3b7b92" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

