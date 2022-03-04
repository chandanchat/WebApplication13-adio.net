<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication13.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                    <tr>
                        <td>Enter Your Name</td>
                        <td><asp:TextBox runat="server" ID="txtname"></asp:TextBox></td>
                    </tr>
                                    <tr>
                        <td>Enter Your Age</td>
                        <td><asp:TextBox runat="server" ID="txtage"></asp:TextBox></td>
                    </tr>
                <tr>
                    <td colspan="2"><asp:Button runat="server" id="btninsert" Text="Save" OnClick="btninsert_Click"/></td>
                </tr>
            </table>
        </div>
            <table>
        <tr>
            <td><asp:GridView ID="grd" runat="server" OnRowCommand="grd_RowCommand" AutoGenerateColumns="false" >
                <Columns>
                    <asp:TemplateField HeaderText="Employee Id">
                        <ItemTemplate>
                            <%#Eval("id") %>
                        </ItemTemplate>
                    </asp:TemplateField >
                                        <asp:TemplateField HeaderText="Employee Name">
                        <ItemTemplate>
                            <%#Eval("name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Age">
                        <ItemTemplate>
                            <%#Eval("age") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employee Delete">
                        <ItemTemplate>
                             <asp:LinkButton runat="server" ID="btndelete" Text="Delete" CommandName="A" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Update">
                        <ItemTemplate>
                             <asp:LinkButton runat="server" ID="btnedit" Text="Edit" CommandName="B" CommandArgument='<%#Eval("id") %>' ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView></td>
           
        </tr>
    </table>
    </form>

</body>
</html>
