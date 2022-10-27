using HarmonyLib;
using System.IO;
using UltraAchievement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    public static class Cybergrind25
    {
        [HarmonyPatch(typeof(EndlessGrid), "NextWave")]

        public static void Postfix(EndlessGrid __instance)
        {
            string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
            string name = "Cybergrind Wave 25";
            string description = "You reached cybergrind wave 25!";
            string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
            string mod = "UltraAchievements Protract";
            int i = __instance.currentWave;
            if (i == 25)
            {
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
        }
    }
}
