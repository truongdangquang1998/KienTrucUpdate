using ApiModel;
using DataAccess.EntityDAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.TransactionBLL
{
    public class StaffCheckBalanceATMBLL
    {
        private readonly DataAccess<ATMInfo> _atmInfo;
        public StaffCheckBalanceATMBLL()
        {
            _atmInfo = new DataAccess<ATMInfo>();
        }
        public ApiStaffCheckBalanceATMModel CheckAvailableBalance(int atmID)
        {
            ApiStaffCheckBalanceATMModel balanceATMModel = new ApiStaffCheckBalanceATMModel();
            ATMInfo info = _atmInfo.GetByCondition(x => x.ATMID == atmID);
            if (info != null)
            {
                balanceATMModel.AvailableBalanceATM = info.ATMBalance;
                return balanceATMModel;
            }
            else
            {
                balanceATMModel.ErrorMessages = new List<string> { "ATM không tồn tại." };
            }
            return balanceATMModel;
        }
    }
}
