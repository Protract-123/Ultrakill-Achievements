using HarmonyLib;
using System.IO;
using UltraAchievement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(StyleHUD), "AddPoints")]

    public static class Chargeback
    {
        public static void Postfix(string pointID)
        {
            
            string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
            string name = "Fuck You";
            string description = "You CHARGEBACKED AN ENEMY";
            string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
            string mod = "UltraAchievements Protract";
            if (pointID == "ultrakill.chargeback")
            {
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
        }
    }
}
