<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="FrizerieWebClient.Lista" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="margin-top:0; font-weight: 600;">Programări Existente</h2>
   

    <div class="table-container">
        <asp:GridView ID="gvProgramari" runat="server" AutoGenerateColumns="False" 
            CssClass="modern-table" GridLines="None" 
            OnRowCommand="gvProgramari_RowCommand" DataKeyNames="Id">
            
            <Columns>
                <asp:BoundField DataField="Client" HeaderText="Client" />
                <asp:BoundField DataField="Data" HeaderText="Data" DataFormatString="{0:dd MMM yyyy}" />
                <asp:BoundField DataField="TipTuns" HeaderText="Serviciu" />


                <asp:TemplateField HeaderText="Acțiuni">
                    <ItemTemplate>
                        <div style="display: flex; gap: 8px; flex-wrap: nowrap; align-items: center; justify-content: flex-start;">
                            <asp:Button ID="btnEdit" runat="server" Text="Editează" 
                                CommandName="EditeazaProgramare" 
                                CommandArgument='<%# Container.DisplayIndex %>' 
                                CssClass="btn-edit" />

                            <asp:Button ID="btnSterge" runat="server" Text="Șterge" 
                                CommandName="StergeProgramare" 
                                CommandArgument='<%# Eval("Id") %>' 
                                OnClientClick="return confirm('Sigur dorești să anulezi această programare?');" 
                                CssClass="btn-delete" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <div id="editModal" class="modal-overlay" style="display:none; position: fixed; top: 0; left: 0; width: 100%; height: 100%; background: rgba(0,0,0,0.5); z-index: 2000; justify-content: center; align-items: center;">
        <div class="container" style="max-width: 400px; margin-top: 0;">
            <h3>Modifică Programarea</h3>
            <asp:HiddenField ID="hfEditId" runat="server" />
            <label>Nume Client:</label>
            <asp:TextBox ID="txtEditNume" runat="server" />
            <label>Data:</label>
            <asp:TextBox ID="txtEditData" runat="server" TextMode="Date" />
            <label>Serviciu:</label>
            <asp:DropDownList ID="ddlEditTip" runat="server">
                <asp:ListItem>Tuns Barbat</asp:ListItem>
                <asp:ListItem>Tuns + Barba</asp:ListItem>
                <asp:ListItem>Tuns Femei</asp:ListItem>
                <asp:ListItem>Tuns Copii</asp:ListItem>
                <asp:ListItem>Pachet Complet</asp:ListItem>
            </asp:DropDownList>
            <div style="margin-top: 15px; text-align: center;">
                 <asp:Label ID="lblModalMsg" runat="server" ForeColor="Red" Font-Size="13px" Font-Weight="Bold" />
            </div>
            <div style="display:flex; gap: 10px; margin-top: 20px;">
                <asp:Button ID="btnUpdate" runat="server" Text="Salvează Modificările" OnClick="btnUpdate_Click" CssClass="btn-modal" />
                <button type="button" onclick="closeModal()" class="btn-cancel">Anulează</button>
            </div>
        </div>
    </div>

    <div style="margin-top: 20px; text-align: center;">
        <asp:Label ID="lblStatus" runat="server" Font-Size="14px" />
    </div>

    <script type="text/javascript">
        function openModal() {
            document.getElementById('editModal').style.display = 'flex';
        }
        function closeModal() {
            document.getElementById('editModal').style.display = 'none';
        }
    </script>
</asp:Content>