using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace CodeHelper.API.Pinterest
{
    public sealed class BoardsResult : BaseClass
    {
        #region Properties
        [JsonPropertyName("items")] public List<Board> Boards { get; set; } = new();
        [JsonPropertyName("bookmark")]  public string? Bookmark { get; set; } = null;
        #endregion

        #region Constructors
        public BoardsResult() { }
        #endregion
    }
}
