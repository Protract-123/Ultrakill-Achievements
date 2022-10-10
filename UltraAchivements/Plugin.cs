using BepInEx;
using UnityEngine;
using UnityEngine.UI;
using HarmonyLib;

namespace Ultrakill_Achivements
{
    [BepInPlugin("protract.uk.achivements", "UK ACHIVEMENTS", "0.1.2")]
    [BepInProcess("ULTRAKILL.exe")]
    [BepInDependency("zed.uk.uihelper")]

    [HarmonyPatch(typeof(OptionsMenuToManager), "Start")]
    public class Achivements : BaseUnityPlugin
    {
        public void Start()
        {
            var harmony = new Harmony("Protract.UK.Achivements");
            harmony.PatchAll();
        }
        public static void Prefix(OptionsMenuToManager __instance)
        {
            void transform(Transform tf)
            {
                bool wasActive = tf.gameObject.activeSelf;
                tf.gameObject.SetActive(false);
                //tf.localScale = new Vector3(.5f, 1f, 1f);
                tf.GetComponent<RectTransform>().sizeDelta = new Vector2(480, 80);
                //tf.Find("Text").localScale = new Vector3(2f, 1f, 1f);

                Traverse hudEffect = Traverse.Create(tf.gameObject.GetComponent<HudOpenEffect>());
                hudEffect.Field("originalWidth").SetValue(1f);
                hudEffect.Field("originalHeight").SetValue(1f);
                tf.gameObject.SetActive(wasActive);
            }
            if (__instance.pauseMenu.name == "Main Menu (1)")
            {
                print("hello world please work");
                __instance.pauseMenu.transform.Find("Panel").localPosition = new Vector3(0, -330, 0);
                GameObject achivementsButton = GameObject.Instantiate(__instance.pauseMenu.transform.Find("Continue").gameObject, __instance.pauseMenu.transform, true);
                achivementsButton.SetActive(false);
                achivementsButton.transform.localPosition = new Vector3(0, -260, 0);
                transform(achivementsButton.transform);
                achivementsButton.GetComponentInChildren<Text>(true).text = "Achivements";
                achivementsButton.name = "ACHIVEMENTS";
                achivementsButton.SetActive(true);

                GameObject achievementsDisplay = GameObject.Instantiate(__instance.optionsMenu.transform.Find("Gameplay Options").gameObject, __instance.transform, true);
                achievementsDisplay.SetActive(false);
                GameObject achivementText = achievementsDisplay.transform.Find("Text").gameObject;
                Text achText = achivementText.gameObject.GetComponent<Text>();
                achText.text = "--ACHIEVEMENTS--";
                Transform achArea = achievementsDisplay.transform.Find("Scroll Rect (1)");
                GameObject achContent = achArea.gameObject.transform.Find("Contents").gameObject;
                int ex = achContent.transform.childCount;
                for (int i = 0; i < ex; i++)
                {   
                    achArea.transform.GetChild(i).gameObject.SetActive(false);
                }
            
                void activateAchivements()
                {
                    achievementsDisplay.SetActive(true);
                }

                achivementsButton.GetComponent<Button>().onClick.RemoveAllListeners(); 
                achivementsButton.GetComponent <Button>().onClick.AddListener(activateAchivements);
            }

        }

    }
}
