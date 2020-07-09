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
    public class StaffService
    {
        private string _pathAPI;
        static HttpClient _client;
        public StaffService()
        {
            _client = new HttpClient();
            _pathAPI = ConfigurationManager.AppSettings["WebApi"];
        }
        public ApiStaffCheckBalanceATMModel GetStaffCheckBalance(int atmId)
        {
            try
            {
                var loginStr = "";
                var repose = new ApiStaffCheckBalanceATMModel();
                string apilink = _pathAPI + string.Format("StaffCheckBalance?atmId={0}", atmId);
                HttpResponseMessage response = _client.GetAsync(apilink).Result;
                if (response.IsSuccessStatusCode)
                {
                    loginStr = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    repose = serializer.Deserialize<ApiStaffCheckBalanceATMModel>(loginStr);
                }
                return repose;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ApiPaymentTransactionModel GetPaymentTransaction(string accountNumber, double payment, int atmId)
        {
            try
            {
                var loginStr = "";
                var repose = new ApiPaymentTransactionModel();
                string apilink = _pathAPI + string.Format("StaffPaymentTransaction?accountNumber={0}&payment={1}&atmId={2}", accountNumber, payment, atmId);
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
        public ApiStaffTransactionStatisticsCustomerModel GetStaffTransactionStatistics(string accountNumber)
        {
            try
            {
                var loginStr = "";
                var repose = new ApiStaffTransactionStatisticsCustomerModel();
                string apilink = _pathAPI + string.Format("StaffTransactionStatistics?accountNumber={0}", accountNumber);
                HttpResponseMessage response = _client.GetAsync(apilink).Result;
                if (response.IsSuccessStatusCode)
                {
                    loginStr = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    repose = serializer.Deserialize<ApiStaffTransactionStatisticsCustomerModel>(loginStr);
                }
                return repose;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //public ApiJsonResult PostStaffAddCustomer(Customer customer, double money, AccountCard.AccountTypes types, int bankId)
        //{
        //StaffAddCustomer? money = 1 & types = 1 & bankId = 1
        //}


        //public ApiJsonResult PostResetPasswordCustomer(string account)
        //{
        //ResetPasswordCustomer? account = 1
        //}

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
