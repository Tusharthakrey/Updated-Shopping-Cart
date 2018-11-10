using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Training_19Sep18_PuneConnectionString"].ConnectionString))
        {


            string query = "select count(1) from signup_161365 where email=@email AND password=@password  ";

            SqlCommand cmd = new SqlCommand(query, sqlcon);
            sqlcon.Open();
            cmd.Parameters.AddWithValue("@email", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1)
            {
                Session["user"] = TextBox1.Text.Trim();
                Response.Redirect("Default.aspx");
            }
            else
            {
                Label1.Text = "User not Found";
            }
        }
            
    }
}