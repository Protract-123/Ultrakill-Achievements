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
            if (__instance != null)
            {
                string currentweapon = __instance.currentWeapon.name;
                int currentvariation = __instance.currentVariation;
                if (currentweapon == "RailcannonHarpoon(Clone)")
                {
                    string icon = $"{Achivements.path3}\\Sprites\\Icons\\screwdriver.jpeg";
                    string name = "Why...";
                    string description = "Hold the screwdriver...";
                    string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
                    string mod = "UltraAchievements Protract";
                    Core.ShowAchievementI(icon, name, description, sprite, mod);
                }
            }
        }

    }
}
