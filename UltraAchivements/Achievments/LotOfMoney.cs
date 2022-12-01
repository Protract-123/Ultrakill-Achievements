using HarmonyLib;
using System.IO;
using UltraAchievement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(MoneyText), "DivideMoney")]
    public static class LotOfMoney
    {
        public static void Postfix(int dosh)
        {
            if (dosh > 1000000000) {

                string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\Icons\\elon.jpeg";
                string name = "Thats a lot of money";
                string description = "Have 1 Billion Money";
                string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\achBG.png";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
        }
    }
}
