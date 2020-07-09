using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Staff : Person
    {
        public enum Positions
        {
            Admin, Tellers
        }
        [Required(ErrorMessage = "Property: Code Error: The PersonBirth field is required.")]
        public Positions? Position { get; set; }
        public Staff(string personName, DateTime personBirth, string idCard, string personPhone, string personAddress, string personEmail, Positions? position)
        {
            this.PersonName = personName;
            this.PersonBirth = personBirth;
            this.IdCard = idCard;
            this.PersonPhone = personPhone;
            this.PersonAddress = personAddress;
            this.PersonEmail = personEmail;
            this.Position = position;
        }
        public Staff()
        {

        }
    }
}
