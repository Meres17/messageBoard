using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace messageBoard
{
    public partial class postResponse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                lblIp.Text = Request.GetRealIp();
                lblPostTime.Text = DateTime.Now.ToString();

            }
            else
            {
                
            }
        }

 
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["messageBoardConnectionString"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into messageBoardFT (topic,author,article,publishedDate,ip) values (@topic,@author,@article,@publishedDate,@ip)";

                cmd.Parameters.Add(new SqlParameter("@topic", System.Data.SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@author", System.Data.SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@article", System.Data.SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@publishedDate", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@ip", System.Data.SqlDbType.NVarChar));


                cmd.Parameters["@topic"].Value = txtTopic.Text;
                cmd.Parameters["@author"].Value = txtAlias.Text;
                cmd.Parameters["@article"].Value = txtArticle.Text;
                cmd.Parameters["@publishedDate"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                cmd.Parameters["@ip"].Value = Request.GetRealIp();
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("messageBoard.aspx");
        }



    }
}