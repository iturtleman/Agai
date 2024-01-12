using AgaiEngine.Effects;
using System;
using System.Collections.Generic;

namespace AgaiEngine.Attacks
{
    public interface IAttackDefinition
    {

        /** Attack  namme */
        string Name { get; }

        /** Attack Description */
        string Description { get; }

        /** MenuIcon url string*/
        string MenuIcon { get; }

        /** Base damage caued ny this attack. Used by calculations */
        float BaseDamage { get; }

        /** Base mana cost, used by calculations */
        float BaseManaCost { get; }

        /** Time it takes to use this attack (0 means instant, -1 means var, all other values are in seconds)*/
        TimeSpan TimeToUse { get; }

        /** Max value the attack charge gauge can reach in sec */
        float MaxCharge { get; }

        /** Amount of power increase gained from charging as a percentage of damage for max charge */
        float ChargePowerFactor { get; }

        /** Number of enemies/allies that can be hit per frame (higher number allows things like AOE) */
        float MaxTargetsPerUse { get; }

        /** Elemental Levels  */
        Dictionary<Elements, uint> Elements { get; }

        /** Whether or not this can hit targets w/o accuracy check */
        bool IsHoming { get; }

        AttackDuration UseTime { get; }

        /** Effects */
        HashSet<IEffect> Effects { get; }
    }
}