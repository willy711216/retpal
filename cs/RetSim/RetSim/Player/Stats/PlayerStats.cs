﻿using System;

namespace RetSim
{
    public class PlayerStats
    {
        private Player Player { get; init; }
        private Stat[] All { get; init; }

        public Stat this[StatName key]
        {
            get => All[(int)key];
            private set => All[(int)key] = value;
        }

        public float EffectiveCritDamage = Constants.Stats.PhysicalCritBonus;
        public float EffectiveSpellCritDamage = Constants.Stats.SpellCritBonus;

        public float HitPenalty = 1f; //TODO: HACK
        public float EffectiveHitChance => this[StatName.HitChance].Value - HitPenalty;

        public float EffectiveSpellMissChance
        {
            get
            {
                float miss = Constants.Boss.SpellMissChance - this[StatName.SpellHit].Value;

                return miss > Constants.Boss.MininumSpellMissChance ? Constants.Boss.MininumSpellMissChance : 0;
            }
        }

        public float EffectiveMissChance
        {
            get
            {
                float miss = Constants.Boss.MissChance - EffectiveHitChance;

                return miss > 0 ? miss : 0;
            }
        }

        public float DodgeChanceReduction
        {
            get
            {
                float expertise = this[StatName.Expertise].Value;

                if (expertise >= Constants.Stats.ExpertiseCap)
                    return Constants.Stats.ExpertiseCap / Constants.Stats.ExpertisePerDodge;

                else
                    return expertise / Constants.Stats.ExpertisePerDodge;
            }
        }

        public float EffectiveDodgeChance
        {
            get
            {
                float dodge = Constants.Boss.DodgeChance - DodgeChanceReduction;

                return dodge > 0 ? dodge : 0;
            }
        }

        public float EffectiveAttackSpeed => (1 + (this[StatName.Haste].Value * 0.01f)) * Player.Modifiers.AttackSpeed;

        public PlayerStats(Player player)
        {
            Player = player;
            var equipment = Player.Equipment;
            var race = Player.Race;

            StatSet gear = Equipment.CalculateStats(equipment);

            All = new Stat[Enum.GetNames(typeof(StatName)).Length];

            this[StatName.Health] = new IntegerStat(StatName.Health, Constants.BaseStats.Health + race.Stats[StatName.Health], gear[StatName.Health]);
            this[StatName.Stamina] = new IntegerStat(StatName.Stamina, race.Stats[StatName.Stamina], gear[StatName.Stamina], (this[StatName.Health], Constants.Stats.StaminaPerHealth));

            this[StatName.Armor] = new IntegerStat(StatName.Armor, 0, gear[StatName.Armor]);
            this[StatName.Resilience] = new IntegerStat(StatName.Resilience, 0, gear[StatName.Resilience]);

            this[StatName.SpellCrit] = new DecimalStat(StatName.SpellCrit, Constants.BaseStats.SpellCritChance, gear[StatName.SpellCrit]);
            this[StatName.SpellCritRating] = new Rating(StatName.SpellCritRating, 0, gear[StatName.SpellCritRating], this[StatName.SpellCrit], Constants.Ratings.SpellCrit);
            this[StatName.Mana] = new IntegerStat(StatName.Mana, Constants.BaseStats.Mana, gear[StatName.Mana]);
            this[StatName.Intellect] = new IntegerStat(StatName.Intellect, race.Stats[StatName.Intellect], gear[StatName.Intellect], (this[StatName.Mana], Constants.Stats.IntellectPerMana), (this[StatName.SpellCrit], Constants.Stats.IntellectPerSpellCrit));
            
            this[StatName.ManaPer5] = new IntegerStat(StatName.ManaPer5, 0, gear[StatName.ManaPer5]);

            this[StatName.AttackPower] = new IntegerStat(StatName.AttackPower, Constants.BaseStats.AttackPower, gear[StatName.AttackPower]);
            this[StatName.Strength] = new IntegerStat(StatName.Strength, race.Stats[StatName.Strength], gear[StatName.Strength], (this[StatName.AttackPower], Constants.Stats.StrengthPerAP));

            this[StatName.CritChance] = new DecimalStat(StatName.CritChance, Constants.BaseStats.CritChance, gear[StatName.CritChance]);
            this[StatName.CritRating] = new Rating(StatName.CritRating, 0, gear[StatName.CritRating], this[StatName.CritChance], Constants.Ratings.Crit);
            this[StatName.Agility] = new IntegerStat(StatName.Agility, race.Stats[StatName.Agility], gear[StatName.Agility], (this[StatName.CritChance], Constants.Stats.AgilityPerCrit), (this[StatName.Armor], Constants.Stats.AgilityPerArmor));
            

            this[StatName.HitChance] = new DecimalStat(StatName.HitChance, 0, gear[StatName.HitChance]);
            this[StatName.HitRating] = new Rating(StatName.HitRating, 0, gear[StatName.HitRating], this[StatName.HitChance], Constants.Ratings.Hit);

            this[StatName.Haste] = new DecimalStat(StatName.Haste, 0, gear[StatName.Haste]);
            this[StatName.HasteRating] = new Rating(StatName.HasteRating, 0, gear[StatName.HasteRating], this[StatName.Haste], Constants.Ratings.Haste);

            this[StatName.Expertise] = new IntegerStat(StatName.Expertise, 0, gear[StatName.Expertise]);
            this[StatName.ExpertiseRating] = new Rating(StatName.ExpertiseRating, 0, gear[StatName.ExpertiseRating], this[StatName.Expertise], Constants.Ratings.Expertise);

            this[StatName.ArmorPenetration] = new IntegerStat(StatName.ArmorPenetration, 0, gear[StatName.ArmorPenetration]);

            this[StatName.SpellPower] = new IntegerStat(StatName.SpellPower, 0, gear[StatName.SpellPower]);
            
            this[StatName.SpellHit] = new DecimalStat(StatName.SpellHit, 0, gear[StatName.SpellHit]);
            this[StatName.SpellHitRating] = new Rating(StatName.SpellHitRating, 0, gear[StatName.SpellHitRating], this[StatName.SpellHit], Constants.Ratings.SpellHit);

            this[StatName.SpellHaste] = new DecimalStat(StatName.SpellHaste, 0, gear[StatName.SpellHaste]);
            this[StatName.SpellHasteRating] = new Rating(StatName.SpellHasteRating, 0, gear[StatName.SpellHasteRating], this[StatName.SpellHaste], Constants.Ratings.SpellHaste);

            this[StatName.Spirit] = new DecimalStat(StatName.Spirit, 0, gear[StatName.Spirit]);
            this[StatName.WeaponDamage] = new DecimalStat(StatName.WeaponDamage, 0, gear[StatName.WeaponDamage]);
        }
    }
}
