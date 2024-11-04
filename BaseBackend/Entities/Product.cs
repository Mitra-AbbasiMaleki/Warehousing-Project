#nullable disable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using BaseBackend.Entities.Interfaces;
using BaseBackend.Enums;

namespace BaseBackend.Entities
{
    [DebuggerDisplay("ProductName:{Name} - CategoryName:{CategoryName} - Quantity:{Quantity} - Price:{Price}.")]
    public class Product : IBaseEntity
    {
        #region property
        private readonly int nextId = 1;
        public int Id { get; set; }   // شناسه محصول
        public string Name { get; set; }     // نام محصول
        public ProductCategory Category { get; set; } //گروه محصول
        public string CategoryName
        {
            get { return Category != null ? Category.CategoryName : "No Category"; }
        }
        public int Quantity { get; set; }           //تعداد محصول
        public decimal Price { get; set; }          // قیمت خرید
        public DateTime ExpiryDate { get; set; }    //تاریخ انقضا
        public string Description { get; set; }     //توضیحات محصول
        public Warehouse Warehouse { get; set; }    //ارجاع به انیار
        public ProductStatus Status { get; set; }   // وضعیت محصول
        public MeasurementUnit Unit { get; set; }   //واحد اندازه گیری
        public Person Supplier { get; set; }        //نام تامین کننده کالا

        public string UnitName
        { 
            get { return Unit != null ? Unit.Name : "No Unit"; } 
        }
        public string WarehouseName
        {
            get { return Warehouse != null ? Warehouse.Name : "No Warehouse"; }
        }

        public string SupplierFullName
        { 
            get { return Supplier != null ? Supplier.FullName : "شخص مورد نظر پیدا نشد"; }
        }

        //public DateTime CreatedAt { get; set; } //تاریخ ایجاد
        //public int CreatedByUserId { get; set; } //شخص ایجاد کننده
        //public DateTime updatedAt { get; set; } //تاریخ بروزرسانی
        //public int UpdatedByUserId { get; set; } // شخص بروزرسانی کننده
        //public bool IsDeleted { get; set; } //خذف شده
        //public DateTime DeletedAt { get; set; } //تاریخ حذف
        //public int DeletedByUserId { get; set; } //شخص حذف کننده
        #endregion

        #region constructor
        //   کلاس سازنده محصولات
        public Product()
        {
            Id = nextId++;
        }
        public Product(string name, ProductCategory category, int quantity, MeasurementUnit unit):this()
        {
            Name = name;
            Category = category;
            Quantity = quantity;
            Unit = unit;
        }
        public Product(string name, ProductCategory category, int quantity, MeasurementUnit unit, decimal price, ProductStatus? status = null) :this(name, category, quantity, unit)
        {
            Status = status ?? ProductStatus.Available;
            Price = price;
        }
        public Product(string name, ProductCategory category, int quantity, MeasurementUnit unit, decimal price,Warehouse warehouse, Person supplier,DateTime expiryDate, string description, ProductStatus? status = null)
            :this(name,category,quantity,unit,price, status)
        {
            Warehouse = warehouse;
            Supplier = supplier;
            ExpiryDate = expiryDate;
            Description = description;
        }

        #endregion

        #region Method
        //مقداردهی اولیه به وضعیت کالا
        private void InitialStatus() => Status = ProductStatus.Available;
        // متد برای به‌روزرسانی موجودی کالا
        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity > 0)
                Quantity += newQuantity;
            else
                return;
        }
        // متد برای چک کردن موجودی
        public bool IsAvailable(int quantity)
        {
            return Quantity > quantity;
        }

        // متد برای چک کردن تاریخ انقضا
        public bool IsExpired()
        {
            return DateTime.Now > ExpiryDate;
        }

        // متد برای کاهش موجودی پس از فروش کالا
        public bool SellProduct(int quantity)
        {
            if (IsAvailable(quantity))
            {
                Quantity -= quantity;
                return true;  // فروش موفقیت‌آمیز بود
            }
            else
                return false; // موجودی کافی نیست
        }

        //برای به‌روزرسانی اطلاعات محصول
        public void UpdateProductInfo(string newName, decimal newPrice, ProductCategory newCategory, int newQuantity)
        {
            if (!string.IsNullOrEmpty(newName))
                Name = newName;

            if (newPrice > 0)
                Price = newPrice;

            // به روزرسانی گروه محصول
            Category = newCategory;

            if (newQuantity >= 0)
                Quantity = newQuantity;
        }

        // لیستی از محصولات منقضی شده
        public static List<Product> GetExpiredProducts(List<Product> products)
        {
            List<Product> expiredProducts = new List<Product>();

            foreach (var product in products)
            {
                if (product.ExpiryDate < DateTime.Now) // بررسی تاریخ انقضا
                {
                    expiredProducts.Add(product);
                }
            }
            return expiredProducts;
        }
        #endregion
    }
}
