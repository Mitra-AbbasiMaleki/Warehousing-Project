#nullable disable
using BaseBackend.Entities.Interfaces;
using BaseBackend.Enums;
using System;

namespace BaseBackend.Entities
{
    public class Person: IBaseEntity, ICreateableEntity, IDeleteableEntity, IUpdatableEntity
    {
        private static int nextId = 1; //متغیر static برای تولید Id بعدی
        public int Id { get; set; }   // شناسه شخص
        public UserRole Role { get; set; }      // موقعیت شغلی
        public string FirstName { get; set; }      // نام
        public string LastName { get; set; }       // نام خانوادگی
        public string NationalCode { get; set; }   //کد ملی
        public string PhoneNumber { get; set; }    // شماره تماس
        public string Address { get; set; }        // آدرس
        //پیاده سازی اینترفیس
        public DateTime CreatedAt { get; set; } //تاریخ ایجاد
        public int CreatedByUserId { get; set; } //شخص ایجاد کننده
        public DateTime updatedAt { get; set; } //تاریخ بروزرسانی
        public int UpdatedByUserId { get; set; } // شخص بروزرسانی کننده
        public bool IsDeleted { get; set; } //خذف شده
        public DateTime DeletedAt { get; set; } //تاریخ حذف
        public int DeletedByUserId { get; set; } //شخص حذف کننده
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        // سازنده کلاس
        public Person(UserRole role,string firstName, string lastName, string nationalCode, string phoneNumber, string address)
        {
            Id = nextId;
            nextId++;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        // سازنده کلاس
        public Person(UserRole role, string firstName, string lastName, string nationalCode)
        {
            Id = nextId;
            nextId++;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
        }
        public string GetFullName
        {
            get { return FirstName + " " + LastName; }
        }
        public void UpdateContactInfo(string newPhoneNumber, string newEmail, string newAddress)
        {
            UpdatedByUserId = this.Id;
            PhoneNumber = newPhoneNumber;
            Address = newAddress;
            Console.WriteLine("اطلاعات تماس مشتری به‌روزرسانی شد.");
        }

    }
    
}

