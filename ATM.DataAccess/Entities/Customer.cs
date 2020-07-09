using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer : Person
    {
        [Required(ErrorMessage = "Property: Code Error: The CompanyName field is required.")]
        [DefaultValue("None")]
        public string CompanyName { get; set; }
        public Customer(string personName, DateTime personBirth, string idCard, string personPhone, string personAddress, string personEmail, string companyName)
        {
            this.PersonName = personName;
            this.PersonBirth = personBirth;
            this.IdCard = idCard;
            this.PersonPhone = personPhone;
            this.PersonAddress = personAddress;
            this.PersonEmail = personEmail;
            this.CompanyName = companyName;
        }
        public Customer()
        {

        }

    }
}
