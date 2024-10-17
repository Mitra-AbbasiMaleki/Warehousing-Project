using BaseBackend.Entities.Interfaces;

namespace BaseBackend.Entities
{
    public class OrderItem:IBaseEntity
    {
        public int Id { get; set; } //شناسه جزئیات سفارش
        public string ProductName { get; set; } //نام محصول
        public int Quantity { get; set; } //تعداد محصول
        public decimal UnitPrice { get; set; } // قیمت هر واحد از محصول

        public decimal TotalPrice //محاسبه قیمت محصول = تعداد * قیمت واحد
        {
            get { return Quantity * UnitPrice; }
        }
    }
}
