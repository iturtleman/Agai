
namespace Agai;
using System.Numerics;

public record class EnergyFlowPanel(string Name, Rarity Rarity, float Boost=0)
{
    public HashSet<Effects>? Left { get; init; }
    public HashSet<Effects>? Right { get; init; }
    public HashSet<Effects>? Up { get; init; }
    public HashSet<Effects>? Down { get; init; }
}

public enum Effects
{
    None=0,
    In,
    Out,
}
public enum Rarity
{
    Common=0,
    Uncommon,
    Rare,
    Epic,
}