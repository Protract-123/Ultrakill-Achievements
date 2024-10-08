﻿using HarmonyLib;
using System.IO;
using UltraAchievement;
using UnityEngine;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(ClashModePickup), "Activate")]
    public static class AllCrates
    {
        public static void Postfix()
        {
            string icon = $"{Achivements.path3}\\Sprites\\Icons\\CrashBand.jpeg";
            string name = "Crash Bandicoot";
            string description = "Unlock Clash Mode";
            string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
            string mod = "UltraAchievements Protract";
            Core.ShowAchievementI(icon, name, description, sprite, mod);
        }
    }
}
