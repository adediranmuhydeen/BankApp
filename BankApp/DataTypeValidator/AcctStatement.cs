using BankApp.LogInAndTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Tables
{
    public class AcctStatement
    {
        private Stack<string> statmentOfAcctHandler = null;
        private Stack<string> ballanceDispAccountHandler = null;
        public AcctStatement()
        {
            statmentOfAcctHandler = new Stack<string>();
            ballanceDispAccountHandler = new Stack<string>();  
        }
        
        public void UpdateStatementTable(string acctNameAndBallanceDisp)
        {
            statmentOfAcctHandler.Push(acctNameAndBallanceDisp);

        }
    }
}


  
