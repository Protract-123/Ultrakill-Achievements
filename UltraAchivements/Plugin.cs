using BepInEx;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using HarmonyLib;
using GameConsole;
using System.IO;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;
using UltraAchievement;

namespace Ultrakill_Achivements
{
    [BepInPlugin("protract.uk.achivements", "UK ACHIVEMENTS", "0.1.2")]
    [BepInProcess("ULTRAKILL.exe")]

    [HarmonyPatch(typeof(OptionsMenuToManager), "Start")]
    public class Achivements : BaseUnityPlugin
    {
        private GameObject _achDisplay;
        private GameObject _canvas;
        private GameObject menu;
        private static string path = $"{Application.persistentDataPath}\\achievements.uaf";






        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (!scene.name.StartsWith("Main Menu"))
                return;

            GameObject[] rootObjects = scene.GetRootGameObjects();
            foreach (var item in rootObjects)
            {
                if (item.name == "Canvas")
                {
                    _canvas = item;
                }
            }
            
        }
        public void Start()
        {
            var harmony = new Harmony("Protract.UK.Achivements");
            harmony.PatchAll();
            SceneManager.sceneLoaded += OnSceneLoaded;

        }

        public void Update()
        {

            Scene scene = SceneManager.GetActiveScene();
            if (scene.name.Contains("Menu"))
            {
                if (_achDisplay == null)
                {
                    _achDisplay = _canvas.transform.Find("achDisplay").gameObject;
                }
                if(menu == null)
                {
                    menu = _canvas.transform.Find("Main Menu (1)").gameObject;
                }

                
                if (Keyboard.current.escapeKey.wasPressedThisFrame)
                {
                    if (_achDisplay.activeSelf == true)
                    {
                        _achDisplay.SetActive(!_achDisplay.activeSelf);
                        menu.SetActive(true);
                    }
                }
            }

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
                //initalise achButton
                __instance.pauseMenu.transform.Find("Panel").localPosition = new Vector3(0, -330, 0);
                GameObject achivementsButton = GameObject.Instantiate(__instance.pauseMenu.transform.Find("Continue").gameObject, __instance.pauseMenu.transform, true);
                achivementsButton.SetActive(false);
                achivementsButton.transform.localPosition = new Vector3(0, -260, 0);
                transform(achivementsButton.transform);
                achivementsButton.GetComponentInChildren<Text>(true).text = "Achivements";
                achivementsButton.name = "ACHIVEMENTS";
                achivementsButton.SetActive(true);

                //initialise achDisplay
                GameObject achievementsDisplay = GameObject.Instantiate(__instance.optionsMenu.transform.Find("Gameplay Options").gameObject, __instance.transform, true);
                achievementsDisplay.name = "achDisplay";
                achievementsDisplay.SetActive(false);
                GameObject achivementText = achievementsDisplay.transform.Find("Text").gameObject;
                Text achText = achivementText.gameObject.GetComponent<Text>();
                achText.text = "--ACHIEVEMENTS--";
                Transform achArea = achievementsDisplay.transform.Find("Scroll Rect (1)");
                GameObject achContent = achArea.gameObject.transform.Find("Contents").gameObject;
                
                //activate achDisplay
                int ex = achContent.transform.childCount;
                for (int i = 0; i < ex; i++)
                {   
                    achContent.transform.GetChild(i).gameObject.SetActive(false);
                }
            

                Button.ButtonClickedEvent modsButton = achivementsButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
                modsButton.AddListener(delegate
                {
                    __instance.CheckIfTutorialBeaten();
                    __instance.pauseMenu.SetActive(false);
                    achievementsDisplay.SetActive(true);
                });

                //set achDisplay content
                string[][] GetAchievements()
                {

                    List<string> achievements = File.ReadAllLines(path).ToList<string>();
                    int i = 0;
                    string[][] achivement = new string[achievements.Count()][];
                    foreach (var ach in achievements)
                    {
                        achivement[i] = ach.Split('.');
                        i++;
                    }
                    return achivement;
                }
                
                string[][] achList = GetAchievements();
                int achLength = achList.GetLength(0);

                GameObject template = new GameObject("template");
                template.SetActive(false);
                GameObject templateText = GameObject.Instantiate(achivementText);
                templateText.SetActive(false);

                achContent.GetComponent<VerticalLayoutGroup>().childAlignment = TextAnchor.UpperCenter;


                for (int i = 0; i < achLength; i++)
                {
                    GameObject x = GameObject.Instantiate(template, achContent.transform, true);
                    x.AddComponent<RectTransform>();
                    x.name = $"ach{i}";
                    x.GetComponent<RectTransform>().sizeDelta = new Vector2(100,5); 
                    x.transform.localPosition = new Vector3(0,-36,1);
                    VerticalLayoutGroup vlg = achContent.GetComponent<VerticalLayoutGroup>();
                    vlg.childAlignment = TextAnchor.UpperCenter;
                    vlg.childScaleHeight = true;


                    GameObject y = GameObject.Instantiate(templateText, x.transform, true);
                    y.transform.localPosition = new Vector3(0,0.5f,0);
                    y.transform.localScale = new Vector3(0.11f, 0.11f,1);
                    y.name = $"achText{i}";

                    x.AddComponent<Image>();
                    Image sprite = x.GetComponent<Image>();
                    sprite.color = new Color(0.2745f, 0.2745f, 0.3529f, 0.4f);
                    
                    Text text1 = y.GetComponent<Text>();
                    text1.text = $"{achList[i][0]}";
                    text1.alignment = (TextAnchor)TextAlignment.Center;
                    text1.fontSize = 12;

                    x.SetActive(true);
                    y.SetActive(true);



                }

            }

        }

    }
}
