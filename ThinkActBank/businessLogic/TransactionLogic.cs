using System;
using System.Collections.Generic;
using System.Linq;
using ThinkActBank.businessLogic;
using ThinkActBank.model;

namespace ThinkActBank
{

    public class TransactionLogic
    {
        public static decimal? myBalance = null;
        public static decimal TransferMoney = 0;
        public static decimal senderAccountBalance = 0;
        public static decimal recipientAccountBalance = 0;
        public static string senderAccountNo = String.Empty;
        public static string recipientAccountNo = String.Empty;
        public static int indexNumber1 = 0;
        public static string senderAccName = Authentication.CurrentUser.FullName;
        public static string recipientAccName = String.Empty;
        public static string accountIndexNumber = String.Empty;
        public static string senderAccountNumber = String.Empty;
        public static string recipientAccountNumber = String.Empty;
        public static decimal WithdrawMoney = 0;
        public static decimal WithdrawAccountBalance = 0;
        public static string WithdrawAccountNumber = String.Empty;
        public static decimal depositMoney = 0;
        public static decimal depositAccountBalance = 0;
        public static string depositAccountNumber = String.Empty;
        public static string accountID = String.Empty;


        public static List<Account> DisplayCurrentUserList = new List<Account>();

        public static void cloneList()
        {
            DisplayCurrentUserList.Clear();
            var CurrentUserList = AccountLogic.Accounts;
            foreach (var listOfAccount in CurrentUserList)
            {
                DisplayCurrentUserList.Add(listOfAccount);
            }
        }

        public static void IdIsNotCurrent()
        {

            DisplayCurrentUserList.RemoveAll(x => x.UserId != Authentication.CurrentUser.Id);

        }

        public static void DisplayAccountDetails()
        {

            var accountName = Authentication.CurrentUser;
            string name = accountName.FullName;
            var CurrentUserList = AccountLogic.Accounts.Where(x => x.UserId == Authentication.CurrentUser.Id);

            DataFormatting.PrintSeperatorLine();
            DataFormatting.PrintRow(" NAME ", " ACCOUNT NUMBER", "ACCOUNT TYPE", " BALANCE");
            DataFormatting.PrintSeperatorLine();
            foreach (var listOfAccount in CurrentUserList)
            {
                DataFormatting.PrintRow(name, listOfAccount.AccountNumber, listOfAccount.AccountType.ToString(), listOfAccount.Amount.ToString());
                DataFormatting.PrintSeperatorLine();
            }
        }




        public static void TransferBalance()
        {
            Console.Clear();
            cloneList();
            IdIsNotCurrent();
            if (DisplayCurrentUserList.Count == 0)
            {
                Console.WriteLine("No Account Found!");
                return;
            }
            DisplayAccountDetails();
            int counting = 0;
            Console.WriteLine("Please! Choose the Sender Account Number ");
            Console.WriteLine("Press 1 for Account No 1 or other Account");
            accountIndexNumber = String.Empty;
            while (Validation.TransactionLogicCheckingIsNotCorrect(accountIndexNumber))
            {
                if (counting >= 1)
                {

                    Console.WriteLine("Please! choose the Sender Account Number");
                    Console.WriteLine("Invalid Number");
                }

                counting++;
                accountIndexNumber = Console.ReadLine();
            }
            indexNumber1 = Int32.Parse(accountIndexNumber) - 1;


            var AccountIndex = DisplayCurrentUserList[indexNumber1];
            senderAccountNumber = AccountIndex.AccountNumber;
            Console.Write("Recipient Account Number");
            recipientAccountNumber = Console.ReadLine();
            var accountInfo = AccountLogic.Accounts;
            int count = 0;
            foreach (var acc in accountInfo)
            {
                count++;
                bool numberValidation = acc.AccountNumber.Equals(recipientAccountNumber);

                if (numberValidation == true)
                {
                    break;
                }
                if (count == accountInfo.Count)
                {
                    if (numberValidation == false)
                    {
                        Console.WriteLine("Incorrect Number!!!");
                        return;

                    }
                }


            }
            Console.Write("How Much: ");
            string transferAmount = Console.ReadLine();
            TransferMoney = Convert.ToDecimal(transferAmount);

            var senderInfo = AccountLogic.Accounts.Where(p => p.AccountNumber == senderAccountNumber);

            foreach (var info in senderInfo)
            {
                if (TransferMoney >= (info.Amount + 1))
                {
                    Console.WriteLine("Insuffienct Balance");
                    return;
                }
                senderAccountBalance = info.Amount - TransferMoney;
                info.Amount = senderAccountBalance;
                senderAccountNo = info.AccountNumber;
            }

            var recipientInfo = AccountLogic.Accounts.Where(p => p.AccountNumber == recipientAccountNumber);

            foreach (var info in recipientInfo)
            {
                recipientAccountBalance = info.Amount + TransferMoney;
                info.Amount = recipientAccountBalance;
                recipientAccName = info.UserId;
                recipientAccountNumber = info.AccountNumber;
            }

            var recipientUserInfo = Authentication.Users.Where(k => k.Id == recipientAccName);
            foreach (var myInfo in recipientUserInfo)
            {
                recipientAccName = myInfo.FullName;
            }

        }

