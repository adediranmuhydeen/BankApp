using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.LogInAndTransaction
{

    public class LoginChecker
    {
        
        public Dictionary<string, string> checkLogIn = null;
        public LoginChecker()
        {
            checkLogIn = new Dictionary<string, string>();
        }
        public bool AddLoginDetails(string email, string password)
        {
            int dictionarySize = checkLogIn.Count;
            checkLogIn.Add(email, password);
            int secondSize = checkLogIn.Count;
            if (secondSize -1 != dictionarySize)
            {
                return false;
            }
            else
            {
                return true;
            }            
        }

        public bool CheckLoginParameters (string email, string password)
        {
            
            foreach (KeyValuePair<string, string> kvp in checkLogIn)
            {
                if(kvp.Key == email && kvp.Value == password)
                {
                    return true;
                }
            }
           return false;
        }

        public bool AssignLoginParameters(string email, string password)
        {

            foreach (KeyValuePair<string, string> kvp in checkLogIn)
            {
                if (kvp.Key == email && kvp.Value == password)
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool LogCustomerIn()
        {

            return true;
        }
    }
}
