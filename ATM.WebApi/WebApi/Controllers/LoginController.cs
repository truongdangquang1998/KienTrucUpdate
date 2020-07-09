using ApiModel;
using BusinessLogic.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class LoginController : ApiController
    {
        private readonly UserLoginBLL _bllUserLogin;
        public LoginController()
        {
            _bllUserLogin = new UserLoginBLL();
        }
        [Route("Login")]
        //[SwaggerResponse(200, "Returns detail login", typeof(ApiUserLoginModel))]
        //[SwaggerResponse(500, "Internal Server Error")]
        //[SwaggerResponse(400, "Bad Request")]
        //[SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]
        public IHttpActionResult Login(string account, string pass, int atmId)
        {
            var repose = _bllUserLogin.UserLogin(account, pass, atmId);
            return new HttpApiActionResult(HttpStatusCode.OK, repose);
        }
    }
}
