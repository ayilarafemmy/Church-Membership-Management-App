using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class forgotpss : System.Web.UI.Page
{
  SqlCommand cmd = new SqlCommand();
  SqlConnection con = new SqlConnection();
  SqlDataAdapter sda = new SqlDataAdapter();
  DataSet ds = new DataSet();
  protected void Page_Load(object sender, EventArgs e)
  {

  }

  protected void Button1_Click(object sender, EventArgs e)
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);
    con.Open();
    cmd.CommandText = "select * from Member_Data where Phone='" + TextBox1.Text + "' and email='"+TextBox2.Text+"'";
    cmd.Connection = con;
    sda.SelectCommand = cmd;
    sda.Fill(ds, "Member_Data");
    MessageBox("Validation Successful");

    if (ds.Tables[0].Rows.Count > 0)
    {
      TextBox3.Visible = true;
      Button2.Visible = true;
    

    }
    else
    {
      MessageBox("Email & Phone Provided is not associated with any account!");
      return;
    }
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
  string insertRecord(string query)
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);

    try
    {
      con.Open();

      SqlCommand cmd = new SqlCommand(query, con);
      cmd.ExecuteNonQuery();

      con.Close();
      return "1";

    }
    catch (Exception ex)
    {
      //MessageBox("at INSERT " + ex.Message);
      // UploadStatusLabel.Text = ex.Message;
      return "0" + ex.Message;
    }

  }

  protected void Button2_Click(object sender, EventArgs e)
  {
    string body = "Update Member_Data Set Password ='" + TextBox3.Text + "' where Phone='" + TextBox1.Text + "'";
    insertRecord(body);

    MessageBox("Password Changed Successfully");
    HtmlMeta meta = new HtmlMeta();
    meta.HttpEquiv = "Refresh";
    meta.Content = "1;url=login.aspx";
    this.Page.Controls.Add(meta);
  }

}
