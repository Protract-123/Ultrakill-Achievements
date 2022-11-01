﻿using HarmonyLib;
using System.IO;
using UltraAchievement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(FerrymanFake), "BlowCoin")]
    public static class FerrymanSave
    {
        public static void Postfix()
        {
            string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
            string name = "Payment to travel";
            string description = "Pick up a coin";
            string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
            string mod = "UltraAchievements Protract";
            Core.ShowAchievementI(icon, name, description, sprite, mod);
        }
    }
}