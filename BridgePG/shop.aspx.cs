using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class shop : System.Web.UI.Page
    {
        public string message = "";
        public string posturl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((string)Session["logedin"] != "true")
                { }

            }
            catch (Exception)
            {
                Session["logedin"] = "false";



            }


            try
            {

                if (Session["logedin"] == "true")
                {
                    LinkButton1.Text = "LogOut";

                }
                else
                {

                    LinkButton1.Text = "Login";
                }


            }
            catch (Exception)
            {
                LinkButton1.Text = "Login";


            }




        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string)Session["logedin"] != "true") Response.Redirect("login.aspx", true);
                else
                {

                    string merchant_id = ConfigurationManager.AppSettings["merchant_id"];
                    string csc_id = Session["username"].ToString();
                    string merchant_txn = merchant_id + DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0');
                    string merchant_txn_date_time = DateTime.Now.Year.ToString().PadLeft(4, '0') + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Day.ToString().PadLeft(2, '0') + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0');
                    string product_id = ConfigurationManager.AppSettings["product_id1"];
                    string product_name = ConfigurationManager.AppSettings["product_name1"];
                    string txn_amount = "50";
                    string amount_parameter = "NA";
                    string txn_mode = "D";
                    string txn_type = "D";
                    string merchant_receipt_no = merchant_id + DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0');
                    string csc_share_amount = "0";
                    string pay_to_email = "a@abc.com";
                    string return_url = ConfigurationManager.AppSettings["SUCCESS_URL"];
                    string cancel_url = ConfigurationManager.AppSettings["pay_cancel_uri"];
                    string Currency = "INR";
                    string Discount = "0";
                    string param_1 = "NA";
                    string param_2 = "NA";
                    string param_3 = "NA";
                    string param_4 = "NA";



                    string message = BridgePGUtil.CreateMessage(merchant_id, csc_id, merchant_txn, merchant_txn_date_time, product_id,
                                         product_name, txn_amount, amount_parameter, txn_mode, txn_type, merchant_receipt_no,
                                         csc_share_amount, pay_to_email, return_url, cancel_url, Currency, Discount, param_1,
                                         param_2, param_3, param_4);

                    message = ConfigurationManager.AppSettings["merchant_id"] + "|" + message;

                    Response.Clear();

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<html>");
                    sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
                    sb.AppendFormat("<form name='form' action='{0}' method='post'>", BridgePGUtil.CreateURLappendString());
                    sb.AppendFormat("<input type='hidden' name='message' value='{0}'>", message);
                    sb.Append("</form>");
                    sb.Append("</body>");
                    sb.Append("</html>");
                    string strpost = sb.ToString();

                    Response.Write(strpost);

                    Response.End();





                }
            }
            catch (Exception)
            {


            }






        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string)Session["logedin"] != "true") Response.Redirect("login.aspx", true);
                else
                {
                    string merchant_id = ConfigurationManager.AppSettings["merchant_id"];
                    string csc_id = Session["username"].ToString();
                    string merchant_txn = merchant_id + DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0');
                    string merchant_txn_date_time = DateTime.Now.Year.ToString().PadLeft(4, '0') + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Day.ToString().PadLeft(2, '0') + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0');
                    string product_id = ConfigurationManager.AppSettings["product_id3"];
                    string product_name = ConfigurationManager.AppSettings["product_name3"];
                    string txn_amount = "100";
                    string amount_parameter = "NA";
                    string txn_mode = "D";
                    string txn_type = "D";
                    string merchant_receipt_no = merchant_id + DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0');
                    string csc_share_amount = "0";
                    string pay_to_email = "a@abc.com";
                    string return_url = ConfigurationManager.AppSettings["SUCCESS_URL"];
                    string cancel_url = ConfigurationManager.AppSettings["pay_cancel_uri"];
                    string Currency = "INR";
                    string Discount = "0";
                    string param_1 = "NA";
                    string param_2 = "NA";
                    string param_3 = "NA";
                    string param_4 = "NA";



                    string message = BridgePGUtil.CreateMessage(merchant_id, csc_id, merchant_txn, merchant_txn_date_time, product_id,
                                         product_name, txn_amount, amount_parameter, txn_mode, txn_type, merchant_receipt_no,
                                         csc_share_amount, pay_to_email, return_url, cancel_url, Currency, Discount, param_1,
                                         param_2, param_3, param_4);

                    message = ConfigurationManager.AppSettings["merchant_id"] + "|" + message;


                    Response.Clear();

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<html>");
                    sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
                    sb.AppendFormat("<form name='form' action='{0}' method='post'>", BridgePGUtil.CreateURLappendString());
                    sb.AppendFormat("<input type='hidden' name='message' value='{0}'>", message);
                    sb.Append("</form>");
                    sb.Append("</body>");
                    sb.Append("</html>");

                    Response.Write(sb.ToString());

                    Response.End();





                }
            }
            catch (Exception)
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string)Session["logedin"] != "true") Response.Redirect("login.aspx", true);
                else
                {
                    string merchant_id = ConfigurationManager.AppSettings["merchant_id"];
                    string csc_id = Session["username"].ToString();
                    string merchant_txn = merchant_id + DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0');
                    string merchant_txn_date_time = DateTime.Now.Year.ToString().PadLeft(4, '0') + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Day.ToString().PadLeft(2, '0') + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0');
                    string product_id = ConfigurationManager.AppSettings["product_id2"];
                    string product_name = ConfigurationManager.AppSettings["product_name2"];
                    string txn_amount = "150";
                    string amount_parameter = "NA";
                    string txn_mode = "D";
                    string txn_type = "D";
                    string merchant_receipt_no = merchant_id + DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0');
                    string csc_share_amount = "0";
                    string pay_to_email = "a@abc.com";
                    string return_url = ConfigurationManager.AppSettings["SUCCESS_URL"];
                    string cancel_url = ConfigurationManager.AppSettings["pay_cancel_uri"];
                    string Currency = "INR";
                    string Discount = "0";
                    string param_1 = "NA";
                    string param_2 = "NA";
                    string param_3 = "NA";
                    string param_4 = "NA";



                    string message = BridgePGUtil.CreateMessage(merchant_id, csc_id, merchant_txn, merchant_txn_date_time, product_id,
                                         product_name, txn_amount, amount_parameter, txn_mode, txn_type, merchant_receipt_no,
                                         csc_share_amount, pay_to_email, return_url, cancel_url, Currency, Discount, param_1,
                                         param_2, param_3, param_4);

                    message = ConfigurationManager.AppSettings["merchant_id"] + "|" + message;


                    Response.Clear();

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<html>");
                    sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
                    sb.AppendFormat("<form name='form' action='{0}' method='post'>", BridgePGUtil.CreateURLappendString());
                    sb.AppendFormat("<input type='hidden' name='message' value='{0}'>", message);
                    sb.Append("</form>");
                    sb.Append("</body>");
                    sb.Append("</html>");

                    Response.Write(sb.ToString());

                    Response.End();





                }
            }
            catch (Exception)
            {

            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Session["logedin"] != "true")
            {
                Response.Redirect("login.aspx", true);

            }
            else
            {
                Session["logedin"] = "false";
                LinkButton1.Text = "Login";

            }
        }
    }
}