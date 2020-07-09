using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Person
    {
        [Key]
        [Required]
        public int PersonID { get; set; }

        [Required(ErrorMessage = "Property: Code Error: The PersonName field is required.")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Property: Code Error: The PersonBirth field is required.")]
        public DateTime PersonBirth { get; set; }
        [Required(ErrorMessage = ("Property: Code Error: The IdCard field is required."))]
        public string IdCard { get; set; }
        [Required(ErrorMessage = "Property: Code Error: The PersonPhone field is required.")]
        [RegularExpression("^0\\d{9}$")]
        public string PersonPhone { get; set; }

        [Required(ErrorMessage = "Property: Code Error: The PersonAddress field is required.")]
        public string PersonAddress { get; set; }

        [Required(ErrorMessage = "Property: Code Error: The PersonEmail field is required.")]
        [DataType(DataType.EmailAddress)]
        public string PersonEmail { get; set; }
        public virtual ICollection<AccountCard> AccountCards { get; set; }

    }
}
