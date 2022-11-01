using GameConsole.Commands;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraAchievement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(HudMessage), "PlayMessage")]
    public static class HakitaSecret
    {
        public static void Postfix()
        {
            UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
            if (scene != null)
            {
                if (scene.name == "Level 5-1")
                {
                    HudMessage hakita;
                    GameObject[] root = scene.GetRootGameObjects();
                    if (root != null)
                    {
                        foreach (GameObject go in root)
                        {
                            if (go.name == "2 - Elevator")
                            {
                                hakita = go.GetComponentInChildren<HudMessage>();
                                if (hakita != null)
                                {
                                    if (hakita.message == "YOU'RE NOT SUPPOSED TO BE HERE.")
                                    {
                                        string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                                        string name = "YOU'RE NOT SUPPOSED TO BE HERE.";
                                        string description = "Try to get to future content";
                                        string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                                        string mod = "UltraAchievements Protract";
                                        Core.ShowAchievementI(icon, name, description, sprite, mod);
                                    }
                                }
                            }
                        }
                    }
                }
                if (scene.name == "Level 6-1")
                {
                    HudMessage hakita;
                    GameObject[] root = scene.GetRootGameObjects();
                    if (root != null)
                    {
                        foreach (GameObject go in root)
                        {
                            if (go.name == "1S - P DOOR")
                            {
                                hakita = go.GetComponentInChildren<HudMessage>();
                                if (hakita != null)
                                {
                                    if (hakita.message == "YOU'RE NOT SUPPOSED TO BE HERE.")
                                    {
                                        string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                                        string name = "YOU'RE NOT SUPPOSED TO BE HERE.";
                                        string description = "Try to get to future content";
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
}
