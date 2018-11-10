using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AddtoCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("sno");
            dt.Columns.Add("ProductID");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("Price");
            dt.Columns.Add("ProductImage");
            dt.Columns.Add("cost");
            dt.Columns.Add("totalcost");

            if (Request.QueryString["id"] != null)
            {
                if (Session["Buyitems"] == null)
                {

                    dr = dt.NewRow();
                    String mycon = "Data Source=ndamssql\\sqlilearn;Initial Catalog=Training_19Sep18_Pune;Persist Security Info=True;User ID=sqluser;Password=sqluser";
                    SqlConnection scon = new SqlConnection(mycon);
                    String myquery = "select * from  ProductDetail_161365 where ProductID=" + Request.QueryString["id"];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = myquery;
                    cmd.Connection = scon;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dr["sno"] = 1;
                    dr["ProductID"] = ds.Tables[0].Rows[0]["ProductID"].ToString();
                    dr["ProductName"] = ds.Tables[0].Rows[0]["ProductName"].ToString();
                    dr["ProductImage"] = ds.Tables[0].Rows[0]["ProductImage"].ToString();
                    dr["Price"] = ds.Tables[0].Rows[0]["Price"].ToString();
                    dt.Rows.Add(dr);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    Session["buyitems"] = dt;
                }
                else
                {

                    dt = (DataTable)Session["buyitems"];
                    int sr;
                    sr = dt.Rows.Count;

                    dr = dt.NewRow();
                    String mycon = "Data Source=ndamssql\\sqlilearn;Initial Catalog=Training_19Sep18_Pune;Persist Security Info=True;User ID=sqluser;Password=sqluser";
                    SqlConnection scon = new SqlConnection(mycon);
                    String myquery = "select * from  ProductDetail_161365 where productid=" + Request.QueryString["id"];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = myquery;
                    cmd.Connection = scon;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dr["sno"] = sr + 1;
                    dr["ProductID"] = ds.Tables[0].Rows[0]["ProductID"].ToString();
                    dr["ProductName"] = ds.Tables[0].Rows[0]["ProductName"].ToString();
                    dr["ProductImage"] = ds.Tables[0].Rows[0]["ProductImage"].ToString();
                    dr["Price"] = ds.Tables[0].Rows[0]["Price"].ToString();
                    dt.Rows.Add(dr);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    Session["buyitems"] = dt;

                }
            }
            else
            {
                dt = (DataTable)Session["buyitems"];
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}