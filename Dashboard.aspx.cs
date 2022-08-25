using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Dashboard : System.Web.UI.Page
{
  SqlCommand cmd = new SqlCommand();
  SqlDataAdapter sda = new SqlDataAdapter();
  DataSet ds = new DataSet();
  SqlConnection con = new SqlConnection();
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


  }

  protected void Button1_Click(object sender, EventArgs e)
  {
    if (DropDownList14.SelectedItem.Text == "Are You Joining Us")
    {
      MessageBox("Kindly select if The Individual is Joining Us");
      return;
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);
    con.Open();
    string name = TextBox3.Text;

    string checkUser = "select Count(*) from Member_Data where Phone = '" + name + "'";

    SqlCommand command = new SqlCommand(checkUser, con);
    int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
    if (temp >= 1)
    {
      MessageBox("Member Already exists");
    }
    else
    {
      SqlCommand cmd = new SqlCommand("Insert into Member_Data" + "(FirstName,LastName,Phone,email,Sex,Birthday_Day,Birthday_Month,Position,Unit1,Unit2,Unit3,Home_Address,Alt_Phone,Occupation,Office_Address,EmploymentStatus,BornAgain,Baptised,WorkerStatus,MaritalStatus,Capture_Date,CapturedBy,UserRole,Password,Salutation,JoinUs) values (@FirstName,@LastName,@Phone,@email,@Sex,@Birthday_Day,@Birthday_Month,@Position,@Unit1,@Unit2,@Unit3,@Home_Address,@Alt_Phone,@Occupation,@Office_Address,@EmploymentStatus,@BornAgain,@Baptised,@WorkerStatus,@MaritalStatus,@Capture_Date,@CapturedBy,@UserRole,@Password,@Salutation,@JoinUs)", con);
      cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
      cmd.Parameters.AddWithValue("@LastName", TextBox2.Text);
      cmd.Parameters.AddWithValue("@Phone", TextBox3.Text);
      cmd.Parameters.AddWithValue("@email", TextBox4.Text);
      cmd.Parameters.AddWithValue("@Sex", DropDownList1.SelectedItem.Text);
      cmd.Parameters.AddWithValue("@Birthday_Day", TextBox5.Text);
     // DateTime tt = DateTime.Now.ToString("dd/MM/yyyy");
      string tt = DateTime.Now.ToString("dd/MM/yyyy");
      cmd.Parameters.AddWithValue("@Birthday_Month", DropDownList2.SelectedValue);
      cmd.Parameters.AddWithValue("@Position", DropDownList3.SelectedItem.Text);
      cmd.Parameters.AddWithValue("@Unit1", DropDownList4.SelectedValue);
      cmd.Parameters.AddWithValue("@Unit2", DropDownList5.SelectedValue);
      cmd.Parameters.AddWithValue("@Unit3", DropDownList6.SelectedValue);
      cmd.Parameters.AddWithValue("@Home_Address", TextBox6.Text);
      cmd.Parameters.AddWithValue("@Alt_Phone", TextBox7.Text);
      cmd.Parameters.AddWithValue("@Occupation", TextBox8.Text);
      cmd.Parameters.AddWithValue("@Office_Address", TextBox9.Text);
      cmd.Parameters.AddWithValue("@EmploymentStatus", DropDownList7.SelectedValue);
      cmd.Parameters.AddWithValue("@BornAgain", DropDownList8.SelectedValue);
      cmd.Parameters.AddWithValue("@Baptised", DropDownList9.SelectedValue);
      cmd.Parameters.AddWithValue("@WorkerStatus", DropDownList10.SelectedValue);
      cmd.Parameters.AddWithValue("@MaritalStatus", DropDownList11.SelectedValue);
      cmd.Parameters.AddWithValue("@Capture_Date", tt);
      cmd.Parameters.AddWithValue("@CapturedBy", "Admin");
      cmd.Parameters.AddWithValue("@UserRole", DropDownList12.SelectedItem.Text);
      cmd.Parameters.AddWithValue("@Salutation", DropDownList13.SelectedValue);
      string os = CreateRandomPassword1(5);
      cmd.Parameters.AddWithValue("@Password", os);
      cmd.Parameters.AddWithValue("@JoinUs", DropDownList14.SelectedItem.Text);
      cmd.ExecuteNonQuery();
      MessageBox("Member Added Successfully!");
      con.Close();
      var subacct = "GARANTIA";
      var subacctpwd = "Garantia";
      var ownermail = "ayilarafemi@yahoo.com";
      var propertytrust = "08058000848";
      var sendto = "'" + TextBox3.Text + "'";
      var message = "Hello "+DropDownList13.SelectedItem.Text+" " + TextBox1.Text + " You have been registered as a Member of RCCG Olive Gardens, Your Username is: " + TextBox3.Text + " Password is:" + os + ".God Bless You";
      var senderid = "OliveGarden";
      string apicommand = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" + ownermail + "&subacct=" + subacct + "&subacctpwd=" + subacctpwd + "&message=" + message + "&sender=" + senderid + "&sendto=" + sendto + "&msgtype=0";
      System.Net.WebClient c = new System.Net.WebClient();
      var response = c.DownloadString(apicommand);

      string url = "http://www.rccgolivegardens.org.ng/cms";
      string web = "http://www.rccgolivegardens.org.ng";
      string body1 = "Dear "+DropDownList13.SelectedItem.Text+" " + TextBox1.Text + "," + Environment.NewLine + "With Joy in our heart, we welcome you once again to RCCG Olive Gardens, Lagos Province 69HQ.We will be praying for you and we will constantly provide you with information that will help you in your walk with our Lord Jesus Christ." + Environment.NewLine + " Feel Free to Login with your Credentials as below: " + Environment.NewLine + "" + Environment.NewLine + " Phone Number: " + TextBox3.Text + "  as your Username," + Environment.NewLine + " Password: " + os + " " + Environment.NewLine + " To view and Update your profile or get vital information about our programmes please login at: " + url + " " + Environment.NewLine + " For Further information, Kindly send an email to : info@rccgolivegardens.org.ng or Visit our Website : " + web + "";
      SendMail(TextBox4.Text, body1);


      System.Web.UI.HtmlControls.HtmlMeta meta = new HtmlMeta();
      meta.HttpEquiv = "Refresh";
      meta.Content = "1;url=Dashboard.aspx";
      this.Page.Controls.Add(meta);




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
    mail.Subject = "" + SenderID + " Olive Membership Registration Alert";
    mail.Body = body;
    SmtpServer.EnableSsl = true;
    SmtpServer.Port = joe;
    SmtpServer.Credentials = new System.Net.NetworkCredential("" + Senderemail + "", "" + Mail_Password + "");
    SmtpServer.EnableSsl = false;
    NetworkCredential NetworkCred = new NetworkCredential("" + Senderemail + "", "" + Mail_Password + "");
    SmtpServer.Send(mail);
  }


  public static string CreateRandomPassword1(int PasswordLength)

  {

    string _allowedChars = "L2TUVWX3MN14EFGHI678SYZ155773764524OPQR12503JABECDFJHIGTKLMONRSPUZWXYabcdefghijklmnopqrstuvwzxy";

    Random randNum = new Random();

    char[] chars = new char[PasswordLength];

    int allowedCharCount = _allowedChars.Length;

    for (int i = 0; i < PasswordLength; i++)

    {

      chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];

    }

    return new string(chars);

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
