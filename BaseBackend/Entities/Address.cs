using BaseBackend.Entities.Interfaces;
using BaseBackend.Enums;
using System.Diagnostics;

namespace BaseBackend.Entities
{
    [DebuggerDisplay("Address {Name}: {City} - {Street}.")]
    public class Address : IBaseEntity
    {
        private readonly int nextId = 1; 
        public int Id { get; set; }                    // شناسه آدرس
        public AddressTitle Title { get; set; }                  //عنوان محل آدرس
        public int PersonId { get; set; }              // شناسه شخص
        public string PostalCode { get; set; }         // کد پستی
        public string Province { get; set; }           // استان
        public string City { get; set; }               // شهر 
        public string Street { get; set; }             // خیابان
        public string Number { get; set; }             // پلاک 
       
        //سازنده کلاس
        public Address()
        {
            Id = nextId++;
        }
        public Address(AddressTitle title,string city, string street):this()
        {
            Title = title;
            City = city;
            Street = street;
        }
        public Address(AddressTitle title,string province,string city,string street,string number):this(title,city,street)
        {
            Province = province;
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
