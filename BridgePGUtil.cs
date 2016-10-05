using System;
using System.Collections.Generic;

using System.Web;
using BridgePG;
using System.IO;
using System.Configuration;
using System.Net;
using System.Text;
using System.Xml;

namespace WebApplication2
{
    public static class BridgePGUtil
    {
        public static string CreateMessage(string merchant_id,
                                    string csc_id,
                                    string merchant_txn,
                                    string merchant_txn_date_time,
                                    string product_id,
                                    string product_name,
                                    string txn_amount,
                                    string amount_parameter,
                                    string txn_mode,
                                    string txn_type,
                                    string merchant_receipt_no,
                                    string csc_share_amount,
                                    string pay_to_email,
                                    string return_url,
                                    string cancel_url,
                                    string Currency,
                                    string Discount,
                                    string param_1,
                                    string param_2,
                                    string param_3,
                                    string param_4)
        {


            string postMessage = "merchant_id=" + merchant_id + "|"
                                + "csc_id=" + csc_id + "|"
                                + "merchant_txn=" + merchant_txn + "|"
                                + "merchant_txn_date_time=" + merchant_txn_date_time + "|"
                                + "product_id=" + product_id + "|"
                                + "product_name=" + product_name + "|"
                                + "txn_amount=" + txn_amount + "|"
                                + "amount_parameter=" + amount_parameter + "|"
                                + "txn_mode=" + txn_mode + "|"
                                + "txn_type=" + txn_type + "|"
                                + "merchant_receipt_no=" + merchant_receipt_no + "|"
                                + "csc_share_amount=" + csc_share_amount + "|"
                                + "pay_to_email=" + pay_to_email + "|"
                                + "return_url=" + return_url + "|"
                                + "cancel_url=" + cancel_url + "|"
                                + "Currency=" + Currency + "|"
                                + "Discount=" + Discount + "|"
                                + "param_1=" + param_1 + "|"
                                + "param_2=" + param_2 + "|"
                                + "param_3=" + param_3 + "|"
                                + "param_4=" + param_4 + "|";

            Crypto.privateKey = ConfigurationManager.AppSettings["PRIVATE_KEY"];
            Crypto.publicKey = ConfigurationManager.AppSettings["PUBLIC_KEY"];


            return Crypto.encrypt(postMessage, Crypto.publicKey, Crypto.privateKey);
        }

        public static string CreateURLappendString()
        {


            return ConfigurationManager.AppSettings["PAY_URL"] + BridgePG.Crypto.uriHash();
        }







