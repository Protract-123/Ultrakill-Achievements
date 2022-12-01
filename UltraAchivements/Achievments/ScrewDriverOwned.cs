using GameConsole;
using HarmonyLib;
using System.IO;
using UltraAchievement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(GunControl), "Update")]

    public static class ScrewDriverOwned
    {
        public static void Postfix(GunControl __instance)
        {
            string currentweapon = __instance.currentWeapon.name;
            int currentvariation = __instance.currentVariation;
            if(currentweapon == "RailcannonHarpoon(Clone)")
            {
                string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\Icons\\screwdriver.jpeg";
                string name = "Why...";
                string description = "Hold the screwdriver...";
                string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\achBG.png";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
        }

    }
}
