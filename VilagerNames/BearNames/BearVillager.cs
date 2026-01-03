using MelonLoader;
using HarmonyLib;
using UnityEngine;

using System.Collections.Generic;

[assembly: MelonInfo(typeof(BearNames.BearVillager), "Bear Names", "1.0.0", "Krasipeace")]
[assembly: MelonGame("Crate Entertainment", "Farthest Frontier")]

namespace BearNames
{
    public class BearVillager : MelonMod
    {
        #region Collections
        private static readonly List<string> BearMaleNames = new List<string>
        {
            "Baloo","Pooh","Paddington","Yogi","BooBoo","Smokey","Ted","Lotso","Kenai","Koda",
            "Po","Grizzly","Ice","Grizz","Pardo","LittleJohn","Bungle","Papa","Humphrey","Barney",
            "BJ","Rupert","Fozzie","Corky","Tenderheart","Grumpy","Braveheart","Champ","Nobleheart","Trueheart",
            "Swiftheart","Brightheart","Goodluck","SirBearington","Ben","Bruno","Nanook","Kodi","Koba","Snowball",
            "Ursus","Bjorn","Beorn","Boris","Misha","Mishka","Arktos","Callisto","Atlas","Titan",
            "Hercules","Zeus","Thor","Odin","Ares","Hades","Fenrir","Behemoth","Goliath","Mammoth",
            "Colossus","Leviathan","Juggernaut","King","Prince","Duke","Lord","Emperor","Monarch","Caesar",
            "PaddingtonBrown","Wojtek","Churchill","Bart","Sequoia","Tahoe","Yosemite","Denali","Kodiak","Adirondack",
            "Braham","Eirsson","Jhavi","Havroun","Knute","Ulfgar","Stigandr","Hrothmar","Bjora","Eigil",
            "Asvald","Halvard","Torsten","Ragnar","Sigurd","Ivar","Ulfric","Leif","Erik","Harald",
            "Warden","Sentinel","Guardian","Tracker","Ranger","Hunter","Viking","Berserker","Warlord","Champion",
            "Hero","Avenger","Defender","Crusader","Paladin","Samurai","Ronin","Gladiator","Spartan","Legionnaire",
            "PaddingtonJunior","BalooJunior","PoohBearer","Norm","Barry","Iceberg","PolarPete","Arlo","Baxter","Hudson",
            "Otis","Monty","Rocco","Franklin","Walter","Archibald","Sebastian","Maximus","Augustus","Cassius",
            "Thorvald","Bjornar","Stellan","Magnus","Alaric","Edmund","Roland","Percival","Gareth","Tristan"
        };

        private static readonly List<string> BearFemaleNames = new List<string>
        {
            "Goldilocks","MamaBerenstain","Cheer","Harmony","LoveALot","Bedtime","Friend","Wish","Share","Funshine",
            "Daydream","HeartSong","SweetDreams","LaughALot","Ursula","Ursa","Rosie","Daisy","Honey","Maple",
            "Cocoa","Mocha","Luna","Stella","Aurora","Celeste","Snowflake","Snowdrop","Frostine","Crystal",
            "Artemis","Athena","Hera","Persephone","Gaia","Rhea","Selene","Freya","Frigg","Hel",
            "Skadi","Idunn","Demeter","Hestia","Nyx","Eos","Theia","Circe","Calypso","Andromeda",
            "Matsa","Rosabelle","Isabella","Olivia","Amelia","Charlotte","Sophia","Eleanor","Margaret","Elizabeth",
            "JhaviFemale","Sigrid","Astrid","Yrsa","Hilda","Runa","Solveig","Kara","Liv","Ingrid",
            "Alfhild","Thyra","Gudrun","Ragnhild","Torhild","Svala","Freydis","Eira","Brynhild","Hervor",
            "Willow","Hazel","Juniper","Clover","Flora","Blossom","Ivy","Petunia","Rosewood","Magnolia",
            "Autumn","Summer","Spring","Dawn","Twilight","Moonshadow","MidnightRose","Starlight","Auriel","Celestia",
            "Queen","Princess","Duchess","Countess","Empress","Matron","Keeper","Oracle","Seer","Highmother",
            "Wardeness","Guardianess","Sentineless","Abbess","Highlady","Lady","Regina","Majesty","Consort","Dowager",
            "Bella","Lola","Molly","Lucy","Sadie","Ruby","Amber","Opal","Pearl","Ivory",
            "Velvet","Satin","Lace","Chiffon","Melody","HarmonyBelle","Lullaby","Sonnet","Lyric","Tempo",
            "Elowen","Aveline","Seraphina","Isolde","Rowena","Cordelia","Maribel","Anastasia","Valentina","Genevieve"
        };

        private static readonly List<string> BearArmyNames = new List<string>
        {
            "Stoic Alder", "Poised Arrow", "Waiting Sorrow", "Guiding Star", "Burning River", "Fading Aurora", "Stepped In Light"
        };
        #endregion

