using System;
using ThinkActBank.enumdata;
using ThinkActBank.model;

namespace ThinkActBank.businessLogic
{
    public static class UsersInput
    {

        public static string chooseAfter = string.Empty;
        public static bool returnCode = false;
        public static void SignUpU()
        {
            while (true)
            {
                int counting = 0;
                string choose = string.Empty;
                string _choose = string.Empty;

                Console.WriteLine("To Sign Up Press '1'");
                Console.WriteLine("To Login Press '2'");
                Console.WriteLine("To Exit Press '3'");
                Console.Write(">>>  ");

                while (!Validation.IsOneOrTwoOrThree(choose))
                {

                    if (counting >= 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Number is Invalid");
                    }
                    counting++;
                    choose = Console.ReadLine();

                }



                if (choose == "1")
                {
                    string fullname = "";
                    string username = "";
                    string password = "";

                    Console.Write("Fullname: ");
                    counting = 0;
                    while (Validation.FullNameIsInValid(fullname))
                    {

                        if (counting >= 1)
                        {

                            Console.Clear();
                            Console.WriteLine("Example: adeosun ayodeji");
                            Console.WriteLine("Name is Invalid");
                        }
                        counting++;
                        fullname = Console.ReadLine();
                    }

                    Console.Write("Username: ");
                    counting = 0;
                    while (Validation.UserNameExistOrIsInvalid(username))
                    {

                        if (counting >= 1)
                        {

                            Console.Clear();
                            Console.WriteLine("Example: Reatc02");
                            Console.WriteLine("Name Exist or Empty");
                        }

                        counting++;
                        username = Console.ReadLine();
                    }

                    Console.Write("password: ");
                    counting = 0;
                    while (Validation.PasswordIsNotStrong(password))
                    {

                        if (counting >= 1)
                        {

                            Console.Clear();
                            Console.WriteLine("Example: @dkjhkAJS18283");
                            Console.WriteLine("PassWord is Not Strong");
                        }
                        counting++;
                        password = Console.ReadLine();
                    }

                    User userInfo = new User(username, password, fullname);
                    Authentication.RegisterUser(userInfo);
                    Console.WriteLine("User Created Successfully");
                    continue;
                }

                if (choose == "2")
                {
                    while (true)
                    {
                        string username = "";
                        string password = "";

                        Console.Clear();
                        Console.Write("Username: ");
                        username = Console.ReadLine();

                        Console.Write("password: ");
                        password = Console.ReadLine();


                        var user = Authentication.UserLogin(username, password);
                        if (user == null)
                        {
                            Console.WriteLine("Incorrect username or password");
                            Console.WriteLine("Sign up a new Account by Pressing '1' ");
                            Console.WriteLine("Login to your Account by Pressing '2' ");
                            string signUp = Console.ReadLine();

                            if (signUp == "1")
                            {
                                SignUpU();
                                if (returnCode)
                                {
                                    return;
                                }

                            }

                            if (signUp == "2")
                            {
                                continue;
                            }
                        }
                        break;
                    }


                    while (true)
                    {

                        Console.Clear();
                        Console.WriteLine("To Create Account Press '1'");
                        Console.WriteLine("To Make a Transaction Press '2'");
                        Console.WriteLine("To Log Out Press '3'");
                        Console.Write(">>>>>  ");
                        counting = 0;
                        chooseAfter = String.Empty;
                        while (!Validation.IsOneOrTwoOrThree(chooseAfter))
                        {

                            if (counting >= 1)
                            {
                                Console.WriteLine("Number is Invalid");
                            }
                            counting++;
                            chooseAfter = Console.ReadLine();
                        }
                        if (chooseAfter == "1")
                        {

                            Console.Clear();
                            Console.WriteLine("Choose Account Type");
                            Console.WriteLine("To Create Savings Account Press '1'");
                            Console.WriteLine("To Create Current Account Press '2'");
                            string chooseType = String.Empty;
                            counting = 0;
                            while (!Validation.IsOneOrTwo(chooseType))
                            {

                                if (counting >= 1)
                                {
                                    Console.WriteLine("Number is Invalid");
                                }
                                counting++;
                                chooseType = Console.ReadLine();
                            }
                            if (chooseType == "1")
                            {

                                Account getAccount = new Account();
                                getAccount.AccountNumber = Validation.GenerateAccountNumber();
                                getAccount.AccountType = AccountType.Savings;
                                getAccount.CreatedOn = DateTime.UtcNow;
                                var user = Authentication.CurrentUser;
                                getAccount.UserId = user.Id;
                                getAccount.Amount = 0;
                                AccountLogic.AddAccount(getAccount);
                            }
                            if (chooseType == "2")
                            {
                                Account getAccount = new Account();
                                getAccount.AccountNumber = Validation.GenerateAccountNumber();
                                getAccount.AccountType = AccountType.Current;
                                getAccount.CreatedOn = DateTime.UtcNow;
                                var user = Authentication.CurrentUser;
                                getAccount.UserId = user.Id;
                                getAccount.Amount = 1000;
                                AccountLogic.AddAccount(getAccount);
                            }
                            TransactionLogic.DisplayAccountDetails();
                            Console.ReadLine();


                        }

                        if (chooseAfter == "2")
                        {

                            Console.Clear();
                            Console.WriteLine("TO DEPOSIT, TYPE '1'");
                            Console.WriteLine("TO TRANSFER, TYPE \"2\"");
                            Console.WriteLine("TO WITHDRAW, TYPE \"3\"");
                            Console.WriteLine("TO CHECK BALANCE, TYPE \"4\"");
                            Console.WriteLine("TO PRINT ACCOUNT STATEMENT, TYPE \"5\"");
                            string chooseTransaction = String.Empty;
                            counting = 0;
                            while (!Validation.IsBtwOneAndSix(chooseTransaction))
                            {

                                if (counting >= 1)
                                {
                                    Console.WriteLine("Number is Invalid");
                                }
                                counting++;
                                chooseTransaction = Console.ReadLine();
                            }
                            if (chooseTransaction == "1")
                            {
                                TransactionLogic.DepositBalance();

                                Transaction depositRecipientAccount = new Transaction();
                                depositRecipientAccount.CreatedOn = DateTime.Now.ToShortDateString();
                                depositRecipientAccount.Description = $"Your Account is {TransactionType.Credited}";
                                depositRecipientAccount.TransactionAmount = TransactionLogic.depositMoney;
                                depositRecipientAccount.Amount = TransactionLogic.depositAccountBalance;
                                AccountLogic.AddTransaction(depositRecipientAccount);
                                var depositId = TransactionLogic.GetId(TransactionLogic.depositAccountNumber);
                                depositRecipientAccount.AccountId = depositId;
                                Console.WriteLine("Transaction Successfully");


                            }
                            if (chooseTransaction == "2")
                            {
                                TransactionLogic.TransferBalance();
                                Transaction TransferSenderAccount = new Transaction();
                                TransferSenderAccount.CreatedOn = DateTime.Now.ToShortDateString();
                                TransferSenderAccount.Description = $"You transfer money to {TransactionLogic.recipientAccName}";
                                TransferSenderAccount.TransactionAmount = TransactionLogic.TransferMoney;
                                TransferSenderAccount.Amount = TransactionLogic.senderAccountBalance;
                                AccountLogic.AddTransaction(TransferSenderAccount);
                                var senderId = TransactionLogic.GetId(TransactionLogic.senderAccountNumber);
                                TransferSenderAccount.AccountId = senderId;


                                Transaction TransferRecipientAccount = new Transaction();
                                TransferRecipientAccount.CreatedOn = DateTime.Now.ToShortDateString();
                                TransferRecipientAccount.Description = $"You receive money from {TransactionLogic.senderAccName}";
                                TransferRecipientAccount.TransactionAmount = TransactionLogic.TransferMoney;
                                TransferRecipientAccount.Amount = TransactionLogic.recipientAccountBalance;
                                AccountLogic.AddTransaction(TransferRecipientAccount);
                                var recipientId = TransactionLogic.GetId(TransactionLogic.recipientAccountNumber);
                                TransferRecipientAccount.AccountId = recipientId;
                                Console.WriteLine("Transaction Successfully");

                            }
                            if (chooseTransaction == "3")
                            {
                                TransactionLogic.WithdrawBalance();
                                Transaction withdrawAccount = new Transaction();
                                withdrawAccount.CreatedOn = DateTime.Now.ToShortDateString();
                                withdrawAccount.Description = $"Your Account is {TransactionType.Debited}";
                                withdrawAccount.TransactionAmount = TransactionLogic.WithdrawMoney;
                                withdrawAccount.Amount = TransactionLogic.WithdrawAccountBalance;
                                AccountLogic.AddTransaction(withdrawAccount);
                                var withdrawId = TransactionLogic.GetId(TransactionLogic.WithdrawAccountNumber);
                                withdrawAccount.AccountId = withdrawId;
                                Console.WriteLine("Transaction Successfully");


                            }
                            if (chooseTransaction == "4")
                            {
                                TransactionLogic.Balance();
                                Console.WriteLine(TransactionLogic.myBalance);
                                Console.ReadLine();
                            }
                            if (chooseTransaction == "5")
                            {
                                TransactionLogic.PrintStatement();
                                Console.ReadLine();
                            }
                        }

                        if (chooseAfter == "3")
                        {
                            SignUpU();
                            if (returnCode)
                            {
                                return;
                            }
                        }
                    }
                }

                if (choose == "3")
                {
                    returnCode = true;
                    return;
                }
            }
        }
    }
}
