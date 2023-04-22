using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkActBank.model;

namespace ThinkActBank.businessLogic
{
    public static class AccountLogic
    {
        public static List<Account> Accounts { get; set; } = new List<Account>();
        public static List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public static void AddAccount(Account accountData)
        {
            Accounts.Add(accountData);
        }

        public static void AddTransaction(Transaction data)
        {
            {
                Transactions.Add(data);
            }
        }

    }
}