        //2
        public static string transaction_enquiry(string merchant_id, string merchant_txn)
        {
            
            string data = "merchant_id=" + merchant_id + "|merchant_txn=" + merchant_txn + "|";
            Crypto.privateKey = ConfigurationManager.AppSettings["PRIVATE_KEY"];
            Crypto.publicKey = ConfigurationManager.AppSettings["PUBLIC_KEY"];
            string request_data = Crypto.encrypt(data, Crypto.publicKey, Crypto.privateKey);


            string response = "";
            XmlDocument req = new XmlDocument();

            XmlNode docNode = req.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            req.AppendChild(docNode);
            XmlNode xml = req.AppendChild(req.CreateElement("xml"));
            XmlNode merchant_id_node = xml.AppendChild(req.CreateElement("merchant_id"));
            merchant_id_node.InnerXml = merchant_id;
            XmlNode request_data_node = xml.AppendChild(req.CreateElement("request_data"));
            request_data_node.InnerXml = request_data;


            string appuri = ConfigurationManager.AppSettings["API_URL"] + "transaction/enquiry" + "/format/xml";

            callApi(appuri, req.OuterXml, ref  response);

            XmlDocument responsestr = new XmlDocument();

            responsestr.LoadXml(response);

            string result = responsestr.GetElementsByTagName("response_status")[0].InnerXml;
            if (result == "Success")
            {
                string response_data = responsestr.GetElementsByTagName("response_data")[0].InnerXml;

                response = Crypto.decrypt(response_data, Crypto.privateKey, Crypto.publicKey, true);


            }
            return response;
        }
        //3
        public static string transaction_status(string merchant_id, string merchant_txn, string csc_txn)
        {

            string data = "merchant_id=" + merchant_id + "|merchant_txn=" + merchant_txn + "|csc_txn=" + csc_txn + "|";
            Crypto.privateKey = ConfigurationManager.AppSettings["PRIVATE_KEY"];
            Crypto.publicKey = ConfigurationManager.AppSettings["PUBLIC_KEY"];
            string request_data = Crypto.encrypt(data, Crypto.publicKey, Crypto.privateKey);


            string response = "";
            XmlDocument req = new XmlDocument();

            XmlNode docNode = req.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            req.AppendChild(docNode);
            XmlNode xml = req.AppendChild(req.CreateElement("xml"));
            XmlNode merchant_id_node = xml.AppendChild(req.CreateElement("merchant_id"));
            merchant_id_node.InnerXml = merchant_id;
            XmlNode request_data_node = xml.AppendChild(req.CreateElement("request_data"));
            request_data_node.InnerXml = request_data;


            string appuri = ConfigurationManager.AppSettings["API_URL"] + "transaction/status" + "/format/xml";

            callApi(appuri, req.OuterXml, ref  response);



            XmlDocument responsestr = new XmlDocument();

            responsestr.LoadXml(response);

            string result = responsestr.GetElementsByTagName("response_status")[0].InnerXml;
            if (result == "Success")
            {
                string response_data = responsestr.GetElementsByTagName("response_data")[0].InnerXml;

                response = Crypto.decrypt(response_data, Crypto.privateKey, Crypto.publicKey, true);


            }

            return response;
        }
        //4
        public static string refund_log(string merchant_id, string merchant_txn, string csc_txn,
                   string merchant_txn_status, string merchant_reference, string refund_deduction, string refund_mode,
            string refund_type, string refund_trigger, string refund_reason)
        {

            string data = "merchant_id=" + merchant_id + "|merchant_txn=" + merchant_txn + "|csc_txn=" + csc_txn +
                   "|merchant_txn_status=" + merchant_txn_status + "|merchant_reference=" + merchant_reference +
                   "|refund_deduction=" + refund_deduction + "|refund_mode=" + refund_mode + "|refund_type=" + refund_type +
                   "|refund_trigger=" + refund_trigger + "|refund_reason=" + refund_reason + "|";
            Crypto.privateKey = ConfigurationManager.AppSettings["PRIVATE_KEY"];
            Crypto.publicKey = ConfigurationManager.AppSettings["PUBLIC_KEY"];
            string request_data = Crypto.encrypt(data, Crypto.publicKey, Crypto.privateKey);


            string response = "";
            XmlDocument req = new XmlDocument();

            XmlNode docNode = req.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            req.AppendChild(docNode);
            XmlNode xml = req.AppendChild(req.CreateElement("xml"));
            XmlNode merchant_id_node = xml.AppendChild(req.CreateElement("merchant_id"));
            merchant_id_node.InnerXml = merchant_id;
            XmlNode request_data_node = xml.AppendChild(req.CreateElement("request_data"));
            request_data_node.InnerXml = request_data;


            string appuri = ConfigurationManager.AppSettings["API_URL"] + "refund/log" + "/format/xml";

            callApi(appuri, req.OuterXml, ref  response);



            XmlDocument responsestr = new XmlDocument();

            responsestr.LoadXml(response);

            string result = responsestr.GetElementsByTagName("response_status")[0].InnerXml;
            if (result == "Success")
            {
                string response_data = responsestr.GetElementsByTagName("response_data")[0].InnerXml;

                response = Crypto.decrypt(response_data, Crypto.privateKey, Crypto.publicKey, true);


            }

            return response;
        }
        //5
        public static string refund_status(string merchant_id, string merchant_txn, string csc_txn, string refund_reference)
        {

            // Input String: merchant_id=1234|csc_txn=1234556|merchant_txn=12|refund_reference=1234567890|
            string data = "merchant_id=" + merchant_id + "|merchant_txn=" + merchant_txn + "|csc_txn=" + csc_txn + "|refund_reference=" + refund_reference + "|";
            Crypto.privateKey = ConfigurationManager.AppSettings["PRIVATE_KEY"];
            Crypto.publicKey = ConfigurationManager.AppSettings["PUBLIC_KEY"];
            string request_data = Crypto.encrypt(data, Crypto.publicKey, Crypto.privateKey);



            string response = "";
            XmlDocument req = new XmlDocument();

            XmlNode docNode = req.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            req.AppendChild(docNode);
            XmlNode xml = req.AppendChild(req.CreateElement("xml"));
            XmlNode merchant_id_node = xml.AppendChild(req.CreateElement("merchant_id"));
            merchant_id_node.InnerXml = merchant_id;
            XmlNode request_data_node = xml.AppendChild(req.CreateElement("request_data"));
            request_data_node.InnerXml = request_data;


            string appuri = ConfigurationManager.AppSettings["API_URL"] + "refund/status" + "/format/xml";
           // response = "APPURL:" + appuri + "     Request XML:    " + req.OuterXml.ToString();


            callApi(appuri, req.OuterXml, ref  response);


           // return "ffff" + response;
            XmlDocument responsestr = new XmlDocument();

            responsestr.LoadXml(response);

            string result = responsestr.GetElementsByTagName("response_status")[0].InnerXml;
            if (result == "Success")
            {
                string response_data = responsestr.GetElementsByTagName("response_data")[0].InnerXml;
                try
                {
                    response = Crypto.decrypt(response_data, Crypto.privateKey, Crypto.publicKey, true);
                }
                catch (Exception)
                {
                    return response;
                }


            }
            else
            {
                return response;
            }

            return response;
        }

