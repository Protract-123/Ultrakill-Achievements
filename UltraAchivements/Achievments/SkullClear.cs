using HarmonyLib;
using System.IO;
using UltraAchievement;
using UnityEngine;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(FinalRank), "SetTime")]

    public static class SkullClear
    {
        public static void Postfix()
        {
            GameObject main = GameObject.FindGameObjectWithTag("MainCamera");
            FistControl fist = main.GetComponentInChildren<FistControl>();
            ItemIdentifier item = fist.heldObject;
            if (item != null) {
                string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                string name = "Dead on Arrival";
                string description = "Hold a skull on your way out";
                string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);

            }
        }
    }
}
