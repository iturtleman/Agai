namespace AgaiEngine.Attacks.Spells;

using System;
using System.Collections.Generic;
using AgaiEngine.Effects;


/// <summary>
///   A spell, contains the Information, icon, and effects. Creatures will have many spells as an instance
/// \todo add something that spawns the spell into the world
/// </summary>
[Serializable]
public class Spell : ISpell, ISpellDefinition
{
    protected ISpellDefinition definition;
    public Spell(ISpellDefinition definition)
    {
        this.definition = definition;
    }

    public float TimeSpentCasting { get; set; }

    public float Charge { get; set; }

    public float EnemiesHitThisFrame { get; set; }

    public uint TimesCast { get; set; }

    public ISpellDefinition Definition => definition;

    IAttackDefinition IAttack.Definition => definition;

    public uint MinFocus => Definition.MinFocus;

    public uint MinInt => Definition.MinInt;

    HashSet<IEffect> Effects => Definition.Effects;

    public HashSet<ISpellRecipe> Recipes => Definition.Recipes;

    public string Name => Definition.Name;

    public string Description => Definition.Description;

    public string MenuIcon => Definition.MenuIcon;

    public float BaseDamage => Definition.BaseDamage;

    public float BaseManaCost => Definition.BaseManaCost;

    public AttackDuration UseTime { get; set; } = AttackDuration.Time;
    public TimeSpan TimeToUse => Definition.TimeToUse;

    public float MaxCharge => Definition.MaxCharge;

    public float ChargePowerFactor => Definition.ChargePowerFactor;

    public float MaxTargetsPerUse => Definition.MaxTargetsPerUse;

    public Dictionary<Elements, uint> Elements => Definition.Elements;

    public bool IsHoming => Definition.IsHoming;

    HashSet<IEffect> IAttackDefinition.Effects => throw new NotImplementedException();

    public float ChargeDrain(Creature attacker)
    {
        return ChargeDrain(attacker);
    }

    /// <summary>
    /// Damage this attack does
    /// </summary>
    /// <param name="attacker">user of attack</param>
    /// <param name="target">target of attack</param>
    /// <param name="helper">assister for attack</param>
    /// <returns>Per element damage of this attack</returns>
    public Dictionary<Elements, float> GetDamage(Creature attacker, Creature target = null, Creature helper = null)
    {
        return this.GetDamage(attacker, TimesCast, target, helper);
    }

    /// <summary>
    /// Damage per second this attack does
    /// </summary>
    /// <param name="attacker">user of attack</param>
    /// <param name="target">target of attack</param>
    /// <param name="helper">assister for attack</param>
    public Dictionary<Elements, float> GetDps(Creature attacker, Creature target = null)
    {
        return GetDps(attacker, target);
    }

    /// <summary>
    /// Mana cost of this attack
    /// </summary>
    /// <param name="attacker">User of the attack</param>
    /// <param name="helper">Assister to the attack</param>
    /// <returns></returns>
    public Tuple<float, float> GetManaCost(Creature attacker, Creature helper = null)
    {
        return GetManaCost(attacker, helper);
    }
}