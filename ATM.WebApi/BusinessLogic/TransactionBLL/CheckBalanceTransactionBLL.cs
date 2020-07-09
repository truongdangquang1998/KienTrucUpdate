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
    public class CheckBalanceTransactionBLL
    {
        private readonly DataAccess<UserLogin> _userLogin;
        private readonly DataAccess<AccountCard> _accountCard;
        private readonly PersonBLL _personBLL;
        public CheckBalanceTransactionBLL()
        {
            _userLogin = new DataAccess<UserLogin>();
            _accountCard = new DataAccess<AccountCard>();
            _personBLL = new PersonBLL();
        }
        public ApiCheckBalanceTransactionModel CheckBalanceTransaction(string acc)
        {
            ApiCheckBalanceTransactionModel checkBalance = new ApiCheckBalanceTransactionModel();

            UserLogin userLogin = _userLogin.GetByCondition(x => x.AccountNumber.Equals(acc));
            AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber.Equals(userLogin.AccountNumber));

            checkBalance.ApiPersonModel = _personBLL.PersonInfo(accountCard);
            checkBalance.AvailableBalance = accountCard.AvailableBalance;
            try
            {
                if (checkBalance != null)
                {
                    return checkBalance;
                }
            }
            catch (Exception ex)
            {
                checkBalance.ErrorMessages = new List<string> { ex.ToString(), "Lỗi hệ thống." };
            }
            return checkBalance;
        }
    }
}
