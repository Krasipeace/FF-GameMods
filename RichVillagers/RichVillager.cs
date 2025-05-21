using HarmonyLib;
using MelonLoader;

using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using System.Linq;
using System.Data;

[assembly: MelonInfo(typeof(RichVillagers.RichVillager), "Rich Villagers", "1.0.1", "Krasipeace")]
[assembly: MelonGame("Crate Entertainment", "Farthest Frontier")]
namespace RichVillagers
{
    public class RichVillager : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Villagers are 10 times reacher than normal");
        }

        [HarmonyPatch(typeof(MarketBuilding), "GenerateMonthlyTaxes")]
        public class PatchMarketIncome
        {
            protected static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                var fieldInfo = AccessTools.Field(typeof(ExpenseManager.Gain), nameof(ExpenseManager.Gain.amount));

                for (int i = 0; i < codes.Count - 1; i++)
                {
                    if (codes[i].opcode == OpCodes.Stfld && codes[i].operand as FieldInfo == fieldInfo)
                    {
                        codes.Insert(i, new CodeInstruction(OpCodes.Ldc_I4, 10));
                        codes.Insert(i + 1, new CodeInstruction(OpCodes.Mul));
                        i += 2;
                    }
                }

                return codes.AsEnumerable();
            }
        }
    }
}
