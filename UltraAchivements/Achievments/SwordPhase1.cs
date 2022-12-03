using HarmonyLib;
using System.IO;
using UltraAchievement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(SwordsMachine), "EndFirstPhase")]
    public static class Phase1SwordAchivement
    {
        public static void Postfix()
        {
            string icon = $"{Achivements.path3}\\Sprites\\Icons\\swordmachine.png";
            string name = "Swordsmachine Phase 1";
            string description = "You beat Swordsmachine Phase 1";
            string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
            string mod = "UltraAchievements Protract";
            Core.ShowAchievementI(icon, name, description,sprite, mod);
        }
    }
}
