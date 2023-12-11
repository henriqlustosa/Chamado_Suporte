<%@ Page Language="C#" AutoEventWireup="true" CodeFile="telaoChamado.aspx.cs" Inherits="telaoChamado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
     <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script type="text/javascript">
        setTimeout(function() {
            window.location.reload(1);
        }, 10000); //60000 1 minutos // 120000 2 min  Junior 03/01/2022
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="container-fluid">
        <asp:GridView ID="GridViewChamados" AutoGenerateColumns="False" 
            runat="server" BackColor="WhiteSmoke"
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" CellPadding="14"
                Font-Bold="true" ForeColor="Black" CellSpacing="8"
                Width="100%" Font-Size="20" HeaderStyle-BackColor="#ADD8E6" OnRowDataBound="GridViewChamados_RowDataBound"> 
            <Columns>
                <asp:BoundField DataField="cac" HeaderText="Cac" SortExpression="cac" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="setor" HeaderText="Setor" SortExpression="setor" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="nomeContato" HeaderText="Nome Contato" SortExpression="nomeContato"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ramal" HeaderText="Ramal" SortExpression="ramal" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="titulo" HeaderText="Titulo" SortExpression="titulo" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="ocorrencia" HeaderText="Ocorrência" SortExpression="ocorrencia" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="dt_hora" HeaderText="Data e Hora" SortExpression="dt_hora"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="statusCor" HeaderText="statusCor" SortExpression="statusCor"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" Visible="False">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
            
            </Columns>
        </asp:GridView>
      
    </div>
   
    </form>
</body>
</html>
