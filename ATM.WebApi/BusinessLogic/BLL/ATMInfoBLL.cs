using DataAccess.EntityDAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BLL
{
    public class ATMInfoBLL
    {
        private DataAccess<ATMInfo> _atmInfo;
        public ATMInfoBLL()
        {
            _atmInfo = new DataAccess<ATMInfo>();
        }
        public ATMInfo UpdateAvailableBalanceWithdrawlATM(int atmID, double transactionMoney)
        {
            ATMInfo info = _atmInfo.GetById(atmID);
            try
            {
                if (info.ATMBalance > transactionMoney + 1000000)
                {
                    double balance = info.ATMBalance - transactionMoney;
                    info.ATMBalance = balance;
                    _atmInfo.Update(info);
                    return info;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public ATMInfo UpdateAvailableBalancePaymentATM(int atmID, double transactionMoney)
        {
            ATMInfo info = _atmInfo.GetById(atmID);
            try
            {
                if (info != null)
                {
                    double balance = info.ATMBalance + transactionMoney;
                    info.ATMBalance = balance;
                    _atmInfo.Update(info);
                    return info;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }
    }
}
