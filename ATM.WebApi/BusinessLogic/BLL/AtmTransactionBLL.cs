using DataAccess.EntityDAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BLL
{
    public class AtmTransactionBLL
    {
        private readonly DataAccess<ATMTransaction> _atmTransaction;
        public AtmTransactionBLL()
        {
            _atmTransaction = new DataAccess<ATMTransaction>();
        }
        public bool AddTransaction(string acc, double transMoney, DateTime dateTime, int atmID)
        {
            ATMTransaction transaction = new ATMTransaction(transMoney, dateTime, ATMTransaction.TransactionTypes.Withdrawl, acc, acc, atmID);
            try
            {
                _atmTransaction.Add(transaction);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddTransferTransaction(string acc, string beneficiary, double transMoney, DateTime dateTime, int atmID)
        {
            ATMTransaction transaction = new ATMTransaction(transMoney, dateTime, ATMTransaction.TransactionTypes.Transfer, beneficiary, acc, atmID);
            try
            {
                _atmTransaction.Add(transaction);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
