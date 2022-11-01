using GameConsole;
using HarmonyLib;
using System.IO;
using UltraAchievement;
using UnityEngine;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(StyleHUD), "AddPoints")]

    public static class Style
    {
        public static void Postfix(string pointID, GameObject sourceWeapon, StyleHUD __instance)
        {
            Console.print(pointID);
            GunControl gc =  GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<GunControl>();
            GameObject currentWeapon = gc.currentWeapon;
            

            GameObject gameObject = (pointID == "ultrakill.arsenal") ?  currentWeapon : sourceWeapon;
            StyleFreshnessState styleFreshness = __instance.GetFreshnessState(gameObject);
            Console.print(styleFreshness);

            
            if (pointID == "ultrakill.chargeback")
            {
                string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                string name = "Fuck You";
                string description = "You CHARGEBACKED AN ENEMY";
                string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
            else if (pointID == "ultrakill.fireworks")
            {
                string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                string name = "KABLLOOIEE";
                string description = "Explode an enemy in mid-air";
                string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
            else if (pointID == "ultrakill.mauriced")
            {
                string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                string name = "Twomphed";
                string description = "Get thwomphed by maurice";
                string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
            else if (pointID == "ultrakill.parry")
            {

                string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                string name = "Not Today, Thank You";
                string description = "Parry an attack from an enemy";
                string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
            else if (pointID == "ultrakill.ricoshot")
            {
                string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                string name = "You can do that?";
                string description = "Shoot a Coin";
                string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (styleFreshness == null)
            {
                if (styleFreshness == StyleFreshnessState.Dull)
                {
                    string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\swordmachine.png";
                    string name = "Dull as a Door Knob";
                    string description = "Reach the Dull Freshness rank";
                    string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\modthing.jpeg";
                    string mod = "UltraAchievements Protract";
                    Core.ShowAchievementI(icon, name, description, sprite, mod);

                }
            }
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
        }
    }
}