        public static void WithdrawBalance()
        {
            Console.Clear();
            cloneList();
            IdIsNotCurrent();
            if (DisplayCurrentUserList.Count == 0)
            {
                Console.WriteLine("No Account Found!");
                return;
            }
            DisplayAccountDetails();
            Console.WriteLine("Please! Choose the Account Number you will be Withdrawing From Accordingly ");
            Console.Write("Press 1 for Account No 1 or other Account ");
            accountIndexNumber = String.Empty;
            int counting = 0;
            while (Validation.TransactionLogicCheckingIsNotCorrect(accountIndexNumber))
            {

                if (counting >= 1)
                {

                    Console.WriteLine("Please! Choose the Account Number you will be Withdrawing From Accordingly");
                    Console.WriteLine("Invalid Number");
                }

                counting++;
                accountIndexNumber = Console.ReadLine();
            }
            indexNumber1 = Int32.Parse(accountIndexNumber) - 1;

            var AccountIndex = DisplayCurrentUserList[indexNumber1];
            WithdrawAccountNumber = AccountIndex.AccountNumber;
            Console.Write("How Much: ");
            string withdrawAmount = Console.ReadLine();
            WithdrawMoney = Convert.ToDecimal(withdrawAmount);

            var senderInfo = AccountLogic.Accounts.Where(p => p.AccountNumber == WithdrawAccountNumber);

            foreach (var info in senderInfo)
            {
                if (WithdrawMoney >= (info.Amount + 1))
                {
                    Console.WriteLine("Insuffienct Balance");
                    return;
                }
                WithdrawAccountBalance = info.Amount - WithdrawMoney;
                info.Amount = WithdrawAccountBalance;

            }

        }

        public static void DepositBalance()
        {
            Console.Clear();
            cloneList();
            IdIsNotCurrent();
            if (DisplayCurrentUserList.Count == 0)
            {
                Console.WriteLine("No Account Found!");
                return;
            }
            DisplayAccountDetails();
            Console.WriteLine("Please! Choose the Account Number you will be Depositing to Accordingly ");
            Console.Write("Press 1 for Account No 1 or other Account ");
            int counting = 0;
            accountIndexNumber = String.Empty;
            while (Validation.TransactionLogicCheckingIsNotCorrect(accountIndexNumber))
            {

                if (counting >= 1)
                {

                    Console.WriteLine("Please! Choose the Account Number you will be Depositing to Accordingly");
                    Console.WriteLine("Invalid Number");
                }

                counting++;
                accountIndexNumber = Console.ReadLine();
            }
            indexNumber1 = Int32.Parse(accountIndexNumber) - 1;
            var AccountIndex = DisplayCurrentUserList[indexNumber1];
            depositAccountNumber = AccountIndex.AccountNumber;
            Console.Write("How Much: ");
            string depositAmount = Console.ReadLine();
            depositMoney = Convert.ToDecimal(depositAmount);


            var senderInfo = AccountLogic.Accounts.Where(p => p.AccountNumber == depositAccountNumber);

            foreach (var info in senderInfo)
            {
                depositAccountBalance = info.Amount + depositMoney;
                info.Amount = depositAccountBalance;
            }

            
        }

