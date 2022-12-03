using HarmonyLib;
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
            string icon = $"{Achivements.path3}\\Sprites\\Icons\\DeleteSave.jpeg";
            string name = "One step forward, Two steps back";
            string description = "Delete a save file";
            string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
            string mod = "UltraAchievements Protract";
            Core.ShowAchievementI(icon, name, description, sprite, mod);
        }
    }
}
