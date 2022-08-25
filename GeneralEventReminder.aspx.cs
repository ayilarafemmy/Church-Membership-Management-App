using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GeneralEventReminder : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);
    SqlCommand myCommand = new SqlCommand();
    myCommand.CommandType = CommandType.Text;
    myCommand.CommandText = "select a.Message as Message,b.recipient as name,b.phoneno as phone from GeneralMessages a,Generaldata b where a.id=1";
    myCommand.Connection = myConnection;
    SqlDataReader myReader;

    try
    {
      myConnection.Open();
      myReader = myCommand.ExecuteReader();
      while (myReader.Read())
      {
        //ListItem li = new ListItem();
        string Message = myReader["Message"].ToString();
        string name = myReader["name"].ToString();
        string phone = myReader["phone"].ToString();
        var subacct = "GARANTIA";
        var subacctpwd = "Garantia";
        var ownermail = "ayilarafemi@yahoo.com";
        var propertytrust = "08058000848";
        var sendto = "'" + phone + "'";



        var message = "Dear " + name + ","+Message+"";
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

  }
}
