using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiPersonModel
    {
        public string AccountNumber { get; set; }
        public string PersonName { get; set; }
        public ApiPersonModel()
        {

        }
        public ApiPersonModel(string acc, string name)
        {
            AccountNumber = acc;
            PersonName = name;
        }
    }
}
