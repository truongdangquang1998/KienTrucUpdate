using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserLogin
    {
        [Key, Column(Order = 1)]
        public string AccountNumber { get; set; }
        public AccountCard AccountCard { get; set; }
        [Required]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Must be 6 characters")]
        public string Password { get; set; }
        [DefaultValue(0)]
        public int CountPassword { get; set; }

        public virtual ICollection<AccountHistory> AccountHistories { get; set; }
        public virtual ICollection<ATMTransaction> ATMTransactions { get; set; }
        public UserLogin(string accountNumber, string password)
        {
            this.AccountNumber = accountNumber;
            this.Password = password;
        }
        public UserLogin()
        {

        }
    }
}
