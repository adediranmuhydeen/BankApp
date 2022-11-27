using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.LogInAndTransaction
{
    public class AcctTypeSelector
    {
        public static string AcctType(int num)
        {
            string type = "";
            if (num == 1)
            {
                type = "Savings";
            }
            else if (num == 2)
            {
                type = "Current";
            }
            return type;
        }
    }
}
