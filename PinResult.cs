using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace CodeHelper.API.Pinterest
{
    public sealed class PinResults : BaseClass
    {
        #region Properties
        [JsonPropertyName("items")] public List<Pin> Pins { get; set; } = new();
        [JsonPropertyName("bookmark")] public string? Bookmark { get; set; } = null;
        #endregion

        #region Constructors
        public PinResults() { }
        #endregion
    }
}
