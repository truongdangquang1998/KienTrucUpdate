using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiPaymentTransactionModel : ApiJsonResult
    {
        public double AvailableBalance { get; set; }
        public double TransactionMoney { get; set; }
        public double PaymentFee { get; set; }
        public ApiPersonModel ApiPersonModel { get; set; }
    }
}
