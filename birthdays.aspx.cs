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

public partial class birthdays : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["Phone"] != null)
    {
      if (Session["Role"].ToString() == "Member")
      {
        MessageBox("You are not authorized to access this Page!");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=Default.aspx";
        this.Page.Controls.Add(meta);
      }
    }
    else
    {
      Response.Redirect("Login.aspx");
    }

    GridviewBind();
    Labelq.Text = "" + DateTime.Now.ToString("MMMyyyy") + " Celebrants ";
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
  protected void GridviewBind()
  {
    string constring = ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString;
    using (SqlConnection con = new SqlConnection(constring))
    {
      string kunle = DateTime.Now.ToString("MM");
      con.Open();
      SqlCommand cmd = new SqlCommand("Select Salutation,FirstName,LastName,Phone,email,Birthday_Day as BirthDay from Member_Data where Birthday_Month ='"+kunle+"'", con);
      SqlDataReader dr = cmd.ExecuteReader();
      GridView1.DataSource = dr;
      GridView1.DataBind();
      con.Close();
    }
  }
}
