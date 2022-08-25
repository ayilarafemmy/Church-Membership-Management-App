using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class Events : System.Web.UI.Page
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
  }
  protected void GridviewBind()
  {
    string constring = ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString;
    using (SqlConnection con = new SqlConnection(constring))
    {
      con.Open();
      SqlCommand cmd = new SqlCommand("Select Event,Description,Time,Date,MinisterName,MinisterPhone,Role From Events Where Status IS NULL order by Datein asc", con);
      SqlDataReader dr = cmd.ExecuteReader();
      GridView2.DataSource = dr;
      GridView2.DataBind();
      con.Close();
    }
  }

  protected void Button1_Click(object sender, EventArgs e)
  {
    foreach (GridViewRow g1 in GridView1.Rows)
    {
      SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Church_MembershipConnectionString"].ConnectionString);
      SqlCommand com = new SqlCommand("insert into Events(Event,Description,Time,Date,MinisterName,MinisterPhone,Role,Datein) values ('" + g1.Cells[0].Text + "','" + g1.Cells[1].Text + "','" + g1.Cells[2].Text + "','" + g1.Cells[3].Text + "','" + g1.Cells[4].Text + "','" + g1.Cells[5].Text + "','" + g1.Cells[6].Text + "','"+DateTime.Now.ToShortDateString()+"')", con);
      con.Open();
      com.ExecuteNonQuery();
      con.Close();
    }
    lblConfirm.Text = "Records inserted successfully";
    MessageBox("Record Inserted Successfully");
    HtmlMeta meta = new HtmlMeta();
    meta.HttpEquiv = "Refresh";
    meta.Content = "1;url=Events.aspx";
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
  protected void PopulateGrid(object sender, EventArgs e)
  {
    // CHECK IF A FILE HAS BEEN SELECTED.
    if ((FileUpload1.HasFile))
    {
      if (!Convert.IsDBNull(FileUpload1.PostedFile) &
              FileUpload1.PostedFile.ContentLength > 0)
      {
        // SAVE THE SELECTED FILE IN THE ROOT DIRECTORY.
        FileUpload1.SaveAs(Server.MapPath(".") + "\\" + FileUpload1.FileName);

        // SET A CONNECTION WITH THE EXCEL FILE.
        OleDbConnection myExcelConn = new OleDbConnection
            ("Provider=Microsoft.ACE.OLEDB.12.0; " +
                "Data Source=" + Server.MapPath(".") + "\\" + FileUpload1.FileName +
                ";Extended Properties=Excel 12.0;");
        try
        {
          myExcelConn.Open();

          // GET DATA FROM EXCEL SHEET.
          OleDbCommand objOleDB =
              new OleDbCommand("SELECT *FROM [Sheet1$]", myExcelConn);

          // READ THE DATA EXTRACTED FROM THE EXCEL FILE.
          OleDbDataReader objBulkReader = null;
          objBulkReader = objOleDB.ExecuteReader();

          DataTable dt = new DataTable();
          dt.Load(objBulkReader);

          // FINALLY, BIND THE EXTRACTED DATA TO THE GRIDVIEW.
          GridView1.DataSource = dt;
          GridView1.DataBind();

          lblConfirm.Text = "PREVIEW GENERATED SUCCESSFULLY.";
          lblConfirm.Attributes.Add("style", "color:green");
        }
        catch (Exception ex)
        {
          // SHOW ERROR MESSAGE, IF ANY.
          lblConfirm.Text = ex.Message;
          lblConfirm.Attributes.Add("style", "color:red");
        }
        finally
        {
          // CLEAR.
          myExcelConn.Close(); myExcelConn = null;

          if(GridView1.Rows.Count >=1)
          {
            Button1.Visible = true;
          }
        }
      }
    }
  }
 
}
