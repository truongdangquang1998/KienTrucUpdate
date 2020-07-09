using ApiModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ATM.ApiServices
{
    public class LoginService
    {
        private string _pathAPI;
        static HttpClient _client;
        public LoginService()
        {
            _client = new HttpClient();
            _pathAPI = ConfigurationManager.AppSettings["WebApi"];
        }
        public ApiUserLoginModel GetLoginAsync(string acount, string pass, int atmId)
        {
            try
            {
                var loginStr = "";
                var repose = new ApiUserLoginModel();
                string apilink = _pathAPI + string.Format("Login?account={0}&pass={1}&atmId={2}", acount, pass, atmId);
                HttpResponseMessage response = _client.GetAsync(apilink).Result;
                if (response.IsSuccessStatusCode)
                {
                    loginStr = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    repose = serializer.Deserialize<ApiUserLoginModel>(loginStr);
                }
                return repose;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
