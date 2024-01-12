using System;
using System.Collections.Generic;

namespace AgaiEngine.Attacks
{
    /// <summary>
    /// Interface for anything that can do damage
    /// </summary>
    public interface IAttack : IAttackDefinition
    {
        /// <summary>
        /// Amount of time the attack has charged in sec
        /// </summary>
        float Charge { get; }

        /// <summary>
        /// Determines if an attack has dealt damage this loop. Sets to false at each Update
        /// </summary>
        float EnemiesHitThisFrame { get; set; }

        IAttackDefinition Definition { get; }

        /// <summary>
        /// Damage this attack does
        /// </summary>
        /// <param name="attacker">user of attack</param>
        /// <param name="target">target of attack</param>
        /// <param name="helper">assister for attack</param>
        /// <returns>Per element damage of this attack</returns>
        Dictionary<Elements, float> GetDamage(Creature attacker, Creature target = null, Creature helper = null);

        /// <summary>
        /// Damage per second this attack does
        /// </summary>
        /// <param name="attacker">user of attack</param>
        /// <param name="target">target of attack</param>
        /// <param name="helper">assister for attack</param>
        Dictionary<Elements, float> GetDps(Creature attacker, Creature target = null);

        /// <summary>
        /// Mana cost of this attack
        /// </summary>
        /// <param name="attacker">User of the attack</param>
        /// <param name="helper">Assister to the attack</param>
        /// <returns></returns>
        Tuple<float, float> GetManaCost(Creature attacker, Creature helper = null);

    }
    public static class IAttackExtensions
    {
        /// <summary>
        /// Updates/re-calculates elemental level factor. only needs to happen if creature stats change
        /// </summary>
        /// <param name="attacker">Owner of the attack</param>
        /// <returns></returns>
        public static float CalculateElementalLevelFactor(this IAttack a, Creature attacker)
        {
            var elementalLevelFactor = 0.0f;
            foreach (var elem in a.Elements)
            {
                if (elem.Value > 0)
                {
                    var level = attacker.Elements[elem.Key].Value;
                    var val = level * elem.Value;
                    elementalLevelFactor += level * val / (int)RankType.B / 100;
                }
            }
            return elementalLevelFactor;
        }
    }
}
