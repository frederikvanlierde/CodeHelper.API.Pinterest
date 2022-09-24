using System.Text.Json.Serialization;

namespace CodeHelper.API.Pinterest
{
    public sealed class MediaInfo : BaseClass
    {
        #region Properties
        [JsonPropertyName("media_type")] public string MediaType { get; set; }
        #endregion
    }
}
