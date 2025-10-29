using HarmonyLib;
using MelonLoader;

[assembly: MelonInfo(typeof(FastVillagers.FastVillager), "Fast Villagers", "1.0.4", "Krasipeace")]
[assembly: MelonGame("Crate Entertainment", "Farthest Frontier")]

namespace FastVillagers
{
    public class FastVillager : MelonMod
    {
        public override void OnInitializeMelon()
        {
            FastVillagersConfig.Load();
            LoggerInstance.Msg("Fast Villagers activated - config file @<YourGameFolder>\\UserData\\MelonPreferences.cfg -> [FastVillagersConfig]");
        }

        [HarmonyPatch(typeof(Character), "Awake")]
        public class PatchCharacterStats
        {
            protected static void Postfix(Character __instance)
            {
                Traverse.Create(__instance).Field("_shoeBonusBase").SetValue(FastVillagersConfig.VillagerSpeed);
                Traverse.Create(__instance).Field("_turningSpeed").SetValue(FastVillagersConfig.VillagerSpeed * 50f);
            }
        }

        [HarmonyPatch(typeof(TransportWagon), "Awake")]
        public class PatchSupplyWagonSpeed
        {
            protected static void Postfix(TransportWagon __instance)
            {
                Traverse.Create(__instance).Field("_movementSpeed").SetValue(FastVillagersConfig.WagonMoveSpeed);
                Traverse.Create(__instance).Field("_turningSpeed").SetValue(FastVillagersConfig.WagonMoveSpeed * 50f);
                __instance.carryCapacity = FastVillagersConfig.WagonCarryCapacity;
            }
        }
    }
}