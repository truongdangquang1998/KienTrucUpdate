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
    public class PersonBLL
    {
        private DataAccess<Person> _person;
        public PersonBLL()
        {
            _person = new DataAccess<Person>();
        }
        public ApiPersonModel PersonInfo(AccountCard account)
        {
            Person person = _person.GetByCondition(x => x.PersonID == account.PersonID);
            ApiPersonModel personModel = new ApiPersonModel();
            personModel.PersonName = person.PersonName;
            personModel.AccountNumber = account.AccountNumber;
            return personModel;
        }
    }
}
