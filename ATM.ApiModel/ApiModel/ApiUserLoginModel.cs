using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiUserLoginModel : ApiJsonResult
    {
        public enum AccountRole
        {
            Customer, Staff
        }
        public ApiPersonModel ApiPersonModel { get; set; }
        public AccountRole? Role { get; set; }
        public ApiUserLoginModel()
        {

        }
        public ApiUserLoginModel(ApiPersonModel person, AccountRole role)
        {
            ApiPersonModel.AccountNumber = person.AccountNumber;
            ApiPersonModel.PersonName = person.PersonName;
            Role = role;
        }
    }
}
