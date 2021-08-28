﻿using RetSim.AuraEffects;
using System.Collections.Generic;

namespace RetSim
{
    public static partial class Glossaries
    {
        public static class Auras
        {
            public static readonly Seal SealOfTheCrusader = new()
            {
                ID = 20306,
                Name = "Seal of the Crusader",
                Duration = 30 * 1000,
                MaxStacks = 1,
                Persist = 0,
                Effects = new List<AuraEffect>()
                { }
            };

            public static readonly Seal SealOfCommand = new()
            {
                ID = 27170,
                Name = "Seal of Command",
                Duration = 30 * 1000,
                MaxStacks = 1,
                Persist = 400
            };

            public static readonly Seal SealOfBlood = new()
            {
                ID = 31892,
                Name = "Seal of Blood",
                Duration = 30 * 1000,
                MaxStacks = 1,
                Persist = 0,
                Effects = new List<AuraEffect>()
                { }
            };

            public static readonly Aura DragonspineTrophy = new()
            {
                ID = 34775,
                Name = "Dragonspine Trophy",
                Duration = 10 * 1000,
                MaxStacks = 1,
                Effects = new List<AuraEffect>()
                { }
            };

            public static readonly Dictionary<int, Aura> ByID = new()
            {
                { SealOfTheCrusader.ID, SealOfTheCrusader },
                { SealOfCommand.ID, SealOfCommand },
                { SealOfBlood.ID, SealOfBlood },
                { DragonspineTrophy.ID, DragonspineTrophy }
            };

            public static readonly HashSet<Seal> Seals = new()
            {
                SealOfTheCrusader,
                SealOfCommand,
                SealOfBlood
            };

            static Auras()
            {
                SealOfCommand.Effects = new List<AuraEffect>()
                    { new GainProc(Procs.SealOfCommand) };
                SealOfBlood.Effects = new List<AuraEffect>()
                    { new GainProc(Procs.SealOfBlood) };

                SealOfCommand.ExclusiveWith = new List<Seal>()
                { SealOfBlood, SealOfTheCrusader };
                SealOfBlood.ExclusiveWith = new List<Seal>()
                { SealOfCommand, SealOfTheCrusader };
                SealOfTheCrusader.ExclusiveWith = new List<Seal>()
                { SealOfCommand, SealOfBlood };
            }
        }
    }
}