﻿using HarmonyLib;
using System.IO;
using UltraAchievement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(Gabriel), "OnDisable")]
    public static class Gabriel1
    {
        public static void Postfix()
        {
            string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\Icons\\gab1.png";
            string name = "YOU INSIGNIFICANT FUCK";
            string description = "Win for the first time against Gabriel";
            string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\achBG.png";
            string mod = "UltraAchievements Protract";
            Core.ShowAchievementI(icon, name, description, sprite, mod);
        }
    }
}
