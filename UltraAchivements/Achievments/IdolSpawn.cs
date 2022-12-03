using HarmonyLib;
using System.IO;
using UltraAchievement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(Idol), "Start")]
    public static class IdolSpawn
    {
        public static void Postfix()
        {
            string icon = $"{Achivements.path3}\\Sprites\\Icons\\Idol.png";
            string name = "Fuck you invincibility";
            string description = "I hate idols";
            string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
            string mod = "UltraAchievements Protract";
            Core.ShowAchievementI(icon, name, description, sprite, mod);
        }
    }
}
