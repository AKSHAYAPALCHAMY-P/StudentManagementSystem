<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="StudentManagementSystem.Web.Students.Table" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="StudentsTable" runat="server" AutoGenerateColumns="False" DataKeyNames="StudentID" 
                OnRowEditing="StudentsTable_RowEditing" OnRowCancelingEdit="StudentsTable_RowCancelingEdit" 
                OnRowDeleting="StudentsTable_RowDeleting">
                <Columns>
                    
                    <asp:TemplateField HeaderText="StudentName">
                        <ItemTemplate>
                            <asp:Label ID="StudentName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="StudentNameInput" runat="server" Text='<%# Bind("Name") %>' />
                        </EditItemTemplate>

                    </asp:TemplateField>

                   
                    <asp:TemplateField HeaderText="StudentID">
                         <ItemTemplate>
                            <asp:Label ID="StudentID" runat="server" Text='<%# Bind("StudentID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="StudentIDInput" runat="server" Text='<%# Bind("StudentID") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    
                    <asp:TemplateField HeaderText="StudentClass">
                        <ItemTemplate>
                            <asp:Label ID="StudentClass" runat="server" Text='<%# Bind("Class") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="StudentClassInput" runat="server" Text='<%# Bind("Class") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>

                   
                    <asp:TemplateField HeaderText="StudentAddress">
                        <ItemTemplate>
                            <asp:Label ID="StudentAddress" runat="server" Text='<%# Bind("AddressName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="StudentAddressInput" runat="server" Text='<%# Bind("AddressName") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true"/>

                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
