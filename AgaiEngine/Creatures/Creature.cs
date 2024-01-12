
using System.Collections;
using System.Collections.Generic;
using System;
using AgaiEngine.Attacks;
using AgaiEngine.Attacks.Spells;

namespace AgaiEngine
{

    /// <summary>
    /// Creature either player or npc
    /// 
    ///This class is tasked with the following:
    ///	- Storing data used by all creatures.
    ///	- Enacting functionality used by all creatures.
    /// </summary>
    public class Creature
    {
        ////////////////
        // Base Stats //
        ////////////////

        /// Level
        public uint Level=1;

        /// Base Health
        public uint BaseHealth=50;
        /// Max MaxHealth
        public uint MaxHealth=50;
        /// Current Health
        public int Health=50;

        /// Base Mana
        public uint BaseMana;
        /// Max MaxMana
        public uint MaxMana;
        /// Current Mana
        public uint Mana;

        /// Current Str
        public Attribute<uint> Strength;
        /// Current Vit
        public Attribute<uint> Vitality;
        /// Current Dex
        public Attribute<uint> Dexterity;
        /// Current Int
        public Attribute<uint> Intellect;
        /// Current Focus
        public Attribute<uint> Focus;
        /// Current Luck
        public Attribute<uint> Luck;

        /// Intrinsic Defense
        public Attribute<uint> defense;

        #region  Magic stats
        /// Intrinsic Magic Def
        public Attribute<uint> magicDefense;
        /// Current Magic Def
        public uint CurrentMagicDefense;

        /// Current Elemental Points and rank
        public Dictionary<Elements, Attribute<uint>> Elements;

        /// Resistances
        public Dictionary<Elements, uint> Resistances;

        /// Absorbance percentages
        public Dictionary<Elements, float> Absorb;

        // List of spells keyed by name
        internal Dictionary<string, ISpell> Spells = new Dictionary<string, ISpell>(StringComparer.OrdinalIgnoreCase);
        #endregion  Magic stats


        #region Compatibility with helpers

        /// Compatibility Rating can increase over time. Max 1 min 0. Corresponds to how well this creature interacts with others
        public float CompatibilityRating;

        /// Compatibility score
        public UInt16 CompatibilityScore;
        #endregion Compatibility with helpers

        #region Special/cheaty things
        public bool mInvincible;
        #endregion Special/cheaty things

        /// <summary>
        /// Create a Creature with a specific actor and name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="?"></param>
        //    public Creature(string name, Actor& actor) :
        //        AgaiGameObject(name, actor),
        //        Level(1),
        //        BaseHealth(1),
        //        MaxHealth(1),
        //        Health(1),
        //        BaseMana(0),
        //        MaxMana(0),
        //        Mana(0),
        //        Strength(),
        //        Vitality(),
        //        Dexterity(),
        //        Intellect(),
        //        Focus(),
        //        Luck(),
        //        Defense(),
        //        CurrentDefense(0),
        //        MagicDefense(),
        //        CurrentMagicDefense(0),
        //        Elements(),
        //        Resistances(),
        //        Absorb(),
        //        Spells(),
        //        CompatibilityRating(0),
        //        CompatibilityScore(0),
        //        mAttacking(false),
        //        mInvincible(false),
        //        mHitByObjects()
        //{

        //}

        /// <summary>
        /// Loads Data from a YAML node
        /// </summary>
        /// <param name="?"></param>
        //    public virtual void LoadData(const YAML::Node& node) {
        //    try
        //    {
        //        AgaiGameObject::LoadData(node);
        //        const YAML::Node tmp;
        //        ////////////////////////
        //        // Load required data //
        //        ////////////////////////
        //        Strength.LoadData(node.FindValue("Strength"));
        //        Vitality.LoadData(node.FindValue("Vitality"));
        //        Dexterity.LoadData(node.FindValue("Dexterity"));
        //        Intellect.LoadData(node.FindValue("Intellect"));
        //        Focus.LoadData(node.FindValue("Focus"));
        //        Luck.LoadData(node.FindValue("Luck"));

        //        Defense.LoadData(node.FindValue("Defense"));

