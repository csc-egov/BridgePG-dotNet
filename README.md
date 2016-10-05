# BridgePG-dotNet
CSC Bridge PG Integration Kit in C# (.net)


Instructions:
*. Reset your password by using the link you have recieved via email.
*. Login to Merchant Center Portal: "portal.csccloud.in" and follow the below steps:

      Generate Connect Config. File
        1.Click on “CSC Connect”.
        2.Provide the Application Name, Call Back Url and upload the application logo and click on save button to add the application.
        3.Generate your Client ID by clicking on "Generate Client Id" button.
        4.Generate your Client Secret and Client Token.
        5.Click on save button to generate your Connect Config. File.
        6.Download the Connect Config. File.
        
     Generate Bridge Config. File
        1.Click on "CSC Bridge".
        2.Select "Key Manager" option.
        2.Generate keys by clicking on to the “Generate Keys” button.
        3.Download the Bridge Config. File.

Use these configuration file into your code.

The illustrated code sample below provides the understanding of using the dot net integration kit.

Step 1	Create an encrypted payment request as in example file. (payment.aspx)
```c#

      if (!string.IsNullOrEmpty(Convert.ToString(Session["Connectdata"])))
        {
            BridgePGUtil objBridgePGUtil = new BridgePGUtil();
            string merchant_id = ConfigurationManager.AppSettings["MERCHANT_ID"];
            string csc_id = Session["username"].ToString();
            string txn_amount = "50";
            string merchant_receipt_no = merchant_id + DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0');
            string return_url = ConfigurationManager.AppSettings["SUCCESS_URL"];
            string cancel_url = ConfigurationManager.AppSettings["FAILURE_URL"];
            string message = objBridgePGUtil.CreateMessage(merchant_id, csc_id, txn_amount, merchant_receipt_no, return_url, cancel_url);
            message = ConfigurationManager.AppSettings["MERCHANT_ID"] + "|" + message;
            Response.Clear();
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", objBridgePGUtil.CreateURLappendString());
            sb.AppendFormat("<input type='hidden' name='message' value='{0}'>", message);
            // Other params go here
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");
            Response.Write(sb.ToString());
            Response.End();


        }
        else
        {	
            Response.Write("Null Session");
        }
```
Request parameters are adequately set in provided library to their suitable default value. These values can be over written as shown. (BridgePGUtil.aspx)

