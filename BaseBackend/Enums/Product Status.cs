using System.ComponentModel;

namespace BaseBackend.Enums
{
    public enum ProductStatus
    {
        [Description("موجود")]
        Available,       

        [Description("ناموجود")]
        Unavailable,     

        [Description("سفارش داده شده")]
        BackOrdered,   
    }
}