        //        MagicDefense.LoadData(node.FindValue("MagDefense"));
        //        Attribute<uint> Elem;
        //        Elem.LoadData(node.FindValue("Fire"));
        //        Elements[Element::Fire] = Elem;
        //        Elem.LoadData(node.FindValue("Water"));
        //        Elements[Element::Water] = Elem;
        //        Elem.LoadData(node.FindValue("Earth"));
        //        Elements[Element::Earth] = Elem;
        //        Elem.LoadData(node.FindValue("Air"));
        //        Elements[Element::Air] = Elem;
        //        Elem.LoadData(node.FindValue("Aether"));
        //        Elements[Element::Aether] = Elem;
        //        Elem.LoadData(node.FindValue("Darkness"));
        //        Elements[Element::Darkness] = Elem;
        //        Elem.LoadData(node.FindValue("Light"));
        //        Elements[Element::Light] = Elem;
        //        Elem.LoadData(node.FindValue("Void"));
        //        Elements[Element::Void] = Elem;

        //        Level = node["Level"].to<uint>();

        //        BaseHealth = node["BaseHP"].to<uint>();
        //        setMaxHealth();
        //        tmp = node.FindValue("CurrentHealth");
        //        if(tmp)
        //            Health = tmp.to<uint>();
        //        else
        //            Health = MaxHealth;

        //        Mana = node["Mana"].to<uint>();
        //        setMaxMana();
        //        tmp = node.FindValue("CurrentMana");
        //        if(tmp)
        //            Mana = tmp.to<uint>();
        //        else
        //            Mana = MaxMana;


        //        ////////////////////////
        //        // Load Optional Data //
        //        ////////////////////////
        //        tmp = node.FindValue("ResistFire");
        //        if(tmp)
        //            Resistances[Fire] = tmp.to<uint>();
        //        tmp = node.FindValue("ResistWater");
        //        if(tmp)
        //            Resistances[Water] = tmp.to<uint>();
        //        tmp = node.FindValue("ResistEarth");
        //        if(tmp)
        //            Resistances[Earth] = tmp.to<uint>();
        //        tmp = node.FindValue("ResistAir");
        //        if(tmp)
        //            Resistances[Air] = tmp.to<uint>();
        //        tmp = node.FindValue("ResistAether");
        //        if(tmp)
        //            Resistances[Aether] = tmp.to<uint>();
        //        tmp = node.FindValue("ResistDarkness");
        //        if(tmp)
        //            Resistances[Darkness] = tmp.to<uint>();
        //        tmp = node.FindValue("ResistLight");
        //        if(tmp)
        //            Resistances[Light] = tmp.to<uint>();
        //        tmp = node.FindValue("ResistVoid");
        //        if(tmp)
        //            Resistances[Void] = tmp.to<uint>();

        //        tmp = node.FindValue("AbsorbFire");
        //        if(tmp)
        //            Absorb[Fire] = tmp.to<float>();
        //        tmp = node.FindValue("AbsorbWater");
        //        if(tmp)
        //            Absorb[Water] = tmp.to<float>();
        //        tmp = node.FindValue("AbsorbEarth");
        //        if(tmp)
        //            Absorb[Earth] = tmp.to<float>();
        //        tmp = node.FindValue("AbsorbAir");
        //        if(tmp)
        //            Absorb[Air] = tmp.to<float>();
        //        tmp = node.FindValue("AbsorbAether");
        //        if(tmp)
        //            Absorb[Aether] = tmp.to<float>();
        //        tmp = node.FindValue("AbsorbDarkness");
        //        if(tmp)
        //            Absorb[Darkness] = tmp.to<float>();
        //        tmp = node.FindValue("AbsorbLight");
        //        if(tmp)
        //            Absorb[Light] = tmp.to<float>();
        //        tmp = node.FindValue("AbsorbVoid");
        //        if(tmp)
        //            Absorb[Void] = tmp.to<float>();

        //        tmp = node.FindValue("Spells");
        //        if(tmp)
        //        {
        //            foreach(spell, (tmp))
        //            {
        //                string name = (spell)["Name"].to<string>();

        //                Spell s;
        //                spell >> s;
        //                Spells[name] = s;
        //            }
        //        }
        //        tmp = node.FindValue("CompatibilityRating");
        //        if(tmp)
        //        {
        //            CompatibilityRating = tmp.to<float>();
        //        }
        //        tmp = node.FindValue("CompatibilityScore");
        //        if(tmp)
        //        {
        //            CompatibilityScore = tmp.to<UInt16>();
        //        }
        //    }
        //    catch(exception e)
        //    {
        //        cout << e.what() << endl;
        //    }
        //}

        /// <summary>
        /// Produces YAML for this object
        ///	\return pointer to an emmitter. Be sure to delete returned object
        /// </summary>
        //    public virtual YAML::Emitter& Serialize(YAML::Emitter& out) const{

