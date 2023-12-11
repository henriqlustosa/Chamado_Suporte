<%@ Page Title="Bloquear IP" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BloquearIP.aspx.cs" Inherits="BloquearIP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/setores.css" rel="stylesheet" />
    <link href="../css/alinharbtn.css" rel="stylesheet" />
    <%--  <script type="text/javascript" src="js/jquery.js"></script>
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <link href="js/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(function() {

            $("[id$=txtIP]").autocomplete({
                source: function(request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("BloquearIP.aspx/getIP") %>',
                        data: "{ 'prefixo': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function(data) {
                            response($.map(data.d, function(item) {
                                return {
                                    label: item.split(';')[0],
                                    val: item.split(';')[1]
                                }
                            }))
                        },
                        error: function(response) {
                            alert(response.responseText);
                        },
                        failure: function(response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function(e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });

    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <h3 class="title-content">Bloquear IP</h3>
        <div class="row justify-content-center">
            <div class="col-2"></div>
            <div class="col-2">
                <span class="fw-bold">IP:</span>
                <asp:TextBox ID="txtIP" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-1 div-btnbloquear">
                <asp:Button ID="BtnBloquearIP" runat="server" Text="Bloquear IP" class=" btn-cadastrar div-input" OnClick="BtnBloquearIP_Click" />
            </div>
            <div class="col-2"></div>
            <div class="col-2">
               <span class="fw-bold">ID para exluir:</span>
              <asp:TextBox ID="txtIpExcluir" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-1 div-btnbloquear">
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir IP" class="btn-excluir div-input" OnClick="btnExcluir_Click" />
            </div>
            <div class="col-2"></div>
        </div>
        <br />
        <br />
        <asp:GridView ID="GridViewIPbloqueado" runat="server">
        </asp:GridView>

    </div>



</asp:Content>

