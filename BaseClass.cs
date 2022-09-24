using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
namespace CodeHelper.API.Pinterest
{
    public class BaseClass
    {
        //public virtual HttpContent GetJsonString()
        //{
        //    var _j = JsonSerializer.Serialize<object>(this, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
        //    return new StringContent(_j, System.Text.Encoding.UTF8, "application/json");
        //}
    }
}
