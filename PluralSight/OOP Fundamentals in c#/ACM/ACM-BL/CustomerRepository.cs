using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM_BL
{
    public class CustomerRepository
    {

        //create a constructore that creates a new addess repo
        //this establishes a collaboarative relationship between customer repo and address repo
        //another and better way to do this is use an id, see oder rleationship to customer fot this
        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }

        //defina a get and setter for the address repo
        private AddressRepository addressRepository { get; set; }

        //create a Retrieve method which takes a customer Id and and returns it
        public Customer Retrieve(int customerId)
        {
            //create an instance of the customer class
            //customer is the reference variable of type Customer, here I am instanciating it by calling the custrutor with the Id paramter
            //customerId is set on when variable is instanciated
            Customer customer = new Customer(customerId);

            //Lets temp hard coded values to return a populated customer for ID 1
            //Normally we would go to the DB to get these values for ID 1
            if (customerId == 1)
            {
                customer.EmailAddress = "ckish@hublsoft.com";
                customer.FirstName = "Colin";
                customer.LastName = "Kish";
                //now return the customer address list also need to convert it to a list
                customer.AddressList = addressRepository.RetrieveByCustomerId(customerId).ToList();
            }

            return customer;
        }

        //Save method takes in a customer type and saves it to the DB
        public bool Save(Customer customer)
        {

            return true;
        }
 
        
    }
}
