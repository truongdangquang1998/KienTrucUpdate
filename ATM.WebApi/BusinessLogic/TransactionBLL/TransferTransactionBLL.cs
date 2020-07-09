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
    public class TransferTransactionBLL
    {
        private readonly DataAccess<UserLogin> _userLogin;
        private readonly DataAccess<AccountCard> _accountCard;
        private readonly DataAccess<ATMInfo> _atmInfo;
        private readonly DataAccess<BankInfo> _bankInfo;

        private readonly PersonBLL _personBLL;
        private readonly AccountCardBLL _accountCardBLL;
        private readonly AddHistoryBLL _addHistoryBLL;
        private readonly AtmTransactionBLL _atmTransactionBLL;
        public TransferTransactionBLL()
        {
            _userLogin = new DataAccess<UserLogin>();
            _accountCard = new DataAccess<AccountCard>();
            _atmInfo = new DataAccess<ATMInfo>();
            _bankInfo = new DataAccess<BankInfo>();
            _personBLL = new PersonBLL();
            _accountCardBLL = new AccountCardBLL();
            _addHistoryBLL = new AddHistoryBLL();
            _atmTransactionBLL = new AtmTransactionBLL();
        }
        public ApiTransferTransactionModel TransferTransaction(string acc, string beneficiary, double transMoney, int atmID)
        {
            UserLogin userLogin = _userLogin.GetByCondition(x => x.AccountNumber.Equals(acc));
            AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber.Equals(userLogin.AccountNumber));
            ATMInfo atmInfo = _atmInfo.GetByCondition(x => x.ATMID == atmID);
            BankInfo bankInfo = _bankInfo.GetByCondition(x => x.BankID == accountCard.BankID);
            AccountCard benefic = _accountCard.GetByCondition(x => x.AccountNumber == beneficiary);

            var transfer = new ApiTransferTransactionModel();
            if (benefic != null)
            {
                transfer.ApiPersonModelTransfer = _personBLL.PersonInfo(accountCard);
                transfer.ApiPersonModelReceiver = _personBLL.PersonInfo(benefic);
                transfer.TransactionMoney = transMoney;
                if (benefic.BankID == bankInfo.BankID)
                {
                    transfer.TransferFee = accountCard.InternalFee;
                }
                else if (benefic.BankID != bankInfo.BankID)
                {
                    transfer.TransferFee = accountCard.ForeignFee;
                }

                try
                {
                    AccountCard balance = _accountCardBLL.UpdateBalanceAccount(accountCard, transMoney + transfer.TransferFee);
                    if (balance != null)
                    {
                        _accountCardBLL.UpdateBalanceAccountPayment(benefic, transMoney);
                        ATMHistory atmHistory = _addHistoryBLL.AddATMHistory(atmID);
                        _addHistoryBLL.AddAccountHistory(accountCard.AccountNumber, atmHistory.ATMHistoryTime);
                        _atmTransactionBLL.AddTransferTransaction(accountCard.AccountNumber, beneficiary, transMoney, atmHistory.ATMHistoryTime, atmID);

                        transfer.AvailableBalance = balance.AvailableBalance;
                        return transfer;
                    }
                }
                catch (Exception ex)
                {
                    transfer.ErrorMessages = new List<string> { ex.ToString(), "Tài khoản của bạn không đủ." };
                }
            }
            else
                transfer.ErrorMessages = new List<string> { "Tài khoản thụ hưởng không hợp lệ." };
            return transfer;
        }
    }
}
