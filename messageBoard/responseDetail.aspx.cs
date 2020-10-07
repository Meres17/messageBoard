
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace messageBoard
{
    public partial class responseDetail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.RequestStringNull("id"))
                {
                    Response.Redirect("Error.aspx");
                }
                string id = Request.QueryString["id"]?.ToString();


                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["messageBoardConnectionString"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"select * from [messageBoardFT] where [id]={id}";
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lblTopic.Text = dr["topic"].ToString();
                        lblAuthor.Text = dr["author"].ToString();
                        lblPublishedDate.Text = dr["publishedDate"].ToString();
                        lblArticle.Text = dr["article"].ToString();
                    }
                    Session["topic"] = lblTopic.Text;

                }

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["messageBoardConnectionString"].ConnectionString;
                    SqlDataAdapter adapter = new SqlDataAdapter($"select * from [responseFT] where responseId = {id}", conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    Repeater1.DataSource = ds.Tables["table"];
                    Repeater1.DataBind();

                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string url = "responseDetailReply.aspx?";
            string pResponseId = "responseId="+ Request.QueryString["id"]?.ToString();
            string pTopic = "&topic=" + Session["topic"]?.ToString();
            Response.Redirect(url+pResponseId+pTopic);
        }
    }
}