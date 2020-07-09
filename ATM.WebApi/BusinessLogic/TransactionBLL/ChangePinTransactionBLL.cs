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
    public class ChangePinTransactionBLL
    {
        private readonly DataAccess<UserLogin> _userLogin;
        private readonly AddHistoryBLL _addHistoryBLL;
        public ChangePinTransactionBLL()
        {
            _userLogin = new DataAccess<UserLogin>();
            _addHistoryBLL = new AddHistoryBLL();
        }
        public ApiChangePinTransactionModel ChangePinTransaction(string acc, string oldPass, string newPass)
        {
            var apiChangePinTransactionModel = new ApiChangePinTransactionModel();
            try
            {
                UserLogin userLogin = _userLogin.GetByCondition(x => x.AccountNumber.Equals(acc));

                if (userLogin.Password == oldPass)
                {
                    userLogin.Password = newPass;
                    _userLogin.Update(userLogin);
                    _addHistoryBLL.AddAccountHistory(acc, DateTime.Now);
                    apiChangePinTransactionModel.Message = "Cập nhật mật khẩu thành công.";
                }
            }
            catch (Exception)
            {
                apiChangePinTransactionModel.Message = "Cập nhật mật khẩu không thành công.";
            }
            return apiChangePinTransactionModel;
        }
    }
}
