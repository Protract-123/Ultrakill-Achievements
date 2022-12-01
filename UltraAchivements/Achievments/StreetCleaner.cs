using HarmonyLib;
using UltraAchievement;
using UnityEngine;
using System.IO;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(Machine), "CanisterExplosion")]

    public static class StreetCleaner
    {
        public static void Postfix()
        {
            string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\Icons\\streetClean.jpeg";
            string name = "Backstab";
            string description = "Kill a StreetCleaner with a Coin";
            string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\achBG.png";
            string mod = "UltraAchievements Protract";
            Core.ShowAchievementI(icon, name, description, sprite, mod);
        }
    }
}
