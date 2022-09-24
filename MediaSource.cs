using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeHelper.API.Pinterest
{
    public sealed class MediaSource : BaseClass
    {
        #region Properties
        [JsonPropertyName("source_type")] public string? SourceType { get; set; } = "image_url";
        [JsonPropertyName("content_type")] public string? ContentType { get; set; }
        [JsonPropertyName("data")] public string? Data { get; set; }
        [JsonPropertyName("url")] public string? Url { get; set; }
        #endregion

        #region Constructors
        public MediaSource() { }
        #endregion
    }
}
