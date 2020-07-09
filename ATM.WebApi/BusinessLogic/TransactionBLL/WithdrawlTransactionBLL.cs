using ApiModel;
using BusinessLogic.BLL;
using DataAccess.EntityDAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.TransactionBLL
{
    public class WithdrawlTransactionBLL
    {
        private readonly DataAccess<UserLogin> _userLogin;
        private readonly DataAccess<AccountCard> _accountCard;
        private readonly DataAccess<ATMInfo> _atmInfo;
        private readonly DataAccess<BankInfo> _bankInfo;

        private readonly PersonBLL _personBLL;
        private readonly AccountCardBLL _accountCardBLL;
        private readonly AddHistoryBLL _addHistoryBLL;
        private readonly AtmTransactionBLL _atmTransactionBLL;
        private readonly ATMInfoBLL _atmInfoBLL;
        public WithdrawlTransactionBLL()
        {
            _userLogin = new DataAccess<UserLogin>();
            _accountCard = new DataAccess<AccountCard>();
            _atmInfo = new DataAccess<ATMInfo>();
            _bankInfo = new DataAccess<BankInfo>();
            _personBLL = new PersonBLL();
            _accountCardBLL = new AccountCardBLL();
            _addHistoryBLL = new AddHistoryBLL();
            _atmTransactionBLL = new AtmTransactionBLL();
            _atmInfoBLL = new ATMInfoBLL();
        }
        public ApiWithdrawlTransactionModel WithdrawlTransaction(string acc, double transMoney, int atmID)
        {
            UserLogin userLogin = _userLogin.GetByCondition(x => x.AccountNumber.Equals(acc));
            AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber.Equals(userLogin.AccountNumber));
            ATMInfo atmInfo = _atmInfo.GetByCondition(x => x.ATMID == atmID);
            BankInfo bankInfo = _bankInfo.GetByCondition(x => x.BankID == accountCard.BankID);

            var withdrawl = new ApiWithdrawlTransactionModel();
            if (transMoney >= 50000 && transMoney <= 5000000)
            {
                withdrawl.ApiPersonModel = _personBLL.PersonInfo(accountCard);
                withdrawl.TransactionMoney = transMoney;

                if (atmInfo.BankID == bankInfo.BankID)
                {
                    withdrawl.WithdrawlFee = accountCard.InternalFee;
                }
                else if (atmInfo.BankID != bankInfo.BankID)
                {
                    withdrawl.WithdrawlFee = accountCard.ForeignFee;
                }
                try
                {
                    AccountCard balance = _accountCardBLL.UpdateBalanceAccount(accountCard, transMoney + withdrawl.WithdrawlFee);

                    if (balance != null)
                    {
                        _atmInfoBLL.UpdateAvailableBalanceWithdrawlATM(atmID, transMoney);
                        ATMHistory atmHistory = _addHistoryBLL.AddATMHistory(atmID);
                        _addHistoryBLL.AddAccountHistory(accountCard.AccountNumber, atmHistory.ATMHistoryTime);
                        _atmTransactionBLL.AddTransaction(accountCard.AccountNumber, transMoney, atmHistory.ATMHistoryTime, atmID);

                        _accountCard.GetByCondition(x => x.AccountNumber == accountCard.AccountNumber);
                        withdrawl.AvailableBalance = balance.AvailableBalance;
                        return withdrawl;
                    }
                }
                catch (Exception ex)
                {
                    withdrawl.ErrorMessages = new List<string> { ex.ToString(), "Giao dịch rút tiền không thành công." };
                }
            }
            else
                withdrawl.ErrorMessages = new List<string> { "Số tiền giao dịch không hợp lệ." };
            return withdrawl;
        }
    }
}
