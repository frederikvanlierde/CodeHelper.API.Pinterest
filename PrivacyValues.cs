using System.ComponentModel;
namespace CodeHelper.API.Pinterest
{
    public enum PrivacyValues
    {
        [Description("")]
        All,
        [Description("PUBLIC")]
        Public,
        [Description("PROTECTED")]
        Protected,
        [Description("SECRET")]
        Secret
    }
}
