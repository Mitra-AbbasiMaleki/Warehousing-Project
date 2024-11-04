using System.ComponentModel;

namespace BaseBackend.Enums
{
    public enum AddressTitle
    {
        [Description("منزل")]
        HOME,

        [Description("محل کار")]
        WORK,

        [Description("دیگر")]
        OTHER   // دیگر
    }
}
