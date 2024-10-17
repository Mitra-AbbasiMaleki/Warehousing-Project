using System;
using System.Collections.Generic;
using System.Text;
namespace BaseBackend.Entities
{
    public class Warehouse
    {
        // خصوصیات انبار
        private static int nextId = 1; //متغیر static برای تولید Id بعدی
        public int WarehouseID { get; set; }          // شناسه انبار
        public string Location { get; set; }          // مکان انبار
        
        public Dictionary<Product, int> Inventory { get; set; } = new Dictionary<Product, int>(); // لیستی از محصولات و موجودی هرکدام
        public List<Product> Products;

        // سازنده
        public Warehouse(int warehouseId, string location)
        {
            WarehouseID = nextId;
            nextId++;
            Location = location;
            Products = new List<Product>();
        }

        // افزودن محصول به انبار
        public void AddProductToWarehouse(Product product, int quantity)
        {
            //if ()
            //{
            //    Inventory[product] += quantity; // اگر محصول موجود است، تعداد را افزایش بده
            //    product.UpdateQuantity(quantity);
            //}
            //else
            //{
            //    Inventory.Add(product, quantity); // اگر محصول جدید است، آن را به انبار اضافه کن
            //}
            Console.WriteLine($"{quantity} units of {product.ProductName} added to the warehouse.");
            //if (Inventory.ContainsKey(product))
            //{
            //    Inventory[product] += quantity; // اگر محصول موجود است، تعداد را افزایش بده
            //    product.UpdateQuantity (quantity);
            //}
            //else
            //{
            //    Inventory.Add(product, quantity); // اگر محصول جدید است، آن را به انبار اضافه کن
            //}
            //Console.WriteLine($"{quantity} units of {product.ProductName} added to the warehouse.");
        }

        // حذف محصول از انبار
        public void RemoveProductFromWarehouse(Product product, int quantity)
        {
            if (Inventory.ContainsKey(product) && Inventory[product] >= quantity)
            {
                Inventory[product] -= quantity; // کاهش موجودی
                Console.WriteLine($"{quantity} units of {product.ProductName} removed from the warehouse.");
            }
            else
            {
                Console.WriteLine($"Insufficient stock of {product.ProductName} to remove {quantity} units.");
            }
        }

        // نمایش موجودی انبار
        public void ShowInventory()
        {
            Console.WriteLine("Warehouse Inventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"Product: {item.Key.ProductName}, Stock: {item.Value}");
            }
        }
        // جستجوی محصول بر اساس شناسه
        public Product FindProductById(int productId)
        {
            foreach (var item in Inventory)
            {
                if (item.Key.Id == productId)
                {
                    return item.Key; // محصول مورد نظر پیدا شد
                }
            }
            return null; // اگر محصول یافت نشد
        }

       // چک کردن موجود بودن یک کالا
        public bool IsValidQuantity(int productId)
        {
            var product = FindProductById(productId);
            return product!=null? true : false;
        }
    }

}
