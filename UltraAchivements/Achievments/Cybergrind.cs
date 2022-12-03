using GameConsole;
using HarmonyLib;
using System.IO;
using UltraAchievement;
using UnityEngine;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(EndlessGrid), "Update")]
    public static class Cybergrind
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
                if (i >= 25)
                {
                    string icon = $"{Achivements.path3}\\Sprites\\Icons\\25.jpeg";
                    string name = "Cybergrind Wave 25";
                    string description = "You reached cybergrind wave 25!";
                    string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
                    string mod = "UltraAchievements Protract";
                    Core.ShowAchievementI(icon, name, description, sprite, mod);
                }
                else if (i >= 50)
                {
                    string icon = $"{Achivements.path3}\\Sprites\\Icons\\50.jpeg";
                    string name = "The Grind";
                    string description = "You reached cybergrind wave 50!";
                    string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
                    string mod = "UltraAchievements Protract";
                    Core.ShowAchievementI(icon, name, description, sprite, mod);
                }

            }
        }
    }
}
