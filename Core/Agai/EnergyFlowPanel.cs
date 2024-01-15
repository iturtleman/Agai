
namespace Agai;
using System.Numerics;

public record class EnergyFlowPanel(string Name, Rarity Rarity, float Boost = 0)
{
    public HashSet<Effects>? Left { get; init; }
    public HashSet<Effects>? Right { get; init; }
    public HashSet<Effects>? Up { get; init; }
    public HashSet<Effects>? Down { get; init; }

    public static EnergyFlowPanel Default => new EmptyEnergyPanel();
}

public enum Effects
{
    None = 0,
    In,
    Out,
}
public enum Rarity
{
    None = 0,
    Common = 1,
    Uncommon,
    Rare,
    Epic,
}

public record class EmptyEnergyPanel : EnergyFlowPanel
{
    public EmptyEnergyPanel()
        : base(Name: "Empty", Rarity: Rarity.None, Boost: 0)
    {
    }
}

public record class SourceEnergyPanel : EnergyFlowPanel
{
    public SourceEnergyPanel()
        : base(Name: "Source", Rarity: Rarity.None, Boost: 1)
    {
        Left = [Effects.Out];
        Right = [Effects.Out];
        Up = [Effects.Out];
        Down = [Effects.Out];
    }
}


public record class DownSourceEnergyPanel : EnergyFlowPanel
{
    public DownSourceEnergyPanel()
        : base(Name: "DownSource", Rarity: Rarity.None, Boost: 1)
    {
        Left = [Effects.Out];
        Right = [Effects.Out];
        Up = [Effects.Out];
        Down = [Effects.Out];
    }
}