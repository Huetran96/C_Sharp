using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppATM
{
    class MainApp
    {
        static void Main(string[] args)
        {
            
            AccountList accountListObj = new AccountList();
           
            int choose;
            do
            {
                Menu();
                choose = Int32.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:accountListObj.create();
                        break;
                    case 2: accountListObj.deposit();
                        break;

                    case 3:accountListObj.withDraw();
                        break;
                    case 4:accountListObj.ckeckAccount();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Thank you for using my service. Good bye.");
                        Console.ResetColor();
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid, try again please.");
                        Console.ResetColor();
                        break;
                }
            } while (choose != 5);

        }
        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------WELCOME----------");
            Console.ResetColor();
            Console.WriteLine("1. Create new account.");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Check your account. ");
            Console.WriteLine("5. Exit.");
            Console.WriteLine(" Choose service please!");
        }
        
    }
}
