<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="messageBoard.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>抱歉！請您再重新檢視輸入的網址是否正確。</p>
            <p>您也可以回到<a href="javascript:history.back();">上一頁</a>
                或<a href="messageBoard.aspx">首頁</a></p>
            <p>Sorry. Please check one more time that your website address has been entered correctly.</p>
            <p>You can also back to<a href="javascript:history.back();">Previous page</a> 
                or <a href="messageBoard.aspx">Index</a></p>
        </div>
    </form>
</body>
</html>
