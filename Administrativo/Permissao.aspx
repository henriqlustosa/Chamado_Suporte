<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Permissao.aspx.cs" Inherits="Administrativo_Permissao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/content.css" rel="stylesheet" />
    <link href="../css/permissao.css" rel="stylesheet" />
    <style type="text/css">
        #interna {
            margin: 0 auto;
            width: 50%; /* Valor da Largura */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <h3 class="title-content">Cadastro de Permissões de Usuários</h3>
    <div class="container div-central">
        <div class="col-4"></div>
        <div class="col-4">
            <div class="row">
                <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                        <span class="required fw-bold">Nome </span>
                    <asp:dropdownlist id="DropDownList1" class="form-control" runat="server"
                        autopostback="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:dropdownlist>
                </div>
            </div>
            <br />
            <div class="row">
                <div>
                     <span class="required fw-bold">Permissões</span>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                    <asp:checkboxlist id="CheckBoxList1" runat="server" onselectedindexchanged="CheckBoxList1_SelectedIndexChanged"
                        repeatlayout="Flow" cssclass="flat">
                    </asp:checkboxlist>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="form-group">
                    <div class="col-md-9 col-sm-9 col-xs-12">
                        <asp:button id="btnCad" runat="server" text="Cadastrar" class="button"
                            onclick="btnCad_Click" height="38px" width="104px" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-4"></div>
    </div>

</asp:Content>

