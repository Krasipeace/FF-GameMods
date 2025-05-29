using MelonLoader;
using HarmonyLib;

[assembly: MelonInfo(typeof(ForcedChildLabor.ChildLabor), "Forced Child Labor", "1.0.1", "Krasipeace")]
[assembly: MelonGame("Crate Entertainment", "Farthest Frontier")]
namespace ForcedChildLabor
{
    public class ChildLabor : MelonMod
    {
        public override void OnInitializeMelon()
        {
            ChildLaborConfig.Load();
            LoggerInstance.Msg("Forced children labor activated - config file @<YourGameFolder>/UserData/MelonPreferences.cfg -> [ChildLaborConfig]");
        }

        [HarmonyPatch(typeof(VillagerHealth), "Awake")]
        public class PatchVillagerLabor
        {
            protected static void Postfix(VillagerHealth __instance)
            {
                Traverse.Create(__instance).Field("ageCutoffChild").SetValue(ChildLaborConfig.AgeCutoffChild.Value);
                Traverse.Create(__instance).Field("ageCutoffAdolescent").SetValue(ChildLaborConfig.AgeCutoffAdolescent.Value);
            }
        }

        [HarmonyPatch(typeof(School), "Awake")]
        public class PatchSchoolForLabor
        {
            protected static void Postfix(School __instance)
            {
                Traverse.Create(__instance).Field("minEnrollmentAge").SetValue(ChildLaborConfig.SchoolMinAge.Value);
                Traverse.Create(__instance).Field("maxEnrollmentAge").SetValue(ChildLaborConfig.SchoolMaxAge.Value);
            }
        }
    }
}
