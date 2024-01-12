namespace AgaiEngine.Attacks.Spells;

using Agai;
using AgaiEngine.Effects;

public interface ISpellEffect : IEffect
{
    SpellEffect Effect { get; }
}