using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeHelper.API.Pinterest
{
    public sealed class BoardBoardSection : BaseClass
    {
        #region Properties
        [JsonPropertyName("board_id")] public string? BoardID { get; set; }
        [JsonPropertyName("board_section_id")] public string? BoardSectionID { get; set; }        
        #endregion

        #region Constructors
        public BoardBoardSection() { }
        #endregion        
    }
}
