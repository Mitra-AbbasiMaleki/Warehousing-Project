#nullable disable
using BaseBackend.Entities.Interfaces;
using BaseBackend.Enums;
using System;

namespace BaseBackend.Entities
{
    public class Person: IBaseEntity
    {
        private static int nextId = 1; //متغیر static برای تولید Id بعدی
        public int Id { get; set; }   // شناسه شخص
        public UserRole Role { get; set; }      // موقعیت شغلی
        public string FirstName { get; set; }      // نام
        public string LastName { get; set; }       // نام خانوادگی
        public string NationalCode { get; set; }   //کد ملی
        public string PhoneNumber { get; set; }    // شماره تماس
        public Address Address { get; set; }        // آدرس
        public string address
        {
            get { return Address != null ?Address.ShortAddress : "No Unit"; }
        }
        //پیاده سازی اینترفیس
        //public DateTime CreatedAt { get; set; } //تاریخ ایجاد
        //public int CreatedByUserId { get; set; } //شخص ایجاد کننده
        //public DateTime updatedAt { get; set; } //تاریخ بروزرسانی
        //public int UpdatedByUserId { get; set; } // شخص بروزرسانی کننده
        //public bool IsDeleted { get; set; } //خذف شده
        //public DateTime DeletedAt { get; set; } //تاریخ حذف
        //public int DeletedByUserId { get; set; } //شخص حذف کننده
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        // سازنده کلاس
        public Person()
        {
            Id = nextId;
            nextId++;
        }
        // سازنده کلاس
        public Person(UserRole role, string firstName, string lastName, string nationalCode):this()
        {
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
        }
        // سازنده کلاس
        public Person(UserRole role,string firstName, string lastName, string nationalCode, string phoneNumber, Address address):this(role,firstName,lastName,nationalCode)
        {
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public void UpdateContactInfo(string newPhoneNumber, string newEmail, Address newAddress)
        {
            //UpdatedByUserId = this.Id;
            PhoneNumber = newPhoneNumber;
            Address = newAddress;
        }

    }
    
}

