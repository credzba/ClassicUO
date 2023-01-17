﻿#region license

// Copyright (c) 2021, andreakarasho
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 1. Redistributions of source code must retain the above copyright
//    notice, this list of conditions and the following disclaimer.
// 2. Redistributions in binary form must reproduce the above copyright
//    notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
// 3. All advertising materials mentioning features or use of this software
//    must display the following acknowledgement:
//    This product includes software developed by andreakarasho - https://github.com/andreakarasho
// 4. Neither the name of the copyright holder nor the
//    names of its contributors may be used to endorse or promote products
//    derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS ''AS IS'' AND ANY
// EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER BE LIABLE FOR ANY
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System.Collections.Generic;
using System.Linq;
using ClassicUO.Game.Managers;
using ClassicUO.Utility;

namespace ClassicUO.Game.Data
{
    internal static class SpellsCleric
    {
        private static readonly Dictionary<int, SpellDefinition> _spellsDict;

        static SpellsCleric()
        {
            _spellsDict = new Dictionary<int, SpellDefinition>
            {
                // first circle
                {
                    1,
                    new SpellDefinition
                    (
                        "Angelic Faith",
                        342,
                        0x59EC,
                        0x59EC,
                        "Angelus Terum",
                        60,
                        80,
                        100,
                        TargetType.Beneficial,
                        Reagents.None
                    )
                },
                {
                    2,
                    new SpellDefinition
                    (
                        "Banish Evil",
                        343,
                        0x59ED,
                        0x59ED,
                        "Abigo Malus",
                        40,
                        60,
                        30,
                        TargetType.Harmful,
                        Reagents.None
                    )
                },
                {
                    3,
                    new SpellDefinition
                    (
                        "Dampen Spirit",
                        344,
                        0x59EE,
                        0x59EE,
                        "Abicio Spiritus",
                        11,
                        35,
                        15,
                        TargetType.Beneficial,
                        Reagents.None
                    )
                },
                {
                    4,
                    new SpellDefinition
                    (
                        "Divine Focus",
                        345,
                        0x59EF,
                        0x59EF,
                        "Divinium Cogitatus",
                        4,
                        35,
                        15,
                        TargetType.Neutral,
                        Reagents.None
                    )
                },
                {
                    5,
                    new SpellDefinition
                    (
                        "Hammer of Faith",
                        346,
                        0x59F0,
                        0x59F0,
                        "Malleus Terum",
                        14, 
                        40,
                        20,
                        TargetType.Neutral,
                        Reagents.None
                    )
                },
                {
                    6,
                    new SpellDefinition
                    (
                        "Purge",
                        347,
                        0x59F1,
                        0x59F1,
                        "Repurgo",
                        6,
                        10,
                        5,
                        TargetType.Harmful,
                        Reagents.None
                    )
                },
                {
                    7,
                    new SpellDefinition
                    (
                        "Restoration",
                        348,
                        0x59F2,
                        0x59F2,
                        "Reductio Aetas",
                        50,
                        50,
                        40,
                        TargetType.Beneficial,
                        Reagents.None
                    )
                },
                {
                    8,
                    new SpellDefinition
                    (
                        "Sacred Boon",
                        349,
                        0x59F3,
                        0x59F3,
                        "Vir Consolatio",
                        11,
                        25,
                        15,
                        TargetType.Harmful,
                        Reagents.None
                    )
                },
                {
                    9,
                    new SpellDefinition
                    (
                        "Sacrifice",
                        350,
                        0x59F4,
                        0x59F4,
                        "Adoleo",
                        4,
                        5,
                        5,
                        TargetType.Neutral,
                        Reagents.None
                    )
                },
                {
                    10,
                    new SpellDefinition
                    (
                        "Smite",
                        351,
                        0x59F5,
                        0x59F5,
                        "Ferio",
                        50,
                        80,
                        60,
                        TargetType.Harmful,
                        Reagents.None
                    )
                },
                {
                    11,
                    new SpellDefinition
                    (
                        "Touch of Life",
                        352,
                        0x59F6,
                        0x59F6,
                        "Tactus Vitalis",
                        9,
                        30,
                        10,
                        TargetType.Beneficial,
                        Reagents.None
                    )
                },
                {
                    12,
                    new SpellDefinition
                    (
                        "Trial by Fire",
                        353,
                        0x59F7,
                        0x59F7,
                        "Temptatio Exsuscito",
                        9,
                        45,
                        25,
                        TargetType.Neutral,
                        Reagents.None
                    )
                }
            };
        }

        public static string SpellBookName { get; set; } = SpellBookType.Cleric.ToString();

        public static IReadOnlyDictionary<int, SpellDefinition> GetAllSpells => _spellsDict;
        internal static int MaxSpellCount => _spellsDict.Count;

        public static SpellDefinition GetSpell(int spellIndex)
        {
            if (_spellsDict.TryGetValue(spellIndex, out SpellDefinition spell))
            {
                return spell;
            }

            return SpellDefinition.EmptySpell;
        }

        public static void SetSpell(int id, in SpellDefinition newspell)
        {
            _spellsDict[id] = newspell;
        }

        internal static void Clear()
        {
            _spellsDict.Clear();
        }
    }
}