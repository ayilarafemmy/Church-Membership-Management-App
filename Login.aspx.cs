using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Login2 : System.Web.UI.Page
{
  SqlCommand cmd = new SqlCommand();
  SqlConnection con = new SqlConnection();
  SqlDataAdapter sda = new SqlDataAdapter();
  DataSet ds = new DataSet();
  protected void Page_Load(object sender, EventArgs e)
  {

  }
  void MessageBox(string x)
  {
    // Label1.Text = x;
    try
    {
      string message = x;

      System.Text.StringBuilder sb = new System.Text.StringBuilder();

      sb.Append("<script type = 'text/javascript'>");

      sb.Append("window.onload=function(){");

      sb.Append("alert('");

      sb.Append(message);

      sb.Append("')};");

      sb.Append("</script>");

      ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());


    }
    catch (Exception ex)
    {

    }
  }


  protected void Button1_Click(object sender, EventArgs e)
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);
    con.Open();
    cmd.CommandText = "select * from Member_Data where Phone='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
    cmd.Connection = con;
    sda.SelectCommand = cmd;
    sda.Fill(ds, "Member_Data");



    if (ds.Tables[0].Rows.Count > 0)
    {
      Session["FirstName"] = ds.Tables[0].Rows[0]["FirstName"].ToString();
      Session["email"] = ds.Tables[0].Rows[0]["email"].ToString();
      Session["Phone"] = ds.Tables[0].Rows[0]["Phone"].ToString();
      Session["Role"] = ds.Tables[0].Rows[0]["UserRole"].ToString();
      Session["WorkerStatus"] = ds.Tables[0].Rows[0]["WorkerStatus"].ToString();
      string role = Session["Role"].ToString();
      if (role == "Member")
      {
        //MessageBox("Login Successful");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "1;url=Default.aspx";
        this.Page.Controls.Add(meta);
      }
      else
      {
        //MessageBox("Login Successful");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "1;url=Dashboard.aspx";
        this.Page.Controls.Add(meta);
      }



    }
    else
    {
      //ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme()", true);
      MessageBox("Kindly note that your registered phone number is your user name...Your Username and or Password is incorrect");
      HtmlMeta meta = new HtmlMeta();
      meta.HttpEquiv = "Refresh";
      meta.Content = "6;url=login.aspx";
      this.Page.Controls.Add(meta);
    }

    con.Close();
  }


  protected void LinkButton1_Click(object sender, EventArgs e)
  {
    Response.Redirect("forgotpss.aspx");
  }
}
