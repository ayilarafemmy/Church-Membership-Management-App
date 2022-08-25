using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["Phone"] != null)
    {
      Label5.Text = Session["FirstName"].ToString();
    }
    else
    {
      Response.Redirect("Login.aspx");
    }
    string constring = ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString;
    using (SqlConnection con = new SqlConnection(constring))
    {
      string tt = DateTime.Now.ToString("MM/yyyy");
      using (SqlCommand cmd = new SqlCommand("select count(*) from Member_Data where Capture_Date like '%/"+tt+"'", con))
      {
        cmd.CommandType = CommandType.Text;
        con.Open();
        object o = cmd.ExecuteScalar();
        if (o != null)
        {
          Label1.Text = o.ToString();
        }
        con.Close();
      }
      string yy = DateTime.Now.ToString("MM");
      using (SqlCommand cmd = new SqlCommand("select count(*) from Member_Data where Birthday_Month ='"+yy+"'", con))
      {
        cmd.CommandType = CommandType.Text;
        con.Open();
        object o = cmd.ExecuteScalar();
        if (o != null)
        {
          Label2.Text = o.ToString();
        }
        con.Close();
      }
      using (SqlCommand cmd = new SqlCommand("SELECT count(*) from Member_Data", con))
      {
        cmd.CommandType = CommandType.Text;
        con.Open();
        object o = cmd.ExecuteScalar();
        if (o != null)
        {
          Label3.Text = o.ToString();
        }
        con.Close();
      }
      using (SqlCommand cmd = new SqlCommand("select count(*) from Member_Data where WorkerStatus ='Yes'", con))
      {
        cmd.CommandType = CommandType.Text;
        con.Open();
        object o = cmd.ExecuteScalar();
        if (o != null)
        {
          Label4.Text = o.ToString();
        }
        con.Close();
      }
      //  using (SqlCommand cmd = new SqlCommand("select count(*) from Member_Data where WorkerStatus ='Yes'", con))
      //  {
      //    cmd.CommandType = CommandType.Text;
      //    con.Open();
      //    object o = cmd.ExecuteScalar();
      //    if (o != null)
      //    {
      //      Label5.Text = o.ToString();
      //    }
      //    con.Close();
      //  }
    }
  }
}
