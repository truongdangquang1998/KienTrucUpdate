using BusinessLogic.TransactionBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class TransactionController : ApiController
    {
        private readonly PaymentTransactionBLL _bllPaymentTransaction;
        private readonly TransferTransactionBLL _bllPransferTransaction;
        private readonly WithdrawlTransactionBLL _bllWithdrawlTransaction;
        private readonly ChangePinTransactionBLL _bllChangePinTransaction;
        private readonly CheckBalanceTransactionBLL _bllCheckBalanceTransactionBLL;
        public TransactionController()
        {
            _bllPaymentTransaction = new PaymentTransactionBLL();
            _bllPransferTransaction = new TransferTransactionBLL();
            _bllWithdrawlTransaction = new WithdrawlTransactionBLL();
            _bllChangePinTransaction = new ChangePinTransactionBLL();
            _bllCheckBalanceTransactionBLL = new CheckBalanceTransactionBLL();

        }
        [Route("PaymentTransaction")]
        //[SwaggerResponse(200, "Returns detail payment", typeof(ApiPaymentTransactionModel))]
        //[SwaggerResponse(500, "Internal Server Error")]
        //[SwaggerResponse(400, "Bad Request")]
        //[SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]
        public IHttpActionResult PaymentTransaction(string accountNumber, double payment, int atmId)
        {
            var repose = _bllPaymentTransaction.PaymentTransaction(accountNumber, payment, atmId);
            return new HttpApiActionResult(HttpStatusCode.OK, repose);
        }
        [Route("TransferTransaction")]
        //[SwaggerResponse(200, "Returns detail transfer", typeof(ApiTransferTransactionModel))]
        //[SwaggerResponse(500, "Internal Server Error")]
        //[SwaggerResponse(400, "Bad Request")]
        //[SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]
        public IHttpActionResult TransferTransaction(string accountNumber, string beneficiary, double transfer, int atmId)
        {
            var repose = _bllPransferTransaction.TransferTransaction(accountNumber, beneficiary, transfer, atmId);
            return new HttpApiActionResult(HttpStatusCode.OK, repose);
        }
        [Route("WithdrawlTransaction")]
        //[SwaggerResponse(200, "Returns detail withdrawl", typeof(ApiWithdrawlTransactionModel))]
        //[SwaggerResponse(500, "Internal Server Error")]
        //[SwaggerResponse(400, "Bad Request")]
        //[SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]
        public IHttpActionResult WithdrawlTransaction(string accountNumber, double withdrawl, int atmId)
        {
            var repose = _bllWithdrawlTransaction.WithdrawlTransaction(accountNumber, withdrawl, atmId);
            return new HttpApiActionResult(HttpStatusCode.OK, repose);
        }
        [Route("ChangePinTransaction")]
        //[SwaggerResponse(200, "Returns detail ChangePin", typeof(ApiChangePinTransactionModel))]
        //[SwaggerResponse(500, "Internal Server Error")]
        //[SwaggerResponse(400, "Bad Request")]
        //[SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]
        public IHttpActionResult ChangePinTransaction(string accountNumber, string oldPass, string newPass)
        {
            var repose = _bllChangePinTransaction.ChangePinTransaction(accountNumber, oldPass, newPass);
            return new HttpApiActionResult(HttpStatusCode.OK, repose);
        }
        [Route("CheckBalanceTransaction")]
        //[SwaggerResponse(200, "Returns detail Check balance", typeof(ApiCheckBalanceTransactionModel))]
        //[SwaggerResponse(500, "Internal Server Error")]
        //[SwaggerResponse(400, "Bad Request")]
        //[SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]
        public IHttpActionResult CheckBalanceTransaction(string accountNumber)
        {
            var repose = _bllCheckBalanceTransactionBLL.CheckBalanceTransaction(accountNumber);
            return new HttpApiActionResult(HttpStatusCode.OK, repose);
        }
    }
}
