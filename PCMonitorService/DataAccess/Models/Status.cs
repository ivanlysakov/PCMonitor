using System.ComponentModel;


namespace WebApi.Models
{
    public enum Status
    {
        [Description("Logon")]
        LogOn = 1,

        [Description("Logof")]
        LogOf = 2,
    }
}
