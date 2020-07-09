using DataAccess.EntityDAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BLL
{
    public class AddHistoryBLL
    {
        private readonly DataAccess<ATMHistory> _atmHistory;
        private readonly DataAccess<AccountHistory> _accountHistory;
        public AddHistoryBLL()
        {
            _atmHistory = new DataAccess<ATMHistory>();
            _accountHistory = new DataAccess<AccountHistory>();
        }
        public ATMHistory AddATMHistory(int atmID)
        {
            ATMHistory history = new ATMHistory(DateTime.Now, atmID);
            try
            {
                _atmHistory.Add(history);
                return history;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool AddAccountHistory(string acc, DateTime dateTime)
        {
            AccountHistory history = new AccountHistory(dateTime, acc);
            try
            {
                _accountHistory.Add(history);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
