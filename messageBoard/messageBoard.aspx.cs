using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            GridView1.DataBind();
        }


    }
}