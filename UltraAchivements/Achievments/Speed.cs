using System;
using System.IO;
using HarmonyLib;
using UltraAchievement;
using UnityEngine;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(NewMovement), "Update")]

    public static class Speed
    {
        public static void Postfix()
        {
            GameObject[] root = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            GameObject player = null;
            Rigidbody movement = null;

            if (player == null && root!=null || player.name != "Player")
            {
                foreach (GameObject obj in root)
                {
                    if (obj.name == "Player")
                    {
                        player = obj;
                    }
                }
            }


            if (player != null)
            {
              movement = player.GetComponent<Rigidbody>();

            }


            if (movement != null)
            {
                float x = Math.Abs(movement.velocity.x);
                float z = Math.Abs(movement.velocity.z);
                if (x > 125 || z > 125)
                {

                    string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\Icons\\zoom.jpeg";
                    string name = "Wee!";
                    string description = "Wee! You went Zoom!";
                    string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\achBG.png";
                    string mod = "UltraAchievements Protract";
                    Core.ShowAchievementI(icon, name, description, sprite, mod);
                }
                else if (x>140 || x > 140)
                {
                    string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\Icons\\zoom.jpeg";
                    string name = "Dejavu";
                    string description = "It's a place to go";
                    string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\achBG.png";
                    string mod = "UltraAchievements Protract";
                    Core.ShowAchievementI(icon, name, description, sprite, mod);
                }
            }
        }
    }
}
