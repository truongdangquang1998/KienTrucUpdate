using ApiModel;
using DataAccess.EntityDAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BLL
{
    public class UserLoginBLL
    {
        private readonly DataAccess<UserLogin> _userLogin;
        private readonly DataAccess<AccountCard> _accountCard;
        private readonly DataAccess<Person> _person;
        private readonly PersonBLL _personBLL;
        private readonly AddHistoryBLL _addHistoryBLL;
        public UserLoginBLL()
        {
            _userLogin = new DataAccess<UserLogin>();
            _accountCard = new DataAccess<AccountCard>();
            _person = new DataAccess<Person>();
            _personBLL = new PersonBLL();
            _addHistoryBLL = new AddHistoryBLL();
        }
        public ApiUserLoginModel UserLogin(string acc, string pass, int atmID)
        {
            ApiUserLoginModel userloginmodel = new ApiUserLoginModel();

            UserLogin userLogin = _userLogin.GetByCondition(x => x.AccountNumber.Equals(acc));
            if (userLogin != null)
            {
                AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber.Equals(userLogin.AccountNumber));
                if (accountCard.Status == AccountCard.AccountStatus.Pause)
                {
                    userloginmodel.ErrorMessages = new List<string> { "Tài khoản của bạn đã bị khoá." };
                    return userloginmodel;
                }
                else if (userLogin.CountPassword > 3)
                {
                    UpdateAccountStatusByCountPass(accountCard);
                    userloginmodel.ErrorMessages = new List<string>() { "false", "Tài khoản đã khoá." };
                    return userloginmodel;
                }
                else if (userLogin.Password.Equals(pass))
                {
                    var person = _person.GetByCondition(x => x.PersonID == accountCard.PersonID);
                    userloginmodel.ApiPersonModel = _personBLL.PersonInfo(accountCard);
                    if (person is Staff)
                    {
                        userloginmodel.Role = ApiUserLoginModel.AccountRole.Staff;
                    }
                    else if (person is Customer)
                    {
                        userloginmodel.Role = ApiUserLoginModel.AccountRole.Customer;
                        userloginmodel.ApiPersonModel = new ApiPersonModel(acc, person.PersonName);
                    }
                    try
                    {
                        ATMHistory atmHistory = _addHistoryBLL.AddATMHistory(atmID);
                        _addHistoryBLL.AddAccountHistory(accountCard.AccountNumber, atmHistory.ATMHistoryTime);
                        return userloginmodel;
                    }
                    catch (Exception ex)
                    {
                        userloginmodel.ErrorMessages = new List<string> { ex.ToString(), "Đăng nhập không thành công." };
                        return userloginmodel;
                    }
                }
                else
                {
                    UpdateAccountPasswordByCountPass(userLogin);
                    userloginmodel.ErrorMessages = new List<string> { "Mật khẩu không chính xác." };

                }
            }
            else
                userloginmodel.ErrorMessages = new List<string> { "Tài khoản không tồn tại." };
            return userloginmodel;

        }
        public bool UpdateAccountPasswordByCountPass(UserLogin userLogin)
        {
            userLogin.CountPassword += 1;
            _userLogin.Update(userLogin);
            return true;
        }
        public bool UpdateAccountStatusByCountPass(AccountCard account)
        {
            account.Status = AccountCard.AccountStatus.Pause;
            _accountCard.Update(account);
            return true;
        }
    }
}
