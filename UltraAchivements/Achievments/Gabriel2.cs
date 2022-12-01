﻿using HarmonyLib;
using System.IO;
using UltraAchievement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(GabrielSecond), "OnDisable")]
    public static class Gabriel2
    {        
            public static void Postfix()
            {
                string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\Icons\\gab2.png";
                string name = "Twice beaten by an object";
                string description = "Beat gabriel for the 2nd time";
                string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\achBG.png";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
        }
    
}
