using BaseBackend.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace BaseBackend.Entities
{
    public class Warehouse: IBaseEntity
    {
        // خصوصیات انبار
        private static int nextId = 1; //متغیر static برای تولید Id بعدی
        public int Id { get; set; }          // شناسه انبار
        public string Name { get; set; }   //نام انبار 
        public string Location { get; set; }          // مکان انبار

        public Dictionary<Product, int> Inventory { get; set; }  // لیستی از محصولات و موجودی هرکدام

        // سازنده
        public Warehouse()
        { 
        }
        public Warehouse(string name,string location)
        {
            Id = nextId;
            nextId++;
            Name = name;
            Location = location;
            Inventory = new Dictionary<Product, int>();// لیستی از محصولات و موجودی هرکدام برای انبار
        }

        // افزودن محصول به انبار
        public void AddProductToWarehouse(Product product, int quantity)
        {
            if (Inventory.ContainsKey(product))
            {
                Inventory[product] += quantity; // اگر محصول موجود است، تعداد را افزایش بده
                product.UpdateQuantity(quantity);
            }
            else
            {
                Inventory.Add(product, quantity); // اگر محصول جدید است، آن را به انبار اضافه کن
            }
        }

        // کم کردن موجودی محصول از انبار
        public void RemoveProductFromWarehouse(Product product, int quantity)
        {
            if (Inventory.ContainsKey(product) && Inventory[product] >= quantity)
                Inventory[product] -= quantity; // کاهش موجودی
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
