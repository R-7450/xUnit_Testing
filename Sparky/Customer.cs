using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public int OrderTotal { get; set; }
        public string GreetMessage {  get; set; }
        public bool IsPlatinum { get; set; }

        public Customer()
        {
            IsPlatinum=false;
        }
        public string GreetAndCombineNmaes(string FirstName,string LastName)
        {
            if(string.IsNullOrWhiteSpace(FirstName))
            {
                throw new ArgumentException("Empty first name");
            }
            GreetMessage=$"Hello, {FirstName} {LastName}";
        
            return GreetMessage ;
        }
        public CustomerType GetCustomerDetails()
        {
            if(OrderTotal<100)
            {
                return new BasicCustomer();
            }
            return new  PlatinumCustomer();
        }
    }

    public class CustomerType { }
    public class BasicCustomer:CustomerType { }
    public class PlatinumCustomer:CustomerType { }
}
