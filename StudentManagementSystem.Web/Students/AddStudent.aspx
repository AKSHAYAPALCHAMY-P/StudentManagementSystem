<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="StudentManagementSystem.Web.Students.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>StudentManagementSystem</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="StudentName" runat="server">Name</asp:Label>
            <asp:TextBox ID="StudentNameINput" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="StudentID" runat="server">StudentID</asp:Label>
            <asp:TextBox ID="StudentIDInput" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="StudentClass" runat="server">Class</asp:Label>
            <asp:TextBox ID="StudentClassInput" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="StudentAddress" runat="server">Address</asp:Label>
            <asp:TextBox ID="StudentAddressInput" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="AddStudent_Click" />
        </div>
    </form>
</body>
</html>
