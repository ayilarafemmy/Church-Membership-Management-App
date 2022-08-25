using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class profile : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

    if (Session["Phone"] != null)
    {
      //Label1.Text = Session["Fullname"].ToString();
    }
    else
    {
      Response.Redirect("Login.aspx");
    }
    GridviewBind();
  }
  protected void GridviewBind()
  {
    string constring = ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString;
    using (SqlConnection con = new SqlConnection(constring))
    {
      con.Open();
      SqlCommand cmd = new SqlCommand("Select RefNo as MemberID, Salutation,FirstName,LastName,Phone,email,Sex,Birthday_Day as BirthDay,Birthday_Month as BirthMonth,Position,Unit1,Unit2,Unit3,Home_Address,Alt_Phone as AlternateNo,Occupation,Office_Address,EmploymentStatus,BornAgain,Baptised,WorkerStatus,Capture_Date as RegDate,CapturedBy,UserRole,WeddingAnnivDay,WeddingAnnivMonth from Member_Data where Phone='"+ Session["Phone"].ToString()+ "'", con);
      SqlDataReader dr = cmd.ExecuteReader();
      GridView1.DataSource = dr;
      GridView1.DataBind();
      con.Close();
    }
  }

  protected void Button1_Click(object sender, EventArgs e)
  {
    string uu = "Update Member_Data Set Password='"+TextBox1.Text+"' where Phone='"+ Session["Phone"].ToString()+ "'";
    insertRecord(uu);
    MessageBox("Password Changed Successfully");
    HtmlMeta meta = new HtmlMeta();
    meta.HttpEquiv = "Refresh";
    meta.Content = "1;url=login.aspx";
    this.Page.Controls.Add(meta);
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
}
