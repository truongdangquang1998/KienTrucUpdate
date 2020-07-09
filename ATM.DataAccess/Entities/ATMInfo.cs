using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ATMInfo
    {
        [Key]
        public int ATMID { get; set; }

        [Required(ErrorMessage = "Property: Code Error: The ATMName field is required.")]
        public string ATMName { get; set; }

        [Required(ErrorMessage = "Property: Code Error: The ATMAddress field is required.")]
        public string ATMAddress { get; set; }
        [Required]
        [Range(0, 500000000, ErrorMessage = "Property: Code Error: The ATMBalance field is required.")]
        public double ATMBalance { get; set; }

        [Required]
        public int BankID { get; set; }
        public BankInfo BankInfo { get; set; }

        public virtual ICollection<ATMHistory> ATMHistories { get; set; }
        public virtual ICollection<ATMTransaction> ATMTransactions { get; set; }
        public ATMInfo()
        {

        }
        public ATMInfo(string atmName, string atmAddress, double atmBalance, int bankID)
        {
            this.ATMName = atmName;
            this.ATMAddress = atmAddress;
            this.ATMBalance = atmBalance;
            this.BankID = bankID;
        }
    }
}
