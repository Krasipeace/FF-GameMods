using MelonLoader;

namespace ForcedChildLabor
{
    public static class ChildLaborConfig
    {
        public static MelonPreferences_Category General;
        public static MelonPreferences_Entry<int> AgeCutoffChild;
        public static MelonPreferences_Entry<int> AgeCutoffAdolescent;
        public static MelonPreferences_Entry<int> SchoolMinAge;
        public static MelonPreferences_Entry<int> SchoolMaxAge;

        public static void Load()
        {
            General = MelonPreferences.CreateCategory("ChildLaborConfig");

            AgeCutoffChild = General.CreateEntry("AgeCutoffChild", 7, "Minimum age for labor");
            AgeCutoffAdolescent = General.CreateEntry("AgeCutoffAdolescent", 15, "Adolescent");
            SchoolMinAge = General.CreateEntry("SchoolMinAge", 5, "Minimum school age");
            SchoolMaxAge = General.CreateEntry("SchoolMaxAge", 50, "Maximum school age");

            int ageCutOffChild = AgeCutoffChild.Value;
            int ageCutOffAdolescent = AgeCutoffAdolescent.Value;
            int schoolMinAge = SchoolMinAge.Value;
            int schoolMaxAge = SchoolMaxAge.Value;

            MelonPreferences.Save();
            MelonLogger.Msg($"MelonPreferences.cfg\\[ChildLaborConfig] AgeCutoffChild = {ageCutOffChild}");
            MelonLogger.Msg($"MelonPreferences.cfg\\[ChildLaborConfig] AgeCutoffAdolescent = {ageCutOffAdolescent}");
            MelonLogger.Msg($"MelonPreferences.cfg\\[ChildLaborConfig] SchoolMinAge = {schoolMinAge}");
            MelonLogger.Msg($"MelonPreferences.cfg\\[ChildLaborConfig] SchoolMaxAge = {schoolMaxAge}");
        }
    }
}
