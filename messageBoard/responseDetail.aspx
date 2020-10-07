<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="responseDetail.aspx.cs" Inherits="messageBoard.responseDetail" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title></title>
        <link href="all.css" rel="stylesheet" />
    </head>

    <body>
        <form id="form1" runat="server">
                        <asp:Button ID="btnSubmit" Text="發表回覆" runat="server" OnClick="btnSubmit_Click" />
            <div>
                <%--id給前端,name給後端,runat=server表示運行在伺服器端 占用伺服器資源 會解析成對應的html物件--%>
                    <%--有asp代表是web控制項，可以在.cs頁面呼叫，若沒有就只是單純html物件--%>
                        <br /> 主題:
                        <asp:Label ID="lblTopic" runat="server" Text="Label"></asp:Label>
                        <br /> 發表人:
                        <asp:Label ID="lblAuthor" runat="server" Text="Label"></asp:Label>
                        <br /> 發表時間:
                        <asp:Label ID="lblPublishedDate" runat="server" Text="Label"></asp:Label>
                        <br /> 內容:
                        <asp:Label ID="lblArticle" runat="server" Text="Label"></asp:Label>
                        <br />


            </div>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="odd" style="background-color:#F7F6F3">
                    <h4>
                        <%# Eval("author") %>
                    </h4>
                    <p>
                        <%# Eval("article") %>
                    </p>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="even" >
                    <h4>
                        <%# Eval("author") %>
                    </h4>
                    <p>
                        <%# Eval("article") %>
                    </p>
                    </div>
                </AlternatingItemTemplate>
                
            </asp:Repeater>
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
        </form>
        </body>

    </html>