        //6
        public static string recon_log(string merchant_id, string merchant_txn, string csc_txn, string cscuser_id,
            string product_id, string txn_amount, string merchant_date, string merchant_txn_status, string merchant_reciept)
        {



            string data = "merchant_id=" + merchant_id + "|merchant_txn=" + merchant_txn + "|csc_txn=" + csc_txn +
                "|cscuser_id=" + cscuser_id + "|product_id=" + product_id + "|txn_amount=" + txn_amount +
                 "|merchant_date=" + merchant_date + "|merchant_txn_status=" + merchant_txn_status + "|merchant_reciept=" + merchant_reciept + "|";
            Crypto.privateKey = ConfigurationManager.AppSettings["PRIVATE_KEY"];
            Crypto.publicKey = ConfigurationManager.AppSettings["PUBLIC_KEY"];
            string request_data = Crypto.encrypt(data, Crypto.publicKey, Crypto.privateKey);


            string response = "";
            XmlDocument req = new XmlDocument();

            XmlNode docNode = req.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            req.AppendChild(docNode);
            XmlNode xml = req.AppendChild(req.CreateElement("xml"));
            XmlNode merchant_id_node = xml.AppendChild(req.CreateElement("merchant_id"));
            merchant_id_node.InnerXml = merchant_id;
            XmlNode request_data_node = xml.AppendChild(req.CreateElement("request_data"));
            request_data_node.InnerXml = request_data;


            string appuri = ConfigurationManager.AppSettings["API_URL"] + "recon/log" + "/format/xml";

            callApi(appuri, req.OuterXml, ref  response);



            XmlDocument responsestr = new XmlDocument();

            responsestr.LoadXml(response);

            string result = responsestr.GetElementsByTagName("response_status")[0].InnerXml;
            if (result == "Success")
            {
                string response_data = responsestr.GetElementsByTagName("response_data")[0].InnerXml;

                response = Crypto.decrypt(response_data, Crypto.privateKey, Crypto.publicKey, true);


            }

            return response;
        }


        public static bool callApi(string url, string requestXML, ref string responseXML)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)(HttpWebRequest.Create(url));
                req.Method = "POST";
                req.ProtocolVersion = HttpVersion.Version11;
                req.ContentType = "application/xml";
                string content = requestXML;
                req.ContentLength = content.Length;
                Stream wri = req.GetRequestStream();
                byte[] array = Encoding.UTF8.GetBytes(content);
                wri.Write(array, 0, array.Length);
                wri.Flush();
                wri.Close();
                HttpWebResponse HttpWResp = (HttpWebResponse)req.GetResponse();
                int resCode = (int)HttpWResp.StatusCode;
                StreamReader reader = new StreamReader(HttpWResp.GetResponseStream(), System.Text.Encoding.UTF8);
                string resultData = reader.ReadToEnd();
                responseXML = resultData;
                return true;
            }
            catch (Exception ex)
            {
                responseXML = ex.Message;
                return false;
            }
        }

    }
}