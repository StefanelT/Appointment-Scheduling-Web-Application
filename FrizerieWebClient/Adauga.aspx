<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adauga.aspx.cs" Inherits="FrizerieWebClient.Adauga" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2>Fă o programare online</h2>
    <div style="display: flex; flex-direction: column; gap: 10px;">
        Nume: <asp:TextBox ID="txtNume" runat="server" />
        Data: <asp:TextBox ID="txtData" runat="server" TextMode="Date" />
        Tip: <asp:DropDownList ID="ddlTip" runat="server">
            <asp:ListItem>Tuns Barbat</asp:ListItem>
            <asp:ListItem>Tuns + Barba</asp:ListItem>
            <asp:ListItem>Tuns Femei</asp:ListItem>
            <asp:ListItem>Tuns Copii</asp:ListItem>
            <asp:ListItem>Pachet Complet</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSalveaza" runat="server" Text="Salveaza" OnClick="btnSalveaza_Click" CssClass="btn-save" />
        <asp:Label ID="lblMsg" runat="server" />
    </div>
</asp:Content>
