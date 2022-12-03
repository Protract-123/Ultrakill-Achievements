using HarmonyLib;
using System.IO;
using UltraAchievement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(SwordsMachine), "OnDisable")]
    public static class SwordPhaseKill
    {
        public static void Postfix()
        {
            string icon = $"{Achivements.path3}\\Sprites\\Icons\\swordmachine2.png";
            string name = "Kill the SwordMachine";
            string description = "You beat Swordsmachine";
            string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
            string mod = "UltraAchievements Protract";
            Core.ShowAchievementI(icon, name, description,sprite, mod);
        }
    }
}
