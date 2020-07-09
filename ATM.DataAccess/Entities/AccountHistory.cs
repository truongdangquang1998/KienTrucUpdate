using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AccountHistory
    {
        [Key]
        public int AccountHistoryID { get; set; }
        [Required]
        [DefaultValue(typeof(DateTime), "Now")]
        public DateTime AccountHistoryTime { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        public UserLogin UserLogin { get; set; }
        public AccountHistory(DateTime accountHistoryTime, string accountNumber)
        {
            this.AccountHistoryTime = accountHistoryTime;
            this.AccountNumber = accountNumber;
        }
        public AccountHistory()
        {

        }
    }
}