        //    out << YAML::BeginMap;
        //    out << YAML::Key << "Level" << YAML::Value << Level;
        //    out << YAML::Key << "BaseHP" << YAML::Value << BaseHealth;
        //    out << YAML::Key << "CurrentHealth" << YAML::Value << Health;
        //    out << YAML::Key << "MaxMana" << YAML::Value << MaxMana;
        //    out << YAML::Key << "CurrentMana" << YAML::Value << Mana;
        //    out << YAML::Key << "Strength" << YAML::Value << Strength;
        //    out << YAML::Key << "Vitality" << YAML::Value << Vitality;
        //    out << YAML::Key << "Dexterity" << YAML::Value << Dexterity;
        //    out << YAML::Key << "Intellect " << YAML::Value << Intellect;
        //    out << YAML::Key << "Focus" << YAML::Value << Focus;
        //    out << YAML::Key << "Luck" << YAML::Value << Luck;

        //    out << YAML::Key << "Defense" << YAML::Value << Defense;
        //    out << YAML::Key << "MagicDefense" << YAML::Value << MagicDefense;

        //    out << YAML::Key << "Fire" << YAML::Value << Elements.find(Fire).Value;
        //    out << YAML::Key << "Water" << YAML::Value << Elements.find(Water).Value;
        //    out << YAML::Key << "Earth" << YAML::Value << Elements.find(Earth).Value;
        //    out << YAML::Key << "Air" << YAML::Value << Elements.find(Air).Value;
        //    out << YAML::Key << "Aether" << YAML::Value << Elements.find(Aether).Value;
        //    out << YAML::Key << "Darkness" << YAML::Value << Elements.find(Darkness).Value;
        //    out << YAML::Key << "Light" << YAML::Value << Elements.find(Light).Value;
        //    out << YAML::Key << "Void" << YAML::Value << Elements.find(Void).Value;

        //    out << YAML::Key << "ResistFire" << YAML::Value << Resistances.find(Fire).Value;
        //    out << YAML::Key << "ResistWater" << YAML::Value << Resistances.find(Water).Value;
        //    out << YAML::Key << "ResistEarth" << YAML::Value << Resistances.find(Earth).Value;
        //    out << YAML::Key << "ResistAir" << YAML::Value << Resistances.find(Air).Value;
        //    out << YAML::Key << "ResistAether" << YAML::Value << Resistances.find(Aether).Value;
        //    out << YAML::Key << "ResistDarkness" << YAML::Value << Resistances.find(Darkness).Value;
        //    out << YAML::Key << "ResistLight" << YAML::Value << Resistances.find(Light).Value;
        //    out << YAML::Key << "ResistVoid" << YAML::Value << Resistances.find(Void).Value;

        //    out << YAML::Key << "AbsorbFire" << YAML::Value << Absorb.find(Fire).Value;
        //    out << YAML::Key << "AbsorbWater" << YAML::Value << Absorb.find(Water).Value;
        //    out << YAML::Key << "AbsorbEarth" << YAML::Value << Absorb.find(Earth).Value;
        //    out << YAML::Key << "AbsorbAir" << YAML::Value << Absorb.find(Air).Value;
        //    out << YAML::Key << "AbsorbAether" << YAML::Value << Absorb.find(Aether).Value;
        //    out << YAML::Key << "AbsorbDarkness" << YAML::Value << Absorb.find(Darkness).Value;
        //    out << YAML::Key << "AbsorbLight" << YAML::Value << Absorb.find(Light).Value;
        //    out << YAML::Key << "AbsorbVoid" << YAML::Value << Absorb.find(Void).Value;

        //    out << YAML::Key << "CompatibilityRating" << YAML::Value << CompatibilityRating;
        //    out << YAML::Key << "CompatibilityScore" << YAML::Value << CompatibilityScore;
        //    return out;
        //}

        /// <summary>
        /// Sets the updated Max health and returns the new value
        /// </summary>
        /// <returns>Newly calculated MaxHealth</returns>
        public virtual uint SetMaxHealth()
        {
            MaxHealth = ((3 + (Vitality.Value / 100)) * Level) + BaseHealth;
            return MaxHealth;
        }

        /// <summary>
        /// Set Max Mana value from stats
        /// </summary>
        /// <returns></returns>
        public virtual uint SetMaxMana()
        {
            MaxMana = (((Intellect.Value * 2) + (Vitality.Value * 3 / 10)) + (Focus.Value / 2)) + BaseMana;
            return MaxMana;
        }

        /// <summary>
        /// Returns the current defense (w/o armor)
        /// </summary>
        public virtual uint Defense
        {
            get
            {
                return Defense + ((Strength.Value + Vitality.Value) / 100);
            }
        }

