using MelonLoader;

namespace FastVillagers
{
    public static class FastVillagersConfig
    {
        public static float VillagerSpeed => villagerSpeed?.Value ?? 1.0f;
        public static float WagonMoveSpeed => wagonMoveSpeed?.Value ?? 8.0f;
        public static float WagonCarryCapacity => wagonCarryCapacity?.Value ?? 400.0f;
        private static MelonPreferences_Category fvCategory;
        private static MelonPreferences_Entry<float> villagerSpeed;
        private static MelonPreferences_Entry<float> wagonMoveSpeed;
        private static MelonPreferences_Entry<float> wagonCarryCapacity;

        public static void Load()
        {
            fvCategory = MelonPreferences.CreateCategory("FastVillagersConfig");
            villagerSpeed = fvCategory.CreateEntry("VillagerSpeed", 1.0f, "Villager Speed Multiplier", "In case something weird happen, default mod value is: 1.0");
            wagonMoveSpeed = fvCategory.CreateEntry("WagonMoveSpeed", 8.0f, "Transport Wagon Movement Speed", "In case something weird happen, default mod value is: 8.0");
            wagonCarryCapacity = fvCategory.CreateEntry("WagonCarryCapacity", 400.0f, "Transport Wagon Carry Capacity", "In case something weird happen, default mod value is: 400.0");
            MelonPreferences.Save();
            MelonLogger.Msg($"[FastVillagersConfig] VillagerSpeed = {villagerSpeed.Value}");
            MelonLogger.Msg($"[FastVillagersConfig] WagonMoveSpeed = {wagonMoveSpeed.Value}");
            MelonLogger.Msg($"[FastVillagersConfig] WagonCarryCapacity = {wagonCarryCapacity.Value}");
        }
    }
}