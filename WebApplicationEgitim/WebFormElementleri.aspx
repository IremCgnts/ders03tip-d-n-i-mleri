<%@ Page Language="c#
    " AutoEventWireup="false" CodeBehind="WebFormElementleri.aspx.vb" Inherits="WebApplicationEgitim.WebFormElementleri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Tarayıcıdaki sekme başlık verisi</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" server="" Text="Tıkla" />
            <asp:Calendar runat="server"></asp:Calendar>
            <asp:CheckBox ID="CheckBox1" runat="server"  Text="Onaylıyorum"/>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                <asp:ListItem Value="1">Onayla</asp:ListItem>
                <asp:ListItem Value="0">Reddet</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:CheckBoxList>
        </div>
    </form>
</body>

</html>
