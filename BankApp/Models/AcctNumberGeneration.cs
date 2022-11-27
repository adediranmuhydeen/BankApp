using BankApp.LogInAndTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AccountOpening
{
    public class AcctNumberGeneration : AcctTypeSelector
    {
        
        Customer customer;
        public static string AcctNumber()
        {
            string s = string.Empty;
            Random r = new Random();
            for(int i = 0; i < 10; i++)
            {
               s = String.Concat(s, r.Next(0, 9).ToString());
            }
            return s;
        }
        private string EmailValidation(string email)
        {
            return " ";
        }
        public string GetAcctNumber()
        {
            string customerEmail = customer.Email;
            EmailValidation(customerEmail);
            return "Please Try Again";
        }
    }

}
