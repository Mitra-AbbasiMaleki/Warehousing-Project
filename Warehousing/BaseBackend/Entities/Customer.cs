#nullable disable
using BaseBackend.Entities.Interfaces;
using BaseBackend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BaseBackend.Entities
{
    public class Customer:Person, IBaseEntity
    {
        // ویژگی‌های مشتری

        public DateTime RegistrationDate { get; set; }  // تاریخ ثبت‌ نام مشتری
        public List<Order> Orders { get; set; }  // سوابق سفارش

        // سازنده کلاس
        public Customer(UserRole role,string firstName, string lastName, string nationalCode, string phoneNumber, string address)
        : base(role,firstName, lastName, nationalCode,phoneNumber,address)  //فراخوانی سازنده کلاس پایه
        {
            RegistrationDate = DateTime.Now; // ثبت تاریخ فعلی به عنوان تاریخ ثبت‌نام
            Orders = new List<Order>();  // ایجاد لیست خالی برای سوابق سفارش
        }

        public Customer (UserRole role,string firstName, string lastName, string nationalCode)
        : base(role,firstName, lastName, nationalCode)  //فراخوانی سازنده کلاس پایه
        {
            RegistrationDate = DateTime.Now; // ثبت تاریخ فعلی به عنوان تاریخ ثبت‌نام
            Orders = new List<Order>();  // ایجاد لیست خالی برای سوابق سفارش
        }
        //برای ایجاد سفارش جدید
        public void CreateOrder(Order newOrder)
        {
            // بررسی اینکه آیا سفارشی با این orderId وجود دارد
            if (!Orders.Any(o => o.Id == newOrder.Id))
            {
                Orders.Add(newOrder);
            }

        }

        // افزودن سفارش به سوابق مشتری
        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
    }


}
