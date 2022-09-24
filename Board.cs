using System.Text.Json.Serialization;
using System.Text.Json;
namespace CodeHelper.API.Pinterest
{
    public sealed class Board : BaseClass
    {
        #region Properties
        [JsonPropertyName("id")]            public string? Id { get; set; } 
        [JsonPropertyName("description")]   public string? Description { get; set; } 
        [JsonPropertyName("name")]          public string? Name { get; set; }
        [JsonPropertyName("privacy")]       public string? Privacy { get; set; } 
        [JsonPropertyName("owner")]         public OwnerInfo? Owner { get; set; }
        #endregion

        #region Constructors
        public Board() { }
        #endregion        
    }
}
