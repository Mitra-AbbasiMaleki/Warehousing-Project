#nullable disable
using BaseBackend.Entities.Interfaces;
using BaseBackend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseBackend.Entities
{
    public class Order:IBaseEntity
    {
        private static int nextId = 1; //متغیر static برای تولید Id بعدی
        public int Id { get; set; }          //  شناسه سفارش
        public OrderStatus Status { get; set; }  // وضعیت سفارش
        public DateTime OrderDate { get; set; }  //تاریخ ثبت سفارش
        public string CustomerName { get; set; }   // مرجع به مشتری که سفارش را داده است
        public List<OrderItem> Items { get; set; } // لیست آیتم‌های موجود در سفارش
        public decimal TotalAmount  // مبلغ کل سفارش
        {
            get
            {
                return Items.Sum(item => item.TotalPrice);
            }
        }
        
        public Dictionary<Product, int> Products { get; set; } = new Dictionary<Product, int>();   // لیست محصولات و تعداد آنها

        // سازنده
        public Order(string customerName, List<OrderItem> items)
        {
            Id = nextId;
            nextId++;
            OrderDate = DateTime.Now;
            CustomerName = customerName;
            Items = items;
        }

        //اضافه کردن محصول به سفارش
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        //حذف کردن محصول از سفارش
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
    }
}
