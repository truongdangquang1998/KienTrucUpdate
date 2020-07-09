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
    public class StaffTransactionStatisticsBLL
    {
        private readonly DataAccess<ATMHistory> _atmHistory;
        private readonly DataAccess<ATMTransaction> _atmTransaction;
        private readonly DataAccess<Person> _person;

        private readonly DataAccess<AccountCard> _accountCard;
        private readonly DataAccess<ATMInfo> _atmInfo;

        public StaffTransactionStatisticsBLL()
        {
            _atmHistory = new DataAccess<ATMHistory>();
            _atmTransaction = new DataAccess<ATMTransaction>();
            _person = new DataAccess<Person>();

            _accountCard = new DataAccess<AccountCard>();
            _atmInfo = new DataAccess<ATMInfo>();
        }

        public ListApiStaffTransactionStatisticsCustomerModel StaffTransactionStatistics(int atmId)
        {
            ListApiStaffTransactionStatisticsCustomerModel listApiStaffTransaction = new ListApiStaffTransactionStatisticsCustomerModel();
            List<ApiStaffTransactionStatisticsCustomerModel> statisticsModels = new List<ApiStaffTransactionStatisticsCustomerModel>();
            ATMInfo info = _atmInfo.GetById(atmId);
            List<ATMHistory> aTMHistories = _atmHistory.GetByWhere(x => x.ATMID == atmId).ToList();
            List<ATMTransaction> aTMTransactions = new List<ATMTransaction>();

            foreach (var item in aTMHistories)
            {
                ATMTransaction transaction = _atmTransaction.GetByCondition(x => x.ATMID == info.ATMID && x.TransactionTime == item.ATMHistoryTime);
                if (transaction != null)
                    aTMTransactions.Add(transaction);
            }
            if (aTMHistories.Count != 0 && aTMTransactions.Count != 0)
            {
                foreach (var item in aTMHistories)
                {
                    foreach (var trans in aTMTransactions)
                    {
                        if (item.ATMHistoryTime == trans.TransactionTime)
                        {
                            AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber == trans.AccountNumber);
                            Person person = _person.GetByCondition(x => x.PersonID == accountCard.PersonID);

                            statisticsModels.Add(new ApiStaffTransactionStatisticsCustomerModel()
                            {
                                AtmHistoryName = info.ATMName,
                                AtmHistoryAddress = info.ATMAddress,
                                TransactionMoney = trans.TransactionMoney,
                                TransactionTime = trans.TransactionTime,
                                TransactionType = trans.TransactionType.ToString(),
                                ApiPersonModel = new ApiPersonModel(accountCard.AccountNumber, person.PersonName)
                            });
                        }
                    }
                }
                listApiStaffTransaction.StaffTransactionStatisticsModels = statisticsModels;
                return listApiStaffTransaction;
            }
            else
                listApiStaffTransaction.ErrorMessages = new List<string> { "Hệ thống chưa có giao dịch nào." };
            return listApiStaffTransaction;

        }
    }
}
