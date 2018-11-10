using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Signup : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
   

    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = "Data Source=ndamssql\\sqlilearn;Initial Catalog=Training_19Sep18_Pune;Persist Security Info=True;User ID=sqluser;Password=sqluser";
        con.Open();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("insert into signup_161365" + "(fname,lname,email,gender,address,phone,password) values (@fname,@lname,@email,@gender,@address,@phone,@password)", con);
        cmd.Parameters.AddWithValue("@fname", TextBox1.Text);
        cmd.Parameters.AddWithValue("@lname", TextBox2.Text);
        cmd.Parameters.AddWithValue("@email", TextBox3.Text);
        cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@address", TextBox4.Text);
        cmd.Parameters.AddWithValue("@phone", TextBox5.Text);
        cmd.Parameters.AddWithValue("@password", TextBox6.Text);
        cmd.ExecuteNonQuery();
        Label1.Text = "Signup Successfull.....";
        Response.Redirect("Default.aspx");
    }

    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {

    }
}