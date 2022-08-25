using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class allmembers : System.Web.UI.Page
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
    if(GridView1.Rows.Count >= 1)
    {
      Button1.Visible = true;
    }
  }
  public override void VerifyRenderingInServerForm(Control control)
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

    private void ExportGridToExcel()
  {
    Response.Clear();
    Response.Buffer = true;
    Response.ClearContent();
    Response.ClearHeaders();
    Response.Charset = "";
    string FileName = "AllMembers" + DateTime.Now + ".xls";
    StringWriter strwritter = new StringWriter();
    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.ContentType = "application/vnd.ms-excel";
    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
    GridView1.GridLines = GridLines.Both;
    GridView1.HeaderStyle.Font.Bold = true;
    GridView1.RenderControl(htmltextwrtter);
    Response.Write(strwritter.ToString());
    Response.End();

  }
  protected void GridviewBind()
  {
    string constring = ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString;
    using (SqlConnection con = new SqlConnection(constring))
    {
      con.Open();
      SqlCommand cmd = new SqlCommand("Select RefNo as MemberID, Salutation,FirstName,LastName,Phone,email,Sex,Birthday_Day as BirthDay,Birthday_Month as BirthMonth,Position,Unit1,Unit2,Unit3,Home_Address,Alt_Phone as AlternateNo,Occupation,Office_Address,EmploymentStatus,BornAgain,Baptised,WorkerStatus,Capture_Date as RegDate,CapturedBy,UserRole,WeddingAnnivDay,WeddingAnnivMonth,JoinUs as MembershipStatus from Member_Data", con);
      SqlDataReader dr = cmd.ExecuteReader();
      GridView1.DataSource = dr;
      GridView1.DataBind();
      con.Close();
    }
  }

  protected void Button1_Click(object sender, EventArgs e)
  {
    ExportGridToExcel();
  }


  protected void Button2_Click(object sender, EventArgs e)
  {
    Button1.Visible = false;
    Button3.Visible = true;
    TextBox1.Visible = true;
    GridView1.Visible = false;
    

  }

  protected void Button3_Click(object sender, EventArgs e)
  {
    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);
    SqlCommand myCommand = new SqlCommand();
    myCommand.CommandType = CommandType.Text;
    myCommand.CommandText = "select FirstName,LastName,Phone from Member_Data";
    myCommand.Connection = myConnection;
    SqlDataReader myReader;

    try
    {
      myConnection.Open();
      myReader = myCommand.ExecuteReader();
      while (myReader.Read())
      {
        //ListItem li = new ListItem();
        string FirstName = myReader["FirstName"].ToString();
        string LastName = myReader["LastName"].ToString();
        string Phone = myReader["Phone"].ToString();
        var subacct = "GARANTIA";
        var subacctpwd = "Garantia";
        var ownermail = "ayilarafemi@yahoo.com";
        var propertytrust = "08058000848";
        var sendto = "'" + Phone + "'";


        string oo = "";
        var message = "Dear " + FirstName + ""+oo+""+ LastName + "," + TextBox1.Text + "";
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
      HtmlMeta meta = new HtmlMeta();
      meta.HttpEquiv = "Refresh";
      meta.Content = "1;url=allmembers.aspx";
      this.Page.Controls.Add(meta);
    }

  
}

}
