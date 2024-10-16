using System.Collections.Generic;


namespace BaseBackend.Entities.Interfaces
{
    public interface IOrder
    {
        public Order CreateOrder(Customer customer, List<OrderItem> items);  // متد برای ایجاد سفارش
    }
}
