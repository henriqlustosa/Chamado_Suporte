<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BloquearIP.aspx.cs" Inherits="BloquearIP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        <br />
        <div class="row">
            <div class="col-2">
                IP:
              <asp:TextBox ID="txtIP" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-2">
                <asp:Label ID="Label1" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"></asp:Label>
                <asp:Button ID="BtnBloquearIP" runat="server" Text="Bloquear IP" class="btn btn-success" OnClick="BtnBloquearIP_Click" />
            </div>
             <div class="col-2">
                ID para exluir:
              <asp:TextBox ID="txtIpExcluir" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-1">
                <asp:Label ID="Label2" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"></asp:Label>
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir IP" class="btn btn-danger" OnClick="btnExcluir_Click" />
            </div>
        </div>
        <br /><br />
        <asp:GridView ID="GridViewIPbloqueado" runat="server">
        </asp:GridView>

    </div>



</asp:Content>

