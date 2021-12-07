using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Core.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Accessability
    {
        Public,
        Private,
        OnlyFriends
    }
}
