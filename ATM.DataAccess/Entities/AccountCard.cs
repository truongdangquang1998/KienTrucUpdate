using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AccountCard
    {
        public enum AccountTypes
        {
            Normal, Visa
        }
        public enum AccountRole
        {
            customer, staff
        }
        public enum AccountStatus
        {
            Start, Pause
        }
        [Key]
        [RegularExpression(@"^0[0-9]{2}(1|0)[0-9]{9}$")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Property: Code Error: The AccountType field is required.")]
        [DefaultValue(0)]
        public AccountTypes? AccountType { get; set; }

        [Required]
        [DefaultValue(typeof(DateTime), "Now")]
        public DateTime CardCreationDate { get; set; }
        [Required]
        [Range(0, Double.MaxValue, ErrorMessage = "Property: Code Error:The AvailableBalance field is required.")]
        public double AvailableBalance { get; set; }

        [DefaultValue(3300)]
        public int ForeignFee { get; set; }

        [DefaultValue(1100)]
        public int InternalFee { get; set; }

        [Required(ErrorMessage = "Property: Code Error: The Roles field is required.")]
        public AccountRole? Role { get; set; }

        [Required(ErrorMessage = "Property: Code Error: The Status field is required.")]
        public AccountStatus? Status { get; set; }

        [Required]
        public int BankID { get; set; }
        public BankInfo BankInfo { get; set; }

        [Required]
        public int PersonID { get; set; }
        public Person Person { get; set; }

        public AccountCard(string accountNumber, AccountTypes? accountType, DateTime cardCreationDate, double availableBalance,
            int foreignFee, int internalFee
            , AccountRole? role, AccountStatus? status, int bankID, int personID)
        {
            this.AccountNumber = accountNumber;
            this.AccountType = accountType;
            this.CardCreationDate = cardCreationDate;
            this.AvailableBalance = availableBalance;
            this.ForeignFee = foreignFee;
            this.InternalFee = internalFee;
            this.Role = role;
            this.Status = status;
            this.BankID = bankID;
            this.PersonID = personID;
        }
        public AccountCard()
        {

        }
    }
}
