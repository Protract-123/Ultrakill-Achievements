using GameConsole;
using HarmonyLib;
using System.IO;
using UltraAchievement;
using UnityEngine;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(EndlessGrid), "Update")]
    public static class Cybergrind25
    {
        public static void Postfix()
        {
            
            GameObject[] root = null;
            if(root == null)
            {
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            }
            EndlessGrid arena = null;
            if (root != null && arena == null)
            {
                foreach (GameObject obj in root)
                {
                    if (obj.name == "Everything")
                    {
                        arena = obj.GetComponentInChildren<EndlessGrid>();
                    }
                }
            }
            if (arena != null)
            {
                int i = arena.currentWave;
                if (i == 25)
                {
                    string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                    string name = "Cybergrind Wave 25";
                    string description = "You reached cybergrind wave 25!";
                    string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                    string mod = "UltraAchievements Protract";
                    Core.ShowAchievementI(icon, name, description, sprite, mod);
                }
            }
        }
    }
}
