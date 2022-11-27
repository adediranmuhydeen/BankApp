using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.DataTypeValidator
{
    public class WaitingMessage
    {
        public static void Proceed()
        {
            Console.WriteLine("\n\nPress Enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
