
namespace Agai;

public record class EnergyFlowGrid(string Name, int Width, int Height, int Version)
{
    public List<EnergyFlowPanel> Panels = new(Width*Height);
}