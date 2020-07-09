using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiStaffTransactionStatisticsCustomerModel
    {
        public enum TransactionTypes
        {
            Withdrawl, Transfer, Payment, CheckBalance, ChangePin
        }
        public string AtmHistoryName { get; set; }
        public string AtmHistoryAddress { get; set; }
        public double TransactionMoney { get; set; }
        public DateTime TransactionTime { get; set; }
        public string TransactionType { get; set; }
        public ApiPersonModel ApiPersonModel { get; set; }
    }
    public class ListApiStaffTransactionStatisticsCustomerModel : ApiJsonResult
    {
        public IEnumerable<ApiStaffTransactionStatisticsCustomerModel> StaffTransactionStatisticsModels { get; set; }
    }
}