```c#
    public class BridgePGUtil

        public string merchant_id { get; set; }
        public string csc_id { get; set; }
        public string merchant_receipt_no { get; set; }
        public string return_url { get; set; }
        public string cancel_url { get; set; }
        public string merchant_txn { get; set; }
        public string merchant_txn_date_time{get;set;}
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string txn_amount { get; set; }
        public string amount_parameter { get; set; }
        public string txn_mode { get; set; }
        public string txn_type { get; set; }
        public string csc_share_amount { get; set; }
        public string pay_to_email { get; set; }
        public string Currency { get; set; }
        public string Discount { get; set; }
        public string param_1 { get; set; }
        public string param_2 { get; set; }
        public string param_3 { get; set; }
        public string param_4 { get; set; }
        public string CreateMessage(string merchant_id,string csc_id, string txn_amount,string merchant_receipt_no,string return_url, string cancel_url)
        {
            string postMessage = string.Empty;
            BridgePGUtil objBridgePGUtil=new BridgePGUtil();
            List<BridgePGUtil> objListBridgePGUtil = new List<BridgePGUtil>();
            objBridgePGUtil.merchant_id = merchant_id;
            objBridgePGUtil.csc_id = csc_id;
            objBridgePGUtil.txn_amount = txn_amount;
            objBridgePGUtil.merchant_receipt_no = merchant_receipt_no;
            objBridgePGUtil.return_url = return_url;
            objBridgePGUtil.cancel_url = cancel_url;
            objBridgePGUtil.merchant_txn_date_time = DateTime.Now.Year.ToString().PadLeft(4, '0') + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Day.ToString().PadLeft(2, '0') + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0');
            objBridgePGUtil.merchant_txn = merchant_id + DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0');
            objBridgePGUtil.product_id = ConfigurationManager.AppSettings["product_id1"];
            objBridgePGUtil.product_name = ConfigurationManager.AppSettings["product_name1"];            
            objBridgePGUtil.amount_parameter = "NA";
            objBridgePGUtil.txn_mode = "D";
            objBridgePGUtil.txn_type = "1";
            objBridgePGUtil.csc_share_amount = "0";
            objBridgePGUtil.pay_to_email = "demomerchant@gmail.com";
            objBridgePGUtil.Currency = "INR";
            objBridgePGUtil.Discount = "0";
            objBridgePGUtil.param_1 = "NA";
            objBridgePGUtil.param_2 = "NA";
            objBridgePGUtil.param_3 = "NA";
            objBridgePGUtil.param_4 = "NA";
            objListBridgePGUtil.Add(objBridgePGUtil);

            for (int i = 0; i < objListBridgePGUtil.Count; i++)
            {
                postMessage = "merchant_id=" + objListBridgePGUtil[i].merchant_id + "|"
                                + "csc_id=" + objListBridgePGUtil[i].csc_id + "|"
                                + "merchant_txn=" + objListBridgePGUtil[i].merchant_txn + "|"
                                + "merchant_txn_date_time=" + objListBridgePGUtil[i].merchant_txn_date_time + "|"
                                + "product_id=" + objListBridgePGUtil[i].product_id + "|"
                                + "product_name=" + objListBridgePGUtil[i].product_name + "|"
                                + "txn_amount=" + objListBridgePGUtil[i].txn_amount + "|"
                                + "amount_parameter=" + objListBridgePGUtil[i].amount_parameter + "|"
                                + "txn_mode=" + objListBridgePGUtil[i].txn_mode + "|"
                                + "txn_type=" + objListBridgePGUtil[i].txn_type + "|"
                                + "merchant_receipt_no=" + objListBridgePGUtil[i].merchant_receipt_no + "|"
                                +"csc_share_amount=" + objListBridgePGUtil[i].csc_share_amount + "|"
                                + "pay_to_email=" + objListBridgePGUtil[i].pay_to_email + "|"
                                + "return_url=" + objListBridgePGUtil[i].return_url + "|"
                                + "cancel_url=" + objListBridgePGUtil[i].cancel_url + "|"
                                + "Currency=" + objListBridgePGUtil[i].Currency + "|"
                                + "Discount=" + objListBridgePGUtil[i].Discount + "|"
                                + "param_1=" + objListBridgePGUtil[i].param_1 + "|"
                                + "param_2=" + objListBridgePGUtil[i].param_2 + "|"
                                + "param_3=" + objListBridgePGUtil[i].param_3 + "|"
                                + "param_4=" + objListBridgePGUtil[i].param_4 + "|";                              

            }
            CryptoUtility.privateKeyString = ConfigurationManager.AppSettings["PRIVATE_KEY"];
            CryptoUtility.publicKeyString = ConfigurationManager.AppSettings["PUBLIC_KEY"];
            return CryptoUtility.encryptForWallet(postMessage, CryptoUtility.publicKeyString, CryptoUtility.privateKeyString); 
        }
        public string CreateURLappendString()
        {
            Int64 a = Convert.ToInt64(DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0')) * 883 + (1000 - 883);
            //Int64 a = Convert.ToInt32(DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0'))*883 +(1000-883);

            string returnvalue = ConfigurationManager.AppSettings["PAY_URL"] + a.ToString();
            return returnvalue;
        }
```

Step 2	Create a response as in example file. (payment_response.aspx)