        [HarmonyPatch(typeof(VillagerNameManager), "GetRandomName")]
        public class PatchVillagerNameManager
        {
            protected static bool Prefix(bool isMale, ref string __result)
            {
                if (isMale)
                {
                    __result = BearMaleNames[Random.Range(0, BearMaleNames.Count)];

                    return false;
                }

                if (!isMale)
                {
                    __result = BearFemaleNames[Random.Range(0, BearFemaleNames.Count)];

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
                if (initialized)
                {
                    return;
                }

                initialized = true;

                var field = AccessTools.Field(typeof(VillagerNameManager), "allCompanyNames");
                field.SetValue(null, BearArmyNames);
            }
        }

        [HarmonyPatch(typeof(TransportWagon), "Awake")]
        public class RenameTransportWagon
        {
            protected static void Postfix(TransportWagon __instance)
            {
                Traverse.Create(__instance).Property("displayName").SetValue("Gathering Gale");
            }
        }

        [HarmonyPatch(typeof(SupplyWagon), "Awake")]
        public class RenameSupplyWagon
        {
            protected static void Postfix(SupplyWagon __instance)
            {
                __instance.displayName = "Wandering Spirit";
            }
        }

        [HarmonyPatch(typeof(WagonShop), "Awake")]
        public class RenameWagonShop
        {
            protected static void Postfix(WagonShop __instance)
            {
                __instance.displayName = "Passing Twilight";
            }
        }

        [HarmonyPatch(typeof(School), "Awake")]
        public class RenameSchool
        {
            protected static void Postfix(School __instance)
            {
                Traverse.Create(__instance).Property("displayName").SetValue("Moon Camp");
            }
        }

        [HarmonyPatch(typeof(Pub), "Awake")]
        public class RenamePub
        {
            protected static void Postfix(Pub __instance)
            {
                __instance.displayName = "Autumn's Vale";
            }
        }

        [HarmonyPatch(typeof(Library), "Awake")]
        public class RenameLibrary
        {
            protected static void Postfix(Library __instance)
            {
                __instance.displayName = "Grand Athenaeum";
            }
        }

        [HarmonyPatch(typeof(Crypt), "Awake")]
        public class RenameCrypt
        {
            protected static void Postfix(Crypt __instance)
            {
                __instance.displayName = "Dead Lab";
            }
        }

        [HarmonyPatch(typeof(Graveyard), "Awake")]
        public class RenameGraveyard
        {
            protected static void Postfix(Graveyard __instance)
            {
                Traverse.Create(__instance).Property("displayName").SetValue("Blood Hill");
            }
        }

        [HarmonyPatch(typeof(TradingPost), "Awake")]
        public class RenameTradingPost
        {
            protected static void Postfix(TradingPost __instance)
            {
                __instance.displayName = "Alliance Staging Ground";
            }
        }

        [HarmonyPatch(typeof(HunterBuilding), "Awake")]
        public class RenameHunterBuilding
        {
            protected static void Postfix(HunterBuilding __instance)
            {
                __instance.displayName = "Old Hutment Site";
            }
        }

        [HarmonyPatch(typeof(ForagerShack), "Awake")]
        public class RenameForagerShack
        {
            protected static void Postfix(ForagerShack __instance)
            {
                __instance.displayName = "Stricken Plains";
            }
        }

        [HarmonyPatch(typeof(FishingShack), "Awake")]
        public class RenameFishingShack
        {
            protected static void Postfix(FishingShack __instance)
            {
                __instance.displayName = "Harvest Shore";
            }
        }

        [HarmonyPatch(typeof(SmokeHouse), "Awake")]
        public class RenameSmokeHouse
        {
            protected static void Postfix(SmokeHouse __instance)
            {
                __instance.displayName = "Haar Mire";
            }
        }

        [HarmonyPatch(typeof(Temple), "Awake")]
        public class RenameTemple
        {
            protected static void Postfix(Temple __instance)
            {
                __instance.displayName = "Voice of Koda";
            }
        }

        [HarmonyPatch(typeof(TemporaryShelter), "Awake")]
        public class RenameTemporaryShelter
        {
            protected static void Postfix(TemporaryShelter __instance)
            {
                __instance.displayName = "Harvest Den";
            }
        }

        [HarmonyPatch(typeof(Academy), "Awake")]
        public class RenameAcademy
        {
            protected static void Postfix(Academy __instance)
            {
                __instance.displayName = "The Laboratory";
            }
        }

        [HarmonyPatch(typeof(ApothecaryShop), "Awake")]
        public class RenameApothecary
        {
            protected static void Postfix(ApothecaryShop __instance)
            {
                __instance.displayName = "Arid Esker's Potions";
            }
        }

        [HarmonyPatch(typeof(TownCenter), "Awake")]
        public class RenameTownCenter
        {
            protected static void Postfix(TownCenter __instance)
            {
                __instance.displayName = "Hearth's Glow";
            }
        }
    }
}
