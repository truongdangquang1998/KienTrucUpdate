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
    public class PaymentTransactionBLL
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
        public PaymentTransactionBLL()
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

        public ApiPaymentTransactionModel PaymentTransaction(string acc, double paymentMoney, int atmID)
        {
            ApiPaymentTransactionModel payment = new ApiPaymentTransactionModel();
            UserLogin userLogin = _userLogin.GetByCondition(x => x.AccountNumber.Equals(acc));
            if (userLogin != null)
            {
                AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber.Equals(userLogin.AccountNumber));
                ATMInfo atmInfo = _atmInfo.GetByCondition(x => x.ATMID == atmID);
                BankInfo bankInfo = _bankInfo.GetByCondition(x => x.BankID == accountCard.BankID);
                if (paymentMoney > 50000)
                {
                    payment.ApiPersonModel = _personBLL.PersonInfo(accountCard);
                    payment.TransactionMoney = paymentMoney;
                    if (atmInfo.BankID == bankInfo.BankID)
                    {
                        payment.PaymentFee = accountCard.InternalFee;
                    }
                    else if (atmInfo.BankID != bankInfo.BankID)
                    {
                        payment.PaymentFee = accountCard.ForeignFee;
                    }
                    try
                    {
                        AccountCard balance = _accountCardBLL.UpdateBalanceAccountPayment(accountCard, paymentMoney - payment.PaymentFee);
                        if (balance != null)
                        {
                            ATMHistory atmHistory = _addHistoryBLL.AddATMHistory(atmID);
                            _addHistoryBLL.AddAccountHistory(accountCard.AccountNumber, atmHistory.ATMHistoryTime);
                            _atmTransactionBLL.AddTransaction(accountCard.AccountNumber, paymentMoney, atmHistory.ATMHistoryTime, atmID);

                            _atmInfoBLL.UpdateAvailableBalancePaymentATM(atmID, paymentMoney);
                            payment.AvailableBalance = balance.AvailableBalance;
                            return payment;
                        }

                    }
                    catch (Exception ex)
                    {
                        payment.ErrorMessages = new List<string> { ex.ToString(), "Nạp tiền không thành công." };
                    }
                }
                else
                    payment.ErrorMessages = new List<string> { "Tối thiểu phải 50000đ" };

            }
            return payment;
        }
        public ApiPaymentTransactionModel StaffPaymentTransactionATM(int atmId, string account, double transmoney)
        {
            ApiPaymentTransactionModel payment = new ApiPaymentTransactionModel();
            UserLogin userLogin = _userLogin.GetByCondition(x => x.AccountNumber.Equals(account));
            ATMInfo atmInfo = _atmInfo.GetByCondition(x => x.ATMID == atmId);
            if (transmoney >= 1000000)
            {
                AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber.Equals(userLogin.AccountNumber));
                payment.ApiPersonModel = _personBLL.PersonInfo(accountCard);
                payment.TransactionMoney = transmoney;
                try
                {
                    ATMHistory atmHistory = _addHistoryBLL.AddATMHistory(atmId);
                    _addHistoryBLL.AddAccountHistory(accountCard.AccountNumber, atmHistory.ATMHistoryTime);
                    ATMInfo balance = _atmInfoBLL.UpdateAvailableBalancePaymentATM(atmId, transmoney);
                    payment.AvailableBalance = balance.ATMBalance;
                    return payment;
                }
                catch (Exception ex)
                {
                    payment.ErrorMessages = new List<string> { ex.ToString(), "Không thể nạp tiền vào máy. " };
                }
            }
            else
            {
                payment.ErrorMessages = new List<string> { "Số tiền không nhỏ hơn 1000000đ. " };

            }
            return payment;
        }
    }
}
