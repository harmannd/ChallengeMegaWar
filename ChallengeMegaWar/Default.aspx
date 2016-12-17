<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeMegaWar.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Card game of war!<br />
        <br />
        <asp:Button ID="buttonWar" runat="server" OnClick="buttonWar_Click" Text="War!" />
    
    </div>
        <p>
            <asp:Label ID="labelResults" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
