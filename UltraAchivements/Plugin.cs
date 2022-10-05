using BepInEx;
using UnityEngine;
using UnityEngine.UI;
using HarmonyLib;

namespace Ultrakill_Achivements
{
    [BepInPlugin("protract.uk.achivements", "UK ACHIVEMENTS", "0.1.0")]
    [BepInProcess("ULTRAKILL.exe")]
    [BepInDependency("zed.uk.uihelper")]

    [HarmonyPatch(typeof(OptionsMenuToManager), "Start")]
    public class Achivements : BaseUnityPlugin
    {

        public static void Prefix(OptionsMenuToManager __instance)
        {
            void Halve(Transform tf, bool left)
            {
                bool wasActive = tf.gameObject.activeSelf;
                tf.gameObject.SetActive(false);
                //tf.localScale = new Vector3(.5f, 1f, 1f);
                tf.GetComponent<RectTransform>().sizeDelta = new Vector2(240, 80);
                //tf.Find("Text").localScale = new Vector3(2f, 1f, 1f);
                if (left)
                    tf.localPosition -= new Vector3(120f, 0, 0);
                else
                    tf.localPosition += new Vector3(120f, 0, 0);
                Traverse hudEffect = Traverse.Create(tf.gameObject.GetComponent<HudOpenEffect>());
                hudEffect.Field("originalWidth").SetValue(1f);
                hudEffect.Field("originalHeight").SetValue(1f);
                tf.gameObject.SetActive(wasActive);
            }
            if (__instance.pauseMenu.name == "Main Menu (1)")
            {
                print("hello world please work");
                __instance.pauseMenu.transform.Find("Panel").localPosition = new Vector3(0, -320, 0);
                GameObject achivementsButton = GameObject.Instantiate(__instance.pauseMenu.transform.Find("Continue").gameObject, __instance.pauseMenu.transform, true);
                achivementsButton.SetActive(false);
                achivementsButton.transform.localPosition = new Vector3(0, 300, 0);
                Halve(achivementsButton.transform, false);
                achivementsButton.GetComponentInChildren<Text>(true).text = "Achivements";
                achivementsButton.name = "Achivements";
            }

        }


    }
}
