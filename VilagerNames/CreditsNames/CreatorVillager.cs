using HarmonyLib;

using MelonLoader;

using System.Collections.Generic;

[assembly: MelonInfo(typeof(CreditsNames.CreatorVillager), "Credits Names", "1.0.0", "Krasipeace")]
[assembly: MelonGame("Crate Entertainment", "Farthest Frontier")]
namespace CreditsNames
{
    public class CreatorVillager : MelonMod
    {
        #region Collections
        private static readonly List<string> maleNames = new List<string>()
        {
            "Brian",
            "Paul",
            "Andrew",
            "Brandon",
            "Matthew",
            "William",
            "Scott",
            "Benjamin",
            "Arthur",
            "Eric",
            "Joshua",
            "Dan",
            "Steve",
            "Christopher",
            "Nicholas",
            "Andy",
            "D.",
            "Richard",
            "Hugo",
            "Ricardo",
            "Stefan",
            "Christoph",
            "Tommy",
            "Matthew",
            "Christophe",
            "Paul",
            "Denis",
            "Luis",
            "powbam",
            "RektbyProtoss",
            "RxJunkie",
            "Suh",
            "Logan",
            "Snowmanplayer123"
        };

        private static readonly List<string> femaleNames = new List<string>()
        {
            "Ivy",
            "Melody",
            "Jasmine",
            "Alina",
            "Maite",
            "Linda",
            "eisprinzessin",
            "Maska322",
            "Kamil",
            "Medea"
        };

        private static readonly List<string> companyNames = new List<string>()
        {
            "Programming Team", "Art Band", "Design Knights", "Production Monsters", "Sound Terrors", "Playtesters", "Local Raiders"
        };
        #endregion
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Game Credits Names initiated...");
        }

        [HarmonyPatch(typeof(VillagerNameManager), "GetRandomName")]
        public class PatchGetRandomName
        {
            protected static bool Prefix(bool isMale, ref string __result)
            {
                if (isMale)
                {
                    __result = maleNames[UnityEngine.Random.Range(0, maleNames.Count)];

                    return false;
                }

                if (!isMale)
                {
                    __result = femaleNames[UnityEngine.Random.Range(0, femaleNames.Count)];

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
                field.SetValue(null, companyNames);
            }
        }
    }
}
