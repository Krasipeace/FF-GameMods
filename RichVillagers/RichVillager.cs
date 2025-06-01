using HarmonyLib;
using MelonLoader;

using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using System.Linq;
using System.Data;

[assembly: MelonInfo(typeof(RichVillagers.RichVillager), "Rich Villagers", "1.0.2", "Krasipeace")]
[assembly: MelonGame("Crate Entertainment", "Farthest Frontier")]
namespace RichVillagers
{
    public class RichVillager : MelonMod
    {
        private static MelonPreferences_Category richVillagerConfig;
        private static MelonPreferences_Entry<int> goldMultiplier;
        public static int GoldMultiplier => goldMultiplier?.Value ?? 10;

        public override void OnInitializeMelon()
        {
            richVillagerConfig = MelonPreferences.CreateCategory("RichVillagerConfig", "Rich Villager Config");
            goldMultiplier = richVillagerConfig.CreateEntry<int>("GoldMultiplier", 10, "Gold Multiplier", "Multiplier for market gold income");
            MelonPreferences.Save();

            LoggerInstance.Msg($"Gold Income Market Multiplier: x{GoldMultiplier}. Check \\..\\..\\UserData\\MelonPreferences\\[RichVillagerConfig] for a change.");
        }

        [HarmonyPatch(typeof(MarketBuilding), "GenerateMonthlyTaxes")]
        public class PatchMarketIncome
        {
            protected static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                var fieldInfo = AccessTools.Field(typeof(ExpenseManager.Gain), nameof(ExpenseManager.Gain.amount));
                var goldMultiplierGetter = AccessTools.PropertyGetter(typeof(RichVillager), nameof(GoldMultiplier));

                for (int i = 0; i < codes.Count - 1; i++)
                {
                    if (codes[i].opcode == OpCodes.Stfld && codes[i].operand as FieldInfo == fieldInfo)
                    {
                        codes.Insert(i, new CodeInstruction(OpCodes.Call, goldMultiplierGetter));
                        codes.Insert(i + 1, new CodeInstruction(OpCodes.Mul));
                        i += 2;
                    }
                }

                return codes.AsEnumerable();
            }
        }
    }
}
