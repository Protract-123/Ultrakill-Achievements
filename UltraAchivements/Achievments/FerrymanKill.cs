using HarmonyLib;
using UnityEngine;
using System.IO;
using UltraAchievement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(Ferryman), "OnDisable")]
    public static class FerrymanKill
    {
        public static void Postfix()
        {
            string icon = $"{Achivements.path3}\\Sprites\\Icons\\FerryKill.jpeg";
            string name = "Why would you do that";
            string description = "Just give him a coin";
            string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
            string mod = "UltraAchievements Protract";
            Core.ShowAchievementI(icon, name, description, sprite, mod);
        }

    }
}
