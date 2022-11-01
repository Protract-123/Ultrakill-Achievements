using GameConsole;
using HarmonyLib;
using System.IO;
using UltraAchievement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(FinalRank), "SetRank")]

    public static class LevelClear
    {
        public static void Postfix(string rank)
        {
            string scene = SceneManager.GetActiveScene().name;
            StatsManager stats = null;
            float time;
            if (scene != null)
            {
                GameObject[] root = SceneManager.GetActiveScene().GetRootGameObjects();
                if (root != null)
                {
                    foreach (GameObject obj in root)
                    {
                        if (obj.name == "StatsManager")
                        {
                            stats = obj.GetComponent<StatsManager>();
                            time = stats.seconds;
                            if (rank == "<color=#FFFFFF>P</color>")
                            {
                                if (time < 120)
                                {
                                    string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                                    string name = "Killer Machine";
                                    string description = "P Rank a level in under 2 minutes";
                                    string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                                    string mod = "UltraAchievements Protract";
                                    Core.ShowAchievementI(icon, name, description, sprite, mod);
                                }
                                else if (time < 60)
                                {
                                    string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                                    string name = "UltraKiller Machine";
                                    string description = "P Rank a level in under 1 minute";
                                    string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                                    string mod = "UltraAchievements Protract";
                                    Core.ShowAchievementI(icon, name, description, sprite, mod);
                                }
                            }
                        }
                    }

                    GameObject main = GameObject.FindGameObjectWithTag("MainCamera");
                    FistControl fist = main.GetComponentInChildren<FistControl>();
                    ItemType item = fist.heldObject.itemType;
                    if (main != null)
                    {
                        if (fist != null)
                        {
                            if (item != null)
                            {

                                if (item == ItemType.SkullGreen || item == ItemType.SkullBlue || item == ItemType.SkullRed)
                                {
                                    string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                                    string name = "Dead on Arrival";
                                    string description = "Hold a skull on your way out";
                                    string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                                    string mod = "UltraAchievements Protract";
                                    Core.ShowAchievementI(icon, name, description, sprite, mod);

                                }
                                else if (scene == "Level P-1" && rank == "<color=#FFFFFF>P</color>")
                                {
                                    string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                                    string name = "WEAK";
                                    string description = "P-Rank P-1";
                                    string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                                    string mod = "UltraAchievements Protract";
                                    Core.ShowAchievementI(icon, name, description, sprite, mod);
                                }
                                if (scene == "Level 1-S")
                                {
                                    string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                                    string name = "Puzzle Solver";
                                    string description = "Beat 1-S";
                                    string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                                    string mod = "UltraAchievements Protract";
                                    Core.ShowAchievementI(icon, name, description, sprite, mod);
                                }


                            }
                        }
                    }
                }
            }
        }
    }
}
