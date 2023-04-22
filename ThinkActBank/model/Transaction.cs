using System;
using ThinkActBank.enumdata;

namespace ThinkActBank.model
{
    public class Transaction
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Description { get; set; }
        public TransactionType TransactionType { get; set; }
        public string AccountId { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal Amount { get; set; }
        public string CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
