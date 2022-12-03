using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraAchievement;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    [HarmonyPatch(typeof(SpiderBody), "OnDisable")]
    public static class MalFace
    {
        public static void Postfix()
        {
            string icon = $"{Achivements.path3}\\Sprites\\Icons\\malKill.jpeg";
            string name = "The Malicious Machine";
            string description = "Very Rude";
            string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
            string mod = "UltraAchievements Protract";
            Core.ShowAchievementI(icon, name, description, sprite, mod);
        }
    }
}
