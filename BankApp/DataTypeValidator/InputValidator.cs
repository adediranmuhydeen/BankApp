using BankApp.AccountOpening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankApp.DataTypeValidator
{
    public class InputValidator
    {
        public static bool PasswordValidator( string customerPassword)
        {
            
            bool result = false;
            string s = "^$";
            Regex pReg = new Regex(s);
            if (pReg.IsMatch(customerPassword))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        public InputValidator()
        {
        }
    }
}
