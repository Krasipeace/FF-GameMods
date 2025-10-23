using HarmonyLib;
using UnityEngine;
using MelonLoader;

using System.Collections.Generic;

[assembly: MelonInfo(typeof(VikingNames.VikingNames), "Viking Names", "1.0.3", "Krasipeace")]
[assembly: MelonGame("Crate Entertainment", "Farthest Frontier")]

namespace VikingNames
{
    public class VikingNames : MelonMod
    {
        # region Collections
        private static readonly List<string> MaleVikingNames = new List<string>()
        {
            "Agnar", "Alaric", "Alfgeir", "Alvi", "Arinbjorn", "Arnkell", "Arnor", "Asbjorn", "Askell", "Astrid",
            "Audun", "Bard", "Bersi", "Bjarni", "Bjorn", "Boke", "Bolverk", "Brand", "Brokkr", "Canute",
            "Dag", "Einar", "Erik", "Eyolf", "Eyvindr", "Finn", "Floki", "Folke", "Gardar", "Geirmund",
            "Geri", "Gisli", "Gorm", "Grim", "Gunnar", "Halfdan", "Hallbjorn", "Hallvard", "Hamund", "Harald",
            "Havard", "Hedin", "Helgi", "Herbjorn", "Herleif", "Hermod", "Hervor", "Hildir", "Holmgeir", "Hrolf",
            "Hrut", "Ivar", "Jarl", "Joar", "Jon", "Kalf", "Ketil", "Kjartan", "Kolbein", "Kori",
            "Lager", "Leif", "Lodin", "Magni", "Mar", "Mord", "Narfi", "Neri", "Odd", "Olaf",
            "Orm", "Osvald", "Ottar", "Ragnar", "Randi", "Refil", "Reidar", "Rognvald", "Rolf", "Snorri",
            "Solvi", "Starkad", "Stein", "Steinar", "Stig", "Styrbjorn", "Surt", "Sven", "Thor", "Thorbjorn",
            "Thord", "Thorfinn", "Thorgeir", "Thorleif", "Thorstein", "Torfi", "Tryggvi", "Ulf", "Valdemar", "Vidar"
        };

        private static readonly List<string> FemaleVikingNames = new List<string>()
        {
            "Aasa", "Adils", "Aesa", "Agneta", "Alfhild", "Alva", "Arnbjorg", "Arndis", "Astrid", "Aud",
            "Audhild", "Bergdis", "Bergljot", "Bera", "Birgit", "Bjarnhild", "Bodil", "Borghild", "Brynhild", "Daga",
            "Dagmar", "Disa", "Edda", "Eerika", "Eevi", "Eira", "Elina", "Elsi", "Embla", "Estrid",
            "Frida", "Gerd", "Groa", "Gudrid", "Gunhild", "Hallbera", "Hallfrid", "Hallgerd", "Halldora", "Hannele",
            "Harpa", "Heda", "Helga", "Herborg", "Herdis", "Hervor", "Hildi", "Hildigunn", "Holmfridur", "Hrefna",
            "Hulda", "Ingaborg", "Inga", "Ingeborg", "Ingrid", "Iselin", "Jorunn", "Jutta", "Kara", "Karna",
            "Katla", "Kjerstin", "Kristin", "Laufey", "Liv", "Lova", "Magnhild", "Malla", "Maret", "Marit",
            "Marna", "Mette", "Nanna", "Nilla", "Olga", "Oydis", "Ragnhild", "Ragna", "Randi", "Rannveig",
            "Reeta", "Rikka", "Runa", "Saga", "Sanna", "Signe", "Signy", "Sirkka", "Siv", "Solveig",
            "Steinvor", "Svanhild", "Swanhild", "Thora", "Thordis", "Thorunn", "Thyra", "Tove", "Unn", "Ylva"
        };

