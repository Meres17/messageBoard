using Antlr.Runtime.Tree;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace messageBoard
{
    public partial class messageBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewBind();
                //Response.CacheControl
            }
   
        }
        private void GridViewBind()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["messageBoardConnectionString"].ConnectionString;
            //string joinString = "select M.id,M.topic,M.author,M.publishedDate,COUNT(R.responseId) as response from messageBoardFT as M left join responseFT as R on (M.id=R.responseId) group by M.id,M.author,M.topic,M.publishedDate";
            string selectInSelect = "SELECT *,(select count(*) from responseFT where messageBoardFT.id=responseFT.responseId) as response FROM [messageBoard].[dbo].[messageBoardFT]";
            SqlDataAdapter adapter = new SqlDataAdapter(selectInSelect,conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "messageBoard");

            GridView1.DataSource = ds.Tables["messageBoard"];
            int c = ((DataTable)GridView1.DataSource).Rows.Count;

            //Response.Write(c);
            GridView1.DataBind();
        }
        private void AddDropListItems(DropDownList drop,GridView gridView)
        {
            for (int i = 0; i < gridView.PageCount; i++)
            {
                int page = i + 1;
                ListItem item = new ListItem(page.ToString());
                if (gridView.PageIndex==i)
                {
                    item.Selected = true;
                }
                drop.Items.Add(item);
            }
        }
        private void ArrviePageBorder(Control control,GridView gridView,int border)
        {
            if (gridView.PageIndex==border)
            {
                control.Visible = false;
            }
            else
            {
                control.Visible = true;
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridViewBind();
        }

        protected void txtPageSize_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            try
            {
                Convert.ToInt32(txt.Text);
                Response.Redirect("messageBoard.aspx?pageSize=" + txt.Text);
            }
            catch (Exception)
            {
                //this.Page.RegisterStartupScript("", "< script> alert('彈出的訊息'); </ script > ");
                //Page.RegisterStartupScript(" ", "< script> alert('彈出的訊息'); </ script >");
                ClientScript.RegisterStartupScript(typeof(string), "", "<script> alert('錯誤'); </script>");
                //p1類型(本頁)typeof(string) or page.GetType,p2事件名,p3 script  
                //Response.Write("<script language='javascript'>");
                //Response.Write("alert('輸入格式錯誤')");
                //Response.Write("</script>");
            }

            //desert
            //if (Regex.IsMatch(txt.Text, @"^[0-9]$"))
            //{
            //    Response.Redirect("messageBoard.aspx?pageSize=" + txt.Text);
            //}
            //else
            //{
            //    Response.Write("<script language='javascript'>");
            //    Response.Write("alert('輸入格式錯誤')");
            //    Response.Write("</script>");
            //}

        }

        protected void GridView1_Init(object sender, EventArgs e)
        {
            var pageSize = Request.QueryString["pageSize"] ?? "5";
            GridView1.PageSize = Convert.ToInt32(pageSize);

            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType==DataControlRowType.Pager)
            {
                DropDownList drop = (DropDownList)e.Row.FindControl("dropPage");
                AddDropListItems(drop, GridView1);
                Button btnNext = (Button)e.Row.FindControl("btnPageNext");
                Button btnPrev = (Button)e.Row.FindControl("btnPagePrev");

                ArrviePageBorder(btnNext, GridView1, GridView1.PageCount-1);
                ArrviePageBorder(btnPrev, GridView1, 0);
            }
        }

        protected void dropPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drop = (DropDownList)sender;
            GridView1_PageIndexChanging(GridView1, new GridViewPageEventArgs(drop.SelectedIndex));
        }
    }
}