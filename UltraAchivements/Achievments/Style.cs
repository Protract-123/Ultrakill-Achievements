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
            GunControl gc =  GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<GunControl>();
            GameObject currentWeapon = gc.currentWeapon;
            string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";


            GameObject gameObject = (pointID == "ultrakill.arsenal") ?  currentWeapon : sourceWeapon;
            StyleFreshnessState styleFreshness = StyleFreshnessState.Used;
            bool styleFreshTrue = false;
            if (gameObject)
            {
                styleFreshness = __instance.GetFreshnessState(gameObject);
                styleFreshTrue = true;
            }


            if (pointID == "ultrakill.chargeback")
            {
                string icon = $"{Achivements.path3}\\Sprites\\Icons\\chargeback.png";
                string name = "Fuck You";
                string description = "You CHARGEBACKED AN ENEMY";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
            else if (pointID == "ultrakill.fireworks")
            {
                string icon = $"{Achivements.path3}\\Sprites\\Icons\\demoman.png";
                string name = "KABLLOOIEE";
                string description = "Explode an enemy in mid-air";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
            else if (pointID == "ultrakill.mauriced")
            {
                string icon = $"{Achivements.path3}\\Sprites\\Icons\\mauriced.png";
                string name = "Twomphed";
                string description = "Get thwomphed by maurice";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
            else if (pointID == "ultrakill.parry")
            {

                string icon = $"{Achivements.path3}\\Sprites\\Icons\\ntty.png";
                string name = "Not Today, Thank You";
                string description = "Parry an attack from an enemy";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
            else if (pointID == "ultrakill.ricoshot")
            {
                string icon = $"{Achivements.path3}\\Sprites\\Icons\\Coin.jpeg";
                string name = "You can do that?";
                string description = "Shoot a Coin";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
            if (styleFreshTrue)
            {
                if (styleFreshness == StyleFreshnessState.Dull)
                {
                    string icon = $"{Achivements.path3}\\Sprites\\Icons\\dull.jpeg";
                    string name = "Dull as a Door Knob";
                    string description = "Reach the Dull Freshness rank";
                    string mod = "UltraAchievements Protract";
                    Core.ShowAchievementI(icon, name, description, sprite, mod);

                }
            }
        }
    }
}
