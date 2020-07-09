using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ATMHistory
    {
        [Key]
        public int ATMHistoryID { get; set; }
        [Required]
        [DefaultValue(typeof(DateTime), "Now")]
        public DateTime ATMHistoryTime { get; set; }
        [Required]
        public int ATMID { get; set; }
        public ATMInfo ATMInfo { get; set; }

        public ATMHistory(DateTime atmHistoryTime, int atmId)
        {
            this.ATMHistoryTime = atmHistoryTime;
            this.ATMID = atmId;
        }
        public ATMHistory()
        {

        }
    }
}
