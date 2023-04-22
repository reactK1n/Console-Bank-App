using System;
using System.Collections.Generic;
using ThinkActBank.enumdata;

namespace ThinkActBank.model
{
    public class Account
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Amount { get; set; }
        public string UserId { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }


       

        
    }
}
