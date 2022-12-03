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
                string icon = $"{Achivements.path3}\\Sprites\\Icons\\soap.png";
                string name = "Why a soap in hell?";
                string description = "Pick up The Soap";
                string sprite = $"{Achivements.path3}\\Sprites\\achBG.png";
                string mod = "UltraAchievements Protract";
                Core.ShowAchievementI(icon, name, description, sprite, mod);
            }
        }
    }
}
