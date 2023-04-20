<%@ Page Title="Vizualizar chamados" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VisualizarChamados.aspx.cs" Inherits="VisualizarChamados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/content.css" rel="stylesheet" />
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.4.1/jspdf.debug.js" integrity="sha384-THVO/sM0mFD9h7dfSndI6TS0PgAGavwKvB5hAxRRvc0o9cPLohB0wb/PTA7LdUHs" crossorigin="anonymous"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Teste">
    <div class="container">
        <asp:label id="pegaNomeLoginUsuario" runat="server" text="" visible="False"></asp:label>

        <h3 class="title-content">Visualizar Chamado</h3>

        <asp:label id="LabelID" runat="server" text="Label" visible="False"></asp:label>
        <asp:label id="LabelTagNserie" runat="server" class="font-weight-bold" text=""></asp:label>
        <div class="row">
            <div class="col-1"></div>
            <div class="col-2">
                <span class="fw-bold">Cac:</span>
                <asp:textbox id="txtCac" runat="server" class="form-control" text="HSPMCAC"
                    readonly="True" backcolor="#F2F2F2"></asp:textbox>
            </div>
            <div class="col-2">
                <span class="fw-bold">Setor:</span>
                <asp:textbox id="txtSetor" runat="server" class="form-control" readonly="True" backcolor="#F2F2F2"></asp:textbox>
            </div>
            <div class="col-2">
                <span class="fw-bold">Nome contato:</span>
                <asp:textbox id="txtNomeContato" runat="server" class="form-control" readonly="True" backcolor="#F2F2F2"></asp:textbox>
            </div>
            <div class="col-2">
                <span class="fw-bold">Ramal:</span>
                <asp:textbox id="txtRamal" runat="server" class="form-control" readonly="True" backcolor="#F2F2F2"></asp:textbox>
            </div>
            <div class="col-2">
                <span class="fw-bold">Chamado aberto em:</span>
                <asp:textbox id="txtHoraDtChamado" runat="server" class="form-control" readonly="True" backcolor="#F2F2F2"></asp:textbox>

            </div>
            <div class="col-1"></div>
        </div>
        <br />
        <div class="row">
            <div class="col-1"></div>
            <div class="col-2">
                <span class="fw-bold">Título:</span>
                <asp:textbox id="txtTitulo" runat="server" class="form-control" readonly="True" backcolor="#F2F2F2"></asp:textbox>
            </div>
            <div class="col-8">
                <span class="fw-bold">Ocorrência:</span>
                <asp:textbox id="txtOcorrencia" runat="server" class="form-control" textmode="MultiLine"
                    readonly="True" backcolor="#F2F2F2"></asp:textbox>
            </div>
            <div class="col-1"></div>
        </div>
        <div class="row">
            <div class="col-1"></div>
            <div class="col-10">
                <span class="fw-bold">Solução:</span>
                <asp:textbox id="txtSolucao" runat="server" readonly="True" class="form-control" textmode="MultiLine"></asp:textbox>
            </div>
            <div class="col-1"></div>
        </div>
        <br />
        <div class="row">
            <div class="col-1"></div>
            <div class="col-10">
                <span class="fw-bold">Movimentação do Chamado até o momento:</span>
                <asp:textbox id="txtExtratoChamado" runat="server" class="form-control"
                    textmode="MultiLine" readonly="True" backcolor="#F2F2F2" height="174px"></asp:textbox>
            </div>
            <div class="col-1"></div>
        </div>
        <br />
        <div class="row">
            <div class="col-12 div-btn">
                <asp:button id="btnVoltar" runat="server" class="button"
                    text="Voltar" onclick="btnVoltar_Click" />
            </div>

        </div>

        <%--     Teste PDF--%>

     <%--  
        <button onclick="GerarPDF()">gerar PDF</button>

        <script>
            function GerarPDF()
            {
                var doc = new jsPDF();
                doc.fromHTML('#Teste', 10, 10)
                doc.save('celke.pdf')
            }
        </script>--%>

        <%--  Fim do Teste em PDF--%>
    </div>
    </div>
</asp:Content>

