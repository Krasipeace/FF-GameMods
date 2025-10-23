using HarmonyLib;

using MelonLoader;

[assembly: MelonInfo(typeof(SlowRaiders.SlowRaider), "Slow Raiders", "1.0.3", "Krasipeace")]
[assembly: MelonGame("Crate Entertainment", "Farthest Frontier")]
namespace SlowRaiders
{
    public class SlowRaider : MelonMod
    {
        [HarmonyPatch(typeof(BatteringRam), "Awake")]
        public class PatchBatteringRam
        {
            protected static void Postfix(BatteringRam __instance)
            {
                Traverse.Create(__instance).Field("_movementSpeedBase").SetValue(2f);
                Traverse.Create(__instance).Field("_movementSpeedBaseRun").SetValue(3f);
                __instance.runSpeedBonusIfNotApproachedFirstTarget = 1f;
            }
        }

        [HarmonyPatch(typeof(Catapult), "Awake")]
        public class PatchCatapult
        {
            protected static void Postfix(Catapult __instance)
            {
                Traverse.Create(__instance).Field("_movementSpeedBase").SetValue(2f);
                Traverse.Create(__instance).Field("_movementSpeedBaseRun").SetValue(3f);
                __instance.runSpeedBonusIfNotApproachedFirstTarget = 1f;
            }
        }

        [HarmonyPatch(typeof(Raider), "Awake")]
        public class PatchRaider
        {
            protected static void Postfix(Raider __instance)
            {
                Traverse.Create(__instance).Field("_movementSpeedBase").SetValue(1f);
                Traverse.Create(__instance).Field("_movementSpeedBaseRun").SetValue(2f);
            }
        }
    }
}
