using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace messageBoard
{
    public partial class responseDetailReply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.RequestStringNull("responseId"))
                {
                    Response.Redirect("Error.aspx");
                }
                lblIp.Text = Request.GetRealIp();
                lblPostTime.Text = DateTime.Now.ToString();
                txtTopic.Text = "Re:"+Request.QueryString["topic"]?.ToString();
            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["messageBoardConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand("insert into [responseFT](article,author,publishedDate,responseId,topic,ip) values (@article,@author,@publishedDate,@responseId,@topic,@ip)", conn);
                cmd.Parameters.Add(new SqlParameter("@article", System.Data.SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@author", System.Data.SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@publishedDate", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@responseId", System.Data.SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@topic", System.Data.SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@ip", System.Data.SqlDbType.NVarChar));
                
                cmd.Parameters["@article"].Value = txtArticle.Text;
                cmd.Parameters["@author"].Value = txtAlias.Text;
                cmd.Parameters["@topic"].Value = txtTopic.Text;
                cmd.Parameters["@publishedDate"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                cmd.Parameters["@responseId"].Value = Request.QueryString["responseId"];
                cmd.Parameters["@ip"].Value = Request.GetRealIp();

                conn.Open();
                cmd.ExecuteNonQuery();


            }
            Response.Redirect("responseDetail?id="+ Request.QueryString["responseId"]);
        }
    }
}