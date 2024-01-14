
namespace Agai;

public record struct Position(float x, float y, float z) : IComparable<Position>
{
    public int CompareTo(Position other)
    {
        if (other.x == x)
            if (other.y == y)
                if (other.z == z)
                    return 0;
                else
                    return (int)(other.z * 100 - z * 100);
            else
                return (int)(other.y * 100 - y * 100);
        else
            return (int)(other.x * 100 - x * 100);
    }

    object ToDump()
    {
        return new { x, y, z };
    }
}