using HarmonyLib;
using UltraAchievement;
using System.IO;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(CrateCounter), "AddCoin")]
    public static class CrateCoin
    {
        public static void Postfix()
        {
            string icon = $"{Achivements.path3}\\Sprites\\Icons\\Coin.jpeg";
            string name = "You Got Money";
            string description = "Pick up a coin";
            string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
            string mod = "UltraAchievements Protract";
            Core.ShowAchievementI(icon, name, description, sprite, mod);
        }
    }
}
