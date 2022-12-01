using GameConsole;
using HarmonyLib;
using System.IO;
using UltraAchievement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(Breakable), "Update")]

    public static class Sandcastle
    {
        public static void Postfix()
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name.Contains("4-2"))
            {
                GameObject[] breakables = GameObject.FindGameObjectsWithTag("Breakable");
                GameObject sandcastle = null;

                foreach(GameObject go in breakables)
                {

                    if(go.name == "Sand Castle")
                    {
                        sandcastle= go;
                    }
                }
                if(sandcastle != null && MonoSingleton<StatsManager>.Instance.seconds > 0)
                {
                    if (!sandcastle.activeSelf)
                    {
                        string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\Icons\\sc.jpeg";
                        string name = "You are a Monster";
                        string description = "Destroy the Sandcastle";
                        string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\achBG.png";
                        string mod = "UltraAchievements Protract";
                        Core.ShowAchievementI(icon, name, description, sprite, mod);
                    }
                }


            }



        }
    }
}
