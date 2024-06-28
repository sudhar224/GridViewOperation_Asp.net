using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DataGridView_Operation
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		SqlConnection con = new SqlConnection("Data Source= DESKTOP-7TUTM2S\\SQLEXPRESS; Initial Catalog= DataGrid; Integrated Security = true;");
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void Button1_Click(object sender, EventArgs e)
        {
			con.Open();
			SqlCommand cmd = new SqlCommand("insert into gridView values ('" + TextBox1.Text + "','" + TextBox2.Text + "')", con);
			cmd.CommandType = CommandType.Text;
			cmd.ExecuteNonQuery();
			con.Close();
			Response.Redirect("WebForm1.aspx");

        }
    }
}