        private static readonly List<string> VikingCompanyNames = new List<string>()
        {
            "Ivar the Boneless' Host",
            "Ragnar's Hird",
            "Bjorn Ironside's Kin",
            "Ubbe's Warband",
            "Hvitserk's Fury",
            "Sigurd Snake-in-the-Eye's Guard",
            "Halfdan Ragnarsson's Shieldbreakers",
            "Guthrum's Great Army",
            "Olaf the White's Raiders",
            "Ingvar the Far-Travelled's Fellowship",
            "Thorfinn Karlsefni's Crew",
            "Erik the Red's Northmen",
            "Leif Erikson's Venture",
            "Harald Fairhair's Ravens",
            "Sweyn Forkbeard's Jomsvikings",
            "Canute the Great's Drengir",
            "Harald Hardrada's Huscarls",
            "The Sons of Lodbrok",
            "The White Christ's Foe",
            "The Heathen Horde",
            "The Berserkergang",
            "The Wolfskin Warriors",
            "The Bearcoat Clan",
            "The Serpent's Coil",
            "The Dragon's Breath",
            "The Raven's Banner",
            "The Long Serpent's Wake",
            "The Sea King's Fury",
            "The Axe-Dancers",
            "The Shieldmaiden's Fury",
            "The Ice-Bear Clan",
            "The Frost Giants' Grasp",
            "The Midgard Wyrm's Scale",
            "Yggdrasil's Roots",
            "Valhalla's Chosen",
            "Odin's Eye",
            "Thor's Thunderbolts",
            "Freyja's Falcons",
            "Tyr's Resolve",
            "Loki's Tricksters",
            "Heimdall's Watchers",
            "Bragi's Skalds",
            "Idun's Keepers",
            "Njord's Wave-Riders",
            "Skadi's Hunters",
            "The Swift Axe",
            "The Bloodied Spear",
            "The Iron Shield",
            "The Northern Wind",
            "The Eastern Fury",
            "The Western Tide",
            "The Southern Storm",
            "The Golden Hoard",
            "The Silver Arm",
            "The Black Sail",
            "The White Gull",
            "The Red Dawn",
            "The Shadow Wolves",
            "The Battle-Axe Brotherhood",
            "The Lindisfarne's Scourge",
            "The Seine's Terror",
            "The Volga Boatmen",
            "The Varangian Company",
            "The Embers of Surt",
            "The Mead Hall's Might",
            "The Longship's Shadow",
            "The Oar's Stroke",
            "The Coastal Wyrms",
            "The Fjord's Fury",
            "The Skald's Verse",
            "The Runestone's Whisper",
            "The Sacred Grove's Guardians",
            "The Thing's Decree",
            "The Lawspeaker's Voice",
            "The Oath-Breakers' Bane",
            "The Kin-Slayers' Sorrow",
            "The Peace-Weavers' Hope",
            "The Silver Road's End",
            "The Amber Coast's Claim",
            "The Fur Trade's Grip",
            "The Vikingr's Way",
            "The Norsemen's Call",
            "The Ostmen's Legacy",
            "The Danelaw's Fury",
            "The Strathclyde Raiders",
            "The Pictslayer Host",
            "The Lombard's Lament",
            "The Baltic Buccaneers",
            "The Islemen's Brood",
            "The Faroe Farers",
            "The Greenland Settlers",
            "The Vinland Voyagers"
        };
        #endregion
        # region Prefixes
        [HarmonyPatch(typeof(VillagerNameManager), "GetRandomName")]
        public class Patch_VillagerNameManager_GetRandomName
        {
            protected static bool Prefix(bool isMale, ref string __result)
            {
                if (isMale)
                {
                    __result = MaleVikingNames[Random.Range(0, MaleVikingNames.Count)];

                    return false;
                }

                if (!isMale)
                {
                    __result = FemaleVikingNames[Random.Range(0, FemaleVikingNames.Count)];

                    return false;
                }

                return true;
            }
        }

        [HarmonyPatch(typeof(VillagerNameManager), "GetRandomCompanyName")]
        public class PatchGetRandomCompanyName
        {
            private static bool initialized = false;

            protected static void Prefix()
            {
                if (initialized) return;

                initialized = true;

                var field = AccessTools.Field(typeof(VillagerNameManager), "allCompanyNames");
                field.SetValue(null, VikingCompanyNames);
            }
        }
        #endregion
        #region Postfixes
        [HarmonyPatch(typeof(GuardTower), "Awake")]
        public class RenameGuardTower
        {
            protected static void Postfix(GuardTower __instance)
            {
                __instance.displayName = "Loki's Rest";
            }
        }

