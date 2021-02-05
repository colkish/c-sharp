using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM_BL
{
    class AddressRepository
    {

        //Method to return a address
        public Address Retrieve(int addressId)
        {
            Address address = new Address(addressId);

            if (addressId == 1)
            {
                address.AddressType = 1;
                address.StreetLine1 = "14 Oughton Close";
                address.StreetLine2 = "Leven Estate";
                address.City = "Yarm";
                address.StateProvince = "North Yorkshire";
                address.PostalCode = "TS15 9TP";
                address.Country = "UK";

            }

            return address;
        }

        //method to retrieve all addresses for a given customer as a enumeration
        public IEnumerable<Address> RetrieveByCustomerId(int customerId)
        {
            List<Address> addressList = new List<Address>();
            Address address = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "14 Oughton Close",
                StreetLine2 = "Leven Estate",
                City = "Yarm",
                StateProvince = "North Yorkshire",
                PostalCode = "TS15 9SZ",
                Country = "UK"
            };
            addressList.Add(address);

            address = new Address(2) //no need to instanciate here, already done that, we just now set it to the address 2
            {
                AddressType = 2,
                StreetLine1 = "72 Wetherall",
                StreetLine2 = "Layfield Estate",
                City = "Yarm",
                StateProvince = "North Yorkshire",
                PostalCode = "TS15 9TP",
                Country = "UK"
            };
            addressList.Add(address);
            return addressList;
        }

        public bool Save(Address address)
        {
            return true;
        }

    }
}
