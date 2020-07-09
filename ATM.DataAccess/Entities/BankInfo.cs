using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BankInfo
    {
        [Key]
        public int BankID { get; set; }

        [Required(ErrorMessage = "Property: Code Error: The BankName field is required.")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Property: Code Error: The BankAddress field is required.")]
        public string BankAddress { get; set; }

        public virtual ICollection<AccountCard> AccountCards { get; set; }
        public virtual ICollection<ATMInfo> ATMInfos { get; set; }

        public BankInfo(string bankName, string bankAddress)
        {
            this.BankName = bankName;
            this.BankAddress = bankAddress;
        }
        public BankInfo()
        {

        }
    }
}
