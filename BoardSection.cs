using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CodeHelper.API.Pinterest
{
    public sealed class BoardSection : BaseClass
    {
        #region Properties
        [JsonPropertyName("id")] public string? Id { get; set; }
        [JsonPropertyName("name")] public string? Name { get; set; }    
        #endregion

        #region Constructors
        public BoardSection() { }
        #endregion        
    }
}
