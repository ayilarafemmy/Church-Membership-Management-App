using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WhatsAppApi;

public partial class test1 : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

  }


  protected void Button1_Click(object sender, EventArgs e)
  {
    WhatsApp wh = new WhatsApp(txtphone.Text, txtpass.Text, txtname.Text, true, true);
    wh.OnConnectSuccess += () =>
    {
      wh.OnLoginSuccess += (phone, data) =>
    {
      Label1.Text = "Sendig.....";
      wh.SendMessage(txtmobileno.Text, txtmsg.Text);
      Label1.Text = "Sent";
    };
    wh.OnLoginFailed += (data) =>
    {
      Label1.Text = string.Format("{0}", data);
    };
    wh.Login();
  };
  wh.OnConnectFailed += (ex) =>
            {
                Label1.Text = string.Format("{0}", ex.StackTrace);
};
wh.Connect();
    }

  protected void Button2_Click(object sender, EventArgs e)
  {
    string from = "2347031555678";
    string to = "2348058000848";
    string msg = "text";

    WhatsApp wa = new WhatsApp(from,"", "femi", false, false);

    wa.OnConnectSuccess += () =>
    {
      Label1.Text = "Connected to WhatsApp";

      wa.OnLoginSuccess += (phoneNumber, data) =>
      {
        wa.SendMessage(to, msg);
        Label1.Text = "SenT.....";
      };
      wa.OnLoginFailed += (data) =>
      {
        Label1.Text = string.Format("{0}", data);
      };
      wa.Login();
    };
    wa.OnConnectFailed += (ex) =>
    {
      Label1.Text = string.Format("{0}", ex.StackTrace);
    };
    wa.Connect();
  }



  protected void Button3_Click(object sender, EventArgs e)
  {
    //Label2.Text = DateTime.Now.ToString("d/M/yyyy");
    Label2.Text = DateTime.Now.AddDays(-1).ToString("d/M/yyyy");
  }

}



