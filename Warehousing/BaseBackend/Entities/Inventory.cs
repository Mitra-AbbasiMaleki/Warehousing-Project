#nullable disable
using System;
using System.Collections.Generic;
namespace BaseBackend.Entities
{
    public class Inventory
    {
        //private static int nextId = 1; //متغیر static برای تولید Id بعدی
        public int InventoryId { get; set; } // شناسه موجودی
        public int WarehouseId { get; set; } //شناسه انبار
        public int ProductId { get; set; } //شناسه کالا
        public int Quantity { get; set; } //مقدار موجودی کالا

        private Dictionary<int, Product> products = new Dictionary<int, Product>();  // لیستی از محصولات موجود در انبار
        private List<Order> orders = new List<Order>();                              // لیستی از سفارش‌ها
        private List<Customer> customers = new List<Customer>();                    // لیستی از مشتریان
        
        // اضافه کردن محصول به انبار
        public void AddProduct(Product product)
        {
            if (products.ContainsKey(product.Id))
            {
                products[product.Id].UpdateQuantity(product.Quantity);
            }
            else
            {
                products[product.Id] = product;
            }
        }

        // حذف یا کاهش موجودی یک محصول
        public void RemoveProduct(int productId, int quantity)
        {
            if (products.ContainsKey(productId))
            {
                Product product = products[productId];
                if (product.Quantity >= quantity)
                {
                    product.UpdateQuantity(-quantity);
                }
                else
                {
                    Console.WriteLine("مقدار کافی در انبار موجود نیست.");
                }
            }
            else
            {
                Console.WriteLine("محصول یافت نشد.");
            }
        }

        // اضافه کردن مشتری به سیستم
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        // ثبت یک سفارش
        //public void PlaceOrder(Order order)
        //{
        //    orders.Add(order);
        //    foreach (var product in order.Products)
        //    {
        //        RemoveProduct(product.Id, product.Quantity);  // کم کردن موجودی محصول به‌ازای هر سفارش
        //    }
        //}

        private void RemoveProduct(object id, object quantity)
        {
            throw new NotImplementedException();
        }

        // مشاهده ارزش کل موجودی انبار
        public decimal GetInventoryValue()
        {
            decimal totalValue = 0;
            foreach (var product in products.Values)
            {
                totalValue += product.GetTotalValue();
            }
            return totalValue;
        }

        // نمایش لیست محصولات در انبار
        public void DisplayProducts()
        {
            foreach (var product in products.Values)
            {
                Console.WriteLine($"محصول: {product.Name}, مقدار: {product.Quantity}, قیمت: {product.Price}");
            }
        }

        // نمایش لیست سفارشات
        public void DisplayOrders()
        {
        }
    }

}
