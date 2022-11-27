using BankApp.DataTypeValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AccountOpening
{
    public class Customer
    {
        public Customer()
        {

        }
        public string AcctType { get; set; }
        public string AcctNumber { get { return AcctNumberGeneration.AcctNumber(); } }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirsName + ", " + LastName; } }       
    }
}