        /// Returns current Magic Def (w/o armor)
        public virtual uint MagicDefense
        {
            get
            {
                return Defense + ((Intellect.Value + Focus.Value) / 100);
            }
        }

        /// Returns current dodge chance
        public virtual double DodgeChance { get { return Dexterity.Value * 0.005f; } }

        /// <summary>
        /// Level resistances for an element
        /// </summary>
        /// <param name="Enemy">Enemy The opponent</param>
        /// <param name="e">Element which to check</param>
        /// <returns></returns>
        public virtual uint GetLevelResist(Creature Enemy, Elements e)
        {
            return (Elements[e].Value - Enemy.Elements[e].Value) / (uint)RankType.S;
        }

        /// <summary>
        /// GetEffectiveResist element e
        /// </summary>
        /// <param name="Enemy">Opponent</param>
        /// <param name="e">Element to get resitance of</param>
        /// <returns></returns>
        public virtual uint GetEffectiveResist(Creature Enemy, Elements e)
        {
            var diff = GetLevelResist(Enemy, e);
            diff = diff > 0 ? diff : 0;
            return Resistances[e] + diff;
        }

        /// <summary>
        /// Get the percent of element e absorbed.
        /// </summary>
        /// <param name="Enemy">The opponent</param>
        /// <param name="e">Element</param>
        /// <returns></returns>
        public virtual float GetEffectiveAbsorb(Creature Enemy, Elements e)
        {
            var elemResit = GetEffectiveResist(Enemy, e);
            var elemLevelResist = GetLevelResist(Enemy, e);
            var absorbPercent = Absorb[e];
            var resist = Resistances[e];
            return absorbPercent + elemLevelResist - (((5 * (float)RankType.S) > 0)
                ? (1 - (elemResit / (float)(elemResit + (10 * resist)))) : 0);
        }

        /// <summary>
        /// Obtains the compaibility rating of two creatures. This can return a value between 0 an 2.55
        /// </summary>
        /// <param name="helper">The aiding party</param>
        /// <returns></returns>
        public virtual float GetCompaitbility(Creature helper)
        {
            return (CompatibilityRating + helper.CompatibilityRating)
                / 2.0f * (255 - Math.Abs(CompatibilityScore - helper.CompatibilityScore)) / 100;
        }

        /// <summary>
        /// Does damage taking determination
        /// </summary>
        /// <param name="attaker"></param>
        /// <param name="helper"></param>
        /// <param name="att"></param>
        /// <returns>true if the hit landed, false otherwise (healing too)</returns>
        public virtual bool Hit(Creature attacker, Creature helper, IAttack att)
        {
            bool hasHit = false;
            if (att != null && att.EnemiesHitThisFrame < att.MaxTargetsPerUse)
            {

                // hit chance stuff here

                var cost = att.GetManaCost(attacker, helper);

                ///do doge things

                if (!mInvincible)
                {
                    var damages = att.GetDamage(attacker, this, helper);

                    /// resistance calc and total damage
                    var damage = 0.0f;
                    Dictionary<Elements, float> elementalDamage = new Dictionary<Elements, float>();
                    foreach (var level in att.Elements)
                    {
                        var elementalLevelFactor = (float)((attacker.Elements[level.Key].Value - Elements[level.Key].Value) / (uint)Ranks.A) / 100;
                        var absorb = attacker.Absorb[level.Key];
                        var resist = Resistances[level.Key];
                        var effectiveResist = GetEffectiveResist(attacker, level.Key);
                        var effectiveAbsorb = GetEffectiveAbsorb(attacker, level.Key);
                        //heal here
                        Heal(effectiveAbsorb, level.Key);
                        elementalDamage[level.Key] = damages[level.Key] - effectiveAbsorb - effectiveResist;
                    }

                    /// \todo do buff things

                    foreach (var element in elementalDamage)
                    {
                        damage += element.Value;
                    }

                    if (attacker == this || helper == this)
                    {
                        /// \todo make things be friendly fire or not 
                        return true;
                    }
                    Health -= (int)damage;
                    att.EnemiesHitThisFrame = 0;
                }
                hasHit = true;
            }
            return hasHit;
        }

        /// <summary>
        /// Heals a specific amount based on the Element e
        /// </summary>
        /// <param name="amount">The ammount to attempt to heal (doesn't overheal)</param>
        /// <param name="e">Element which is healing (so buffs can affect it)</param>
        public virtual void Heal(float amount, Elements e)
        {

            var finalMaxHealth = Health + amount;
            if (finalMaxHealth > MaxHealth)
                Health = (int)MaxHealth;
        }
    }
}