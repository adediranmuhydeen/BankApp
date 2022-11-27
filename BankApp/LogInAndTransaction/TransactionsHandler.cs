using BankApp.AccountOpening;
using BankApp.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weekOne.Ui;

namespace BankApp.LogInAndTransaction
{

    public class TransactionsHandler 
    {
        AcctTypeSelector act = new AcctTypeSelector();
        Customer customer;
        DateTime myDate = DateTime.Now;
        AcctStatement myStatement = new AcctStatement();
        AcctStatement myBallance = new AcctStatement();
        double acctBallance = 0, depositAmount, newBallance, withdrawalAmount;
        string statementBody;

        public TransactionsHandler()
        {

        }
        public TransactionsHandler(Customer customer)
        {
            this.customer = customer;
        }


        string acctStatementHeader = "|-------------------|-------------------------------|--------------------------|---------------------|\n| DATE                         DESCRIPTION                     AMOUNT              BALANCE    \n|-------------------|-------------------------------|--------------------------|---------------------|";

        public double MakeDeposit(double depositAmount) 
        {

            acctBallance += depositAmount;
            return acctBallance;
        }
        public double MakeWithdarawal(double withdarawlAmount)
        {
            if(acctBallance <= 1000 || acctBallance < withdarawlAmount + 1000)
            {
                Console.WriteLine();
            }
            acctBallance -= withdarawlAmount;
            return acctBallance;
        }
        public object AddDisplayToStatement(int requestType)
        {
            if (requestType == 2)
            {
                depositAmount = DataTypeChecker.Convert<double>("Enter the amount to deposit");                
                newBallance = MakeDeposit(depositAmount);
                statementBody =$"\n|{myDate}      Mobile Deposit                         {depositAmount}                  {newBallance}        \n|-------------------|-------------------------------|--------------------------|---------------------|";
                acctStatementHeader += statementBody;
                myStatement.UpdateStatementTable(acctStatementHeader);
                Console.WriteLine($"You have deposited {depositAmount} successfully");
            
            }
            else if (requestType == 3)
            {
                withdrawalAmount = DataTypeChecker.Convert<double>("Enter the amount to Withdawal");                
                newBallance = MakeWithdarawal(withdrawalAmount);
                statementBody = $"\n| {myDate}      Mobile Withdrawal                      {withdrawalAmount}                  {newBallance}        \n|-------------------|-------------------------------|--------------------------|---------------------|";
                acctStatementHeader += statementBody;
                myStatement.UpdateStatementTable(acctStatementHeader);
                Console.WriteLine($"You have withdrawn {withdrawalAmount} successfully");
            }
            string acctBallanceHeader = $"|-------------------|-------------------------------|--------------------------|---------------------|\n| FULL NAME         | ACCOUNT NUMBER                |  ACCOUNT TYPE            | AMOUNT BAL          |\n|-------------------|-------------------------------|--------------------------|---------------------|\n {customer.FullName}                 {customer.AcctNumber}                       {customer.AcctType}               {newBallance}         \n|-------------------|-------------------------------|--------------------------|---------------------|";

            if (requestType == 1)
            {
                Console.WriteLine(acctBallanceHeader);
            }
            else if (requestType == 4)
            {

            }
            else if(requestType == 5) { Console.WriteLine(acctStatementHeader); }

            return myStatement;
        }
        public void displayStatementOfAcct()
        {
            foreach (var statement in acctStatementHeader)
            {
                Console.WriteLine(statement);
            }
        }
    }
}
