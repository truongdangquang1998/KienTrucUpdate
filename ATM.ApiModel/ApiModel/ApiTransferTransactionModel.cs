using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiTransferTransactionModel : ApiJsonResult
    {
        public ApiPersonModel ApiPersonModelTransfer { get; set; }
        public ApiPersonModel ApiPersonModelReceiver { get; set; }
        public double TransactionMoney { get; set; }
        public double AvailableBalance { get; set; }
        public double TransferFee { get; set; }
    }
}
