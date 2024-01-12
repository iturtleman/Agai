using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AgaiEngine
{
    /// <summary>
    /// Elements
    /// None is for Physical only and used for attacks etc
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Elements : int
    {
        None = 0,
        Fire,
        Water,
        Earth,
        Air,
        Aether,
        Darkness,
        Light,
        Void,
    };
}