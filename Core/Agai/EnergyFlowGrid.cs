
namespace Agai;

public record class EnergyFlowGrid(string Name, int Width, int Height, int Version)
{
    public EnergyFlowPanel?[,] Panels = new EnergyFlowPanel[Width,Height];
}