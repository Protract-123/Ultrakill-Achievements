
using HarmonyLib;
using System.IO;
using UltraAchievement;

namespace Ultrakill_Achivements.Harmony_Patches
{
    [HarmonyPatch(typeof(SwordsMachine), "EndFirstPhase")]
    public static class Phase1SwordAchivement
    {
        static void Postfix()
        {
            string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
            string name = "Swordsmachine Phase 1";
            string description = "You beat Swordsmachine Phase 1";
            Core.ShowAchievement(icon, name, description);
        }
    }
}