public string bridgeResponseMessage = "Error ", drcResponse = "Error", walletResponseMessage = "", merchant_txn = "", merchant_txn_date_time = "", csc_txn = "", product_id = "", product_name = "", merchant_id = "", csc_id = "", txn_amount = "", pay_to_email = "", amount_parameter = "", txn_mode = "", txn_type = "", merchant_receipt_no = "", csc_share_amount = "", Currency = "", Discount = "", param_1 = "", param_2 = "", param_3 = "", param_4="";

protected void Page_Load(object sender, EventArgs e)
    {
                
        if (!string.IsNullOrEmpty(Convert.ToString(Session["Connectdata"])))
        {
            NameValueCollection nvc = Request.Form;
            if (!string.IsNullOrEmpty(nvc["bridgeResponseMessage"]))
            {                  

                bridgeResponseMessage = nvc["bridgeResponseMessage"];
                CryptoUtility.privateKeyString = ConfigurationManager.AppSettings["PRIVATE_KEY"];
                CryptoUtility.publicKeyString = ConfigurationManager.AppSettings["PUBLIC_KEY"];

                drcResponse = CryptoUtility.decryptFromWallet(bridgeResponseMessage, CryptoUtility.privateKeyString);
                string[] arr = drcResponse.Split("|".ToCharArray());
             
                for (int i = 0; i < arr.Length; i++)
                {
              
                    string[] arr2 = arr[i].Split("=".ToCharArray());
                    if (arr2[0] == "merchant_txn") merchant_txn = arr2[1];
                    if (arr2[0] == "merchant_txn_date_time") merchant_txn_date_time = arr2[1];
                    if (arr2[0] == "csc_txn") csc_txn = arr2[1];
                    if (arr2[0] == "product_id") product_id = arr2[1];
                    if (arr2[0] == "product_name") product_name = arr2[1];                    
                    if (arr2[0] == "merchant_id") merchant_id = arr2[1];
                    if (arr2[0] == "csc_id") csc_id = arr2[1];
                    if (arr2[0] == "txn_amount") txn_amount = arr2[1];
                    if (arr2[0] == "pay_to_email") pay_to_email = arr2[1];
                    if (arr2[0] == "amount_parameter") amount_parameter = arr2[1];
                    if (arr2[0] == "txn_mode") txn_mode = arr2[1];
                    if (arr2[0] == "txn_type") txn_type = arr2[1];
                    if (arr2[0] == "merchant_receipt_no") merchant_receipt_no = arr2[1];             
                    if (arr2[0] == "csc_share_amount") csc_share_amount = arr2[1];
                    if (arr2[0] == "Currency") Currency = arr2[1];
                    if (arr2[0] == "Discount") Discount = arr2[1];
                    if (arr2[0] == "param_1") param_1 = arr2[1];
                    if (arr2[0] == "param_2") param_2 = arr2[1];
                    if (arr2[0] == "param_3") param_3 = arr2[1];
                    if (arr2[0] == "param_4") param_4 = arr2[1];

                }
                SqlConnection con = null;
                con = BTSPL.DBConnccection.GetConnection();
                SqlCommand cmd = null;
                cmd = con.CreateCommand();
                SqlTransaction trans = null;
                try
                {

                    con.Open();
                    trans = con.BeginTransaction();
                    cmd.Transaction = trans;
                    cmd.CommandText = "Update_Txn";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@csc_txn", SqlDbType.VarChar).Value = csc_txn;
                    cmd.Parameters.AddWithValue("@merchant_txn", SqlDbType.VarChar).Value = merchant_txn;
                    cmd.ExecuteNonQuery();
                    trans.Commit();

                }
                catch (Exception ee)
                {
                    trans.Rollback();
                    string msg = ee.Message;
                    BTSPL.Message.Show(this.Page, msg);
                }
                finally
                {
                    trans.Dispose();
                    con.Dispose();
                    con.Close();

                }
                
              }
        }
        else
        {

                        
        }
    }

