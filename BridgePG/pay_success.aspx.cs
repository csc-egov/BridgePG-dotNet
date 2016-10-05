using BridgePG;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class pay_success : System.Web.UI.Page
    {
        public string bridgeResponseMessage = "Error ", drcResponse = "Error", walletResponseMessage = "", merchant_txn = "", merchant_txn_date_time = "", csc_txn = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logedin"] != "true") Response.Redirect("login.aspx", true);

            NameValueCollection nvc = Request.Form;
            if (!string.IsNullOrEmpty(nvc["walletResponseMessage"]))
            {
                walletResponseMessage = nvc["walletResponseMessage"];



            }
            if (!string.IsNullOrEmpty(nvc["bridgeResponseMessage"]))
            {
                bridgeResponseMessage = nvc["bridgeResponseMessage"];
                Crypto.privateKey = ConfigurationManager.AppSettings["PRIVATE_KEY"];
                Crypto.publicKey = ConfigurationManager.AppSettings["PUBLIC_KEY"];

                drcResponse = Crypto.decrypt(bridgeResponseMessage, Crypto.privateKey, Crypto.publicKey, true);
                string[] arr = drcResponse.Split("|".ToCharArray());

                for (int i = 0; i < arr.Length; i++)
                {
                    string[] arr2 = arr[i].Split("=".ToCharArray());
                    if (arr2[0] == "merchant_txn") merchant_txn = arr2[1];
                    TextBoxmerchant_txn.Text = merchant_txn;
                    if (arr2[0] == "merchant_txn_date_time") merchant_txn_date_time = arr2[1];
                    TextBoxmerchant_txn_date_time.Text = merchant_txn_date_time;
                    if (arr2[0] == "csc_txn") csc_txn = arr2[1];
                    TextBoxcsc_txn.Text = csc_txn;
                    if (arr2[0] == "merchant_id") TextBoxmerchant_id.Text = arr2[1];
                    if (arr2[0] == "csc_id") TextBoxcsc_id.Text = arr2[1];
                    if (arr2[0] == "product_id") TextBoxproduct_id.Text = arr2[1];
                    if (arr2[0] == "txn_amount") TextBoxtxn_amount.Text = arr2[1];
                    if (arr2[0] == "amount_parameter") TextBoxamount_parameter.Text = arr2[1];
                    if (arr2[0] == "txn_mode") TextBoxtxn_mode.Text = arr2[1];
                    if (arr2[0] == "txn_type") TextBoxtxn_type.Text = arr2[1];
                    if (arr2[0] == "merchant_receipt_no") TextBoxmerchant_receipt_no.Text = arr2[1];
                    if (arr2[0] == "csc_share_amount") TextBoxcsc_share_amount.Text = arr2[1];

                }



            }





        }

        protected void ButtonTransaction_enquiry_Click(object sender, EventArgs e)
        {
            bridgeResponseMessage = "";
            drcResponse = "Response Transaction Enquiry: " + BridgePGUtil.transaction_enquiry(TextBoxmerchant_id.Text, TextBoxmerchant_txn.Text);

        }

        protected void ButtonTransaction_Status_Click(object sender, EventArgs e)
        {
            bridgeResponseMessage = "";
            drcResponse = "Response Transaction Status: " + BridgePGUtil.transaction_status(TextBoxmerchant_id.Text, TextBoxmerchant_txn.Text, TextBoxcsc_txn.Text);

        }

        protected void Buttonrefund_log_Click(object sender, EventArgs e)
        {
            try
            {
                bridgeResponseMessage = "";
                string res = BridgePGUtil.refund_log(TextBoxmerchant_id.Text, TextBoxmerchant_txn.Text, TextBoxcsc_txn.Text, "1", "2", "3", "4", "5", "6", "7");
                drcResponse = "Response Refund Log: " + res;
                //merchant_id=10001|merchant_reference=2|refund_reference=761727416093012174120821|response_status=Success
                try
                {
                    string[] arr = res.Split("|".ToCharArray());
                    if (arr[3].Split("=".ToCharArray())[1] == "Success")
                    {
                        TextBoxrefund_reference.Text = arr[2].Split("=".ToCharArray())[1];

                    }
                }
                catch (Exception)
                {
                    drcResponse = res;

                }
            }
            catch (Exception ex)
            {
                drcResponse = ex.Message;
            }

        }

        protected void Buttonrefund_status_Click(object sender, EventArgs e)
        {
            bridgeResponseMessage = "";
            if(TextBoxrefund_reference.Text.Length>0)
            drcResponse = "Response Refund Status: " + BridgePGUtil.refund_status(TextBoxmerchant_id.Text, TextBoxmerchant_txn.Text, TextBoxcsc_txn.Text,TextBoxrefund_reference.Text);

        }

        protected void Buttonrecon_log_Click(object sender, EventArgs e)
        {
            bridgeResponseMessage = "";
            drcResponse = "Response Recon Log  Status: " + BridgePGUtil.recon_log(TextBoxmerchant_id.Text, TextBoxmerchant_txn.Text, TextBoxcsc_txn.Text, TextBoxcsc_id.Text, TextBoxproduct_id.Text, TextBoxtxn_amount.Text, TextBoxmerchant_txn_date_time.Text, "Success", "R" + TextBoxmerchant_txn.Text.ToString());

        }
    }
}