using HarmonyLib;
using MelonLoader;
using UnityEngine;

using System.Collections.Generic;

[assembly: MelonInfo(typeof(AngloSaxonNames.AngloSaxonNames), "AngloSaxon Names", "1.0.3", "Krasipeace")]
[assembly: MelonGame("Crate Entertainment", "Farthest Frontier")]
namespace AngloSaxonNames
{
    public class AngloSaxonNames : MelonMod
    {
        #region Collections
        private static readonly List<string> AngloSaxonMaleNames = new List<string>
        {
            "Aethelred", "Aethelwulf", "Beornwulf", "Cenric", "Cuthbert", "Eadric", "Eadwig", "Ealdred", "Eardwulf", "Edgar",
            "Edmund", "Edward", "Egelbert", "Egwald", "Eoferwic", "Eormenric", "Frithuwald", "Godric", "Guthlac", "Hereward",
            "Leofric", "Offa", "Osric", "Oswald", "Osmund", "Oswine", "Oswiu", "Redwald", "Saebald", "Sigeberht", "Sigeric",
            "Sigebehrt", "Sigeheard", "Theodred", "Theodric", "Uhtred", "Wiglaf", "Wulfhere", "Wulfric", "Wulfstan", "Aelfric",
            "Aelfwine", "Aelfheah", "Aelfgar", "Aethelbald", "Aethelberht", "Aethelwine", "Aethelstan", "Beorhthelm", "Beorhtwulf",
            "Burgred", "Ceawlin", "Ceolwulf", "Coenwulf", "Cuthwulf", "Cyning", "Cynric", "Cynewulf", "Dunstan", "Eadbald",
            "Eadgar", "Eadgils", "Eadmund", "Eadric", "Eadwine", "Ealhred", "Ecgberht", "Ecgwine", "Eormenwulf", "Ethelred",
            "Ethelstan", "Forthred", "Godwin", "Grimbald", "Herebeald", "Humbert", "Leofwine", "Oeric", "Osgar", "Oslac",
            "Osric", "Ostwine", "Raedwald", "Saewulf", "Swithred", "Thelwulf", "Tidfrith", "Wigstan", "Wilfrid", "Wulfgifu",
            "Wulfharth", "Wulfnoth", "Wulfrun", "Wynstan", "Yrmenlaf", "Aethelhun", "Aethelmod", "Ceolric", "Cuthheard", "Wulfgar"
        };

        private static readonly List<string> AngloSaxonFemaleNames = new List<string>
        {
            "Aethelthryth", "Aethelgifu", "Aethelburg", "Aethelflæd", "Beorhtwynn", "Ceolburg", "Cwenhild", "Cyneburg", "Eadburh", "Eadgifu",
            "Eadwynn", "Ealdgyth", "Ealhswith", "Edburga", "Edith", "Elfleda", "Ethelreda", "Frideswide", "Godgifu", "Goldrun",
            "Helmgard", "Heregyth", "Hilda", "Hildegyth", "Hildred", "Leofa", "Leofgyth", "Leofrun", "Mildburg", "Mildgyth",
            "Milreda", "Osyth", "Rædwynn", "Saethryth", "Seaxburg", "Seleburg", "Sigeburg", "Sifflaed", "Swidburg", "Theoflæd",
            "Theowynn", "Wulfgifu", "Wulflæd", "Wulfthryth", "Wynflæd", "Wynflaed", "Wynne", "Aelfgyth", "Aelfgifu", "Aelfwynn",
            "Aethelwynn", "Aethelrun", "Beornwynn", "Brynhild", "Cuthburg", "Cynewynn", "Eadgyth", "Ealdwynn", "Eanflæd", "Eanswith",
            "Eanflaed", "Edilgifu", "Elfswith", "Ermenhild", "Frithgyth", "Godrun", "Gytha", "Hereswith", "Hild", "Hildgifu",
            "Leofhild", "Leofwynn", "Mildgytha", "Oslafa", "Ricswith", "Saewynn", "Selethryth", "Sigelgifu", "Sigwynn", "Stanhild",
            "Sunniva", "Swanhild", "Swanwynn", "Swithburg", "Theodgyth", "Tidwynn", "Wynburg", "Wynfrith", "Wynhild", "Wynnflæd",
            "Wulfhild", "Wulfgyd", "Yrsa", "Cwenburh", "Burgwynn", "Cynethryth", "Aelswith", "Aelgifu", "Cenwynn", "Beagwynn"
        };

        private static readonly List<string> AngloSaxonArmyNames = new List<string>
        {
            "Alfred's Guards", "Aethelstan's Host", "Offa's Warband", "Edward's Company", "Edgar's Men", "Aethelberht's Kin"
        };
        #endregion
        [HarmonyPatch(typeof(VillagerNameManager), "GetRandomName")]
        public class PatchVillagerNameManager
        {
            protected static bool Prefix(bool isMale, ref string __result)
            {
                if (isMale)
                {
                    __result = AngloSaxonMaleNames[Random.Range(0, AngloSaxonMaleNames.Count)];

                    return false;
                }

                if (!isMale)
                {
                    __result = AngloSaxonFemaleNames[Random.Range(0, AngloSaxonFemaleNames.Count)];

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
                field.SetValue(null, AngloSaxonArmyNames);
            }
        }

        [HarmonyPatch(typeof(Temple), "Awake")]
        public class RenameTemple
        {
            protected static void Postfix(Temple __instance)
            {
                __instance.displayName = "Church of Haelend";
            }
        }

        [HarmonyPatch(typeof(School), "Awake")]
        public class RenameSchool
        {
            protected static void Postfix(School __instance)
            {
                Traverse.Create(__instance).Property("displayName").SetValue("School of Bede");
            }
        }

        [HarmonyPatch(typeof(Library), "Awake")]
        public class RenameLibrary
        {
            protected static void Postfix(Library __instance)
            {
                __instance.displayName = "Eostre's Library";
            }
        }

        [HarmonyPatch(typeof(GuardTower), "Awake")]
        public class RenameGuardTower
        {
            protected static void Postfix(GuardTower __instance)
            {
                __instance.displayName = "Tower of Tiw";
            }
        }

        [HarmonyPatch(typeof(SupplyWagon), "Awake")]
        public class RenameSupplyWagon
        {
            protected static void Postfix(SupplyWagon __instance)
            {
                __instance.displayName = "Thunor's Caravan";
            }
        }

        [HarmonyPatch(typeof(Pub), "Awake")]
        public class RenamePub
        {
            protected static void Postfix(Pub __instance)
            {
                __instance.displayName = "Frige's Tavern";
            }
        }

        [HarmonyPatch(typeof(ForagerShack), "Awake")]
        public class RenameForagerShack
        {
            protected static void Postfix(ForagerShack __instance)
            {
                __instance.displayName = "Ing Forager Shack";
            }
        }

        [HarmonyPatch(typeof(Crypt), "Awake")]
        public class RenameCrypt
        {
            protected static void Postfix(Crypt __instance)
            {
                __instance.displayName = "Seaxneat's Rest";
            }
        }

        [HarmonyPatch(typeof(HunterBuilding), "Awake")]
        public class RenameHunterBuilding
        {
            protected static void Postfix(HunterBuilding __instance)
            {
                __instance.displayName = "Erce Hunter Cabin";
            }
        }
    }
}
