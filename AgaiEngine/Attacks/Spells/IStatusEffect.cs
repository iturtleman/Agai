namespace AgaiEngine.Attacks.Spells
{
    public interface IStatusEffect
    {
        float Intensity { get; }
        StatusEffect Effect { get; }
    }
}