        [HarmonyPatch(typeof(TransportWagon), "Awake")]
        public class RenameTransportWagon
        {
            protected static void Postfix(TransportWagon __instance)
            {
                Traverse.Create(__instance).Property("displayName").SetValue("Chariot of Meili");
            }
        }

        [HarmonyPatch(typeof(SupplyWagon), "Awake")]
        public class RenameSupplyWagon
        {
            protected static void Postfix(SupplyWagon __instance)
            {
                __instance.displayName = "Tyr's Legacy";
            }
        }

        [HarmonyPatch(typeof(WagonShop), "Awake")]
        public class RenameWagonShop
        {
            protected static void Postfix(WagonShop __instance)
            {
                __instance.displayName = "Nerthus Wagon Shop";
            }
        }

        [HarmonyPatch(typeof(School), "Awake")]
        public class RenameSchool
        {
            protected static void Postfix(School __instance)
            {
                Traverse.Create(__instance).Property("displayName").SetValue("School of Vor");
            }
        }

        [HarmonyPatch(typeof(Pub), "Awake")]
        public class RenamePub
        {
            protected static void Postfix(Pub __instance)
            {
                __instance.displayName = "Bragi's Pub";
            }
        }

        [HarmonyPatch(typeof(Library), "Awake")]
        public class RenameLibrary
        {
            protected static void Postfix(Library __instance)
            {
                __instance.displayName = "Saga's Library";
            }
        }

        [HarmonyPatch(typeof(Crypt), "Awake")]
        public class RenameCrypt
        {
            protected static void Postfix(Crypt __instance)
            {
                __instance.displayName = "Valhalla Halls";
            }
        }

        [HarmonyPatch(typeof(Graveyard), "Awake")]
        public class RenameGraveyard
        {
            protected static void Postfix(Graveyard __instance)
            {
                Traverse.Create(__instance).Property("displayName").SetValue("Valhalla's fields");
            }
        }

        [HarmonyPatch(typeof(TradingPost), "Awake")]
        public class RenameTradingPost
        {
            protected static void Postfix(TradingPost __instance)
            {
                __instance.displayName = "Trading Post of Var";
            }
        }

        [HarmonyPatch(typeof(HunterBuilding), "Awake")]
        public class RenameHunterBuilding
        {
            protected static void Postfix(HunterBuilding __instance)
            {
                __instance.displayName = "Ullr Hunter Cabin";
            }
        }

        [HarmonyPatch(typeof(ForagerShack), "Awake")]
        public class RenameForagerShack
        {
            protected static void Postfix(ForagerShack __instance)
            {
                __instance.displayName = "Vidar Forager Shack";
            }
        }

        [HarmonyPatch(typeof(FishingShack), "Awake")]
        public class RenameFishingShack
        {
            protected static void Postfix(FishingShack __instance)
            {
                __instance.displayName = "Njord Fisherman";
            }
        }

        [HarmonyPatch(typeof(SmokeHouse), "Awake")]
        public class RenameSmokeHouse
        {
            protected static void Postfix(SmokeHouse __instance)
            {
                __instance.displayName = "Smoke House of Hodur";
            }
        }

        [HarmonyPatch(typeof(Temple), "Awake")]
        public class RenameTemple
        {
            protected static void Postfix(Temple __instance)
            {
                __instance.displayName = "Temple of Frigg";
            }
        }

        [HarmonyPatch(typeof(TemporaryShelter), "Awake")]
        public class RenameTemporaryShelter
        {
            protected static void Postfix(TemporaryShelter __instance)
            {
                __instance.displayName = "Skadi's Shelter";
            }
        }

        [HarmonyPatch(typeof(Gate), "Awake")]
        public class RenameGate
        {
            protected static void Postfix(Gate __instance)
            {
                __instance.displayName = "Baldur's Gate";
            }
        }

        [HarmonyPatch(typeof(RaiderGuardTower), "Awake")]
        public class RenameRaiderGuardTower
        {
            protected static void Postfix(RaiderGuardTower __instance)
            {
                __instance.displayName = "Fenrir's Rest";
            }
        }
        #endregion
    }
}