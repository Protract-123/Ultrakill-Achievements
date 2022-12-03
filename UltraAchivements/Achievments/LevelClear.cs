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
                GameObject[] root = SceneManager.GetActiveScene().GetRootGameObjects();
                if (root != null)
                {
                    foreach (GameObject obj in root)
                    {
                        if (obj.name == "StatsManager")
                        {

                            stats = obj.GetComponent<StatsManager>();
                            time = (int)stats.seconds;
                            if (rank == "<color=#FFFFFF>P</color>")
                            {
                                if (time != null)
                                {
                                    if (time < 120)
                                    {
                                        string icon = $"{Achivements.path3}\\Sprites\\Icons\\km.jpg";
                                        string name = "Killer Machine";
                                        string description = "P Rank a level in under 2 minutes";
                                        string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
                                        string mod = "UltraAchievements Protract";
                                        Core.ShowAchievementI(icon, name, description, sprite, mod);
                                    }
                                    if (time < 60)
                                    {
                                        string icon = $"{Achivements.path3}\\Sprites\\Icons\\ukm.jpg";
                                        string name = "UltraKiller Machine";
                                        string description = "P Rank a level in under 1 minute";
                                        string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
                                        string mod = "UltraAchievements Protract";
                                        Core.ShowAchievementI(icon, name, description, sprite, mod);
                                    }
                                }
                            }
                        }
                    }
                    GameObject main;
                    main = GameObject.FindGameObjectWithTag("MainCamera");

                    if (scene == "Level P-1" && rank == "<color=#FFFFFF>P</color>")
                    {
                        string icon = $"{Achivements.path3}\\Sprites\\Icons\\mpp%.png";
                        string name = "WEAK";
                        string description = "P-Rank P-1";
                        string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
                        string mod = "UltraAchievements Protract";
                        Core.ShowAchievementI(icon, name, description, sprite, mod);
                    }
                    if (scene == "Level 1-S")
                    {
                        string icon = $"{Achivements.path3}\\Sprites\\Icons\\1-s.jpeg";
                        string name = "Puzzle Solver";
                        string description = "Beat 1-S";
                        string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
                        string mod = "UltraAchievements Protract";
                        Core.ShowAchievementI(icon, name, description, sprite, mod);
                    }

                    if (main != null)
                    {
                        FistControl fist = main.GetComponentInChildren<FistControl>();

                        if (fist != null)
                        {
                            ItemIdentifier item = fist.heldObject;

                            if (item != null)
                            {
                                ItemType itemType = item.itemType;


                                if (itemType == ItemType.SkullGreen || itemType == ItemType.SkullBlue || itemType == ItemType.SkullRed)
                                {
                                    string icon = $"{Achivements.path3}\\Sprites\\Icons\\dor.jpeg";
                                    string name = "Dead on Arrival";
                                    string description = "Hold a skull on your way out";
                                    string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
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
