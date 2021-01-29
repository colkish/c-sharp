using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM_BL
{
    public class Customer //I want to access this elsewhere so must be public (not the default), this is called the acces modifier
    { //Anything public is the class interface (or contract) once in poruction we should add and never remove from the interface 


        //Constructor is a special type of method which is called automatically when an object of this class in instanciated
        //has the same name as the class
        //define at the top of the class
        //ctor tab tab is the shortcut
        public Customer() //default contructor, must define it if we want to overload it, even if it does nothing
        {
            
        }
        
        //overloaded constructor
        public Customer(int customerId)
        {   //set property to passed 
            CustomerId = customerId;
        }

        //PROPERTIES Start with a capital
        //prop tab tab is the shortcut
        //read only, as DB sets this value
        public int CustomerId { get; private set; }

        public string EmailAddress { get; set; }

        //shorter syntax, creates a backing field automatically
        public string FirstName { get; set; }

        // longer syntax, use if we need to maipulate the data before we get or set it
        private string _lastName; //backing field these are private start with a _
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        //for fullname its a read only property (no setter) that we manipulate from 2 other properties
        //dont need a backing feild as we are using first and last name which already have them
        public string FullName
        {
            get
            {
                string fullName = LastName;         //normal variable start with lowe case    
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;

                }
                return fullName;
            }
        }

        //A static property belongs to the class and not an instance of the class 
        public static int InstanceCount { get; set; }

        //METHODS

        //gets all customers I can give it the same name as above as longs as it has a different signature, in this case paramters are different
        //this is called the method signature, the name and the paramter tpes, NOT the return type
        //this is called overloading, ie.e same name but different parameter types
        public List<Customer> Retreive()
        {

            return new List<Customer>();
        }

        public bool Validate() 
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;
            return isValid;
        }

    }
}
