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

public partial class Message : System.Web.UI.Page
{
  SqlCommand cmd = new SqlCommand();
  SqlConnection con = new SqlConnection();
  SqlDataAdapter sda = new SqlDataAdapter();
  DataSet ds = new DataSet();
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

    if (DropDownList1.SelectedItem.Text == "Defined Messages")
    {

    }
    else
    {
      SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);
      con.Open();
      cmd.CommandText = "Select Message from GeneralMessages where id='" + DropDownList1.SelectedValue + "'";
      cmd.Connection = con;
      sda.SelectCommand = cmd;
      sda.Fill(ds, "GeneralMessages");



      if (ds.Tables[0].Rows.Count > 0)
      {
        Label2.Text = ds.Tables[0].Rows[0]["Message"].ToString();
      }
      con.Close();

      if (Label2.Text == "")
      {
        Label2.Text = "No Message Set yet for this " + DropDownList1.SelectedItem.Text + ", Contact the Administrators";
      }

    }
    string constringS = ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString;
    using (SqlConnection conS = new SqlConnection(constringS))
    {
      using (SqlCommand cmdS = new SqlCommand("select count(id) from GeneralData", conS))
      {
        cmdS.CommandType = CommandType.Text;
        conS.Open();
        object o = cmdS.ExecuteScalar();
        if (o != null)
        {
          Label1.Text = o.ToString();
        }
        conS.Close();


      }
    }
  }
     
  protected void Button1_Click(object sender, EventArgs e)
  {
      if(DropDownList1.SelectedItem.Text== "Defined Messages")
    {
      TextBox1.Visible = false;
      Button2.Visible = false;
      Button3.Visible = false;
      MessageBox("Kindly select Defined Message to be edited");
      return;
      
    }
      else
    {
      TextBox1.Visible = true;
      Button2.Visible = true;
      Button3.Visible = true;


    }
  }


  protected void Button2_Click(object sender, EventArgs e)
  {
    string query = "Update GeneralMessages set Message='" + TextBox1.Text + "',Updateby='" + Session["Phone"].ToString() + "',Updatedate='" + DateTime.Now.ToString() + "' where ID='" + DropDownList1.SelectedValue + "'";
    insertRecord(query);
    MessageBox("" + DropDownList1.SelectedItem.Text + " Updated Successfully");
    HtmlMeta meta = new HtmlMeta();
    meta.HttpEquiv = "Refresh";
    meta.Content = "0;url=Message.aspx";
    this.Page.Controls.Add(meta);
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


  protected void Button3_Click(object sender, EventArgs e)
  {
    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);
    SqlCommand myCommand = new SqlCommand();
    myCommand.CommandType = CommandType.Text;
    myCommand.CommandText = "select a.Message as Message,b.recipient as name,b.phoneno as phone from GeneralMessages a,Generaldata b where a.id="+DropDownList1.SelectedValue+"";
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



        var message = "Dear " + name + "," + Message + "";
        var senderid = "OliveGarden";
        string apicommand = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" + ownermail + "&subacct=" + subacct + "&subacctpwd=" + subacctpwd + "&message=" + message + "&sender=" + senderid + "&sendto=" + sendto + "&msgtype=0";
        System.Net.WebClient c = new System.Net.WebClient();
        var response = c.DownloadString(apicommand);

      }
      myReader.Close();
      MessageBox("Message(s) sent successfully");
      HtmlMeta meta = new HtmlMeta();
      meta.HttpEquiv = "Refresh";
      meta.Content = "1;url=Message.aspx";
      this.Page.Controls.Add(meta);
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
