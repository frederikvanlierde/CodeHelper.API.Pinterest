using System.Text.Json.Serialization;

namespace CodeHelper.API.Pinterest
{
    public sealed class OwnerInfo : BaseClass
    {
        #region Properties
        [JsonPropertyName("username")] public string Username { get; set; } = "";
        #endregion

        #region Constructors
        public OwnerInfo() { }
        #endregion
    }
}
