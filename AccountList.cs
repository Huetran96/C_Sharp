namespace AppATM
{
    public class AccountList
    {
        SortedList<string, Account> accountList = new SortedList<string, Account>();
        string currentID = null;
        int amount;
        int cnt;
        public void create()
        {
            Account acc = new Account();
            acc.Balance = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter user ID: ");
                    acc.UserId = Console.ReadLine().Trim();
                    if (accountList.ContainsKey(acc.UserId))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new Exception("ID already exists, try again.");
                        Console.ResetColor();
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter user name: ");
                    acc.UserName = Console.ReadLine();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter password: ");
                    acc.Password = Console.ReadLine().Trim();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Create new account suscessfully.");
            Console.ResetColor();
            accountList.Add(acc.UserId, acc);
        }
        public void login()
        {
            Console.WriteLine("Enter user ID: ");
            string lgID = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string lgPassword = Console.ReadLine();
            if (accountList.ContainsKey(lgID) && accountList[lgID].Password.Equals(lgPassword))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login successed.");
                Console.ResetColor();
                currentID = lgID;
                cnt = 0;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login failed, try again. (maximum 5 times)");
                Console.ResetColor();
                cnt++;
                if (cnt <= 5)
                {
                    login();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have failed 5 times, your account is locked.");
                    Console.ResetColor();

                }
            }
        }
        public void deposit()
        {
            login();
            if (cnt <=5) {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("DEPOSIT ACCOUNT SERVICE.");
                Console.ResetColor();
                Console.WriteLine("How much money do you want to deposit?");
                enterAmount();
                Console.WriteLine("Insert money into, please!");
                Console.WriteLine("Please wait for countting....");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Deposit acount successed. ");
                Console.ResetColor();
                accountList[currentID].Balance += amount;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your account is locked, cannot be used .");
                Console.ResetColor();

            }
        }
        public void withDraw()
        {
            login();
            if (cnt <=5)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("WITHDRAW ACCOUNT SERVICE.");
                Console.ResetColor();
                Console.WriteLine("How much money do you want to withdraw?");
                enterAmount();
                double fee = (amount * 0.067 / 100);
                if ((amount + fee) < accountList[currentID].Balance)
                {
                    Console.WriteLine("Please wait for countting....");
                    accountList[currentID].Balance -= (amount + fee);
                    Console.WriteLine("Take money, please!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Withdaw successed. ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Balance is not enough.");
                    Console.ResetColor();
                    enterAmount();
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your account is locked, cannot be used .");
                Console.ResetColor();
            }
            
        }

        public void ckeckAccount()
        {
            login();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("YOUR ACCOUNT'S INFORMATION.");
            Console.ResetColor();
            Console.WriteLine("User name: " + accountList[currentID].UserName);
            Console.WriteLine("Balance: " + accountList[currentID].Balance);
        }
        public void enterAmount()
        {
            int op;
            Console.WriteLine("1: 500.000 vnd");
            Console.WriteLine("2: 1.000.000 vnd");
            Console.WriteLine("3: 1.500.000 vnd");
            Console.WriteLine("4: Other amount");
            Console.WriteLine("Selecct amount:  ");
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    amount = 500000;
                    break;
                case 2:
                    amount = 1000000;
                    break;
                case 3:
                    amount = 1500000;
                    break;
                case 4:
                    while (true)
                    {
                        Console.WriteLine("Enter amount: ");
                        amount = int.Parse(Console.ReadLine());
                        if (amount % 50000 != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The amount must be multiple of 50.000 vnd, please try again.");
                            Console.ResetColor();
                        }
                        else break;
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid, try again.");
                    Console.ResetColor();
                    break;
            }

        }
    }
}
