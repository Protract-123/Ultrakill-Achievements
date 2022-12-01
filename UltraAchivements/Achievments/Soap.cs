using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraAchievement;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Ultrakill_Achivements.UltraAchivements.Achievments
{
    public static class Soap
    {
        public static void Update()
        {
            GameObject main = GameObject.FindGameObjectWithTag("MainCamera");
            FistControl fist = main.GetComponentInChildren<FistControl>();
            ItemType item = fist.heldObject.itemType;
            if(item == ItemType.Soap)
            {
                string icon = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\Icons\\soap.png";
                string name = "Why a soap in hell?";
                string description = "Pick up The Soap";
                string sprite = $"{Directory.GetCurrentDirectory()}\\BepInEx\\plugins\\Sprites\\achBG.png";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
        }
    }
}
