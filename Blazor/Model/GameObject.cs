
namespace Agai;
using System.Numerics;
using System.Data;
using Agai.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public record GameObject(string Id)
{
    private JObject original = null!;
    private string? name;

    public GameObject(string id, string? name, Position? position) : this(id)
    {
        this.name = name;
        Position = position;
    }

    public string? Name
    {
        get => string.IsNullOrWhiteSpace(name) ? Id : name;
    }
    public Position? Position { get; init; }
    public int Height { get; init; } = 1;
    public int Width { get; init; } = 1;
    public JToken? Description { get; init; }
    public string? CameFrom { get; init; }
    public JObject Original
    {
        get => original;
        init
        {
            original = value;
            OriginalString = JsonConvert.SerializeObject(value, Formatting.Indented);
        }
    }
    public string OriginalString { get; init; } = string.Empty;
    public bool IsJustName => string.IsNullOrWhiteSpace(Name);

    public static GameObject? FromJson(JObject o)
    {
        if (o is null || !o.HasValues)
            return null;
        var debug = JsonConvert.SerializeObject(o, Formatting.Indented);
        var id = o["0"]!.Value<string>()!;
        var itemName = o["1"]?.Value<string>();
        var position = o["2"]?.ToObject<Position>();
        GameObject? retval = null;
        var objectRefferer = !string.IsNullOrWhiteSpace(itemName) ? itemName : id;
        if (objectRefferer.Equals("Loot_Orb_1_Root"))
        {
            
        }
        return (retval ?? new GameObject(Id: id)
        {
            name = itemName,
            Position = position,
        }) with
        {
            Original = (JObject)o.DeepClone(),
            Description = o["14"],
            CameFrom = o["29"]?.ToObject<string>(),
        };

    }
}
