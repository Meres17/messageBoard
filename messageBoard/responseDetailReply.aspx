<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="responseDetailReply.aspx.cs" Inherits="messageBoard.responseDetailReply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="all.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <p>*表示必填欄位</p>
                <div>發布時間:<asp:Label ID="lblPostTime" runat="server" Text="Label"></asp:Label>
                    IP:<asp:Label ID="lblIp" runat="server" Text="Label"></asp:Label>
                </div>

            </div>
            <div class="reply">
        *標題<asp:TextBox ID="txtTopic" runat="server" Width="600px" required="required"></asp:TextBox>
            <br />
        *暱稱<asp:TextBox ID="txtAlias" runat="server" Width="600px" required="required"></asp:TextBox>
            <br />
        *內容<asp:TextBox ID="txtArticle" runat="server" Height="240px" TextMode="MultiLine" Width="600px" required="required"></asp:TextBox>
            </div>
        </div>

    <hr />
        <div>
            <asp:Button ID="btnSubmit" Text="確定" runat="server" OnClick="btnSubmit_Click" />
            <input type="reset" value="重設" />
        </div>
    </form>
         <ul class="pageUl">
           <li>
                <input type="button" value="回上一頁" onclick="history.go(-1)" />
            </li>
             <li>
                <input type="button" value="回到頂部" onclick="window.scroll(0, 0)" />
              </li>
             <li>
                <input type="button" value="首頁" onclick="location.href = 'messageBoard.aspx'" />
             </li>
         </ul>
</body>
</html>
