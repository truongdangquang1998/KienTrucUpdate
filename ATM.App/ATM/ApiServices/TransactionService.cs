using ApiModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ATM.ApiServices
{
    public class TransactionService
    {
        private string _pathAPI;
        static HttpClient _client;
        public TransactionService()
        {
            _client = new HttpClient();
            _pathAPI = ConfigurationManager.AppSettings["WebApi"];
        }
        public ApiPaymentTransactionModel GetPaymentTransaction(string accountNumber, double payment, int atmId)
        {
            try
            {
                var loginStr = "";
                var repose = new ApiPaymentTransactionModel();
                string apilink = _pathAPI + string.Format("PaymentTransaction?accountNumber={0}&payment={1}&atmId={2}", accountNumber, payment, atmId);
                HttpResponseMessage response = _client.GetAsync(apilink).Result;
                if (response.IsSuccessStatusCode)
                {
                    loginStr = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    repose = serializer.Deserialize<ApiPaymentTransactionModel>(loginStr);
                }
                return repose;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ApiTransferTransactionModel GetTransferTransaction(string accountNumber, string beneficiary, double transfer, int atmId)
        {
            try
            {
                var loginStr = "";
                var repose = new ApiTransferTransactionModel();
                string apilink = _pathAPI + string.Format("TransferTransaction?accountNumber={0}&beneficiary={1}&transfer={2}&atmId={3}", accountNumber, beneficiary, transfer, atmId);
                HttpResponseMessage response = _client.GetAsync(apilink).Result;
                if (response.IsSuccessStatusCode)
                {
                    loginStr = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    repose = serializer.Deserialize<ApiTransferTransactionModel>(loginStr);
                }
                return repose;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ApiWithdrawlTransactionModel GetWithdrawlTransaction(string accountNumber, double withdrawl, int atmId)
        {
            try
            {
                var loginStr = "";
                var repose = new ApiWithdrawlTransactionModel();
                string apilink = _pathAPI + string.Format("WithdrawlTransaction?accountNumber={0}&withdrawl={1}&atmId={2}", accountNumber, withdrawl, atmId);
                HttpResponseMessage response = _client.GetAsync(apilink).Result;
                if (response.IsSuccessStatusCode)
                {
                    loginStr = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    repose = serializer.Deserialize<ApiWithdrawlTransactionModel>(loginStr);
                }
                return repose;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ApiChangePinTransactionModel GetChangePinTransaction(string accountNumber, string oldPass, string newPass)
        {
            try
            {
                var loginStr = "";
                var repose = new ApiChangePinTransactionModel();
                string apilink = _pathAPI + string.Format("ChangePinTransaction?accountNumber={0}&oldPass={1}&newPass={2}", accountNumber, oldPass, newPass);
                HttpResponseMessage response = _client.GetAsync(apilink).Result;
                if (response.IsSuccessStatusCode)
                {
                    loginStr = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    repose = serializer.Deserialize<ApiChangePinTransactionModel>(loginStr);
                }
                return repose;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ApiCheckBalanceTransactionModel GetCheckBalanceTransaction(string accountNumber)
        {
            try
            {
                var loginStr = "";
                var repose = new ApiCheckBalanceTransactionModel();
                string apilink = _pathAPI + string.Format("CheckBalanceTransaction?accountNumber={0}", accountNumber);
                HttpResponseMessage response = _client.GetAsync(apilink).Result;
                if (response.IsSuccessStatusCode)
                {
                    loginStr = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    repose = serializer.Deserialize<ApiCheckBalanceTransactionModel>(loginStr);
                }
                return repose;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ApiUserLoginModel> Get(string acount, string pass, int atmId)
        {
            try
            {

                var loginStr = "";
                var repose = new List<ApiUserLoginModel>();
                string apilink = _pathAPI + string.Format("Login?account={0}&pass={1}&atmId={2}", acount, pass, atmId);
                HttpResponseMessage response = _client.GetAsync(apilink).Result;
                if (response.IsSuccessStatusCode)
                {
                    loginStr = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    repose = serializer.Deserialize<List<ApiUserLoginModel>>(loginStr);
                }
                return repose;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Product product = new Product {  ProductName="123123", ProductPrice=50000 };

        //    var jsonContent = new JavaScriptSerializer().Serialize(product);
        //    POST("https://localhost:44348/api/product", jsonContent);
        //}
        public void POST(string url, string jsonContent)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);//json vao

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            long length = 0;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
