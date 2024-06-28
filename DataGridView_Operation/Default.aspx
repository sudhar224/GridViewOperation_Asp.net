<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataGridView_Operation.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvPhoneBook" runat="server" 
                BackColor="White" ShowFooter="true" BorderColor="#CCCCCC" BorderStyle="None" 
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="phone_book_id" BorderWidth="1px" CellPadding="3" 
                OnRowCommand="gvPhoneBook_RowCommand" OnRowEditing="gvPhoneBook_RowEditing" OnRowCancelingEdit="gvPhoneBook_RowCancelingEdit" OnRowUpdating="gvPhoneBook_RowUpdating" OnRowDeleting="gvPhoneBook_RowDeleting" >

                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

                <Columns>
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("first_name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstName" runat="server" Text='<%#Eval("first_name") %>' ></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtFirstNameFooter" runat="server" ></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Last Name">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("last_name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLastName" Text='<%# Eval("last_name") %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtLastNameFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Contact">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("contact") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContact" Text='<%# Eval("contact") %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtContactFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("email") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEmailFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" ImageUrl="~/Image/edit-logo.png" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="20px" />
                            <asp:ImageButton ID="ImageButton2" ImageUrl="~/Image/delete.png" CommandName="Delete" ToolTip="Delete" runat="server" Height="20px" Width="20px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButton3" ImageUrl="~/Image/Save.png" runat="server" CommandName="Update" ToolTip="Update" Height="20px" Width="20px" />
                            <asp:ImageButton ID="ImageButton4" ImageUrl="~/Image/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="20px" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImageButton5" ImageUrl="~/Image/AddNew.png" CommandName="AddNew" ToolTip="AddNew" Height="20px" Width="20px" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            
            </asp:GridView>
            <br />
            <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label> <br />
            <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" ></asp:Label>
        </div>
    </form>
</body>
</html>
