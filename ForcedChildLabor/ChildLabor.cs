using MelonLoader;
using HarmonyLib;

[assembly: MelonInfo(typeof(ForcedChildLabor.ChildLabor), "Forced Child Labor", "1.0.0", "Krasipeace")]
[assembly: MelonGame("Crate Entertainment", "Farthest Frontier")]
namespace ForcedChildLabor
{

    public class ChildLabor : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Forced children labor activated");
        }

        [HarmonyPatch(typeof(VillagerHealth), "Awake")]
        public class PatchVillagerLabor
        {
            protected static void Postfix(VillagerHealth __instance)
            {
                Traverse.Create(__instance).Field("ageCutoffChild").SetValue(7);
                Traverse.Create(__instance).Field("ageCutoffAdolescent").SetValue(15);
            }
        }

        [HarmonyPatch(typeof(School), "Awake")]
        public class PatchSchoolForLabor
        {
            protected static void Postfix(School __instance)
            {
                Traverse.Create(__instance).Field("minEnrollmentAge").SetValue(5);
                Traverse.Create(__instance).Field("maxEnrollmentAge").SetValue(50);
            }
        }
    }
}
