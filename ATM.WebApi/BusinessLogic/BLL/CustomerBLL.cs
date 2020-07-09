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
    public class CustomerBLL
    {
        private readonly DataAccess<Customer> _customer;
        private readonly DataAccess<AccountCard> _accountCard;
        private readonly DataAccess<UserLogin> _userLogin;
        private readonly DataAccess<Person> _person;
        private readonly DataAccess<ATMTransaction> _atmTransaction;
        private readonly DataAccess<ATMHistory> _atmHistory;
        private readonly DataAccess<ATMInfo> _atmInfo;
        public CustomerBLL()
        {
            _customer = new DataAccess<Customer>();
            _accountCard = new DataAccess<AccountCard>();
            _userLogin = new DataAccess<UserLogin>();
            _person = new DataAccess<Person>();
            _atmTransaction = new DataAccess<ATMTransaction>();
            _atmHistory = new DataAccess<ATMHistory>();
            _atmInfo = new DataAccess<ATMInfo>();

        }
        public string AddAccountCard(AccountCard.AccountTypes type)
        {
            string accountNumber = "071";
            List<AccountCard> accounts = _accountCard.GetByWhere(x => x.AccountType == Entities.AccountCard.AccountTypes.Visa).ToList();
            List<long> convert = new List<long>();
            foreach (var item in accounts)
            {
                string str1 = item.AccountNumber.Substring(3);
                convert.Add(Int32.Parse(str1));
            }
            long max = convert.Max();
            max += 1;
            if (type == Entities.AccountCard.AccountTypes.Visa)
            {
                if (max < 10)
                    accountNumber += "100000000" + max.ToString();
                else if (max < 100)
                    accountNumber += "10000000" + max.ToString();
                else if (max < 1000)
                    accountNumber += "1000000" + max.ToString();
                else if (max < 10000)
                    accountNumber += "100000" + max.ToString();
                else if (max < 100000)
                    accountNumber += "100000" + max.ToString();
                else if (max < 1000000)
                    accountNumber += "10000" + max.ToString();
                else if (max < 10000000)
                    accountNumber += "10000" + max.ToString();
                else if (max < 100000000)
                    accountNumber += "1000" + max.ToString();
                else if (max < 1000000000)
                    accountNumber += "100" + max.ToString();
                else if (max < 10000000000)
                    accountNumber += "10" + max.ToString();
                else
                    accountNumber += "1" + max.ToString();

            }
            else if (type == Entities.AccountCard.AccountTypes.Normal)
            {
                if (max < 10)
                    accountNumber += "000000000" + max.ToString();
                else if (max < 100)
                    accountNumber += "00000000" + max.ToString();
                else if (max < 1000)
                    accountNumber += "0000000" + max.ToString();
                else if (max < 10000)
                    accountNumber += "000000" + max.ToString();
                else if (max < 100000)
                    accountNumber += "000000" + max.ToString();
                else if (max < 1000000)
                    accountNumber += "00000" + max.ToString();
                else if (max < 10000000)
                    accountNumber += "00000" + max.ToString();
                else if (max < 100000000)
                    accountNumber += "0000" + max.ToString();
                else if (max < 1000000000)
                    accountNumber += "000" + max.ToString();
                else if (max < 10000000000)
                    accountNumber += "00" + max.ToString();
                else
                    accountNumber += "0" + max.ToString();
            }
            return accountNumber;
        }
        public UserLogin AddCustomer(Customer customer, double money, AccountCard.AccountTypes type, int bankId)
        {
            try
            {

                Customer temp = _customer.GetByCondition(x => x.PersonID == customer.PersonID);
                if (temp != null)
                {
                    AccountCard accountCard = new AccountCard(AddAccountCard(type), type, DateTime.Now, money, 3300, 1100, AccountCard.AccountRole.customer, AccountCard.AccountStatus.Start, bankId, temp.PersonID);
                    _accountCard.Add(accountCard);
                    UserLogin userLogin = new UserLogin(accountCard.AccountNumber, "111111");
                    _userLogin.Add(userLogin);
                    return userLogin;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public ListApiStaffTransactionStatisticsCustomerModel StaffTransactionStatisticsCustomer(string account)
        {
            ListApiStaffTransactionStatisticsCustomerModel listApiStaffTransaction = new ListApiStaffTransactionStatisticsCustomerModel();
            List<ApiStaffTransactionStatisticsCustomerModel> statisticsModels = new List<ApiStaffTransactionStatisticsCustomerModel>();
            List<ATMTransaction> transactions = _atmTransaction.GetByWhere(x => x.AccountNumber == account).ToList();
            AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber == account);
            Person person = _person.GetByCondition(x => x.PersonID == accountCard.PersonID);
            if (transactions != null)
            {
                foreach (var item in transactions)
                {
                    ATMHistory atmHistory = _atmHistory.GetByCondition(x => x.ATMID == item.ATMID && x.ATMHistoryTime == item.TransactionTime);
                    if (atmHistory != null)
                    {
                        ATMInfo info = _atmInfo.GetByCondition(x => x.ATMID == atmHistory.ATMID);
                        statisticsModels.Add(new ApiStaffTransactionStatisticsCustomerModel()
                        {
                            AtmHistoryName = info.ATMName,
                            AtmHistoryAddress = info.ATMAddress,
                            TransactionMoney = item.TransactionMoney,
                            TransactionTime = item.TransactionTime,
                            TransactionType = item.TransactionType.ToString(),
                            ApiPersonModel = new ApiPersonModel() { AccountNumber = account, PersonName = person.PersonName }
                        });
                    }
                    else
                    {
                        statisticsModels.Add(new ApiStaffTransactionStatisticsCustomerModel()
                        {
                            TransactionMoney = item.TransactionMoney,
                            TransactionTime = item.TransactionTime,
                            TransactionType = item.TransactionType.ToString(),
                            ApiPersonModel = new ApiPersonModel() { AccountNumber = account, PersonName = person.PersonName }
                        });
                    }
                }
                listApiStaffTransaction.StaffTransactionStatisticsModels = statisticsModels;
                return listApiStaffTransaction;
            }
            else
                listApiStaffTransaction.ErrorMessages = new List<string> { "Tài khoản chưa thực hiện giao dịch nào." };
            return listApiStaffTransaction;

        }
        public string ResetPassword(string account)
        {
            try
            {
                AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber == account);
                UserLogin userLogin = _userLogin.GetByCondition(x => x.AccountNumber == accountCard.AccountNumber);
                userLogin.CountPassword = 0;
                userLogin.Password = "111111";
                accountCard.Status = AccountCard.AccountStatus.Start;
                _userLogin.Update(userLogin);
                _accountCard.Update(accountCard);
                return "Đã cập nhật mật khẩu.";
            }
            catch (Exception ex)
            {
                return ex.ToString() + " - Không cập nhật được.";
            }
        }
        public bool UpdateInfoCustomer(string account, Customer person)
        {
            try
            {
                AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber == account);
                Customer customer = (Customer)_person.GetByCondition(x => x.PersonID == person.PersonID);
                customer.PersonName = person.PersonName;
                customer.PersonBirth = person.PersonBirth;
                customer.IdCard = person.IdCard;
                customer.PersonPhone = person.PersonPhone;
                customer.PersonAddress = person.PersonAddress;
                customer.PersonEmail = person.PersonEmail;
                customer.CompanyName = person.CompanyName;
                _person.Update(customer);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
