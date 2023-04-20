<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadastroUsuario.aspx.cs" Inherits="Administrativo_CadastroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/content.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
   <h3 class="title-content">Cadastrar Usuário</h3>

    <div class="nav justify-content-center m-2">
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
            Email="sem@email.com" 
            ContinueDestinationPageUrl="~/Administrativo/Permissao.aspx" 
            FinishDestinationPageUrl="~/Administrativo/Permissao.aspx" CssClass="btn-toggle-nav fw-bold">
            <CreateUserButtonStyle CssClass="button" />
            <LabelStyle CssClass="fw-bold" />
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server" AllowReturn="False">
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="center">
                                    Complete
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Your account has been successfully created.
                                </td>
                            </tr>
                            <tr>
                            <script>
                                window.location = "Permissao.aspx"
                                        </script>
                                <td >
                                    <asp:Button ID="ContinueButton" CssClass="button" runat="server" CausesValidation="False"
                                        CommandName="Continue" Text="Continue" ValidationGroup="CreateUserWizard1" />
                                        
                                        
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
            <CancelButtonStyle CssClass="button" />
        </asp:CreateUserWizard>
    </div>
    </div>
</asp:Content>

