<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RelatorioQuantativo.aspx.cs" Inherits="Administrativo_Relatorios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery.mask.js" type="text/javascript"></script>
    <link href="../css/content.css" rel="stylesheet" />
    <link href="../css/relatorio.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script type="text/javascript">
        $('#<%=txtDtInicio.ClientID %>').mask("99/99/9999");
        $('#<%= txtDtFim.ClientID %>').mask("99/99/9999");
    </script>--%>

    <div class="container">
        <h3 class="title-content">Relatório Quantativo</h3>
        <br />
        <div class="row">
            <%--<div class="col-3"></div>--%>
          
            <%--<div class="col-3"></div>--%>
            <%--<div class="col-4 centralizar ">--%>
            <div class="col-2 ">
                <span class="fw-bold">Total de Chamados:</span>
                <asp:label class="fw-bold" id="LabelTotalChamados" runat="server" forecolor="#3b7b92" text=""></asp:label>
            </div>
            <div class="col-5">  <asp:button runat="server" ID="btnExcel" class="btn btn-success" text="Exportar Excel"  OnClick="btnExcel_Click" />   </div>
              <div class="col-3">
                  <asp:Label ID="Label1" runat="server" Text="Selecione o ano do relatório"></asp:Label>
                  <asp:DropDownList ID="ddlAnoRelatorio" runat="server" AutoPostBack="True" OnLoad="Page_Load">
                      <asp:ListItem>2023</asp:ListItem>
                      <asp:ListItem>2024</asp:ListItem>
                      <asp:ListItem>2025</asp:ListItem>
                      <asp:ListItem>2026</asp:ListItem>
                      <asp:ListItem>2027</asp:ListItem>
                      <asp:ListItem>2028</asp:ListItem>
                      <asp:ListItem>2029</asp:ListItem>
                      <asp:ListItem>2030</asp:ListItem>
                      <asp:ListItem></asp:ListItem>
                  </asp:DropDownList> </div>
        </div>
        <br />


        <div class="row">
            Total de chamados por Mês
        <div class="col-1"></div>
            <div class="col-10">
                <asp:gridview id="GridViewRelMES" autogeneratecolumns="False" 
                    runat="server" cssclass="table table-bordered" headerstyle-horizontalalign="Center" headerstyle-verticalalign="Middle"
                    headerstyle-backcolor="#3b7b92" headerstyle-forecolor="#ffffff" bordercolor="#29336b">
                <Columns>
                    <asp:BoundField DataField="MES" HeaderText="MES" SortExpression="MES" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs">
                        <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                        <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" SortExpression="TOTAL" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs">
                        <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                        <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundField>                  
                   
                </Columns>
            </asp:gridview>
            </div>
        </div>
           <br />

         <div class="row">
           Total de chamados por TItulos
        <div class="col-1"></div>
            <div class="col-10">
                <asp:gridview id="GridViewTotalPorTitulo" autogeneratecolumns="False" 
                    runat="server" cssclass="table table-bordered" headerstyle-horizontalalign="Center" headerstyle-verticalalign="Middle"
                    headerstyle-backcolor="#3b7b92" headerstyle-forecolor="#ffffff" bordercolor="#29336b">
                <Columns>
                    <asp:BoundField DataField="TITULO" HeaderText="TITULO" SortExpression="TITULO" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs">
                        <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                        <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" SortExpression="TOTAL" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs">
                        <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                        <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundField>                   
                   
                </Columns>
            </asp:gridview>
            </div>
        </div>
        <br />

             <div class="row">
           Total de chamados por Setores
        <div class="col-1"></div>
            <div class="col-10">
                <asp:gridview id="GridViewTotalPorSetores" autogeneratecolumns="False" 
                    runat="server" cssclass="table table-bordered" headerstyle-horizontalalign="Center" headerstyle-verticalalign="Middle"
                    headerstyle-backcolor="#3b7b92" headerstyle-forecolor="#ffffff" bordercolor="#29336b">
                <Columns>
                    <asp:BoundField DataField="SETOR" HeaderText="SETOR" SortExpression="SETOR" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs">
                        <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                        <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" SortExpression="TOTAL" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs">
                        <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                        <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundField>                   
                   
                </Columns>
            </asp:gridview>
            </div>
        </div>
     
    
    </div>


</asp:Content>

