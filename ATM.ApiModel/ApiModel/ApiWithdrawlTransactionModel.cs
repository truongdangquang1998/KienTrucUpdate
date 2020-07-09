using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiWithdrawlTransactionModel : ApiJsonResult
    {
        public ApiPersonModel ApiPersonModel { get; set; }
        public double TransactionMoney { get; set; }
        public double WithdrawlFee { get; set; }
        public double AvailableBalance { get; set; }
    }
}
