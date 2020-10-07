<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="messageBoard.aspx.cs" Inherits="messageBoard.messageBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="all.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" value="發表文章" onclick="location.href='postResponse.aspx'" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None" PageSize="5" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnInit="GridView1_Init" OnRowDataBound="GridView1_RowDataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="編號" SortExpression="id" InsertVisible="False" ReadOnly="True" />
                <asp:TemplateField HeaderText="主題" SortExpression="topic">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("topic") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "responseDetail?id="+Eval("id") %>' Text='<%# Eval("topic") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="author" HeaderText="發表人" SortExpression="author" />
                <asp:BoundField DataField="publishedDate" HeaderText="發表日期" SortExpression="publishedDate" />
                <asp:TemplateField HeaderText="回應">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblResponse" runat="server" Text='<%# Eval("response") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <PagerTemplate>
                <asp:Button ID="btnPageTop" runat="server" Text="第一頁" CommandArgument="First" CommandName="Page" />
                <span>第</span>
                <asp:DropDownList runat="server" ID="dropPage" AutoPostBack="True" OnSelectedIndexChanged="dropPage_SelectedIndexChanged" style="width: 95px"></asp:DropDownList>

                <span>頁，每頁顯示</span>
                <asp:TextBox runat="server" ID="txtPageSize" AutoPostBack="True" Text="<%# GridView1.PageSize %>" OnTextChanged="txtPageSize_TextChanged" />
                <span>筆，共<%# ((System.Data.DataTable)GridView1.DataSource).Rows.Count  %>筆</span>
                
                <asp:Button ID="btnPagePrev" runat="server" Text="上一頁" CommandArgument="Prev" CommandName="Page" />
                <asp:Button ID="btnPageNext" runat="server" Text="下一頁" CommandArgument="Next" CommandName="Page" />
                <asp:Button ID="btnPageBottom" runat="server" Text="最終頁" CommandArgument="Last" CommandName="Page" />
            </PagerTemplate>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        </div>
    </form>
         <ul class="pageUl">
           <li>
                <input type="button" value="回上一頁" onclick="history.go(-1)" />
            </li>
             <li>
                <input type="button" value="回到頂部" onclick="window.scroll(0,0)"/>
              </li>
             <li>
                <input type="button" value="首頁" onclick="location.href = 'messageBoard.aspx'" />
             </li>
         </ul>
</body>
</html>
