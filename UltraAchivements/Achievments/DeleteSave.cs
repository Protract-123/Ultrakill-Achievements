﻿using HarmonyLib;
using System.IO;
using UltraAchievement;
using UnityEngine;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(SaveSlotMenu), "ConfirmWipe")]

    public static class DeleteSave
    {
        public static void Prefix()
        {
            string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\Icons\\DeleteSave.jpeg";
            string name = "One step forward, Two steps back";
            string description = "Delete a save file";
            string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\achBG.png";
            string mod = "UltraAchievements Protract";
            Core.ShowAchievementI(icon, name, description, sprite, mod);
        }
    }
}
