using HarmonyLib;

using MelonLoader;

[assembly: MelonInfo(typeof(FastVillagers.FastVillager), "Fast Villagers", "1.0.0", "Krasipeace")]
[assembly: MelonGame("Crate Entertainment", "Farthest Frontier")]
namespace FastVillagers
{
    public class FastVillager : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Villagers move faster, Wagons are faster");
        }

        [HarmonyPatch(typeof(Character), "Awake")]
        public class PatchCharacterStats
        {
            protected static void Postfix(Character __instance)
            {
                Traverse.Create(__instance).Field("_shoeBonusBase").SetValue(1f);
            }
        }

        [HarmonyPatch(typeof(TransportWagon), "Awake")]
        public class PatchSupplyWagonSpeed
        {
            protected static void Postfix(TransportWagon __instance)
            {
                Traverse.Create(__instance).Field("_movementSpeed").SetValue(8f);
                Traverse.Create(__instance).Field("_turningSpeed").SetValue(100f);
                __instance.carryCapacity = 400f;
            }
        }
    }
}
