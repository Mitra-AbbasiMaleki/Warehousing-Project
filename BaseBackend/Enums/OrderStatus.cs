using System.ComponentModel;

namespace BaseBackend.Enums
{
    public enum OrderStatus
    {
        [Description("در انتظار پرداخت")]
        PendingPayment,

        [Description("تأیید شده")]
        Confirmed,

        [Description("ارسال شده")]
        Shipped,  
        
        [Description("تحویل داده شده")]
        Delivered           
    }
}
