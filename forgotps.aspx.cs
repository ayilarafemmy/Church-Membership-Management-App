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

public partial class forgotps : System.Web.UI.Page
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
    cmd.CommandText = "select * from Member_Data where Phone='" + TextBox1.Text + "'";
    cmd.Connection = con;
    sda.SelectCommand = cmd;
    sda.Fill(ds, "Member_Data");



    if (ds.Tables[0].Rows.Count > 0)
    {
      Label3.Text= ds.Tables[0].Rows[0]["Password"].ToString();
      Label4.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
      Label5.Text = ds.Tables[0].Rows[0]["Email"].ToString();
      string body = "Dear "+Label4.Text+", Your Password on the Olive Membership portal is : "+Label3.Text+". Shalom";
      SendMail(Label5.Text, body);

      MessageBox("Password Sent to email "+Label5.Text+" Successfully");
      HtmlMeta meta = new HtmlMeta();
      meta.HttpEquiv = "Refresh";
      meta.Content = "1;url=login.aspx";
      this.Page.Controls.Add(meta);

    }
    else
    {
      MessageBox("Email " + TextBox1.Text + " Provided is not associated with any account!");
      return;
    }
  }
  public static void SendMail(string receiver, string body)
  {
    SqlCommand cmd = new SqlCommand();
    //SqlConnection cont = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlConnection cont = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);
    cont.Open();
    cmd.CommandText = "select * from MessagingCredentials where ID=1";
    cmd.Connection = cont;
    sda.SelectCommand = cmd;
    sda.Fill(ds, "MessagingCredentials");
    string ServerName = ds.Tables[0].Rows[0]["ServerName"].ToString();
    string Senderemail = ds.Tables[0].Rows[0]["Senderemail"].ToString();
    string SenderID = ds.Tables[0].Rows[0]["SenderID"].ToString();
    string ServerPort = ds.Tables[0].Rows[0]["ServerPort"].ToString();
    string Mail_Password = ds.Tables[0].Rows[0]["Mail_Password"].ToString();
    string SMS_ID = ds.Tables[0].Rows[0]["SMS_ID"].ToString();
    //Label2.Text = ds.Tables[0].Rows[0]["Admin_Email"].ToString();
    int joe = Convert.ToInt32(ServerPort);
    cont.Close();
    MailMessage mail = new MailMessage();
    SmtpClient SmtpServer = new SmtpClient("" + ServerName + "");
    mail.From = new MailAddress("" + Senderemail + "", "" + SenderID + "");
    mail.To.Add(receiver);
    mail.Subject = "" + SenderID + " Olive Members Portal - Forgot Password";
    mail.Body = body;
    SmtpServer.EnableSsl = true;
    SmtpServer.Port = joe;
    SmtpServer.Credentials = new System.Net.NetworkCredential("" + Senderemail + "", "" + Mail_Password + "");
    SmtpServer.EnableSsl = false;
    NetworkCredential NetworkCred = new NetworkCredential("" + Senderemail + "", "" + Mail_Password + "");
    SmtpServer.Send(mail);
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
