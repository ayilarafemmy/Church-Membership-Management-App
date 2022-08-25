using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Event_Reminder : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    int month = System.DateTime.Now.Month;
    int day = System.DateTime.Now.Day;
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);

    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);
    SqlCommand myCommand = new SqlCommand();
    myCommand.CommandType = CommandType.Text;
    string joe = DateTime.Now.ToString("d/M/yyyy");
    myCommand.CommandText = "Select Event,Description,Time,MinisterName,MinisterPhone,Role from Events where Date = '" + joe + "'";
    myCommand.Connection = myConnection;
    SqlDataReader myReader;

    try
    {
      myConnection.Open();
      myReader = myCommand.ExecuteReader();
      while (myReader.Read())
      {
        //ListItem li = new ListItem();
        string Event = myReader["Event"].ToString();
        string Description = myReader["Description"].ToString();
        string Time = myReader["Time"].ToString();
        string MinisterName = myReader["MinisterName"].ToString();
        string MinisterPhone = myReader["MinisterPhone"].ToString();
        string Role = myReader["Role"].ToString();
        var subacct = "GARANTIA";
        var subacctpwd = "Garantia";
        var ownermail = "ayilarafemi@yahoo.com";
        var propertytrust = "08058000848";
        var sendto = "'" + MinisterPhone + "'";



        var message = "Dear " + MinisterName + ",You will be ministering at: " + Event + ",Starts by: " + Time + ",your role: " + Role + ".Shalom.RCCGOliveGardens";
        var senderid = "OliveGarden";
        string apicommand = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" + ownermail + "&subacct=" + subacct + "&subacctpwd=" + subacctpwd + "&message=" + message + "&sender=" + senderid + "&sendto=" + sendto + "&msgtype=0";
        System.Net.WebClient c = new System.Net.WebClient();
        var response = c.DownloadString(apicommand);

      }
      myReader.Close();
    }
    catch (Exception err)
    {
      Label1.Text = "Error: " + err + "";
      //Response.Write(err.ToString());
    }
    finally
    {
      myConnection.Close();
    }
    string update = "Update Events set Reminder = 'YES',Status = 'Closed' where Date='" + DateTime.Now.AddDays(-1).ToString("d/M/yyyy") + "'";
    insertRecord(update);

  }

  protected void Button1_Click(object sender, EventArgs e)
  {
    
  }
  string insertRecord(string query)
  {
    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);
    myConnection.Open();
    try
    {
      SqlCommand cmd = new SqlCommand(query, myConnection);
      cmd.ExecuteNonQuery();
      myConnection.Close();
      return "1";
    }
    catch (Exception ex)
    {
      //MessageBox("at INSERT " + ex.Message);
      return "0" + ex.Message;
    }
  }

}
