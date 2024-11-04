using System.ComponentModel;

namespace BaseBackend.Enums
{
    public enum UserRole
    {
        [Description("انتخاب کنید")]
        NOT_SET,

        [Description("مدیر سیستم")]
        ADMIN,    

        [Description("کارمند")]
        USER, 
        
        [Description("مشتری")]
        CUSTOMER, 

        [Description("تامین کننده")]
        SUPPLIER  
    }
}
