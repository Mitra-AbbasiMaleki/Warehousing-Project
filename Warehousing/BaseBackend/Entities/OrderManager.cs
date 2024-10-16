using BaseBackend.Entities.Interfaces;
using System.Collections.Generic;

namespace BaseBackend.Entities
{
    public class OrderManager:IOrder
    {
        private List<Order> Orders = new List<Order>(); // لیست سفارش‌ها

        //ایجاد سفارش جدید
        public Order CreateOrder(Customer customer, List<OrderItem> items)
        {
            Order newOrder = new Order(customer.FullName, items);
            Orders.Add(newOrder);
            customer.AddOrder(newOrder);
            return newOrder;
        }

        public void DisplayOrders()
        {
           // foreach (var order in Orders)
        }
    }

}
