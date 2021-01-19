using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM_BL
{
    public class Customer
    {

        //read only, as DB sets this value
        public int CustomerId { get; private set; }

        public string EmailAddress { get; set; }

        //shorter syntax, creates a backing field automatically
        public string FirstName { get; set; }

        // longer syntax, use if we need to maipulate the data before we get or set it
        private string _lastName; //backing field
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
                string fullName = LastName;
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

    }
}
