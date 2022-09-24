using System.Text.Json.Serialization;
using System;
namespace CodeHelper.API.Pinterest
{
    public sealed class Pin : BaseClass
    {
        #region Properties
        [JsonPropertyName("id")] public string? Id { get; set; }
        [JsonPropertyName("created_at")] public DateTime? CreatedAt { get; set; }
        [JsonPropertyName("link")] public string? Link { get; set; }
        [JsonPropertyName("title")] public string? Title { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("dominant_color")] public string? DominantColor { get; set; }
        [JsonPropertyName("alt_text")] public string? AltText { get; set; }
        [JsonPropertyName("board_id")] public string? BoardID { get; set; }
        [JsonPropertyName("board_section_id")] public string? BoardsectionID { get; set; }
        [JsonPropertyName("board_owner")] public OwnerInfo? BoardOwner { get; set; }
        [JsonPropertyName("parent_pin_id")] public string? ParentPinId { get; set; }
        [JsonPropertyName("media_source")] public MediaSource? Media { get; set; }
        [JsonPropertyName("media")] public MediaInfo? MediaType { get; set; }
        
        #endregion

        #region Constructors
        public Pin() { }
        #endregion
    }
}
