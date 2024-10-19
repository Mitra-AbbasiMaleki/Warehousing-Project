using System;
using System.Collections.Generic;
using System.Text;

namespace BaseBackend.Entities
{
    public class Address
    {
        int nextid = 0;
        public int Id { get; set; }
        public int PostalCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public Address() 
        {
            Id = nextid;
            nextid++;
        }
        public Address(string province,string city,string street,string number):this()
        {
            Province = province;
            City = city;
            Street = street;
            Number = number;
        }
        public string ShortAddress
        {
            get
            {
               return City + "-" + Street;
            }
        }
    }
}
