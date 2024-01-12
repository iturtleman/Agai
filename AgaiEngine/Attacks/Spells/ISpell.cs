using System;
using System.Collections.Generic;
namespace AgaiEngine.Attacks.Spells
{
    public interface ISpell : IAttack, ISpellDefinition
    {
        /// <summary>
        /// Amount of time the spell is being cast in (0 means instant, -1 means var, all other values are in seconds)
        /// </summary>
        float TimeSpentCasting { get; }

        /// <summary>
        /// Drain if charging past cast time
        /// </summary>
        /// <param name="attacker">Caster of the spell</param>
        /// <returns>charge drain per second</returns>
        float ChargeDrain(Creature attacker);

        /// <summary>
        /// Times the spell has been cast
        /// </summary>
        uint TimesCast { get; set; }

        new ISpellDefinition Definition { get; }
    }

    public static class ISpellExtensions
    {
        /// <summary>
        /// Damage this attack does
        /// </summary>
        /// <param name="attacker">user of attack</param>
        /// <param name="target">target of attack</param>
        /// <param name="helper">assister for attack</param>
        /// <returns>Per element damage of this attack</returns>
        public static Dictionary<Elements, float> GetDamage(this ISpell a, Creature attacker, uint TimesCast, Creature target = null, Creature helper = null)
        {
            var FocusLevelMod = attacker.Focus.Value / (uint)RankType.C / 10;
            var IntLevelMod = attacker.Intellect.Value / (uint)RankType.C / 10;
            var CastMod = Math.Max(
                (2.0f * (1 - (2 * 2000 / (TimesCast * FocusLevelMod + 2000)))) + 1,
                0.5f
                );
            float totalPercent = 0;
            foreach (var element in a.Elements)
            {
                totalPercent += element.Value;
            }

            var ChargeDamage = a.Charge > 0 ? Math.Min(a.Charge, a.MaxCharge) * a.ChargePowerFactor : 0;
            var damage = (Math.Min(CastMod, 2.0f) + ChargeDamage) * a.BaseDamage;
            var elementalDamage = new Dictionary<Elements, float>();
            foreach (var element in a.Elements)
            {
                if (element.Value > 0)
                {
                    elementalDamage[element.Key] = (element.Value / totalPercent) * damage;
                }
            }
            return elementalDamage;
        }

        /// <summary>
        /// Damage per second this attack does
        /// </summary>
        /// <param name="attacker">user of attack</param>
        /// <param name="target">target of attack</param>
        /// <param name="helper">assister for attack</param>
        public static Dictionary<Elements, float> GetDps(this ISpell a, Creature attacker, Creature target = null)
        {
            var retval = a.GetDamage(attacker, target);
            foreach (var elem in retval)
            {
                retval[elem.Key] /= (float)a.TimeToUse.TotalSeconds;
            }
            return retval;
        }

        /// <summary>
        /// Mana cost of this attack
        /// </summary>
        /// <param name="attacker">User of the attack</param>
        /// <param name="helper">Assister to the attack</param>
        /// <returns></returns>
        public static Tuple<float, float> GetManaCost(this ISpell a, Creature attacker, Creature helper = null)
        {
            var FocusLevelMod = attacker.Focus.Value / (uint)RankType.C / 10;
            var IntLevelMod = attacker.Intellect.Value / (uint)RankType.C / 10;
            var ChargeMana = a.Charge < a.TimeToUse.TotalSeconds ? Math.Abs(a.ChargeDrain(attacker) * 2) : 0;
            var ElementalLevelFactor = a.CalculateElementalLevelFactor(attacker);
            var Modifiers = Math.Max((((2.0f * 1000) / (1000 + (IntLevelMod * a.TimesCast))) - ElementalLevelFactor), 0.5f);
            var SoloManaCost = Modifiers * a.BaseManaCost + ChargeMana;
            var helperManaCost = 0.0f;
            if (helper != null)
            {
                helperManaCost = a.GetManaCost(helper).Item1;
                SoloManaCost = Math.Min(
                    (float)Math.Abs(
                        (
                            (
                                (
                                    (2 - (helperManaCost / a.BaseManaCost))
                                    * (SoloManaCost)
                                )
                                * (helper.CompatibilityScore)
                            )
                            * (1 - (
                                (float)Math.Abs((attacker.CompatibilityRating - helper.CompatibilityRating)) * 0.1))
                            )
                    ), (SoloManaCost / 2));
            }
            return Tuple.Create(SoloManaCost, helperManaCost * (2.25f - (helper != null ? attacker.GetCompaitbility(helper) : 0f)));
        }

        public static float ChargeDrain(this ISpell a, Creature attacker)
        {
            return Math.Max((a.BaseManaCost  * (Math.Min(a.Charge, a.MaxCharge))), 1.0f) - (a.CalculateElementalLevelFactor(attacker) * 0.1f);
        }
    }
}