        public static void Balance()
        {
            Console.Clear();
            cloneList();
            IdIsNotCurrent();
            if (DisplayCurrentUserList.Count == 0)
            {
                Console.WriteLine("No Account Found!");
                return;
            }
            DisplayAccountDetails();
            Console.WriteLine("Please! Choose the Account Number you want to check the Balance From Accordingly ");
            Console.Write("Press 1 for Account No 1 or other Account ");
            accountIndexNumber = String.Empty;
            int counting = 0;
            while (Validation.TransactionLogicCheckingIsNotCorrect(accountIndexNumber))
            {

                if (counting >= 1)
                {

                    Console.WriteLine("Please! Choose the Account Number you want to check the Balance From Accordingly");
                    Console.WriteLine("Invalid Number");
                }

                counting++;
                accountIndexNumber = Console.ReadLine();
            }
            indexNumber1 = Int32.Parse(accountIndexNumber) - 1;
            var AccountIndex = DisplayCurrentUserList[indexNumber1];
            string AccountNumber = AccountIndex.AccountNumber;


            var isContain = AccountLogic.Accounts.Where(p => p.AccountNumber == AccountNumber);

            foreach (var info in isContain)
            {
                myBalance = info.Amount;
            }
          
        }

        public static void PrintStatement()
        {
            Console.Clear();
            cloneList();
            IdIsNotCurrent();
            if (DisplayCurrentUserList.Count == 0)
            {
                Console.WriteLine("No Account Found!");
                return;
            }
            DisplayAccountDetails();
            Console.WriteLine("Please! Choose the Account Number statement you want ");
            Console.Write("Press 1 for Account No 1 or other Account ");
            int counting = 0;
            accountIndexNumber = String.Empty;
            while (Validation.TransactionLogicCheckingIsNotCorrect(accountIndexNumber))
            {

                if (counting >= 1)
                {

                    Console.WriteLine("Please! Choose the Account Number statement you want");
                    Console.WriteLine("Invalid Number");
                }

                counting++;
                accountIndexNumber = Console.ReadLine();
            }
            indexNumber1 = Int32.Parse(accountIndexNumber) - 1;

            var AccountIndex = DisplayCurrentUserList[indexNumber1];
            string AccountNumber = AccountIndex.AccountNumber;

            var accountInfo = AccountLogic.Accounts.Where(p => p.AccountNumber == AccountNumber);

            DataFormatting.PrintSeperatorLine();
            DataFormatting.PrintRow(" DATE ", " DESCRIPTION", "AMOUNT", " BALANCE");
            DataFormatting.PrintSeperatorLine();
            foreach (var info in accountInfo)
            {
                var IDInfo = AccountLogic.Transactions.Where(x => x.AccountId == info.Id);


                foreach (var MyInfo in IDInfo)
                {
                    DataFormatting.PrintRow(MyInfo.CreatedOn, MyInfo.Description, MyInfo.TransactionAmount.ToString(), MyInfo.Amount.ToString());
                    DataFormatting.PrintSeperatorLine();
                }
            }
        }


        public static string GetId(string accountNumber)
        {
            var senderInfo = AccountLogic.Accounts.Where(p => p.AccountNumber == accountNumber);

            foreach (var info in senderInfo)
            {

                var Id = AccountLogic.Transactions;
                foreach (var list in Id)
                {
                    accountID = info.Id;
                }
            }

            return accountID;
        }
    }

}
