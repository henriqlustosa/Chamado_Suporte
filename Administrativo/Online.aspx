<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Online.aspx.cs" Inherits="Administrativo_Online" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ChangePassword ID="ChangePassword1" runat="server"></asp:ChangePassword>
        <br />    <br />    <br />    <br />

   <%-- <asp:LoginName ID="LoginName1" runat="server" />--%>

    <asp:LoginView ID="LoginView1" runat="server"></asp:LoginView>
    <br />    <br />    <br />    <br />
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" MailDefinition-From="juniorhspm@gmail.com"></asp:PasswordRecovery>

</asp:Content>

