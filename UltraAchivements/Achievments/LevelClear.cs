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
            int time;
            if (scene != null)
            {
                Console.print("test 1 passed");
                GameObject[] root = SceneManager.GetActiveScene().GetRootGameObjects();
                if (root != null)
                {
                    Console.print("test 2 passed");

                    foreach (GameObject obj in root)
                    {
                        if (obj.name == "StatsManager")
                        {
                            Console.print("test 3 passed");

                            stats = obj.GetComponent<StatsManager>();
                            time = (int)stats.seconds;
                            if (rank == "<color=#FFFFFF>P</color>")
                            {
                                Console.print("test 4 passed");
                                Console.print(time);
                                if (time != null)
                                {
                                    if (time < 120)
                                    {
                                        Console.print("give ach1");
                                        string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                                        string name = "Killer Machine";
                                        string description = "P Rank a level in under 2 minutes";
                                        string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                                        string mod = "UltraAchievements Protract";
                                        Core.ShowAchievementI(icon, name, description, sprite, mod);
                                    }
                                    if (time < 60)
                                    {
                                        Console.print("give ach1");
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
                    }
                    GameObject main;
                    main = GameObject.FindGameObjectWithTag("MainCamera");
                    Console.print(main);

                    if (scene == "Level P-1" && rank == "<color=#FFFFFF>P</color>")
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

                    if (main != null)
                    {
                        FistControl fist = main.GetComponentInChildren<FistControl>();
                        Console.print(fist);
                        Console.print("test 5 passed");

                        if (fist != null)
                        {
                            ItemIdentifier item = fist.heldObject;
                            Console.print(item);
                            Console.print("test 6 passed");

                            if (item != null)
                            {
                                ItemType itemType = item.itemType;
                                Console.print("test 7 passed");


                                if (itemType == ItemType.SkullGreen || itemType == ItemType.SkullBlue || itemType == ItemType.SkullRed)
                                {
                                    string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                                    string name = "Dead on Arrival";
                                    string description = "Hold a skull on your way out";
                                    string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                                    string mod = "UltraAchievements Protract";
                                    Core.ShowAchievementI(icon, name, description, sprite, mod);
                                    Console.print("test 8 passed");

                                }

                            }
                        }
                    }
                }
            }
        }
    }
}
