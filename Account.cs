using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppATM
{
    public class Account
    {
        private string userId;
        private string userName;
        private string password;
        private double balance;
        public string UserId
        {
            get { return userId; }
            set
            {
                if (Regex.IsMatch(value, "^[A-Z]{2,}\\d{5,}$"))
                {
                    userId = value;
                }
                else
                {
                    throw new FormatException("Try again. UserId begins with 2 capital letters, followed by at least 5 digits.");
                }

            }
        }
        public string UserName
        {
            get { return userName; }
            set
            {
                if (value.Trim().Length > 5)
                {
                    userName = value;
                }
                else
                {
                    throw new FormatException("Try again.UserName must have at least 5 characters.");
                }
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (Regex.IsMatch(value, "^[A-Za-z0-9]{8,15}"))
                {
                    password = value;
                }
                else
                {
                    throw new FormatException("Try again. Password must contain 8-15 characters of uppercase, lowercase and digits");
                }
            }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }

        }
    }
}
