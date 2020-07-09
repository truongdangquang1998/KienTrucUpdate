using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiCheckBalanceTransactionModel : ApiJsonResult
    {
        public ApiPersonModel ApiPersonModel { get; set; }
        public double AvailableBalance { get; set; }
    }
}
