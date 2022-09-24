using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeHelper.API.Pinterest
{
    public sealed class BoardSectionsResult : BaseClass
    {
        #region Properties
        [JsonPropertyName("items")] public List<BoardSection> Boards { get; set; } = new();
        [JsonPropertyName("bookmark")] public string? Bookmark { get; set; } = null;
        #endregion

        #region Constructors
        public BoardSectionsResult() { }
        #endregion
    }
}
