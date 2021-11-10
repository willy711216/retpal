﻿using RetSim.Items;
using RetSim.Spells;
using RetSim.Spells.SpellEffects;
using RetSim.Units.Player;

namespace RetSim.Data;

public static partial class Spells
{
    public static readonly Spell Melee = new()
    {
        ID = 1,
        Name = "Melee",
        Target = SpellTarget.Enemy,

        Effects = new()
        {
            new WeaponAttack
            {
                School = School.Physical,
                DefenseCategory = DefenseType.White,
                CritCategory = AttackCategory.Physical,
                OnHit = ProcMask.OnAutoAttack,
                OnCrit = ProcMask.OnCrit | ProcMask.OnMeleeCrit
            }
        }
    };

    public static readonly Spell CrusaderStrike = new()
    {
        ID = 35395,
        Name = "Crusader Strike",
        ManaCost = 236,
        Cooldown = 6000,
        GCD = new() { Category = AttackCategory.Physical },
        Target = SpellTarget.Enemy,

        Effects = new()
        {
            new WeaponAttack
            {
                School = School.Physical,
                DefenseCategory = DefenseType.Special,
                CritCategory = AttackCategory.Physical,
                Normalized = true,
                OnHit = ProcMask.OnSpecialAttack,
                OnCrit = ProcMask.OnCrit | ProcMask.OnMeleeCrit,
                Percentage = 1.1f
            }
        }
    };

    public static readonly Spell Judgement = new()
    {
        ID = 20271,
        Name = "Judgement",
        ManaCost = 148,
        Cooldown = 10000,
        Target = SpellTarget.Enemy,

        Effects = new() { new RetSim.Spells.SpellEffects.Judgement() }
    };

    public static readonly Spell SealOfCommand = new()
    {
        ID = 27170,
        Name = "Seal of Command (Aura)",
        Rank = 6,
        ManaCost = 280,
        GCD = new() { Category = AttackCategory.Spell }
    };

    public static readonly Spell SealOfCommandProc = new()
    {
        ID = 20424,
        Name = "Seal of Command",
        Target = SpellTarget.Enemy,

        Effects = new()
        {
            new WeaponAttack
            {
                School = School.Holy,
                DefenseCategory = DefenseType.Special,
                CritCategory = AttackCategory.Physical,
                OnHit = ProcMask.OnSealOfCommand,
                OnCrit = ProcMask.OnCrit | ProcMask.OnMeleeCrit,
                Percentage = 0.7f,
                Coefficient = 0.29f
            }
        }
    };

    public static readonly RetSim.Spells.Judgement JudgementOfCommand = new()
    {
        ID = 27171,
        Name = "Judgement of Command",
        Rank = 6,
        Target = SpellTarget.Enemy,

        Effects = new()
        {
            new Damage
            {
                School = School.Holy,
                DefenseCategory = DefenseType.Ranged,
                CritCategory = AttackCategory.Physical,
                OnHit = ProcMask.OnJudgement | ProcMask.OnRangedAttack,
                OnCrit = ProcMask.OnCrit | ProcMask.OnMeleeCrit,
                Coefficient = 0.429f,
                MinEffect = 228,
                MaxEffect = 252
            }
        }
    };

    public static readonly Spell SealOfBlood = new()
    {
        ID = 31892,
        Name = "Seal of Blood (Aura)",
        ManaCost = 210,
        GCD = new() { Category = AttackCategory.Spell }
    };

    public static readonly Spell SealOfBloodProc = new()
    {
        ID = 31893,
        Name = "Seal of Blood",
        Target = SpellTarget.Enemy,

        Effects = new()
        {
            new WeaponAttack
            {
                School = School.Holy,
                DefenseCategory = DefenseType.Special,
                CritCategory = AttackCategory.Physical,
                OnCrit = ProcMask.OnCrit,
                Percentage = 0.35f
            }
        }
    };

    public static readonly RetSim.Spells.Judgement JudgementOfBlood = new()
    {
        ID = 31898,
        Name = "Judgement of Blood",
        Target = SpellTarget.Enemy,

        Effects = new()
        {
            new Damage
            {
                School = School.Holy,
                DefenseCategory = DefenseType.Ranged,
                CritCategory = AttackCategory.Physical,
                OnHit = ProcMask.OnJudgement | ProcMask.OnRangedAttack,
                OnCrit = ProcMask.OnCrit | ProcMask.OnMeleeCrit,
                Coefficient = 0.429f,
                MinEffect = 331.6f,
                MaxEffect = 361.6f
            }
        }
    };

    public static readonly Spell SealOfTheCrusader = new()
    {
        ID = 27158,
        Name = "Seal of the Crusader",
        Rank = 7,
        ManaCost = 210,
        GCD = new() { Category = AttackCategory.Spell },

        Effects = null
        //TODO: Give this shit an effect
    };

    public static readonly Spell WindfuryTotem = new()
    {
        ID = 25580,
        Name = "Windfury Totem",
        Rank = 5
    };

    public static readonly Spell WindfuryAttack = new()
    {
        ID = 25584,
        Name = "Windfury Attack",
        Rank = 5
    };

    public static readonly Spell WindfuryProc = new()
    {
        ID = 2,
        Name = "Melee (Windfury)",
        Target = SpellTarget.Enemy,

        Effects = new()
        {
            new WeaponAttack
            {
                School = School.Physical,
                DefenseCategory = DefenseType.White,
                CritCategory = AttackCategory.Physical,
                OnHit = ProcMask.OnExtraAttack,
                OnCrit = ProcMask.OnCrit | ProcMask.OnMeleeCrit
            }
        }
    };

    public static readonly Spell AvengingWrath = new()
    {
        ID = 31884,
        Name = "Avenging Wrath",
        ManaCost = 236,
        Cooldown = 180000
    };

    public static readonly Racial HumanRacial = new()
    {
        ID = 20597,
        Name = "Sword / Mace Specialization",
        Requirements = (Player player) => player.Weapon.Type == WeaponType.Sword || player.Weapon.Type == WeaponType.Mace
    };
}