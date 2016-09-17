using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using csc_ecrdrc;

namespace ConnectPayment
{
     [Serializable]
    public class BridgePGUtil
    {
  
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
            objBridgePGUtil.txn_type = "D";
            objBridgePGUtil.csc_share_amount = "0";
            objBridgePGUtil.pay_to_email = "arvind.kumar@csc.gov.in";
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
            string strPRIVATE_KEY = ConfigurationManager.AppSettings["PRIVATE_KEY"];
            string strPUBLIC_KEY = ConfigurationManager.AppSettings["PUBLIC_KEY"];
            strPRIVATE_KEY = Base64Decode(strPRIVATE_KEY);
            strPUBLIC_KEY = Base64Decode(strPUBLIC_KEY);
            CryptoUtility.privateKeyString = strPRIVATE_KEY;
            CryptoUtility.publicKeyString = strPUBLIC_KEY;

            return CryptoUtility.encryptForWallet(postMessage, CryptoUtility.publicKeyString, CryptoUtility.privateKeyString); 
        }
        public string CreateURLappendString()
        {
            Int64 a = Convert.ToInt64(DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0')) * 883 + (1000 - 883);
            string returnvalue = ConfigurationManager.AppSettings["PAY_URL"] + a.ToString();
            return returnvalue;
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
     }
        
}
