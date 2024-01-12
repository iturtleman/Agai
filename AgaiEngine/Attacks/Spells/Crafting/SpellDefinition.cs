using AgaiEngine.Effects;
using System;
using System.Collections.Generic;

namespace AgaiEngine.Attacks.Spells.Crafting
{
    public class SpellDefinition : ISpellDefinition, ICreatable
    {
        private string id;
        #region SpellDescription
        public string Name { get; set; }

        public string Description { get; set; }

        public string MenuIcon { get; set; }

        public Dictionary<Elements, uint> Elements
        {
            get
            {
                var retval = new Dictionary<Elements, uint>();

                return retval;
            }
        }
        #endregion SpellDescription

        #region Character Prerequisites
        public uint MinFocus { get; set; }

        public uint MinInt { get; set; }
        #endregion Character Prerequisites

        #region Customizations
        public HashSet<IEffect> Effects { get; set; } = new HashSet<IEffect>();
        public HashSet<ISpellEffect> SpellEffects { get; set; } = new HashSet<ISpellEffect>();
        #endregion Customizations

        #region Crafting
        public HashSet<ISpellRecipe> Recipes { get; set; } = new HashSet<ISpellRecipe>() { };
        #endregion Crafting

        #region Casting Properties
        public float BaseDamage { get; set; }

        public float BaseManaCost { get; set; }

        public TimeSpan TimeToUse { get; set; }

        public AttackDuration UseTime { get; set; } = AttackDuration.Time;

        public float MaxCharge { get; set; }

        public float ChargePowerFactor { get; set; }

        public float MaxTargetsPerUse { get; set; }

        public bool IsHoming { get; set; }
        #endregion Casting Properties

        public string Creator { get; set; }
        public uint Version { get; set; }

        public string Id { get => id ?? Name; set => id = value ?? throw new ArgumentNullException(nameof(value)); }

        public string LastEditBy { get; set; }

    }
}
