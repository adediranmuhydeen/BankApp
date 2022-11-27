using BankApp.AccountOpening;
using BankApp.DataTypeValidator;
using BankApp.LogInAndTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weekOne.Ui;
using System.Text.RegularExpressions;

namespace BankApp
{
    internal class BankOperation
    {

        static void Main(string[] args)
        {
            Console.Title = "Bank Application";
            
            TransactionsHandler transactionsHandler = null;
            Customer customer = new Customer();

            //Declaring variables
            int acctTypeSelector;
            LoginChecker loginChecker = new LoginChecker();
            string acctType;
            double acctBallance = 0.00;
            int numberOfAcct;
            
            //Collection of data from User

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-----------------------------Welcome To Our Bank-----------------------------\n\nKindly enter your information bellow to open an account");

            customer.FirsName = DataTypeChecker.Convert<string>("\nEnter your first name: ");

            customer.LastName = DataTypeChecker.Convert<string>("Enter your last name");

        
            string phone = DataTypeChecker.Convert<string>("Enter your phone number");
            customer.PhoneNumber = phone.ToString();
            transactionsHandler = new TransactionsHandler(customer);
            
            start:
            string email = DataTypeChecker.Convert<string>("Enter your e-mail address. NB: this will be used as your UserID");
            customer.Email = email;
            if (email.Contains('@') == false || email.Contains('.') == false)
            {
                Console.WriteLine("Enter a valid e-mail address");
                goto start;
            }
            //control:
            string customerPassword = DataTypeChecker.Convert<string>("Kindly choose your PASSWORD ");
            customer.Password = customerPassword;
            bool test = InputValidator.PasswordValidator(customer.Password);
            //if (test == false)
            //{
            //    Console.WriteLine("Your Password must contain special character and not less than 6 in length");
            //    goto control;
            //}

            bool result = loginChecker.AddLoginDetails(email, customer.Password);
            if (result == false)
            {
                Console.WriteLine("");
            }
            Console.WriteLine("Profile created successfully");
            //Customer.Proceed();   
            checkNum:
            numberOfAcct = DataTypeChecker.Convert<int>("How many accounts are you willing to open? (Kindly enter it in figure)");

            if (numberOfAcct > 5 || numberOfAcct < 1)
            {
                Console.WriteLine("\n\nYou can only open 5 account numbers, Pleasee enter a valid input");
                goto checkNum;
            }

            string acctNameAndBallanceDisp;
            while (numberOfAcct > 0)
            {
                Check:
                acctTypeSelector = DataTypeChecker.Convert<int>("Press 1 for Savings Account \nPress 2 for Current Account");
                if(acctTypeSelector > 2 || acctTypeSelector < 1)
                {
                    Console.WriteLine("\nInvalid input, please try again");
                    goto Check;
                }
                customer.AcctType = AcctNumberGeneration.AcctType(acctTypeSelector);
                
                Console.WriteLine($" Congratulations , a {customer.AcctType} account with account number {customer.AcctNumber} has been opened for you ");
                acctNameAndBallanceDisp = $"\n {customer.FullName}          {customer.AcctNumber}                       {customer.AcctType}               {acctBallance}         \n|-------------------|-------------------------------|--------------------------|---------------------|";
                numberOfAcct--;
            }
            //Customer.Proceed();
            Point:
            Console.WriteLine("Kindly Longin to your Profile");

            string UserIdEntered = DataTypeChecker.Convert<string>("\nPlease, enter your email address (UserID)");            

            string passwordEntered = DataTypeChecker.Convert<string>("\nPlease, enter your password");

            bool accessGranter = loginChecker.CheckLoginParameters(UserIdEntered, passwordEntered);

            if(accessGranter == false)
            {
                Console.WriteLine("\nInvalid UserID and Password");
                goto Point;
            }
            
        Tail:
            int requestType = DataTypeChecker.Convert<int>("\nKindly choose appropriate option:\n1) Check Acct Ballance \n2) Make Deposit \n3) Make a Withdrawal\n4) Transfer Fund\n5) Statement of Account");
            
            if(requestType > 5 || requestType < 1)
            {
                Console.WriteLine("The option you chose is invalid");
                goto Tail;
            }

            transactionsHandler.AddDisplayToStatement(requestType);
            //Customer.Proceed();
            goto Tail;
            





        }
    }
}
