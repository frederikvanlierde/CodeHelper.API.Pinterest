using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeHelper.API.Pinterest
{
    public sealed class UserAccountInfo
    {
        #region Properties
        [JsonPropertyName("account_type")]  public string AccountType { get; set; }
        [JsonPropertyName("profile_image")] public string ProfileImage { get; set; }
        [JsonPropertyName("website_url")]   public string WebsiteUrl { get; set; }
        [JsonPropertyName("username")]      public string Username { get; set; }
        #endregion

        #region Constructors
        public UserAccountInfo() { }
        #endregion
    }
}
