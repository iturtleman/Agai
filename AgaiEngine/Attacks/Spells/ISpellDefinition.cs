using System.Collections.Generic;

namespace AgaiEngine.Attacks.Spells
{
    public interface ISpellDefinition : IAttackDefinition
    {
        /** minimum focus required to use the spell */
        uint MinFocus { get; }

        /** minimum intelligence required to use the spell */
        uint MinInt { get; }

        /** Recipe for the spell */
        HashSet<ISpellRecipe> Recipes { get; }
    }
}