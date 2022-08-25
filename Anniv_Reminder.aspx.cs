using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Anniv_Reminder : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    int month = System.DateTime.Now.Month;
    int day = System.DateTime.Now.Day;
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);

    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);
    SqlCommand myCommand = new SqlCommand();
    myCommand.CommandType = CommandType.Text;
    myCommand.CommandText = "Select FirstName,Phone,Birthday_Day,Birthday_Month from Member_Data where Birthday_Day = "+day+" and Birthday_Month = "+month+"";
    myCommand.Connection = myConnection;
    SqlDataReader myReader;

    try
    {
      myConnection.Open();
      myReader = myCommand.ExecuteReader();
      while (myReader.Read())
      {
        //ListItem li = new ListItem();
        string FN = myReader["FirstName"].ToString();
        string Phone= myReader["Phone"].ToString();

      string a = "The miracle is YOU!Happy birthday to someone driven by faith and love of Christ on this day and everyday.Happy Birthday.RCCGOlive";
        string b ="In that moment you take a breath before blowing out your candles, know that U are the greatest wish the Lord has made.Congrats.RCCGOlive";
        string p = "Every day is a gift from God, but on your birthday it comes with special wishes. All our love on your birthday.RCCG Olive";
        string d = "There are no birthday gifts as glorious as the one God gave to us all on this day when you were born.Congrats.RCCGOlive";
        string g= "With long life I will satisfy him and show him my salvation—Psalm 91:16.Happy Birthday and be blessed!.RCCGOlive";
        string f= "Blessings to you and may you feel the presence of the Lord as we all celebrate you on this day!.Congrats.RCCGOlive";
        var subacct = "GARANTIA";
        var subacctpwd = "Garantia";
        var ownermail = "ayilarafemi@yahoo.com";
        var propertytrust = "08058000848";
        var sendto = "'" + Phone + "'";
        string joe = CreateRandomPassword1(1);

        
        var message = "Dear " + FN + ",The miracle is YOU!Happy birthday to someone driven by faith and love of Christ on this day and everyday.Happy Birthday.RCCGOlive";
        var senderid = "LP69-Olive";
        string apicommand = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" + ownermail + "&subacct=" + subacct + "&subacctpwd=" + subacctpwd + "&message=" + message + "&sender=" + senderid + "&sendto=" + sendto + "&msgtype=0";
        System.Net.WebClient c = new System.Net.WebClient();
        var response = c.DownloadString(apicommand);

      }
      myReader.Close();
    }
    catch (Exception err)
    {
      //MessageBox("Error: " + err + "");
      //Response.Write(err.ToString());
    }
    finally
    {
      myConnection.Close();
    }

  
}

  public static string CreateRandomPassword1(int PasswordLength)

  {

    string _allowedChars = "abpdfg";

    Random randNum = new Random();

    char[] chars = new char[PasswordLength];

    int allowedCharCount = _allowedChars.Length;

    for (int i = 0; i < PasswordLength; i++)

    {

      chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];

    }

    return new string(chars);

  }
  protected void Button1_Click(object sender, EventArgs e)
  {
    int month = System.DateTime.Now.Month;
    int day = System.DateTime.Now.Day;
    Label1.Text = month.ToString();
    //Label2.Text = day.ToString();
    string a = "The miracle is YOU!Happy birthday to someone driven by faith and love of Christ on this day and everyday.Happy Birthday.RCCGOlive";
    string b = "In that moment you take a breath before blowing out your candles, know that U are the greatest wish the Lord has made.Congrats.RCCGOlive";
    string p = "Every day is a gift from God, but on your birthday it comes with special wishes. All our love on your birthday.RCCG Olive";
    string d = "There are no birthday gifts as glorious as the one God gave to us all on this day when you were born.Congrats.RCCGOlive";
    string g = "With long life I will satisfy him and show him my salvation—Psalm 91:16.Happy Birthday and be blessed!.RCCGOlive";
    string f = "Blessings to you and may you feel the presence of the Lord as we all celebrate you on this day!.Congrats.RCCGOlive";
 
    string joe = CreateRandomPassword1(1);
    if(joe==a)
    {
      Label2.Text = a.ToString();
    }
    if (joe == b)
    {
      Label2.Text = b.ToString();
    }
    if (joe == p)
    {
      Label2.Text = p.ToString();
    }
    if (joe == d)
    {
      Label2.Text = d.ToString();
    }
    if (joe == g)
    {
      Label2.Text = g.ToString();
    }
    if (joe == f)
    {
      Label2.Text = f.ToString();
    }

  }
}
