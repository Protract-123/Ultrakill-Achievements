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
    [HarmonyPatch(typeof(MinosBoss), "DeathOver")]
    public static class CorpseKill
    {
        public static void Postfix()
        {
            string icon = $"{Achivements.path3}\\Sprites\\Icons\\CorpseKing.jpeg";
            string name = "Killed a Corpes";
            string description = "Kill the Corpse of King Minos";
            string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
            string mod = "UltraAchievements Protract";
            Core.ShowAchievementI(icon, name, description, sprite, mod);
        }
    }
}
