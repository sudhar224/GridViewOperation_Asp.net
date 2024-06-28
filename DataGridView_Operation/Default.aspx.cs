using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataGridView_Operation
{
	public partial class Default : System.Web.UI.Page
	{
		string consrt = ("Data Source= DESKTOP-7TUTM2S\\SQLEXPRESS; Initial Catalog= DataGrid; Integrated Security = true;");
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				ShowGridView();
			}
		}

		public void ShowGridView()
		{
			try
			{
				using (SqlConnection con = new SqlConnection(consrt))
				{
					SqlCommand cmd = new SqlCommand("select * from PhoneBook", con);
					con.Open();
					SqlDataAdapter sda = new SqlDataAdapter(cmd);
					DataTable dtbl = new DataTable();
					sda.Fill(dtbl);

					if(dtbl.Rows.Count > 0)
					{
						gvPhoneBook.DataSource = dtbl;
						gvPhoneBook.DataBind();
					}
					else
					{
						dtbl.Rows.Add(dtbl.NewRow());
						gvPhoneBook.DataSource = dtbl;
						gvPhoneBook.DataBind();
						gvPhoneBook.Rows[0].Cells.Clear();
						gvPhoneBook.Rows[0].Cells.Add(new TableCell());
						gvPhoneBook.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
						gvPhoneBook.Rows[0].Cells[0].Text = "No Data Found..!";
						gvPhoneBook.Rows[0].Cells[0].HorizontalAlign= HorizontalAlign.Center;

					}
					
				}

			}
			catch(Exception ex) 
			{
				lblErrorMessage.Text = ex.Message;
			}
		}

		protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			try
			{
				if(e.CommandName.Equals ("AddNew"))
				{
					using (SqlConnection con = new SqlConnection(consrt))
					{
						con.Open();
						string query = "insert into PhoneBook (first_name,last_name,contact,email) values (@first_name,@last_name,@contact,@email)";
						SqlCommand cmd = new SqlCommand(query, con);
						cmd.Parameters.AddWithValue("@first_name", (gvPhoneBook.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
						cmd.Parameters.AddWithValue("@last_name", (gvPhoneBook.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
						cmd.Parameters.AddWithValue("@contact",(gvPhoneBook.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim());
						cmd.Parameters.AddWithValue("@email", (gvPhoneBook.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
						cmd.ExecuteNonQuery();
						ShowGridView();
						lblSuccessMessage.Text = "New Record Added";
						lblErrorMessage.Text = "";

					}
				}
				
			}
			catch(Exception ex)
			{
				lblSuccessMessage.Text = "";
				lblErrorMessage.Text = ex.Message;
			}
		}

		protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
		{
			gvPhoneBook.EditIndex = e.NewEditIndex;
			ShowGridView();
		}

		protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			gvPhoneBook.EditIndex = -1;
			ShowGridView();
		}

		

		protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(consrt))
				{
					con.Open();
					string query = "delete from PhoneBook where phone_book_id = @id";
					SqlCommand cmd = new SqlCommand(query, con);
					cmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
					cmd.ExecuteNonQuery();
					gvPhoneBook.EditIndex = -1;
					ShowGridView();
					lblSuccessMessage.Text = "Selected Record Deleted";
					lblErrorMessage.Text = "";
					con.Close();
				}
			}
			catch (Exception ex)
			{
				lblSuccessMessage.Text = "";
				lblErrorMessage.Text = ex.Message;
			}
		}

		protected void gvPhoneBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(consrt))
				{
					con.Open();
					string query = "update PhoneBook set first_name = @first_name,last_name = @last_name,contact = @contact,email = @email where phone_book_id = @id";
					SqlCommand cmd = new SqlCommand(query, con);
					cmd.Parameters.AddWithValue("@first_name", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
					cmd.Parameters.AddWithValue("@last_name", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
					cmd.Parameters.AddWithValue("@contact", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim());
					cmd.Parameters.AddWithValue("@email", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
					cmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
					cmd.ExecuteNonQuery();
					gvPhoneBook.EditIndex = -1;
					ShowGridView();
					lblSuccessMessage.Text = "Updated Record Successfully";
					lblErrorMessage.Text = "";
					con.Close();
				}
			}
			catch (Exception ex)
			{
				lblSuccessMessage.Text = "";
				lblErrorMessage.Text = ex.Message;
			}
		}
	}
}