using BepInEx;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using HarmonyLib;
using System.IO;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;
using System;
using Ultrakill_Achivements.UltraAchivements;
using Console = GameConsole.Console;
using Discord;

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
        readonly private static string path = $"{Application.persistentDataPath}\\achievements.uaf";
        
        private static AchStruct[] achListSorted;
        private static List<string> achList;
        private static int pageInt = 0;
        private static GameObject pageTextGO;
        private static GameObject _achContent;
        private static GameObject achTextGO;

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
        int RoundUpValue(float value, int decimalpoint)
        {
            float value1 = value % 9;
            int result = 0;
            if (value1 < 4.5)
            {
                result = (int)Math.Round(value / 9) + 1;
                return result;
            }
            if (value1 > 4.5)
            {
                result = (int)Math.Round(value / 9);
                return result;
            }
            return result;
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
                if (menu == null)
                {
                    menu = _canvas.transform.Find("Main Menu (1)").gameObject;
                }


                if (Keyboard.current.escapeKey.wasPressedThisFrame)
                {
                    if (menu != null && _achDisplay != null)
                    {
                        if (_achDisplay.activeSelf == true)
                        {
                            _achDisplay.SetActive(!_achDisplay.activeSelf);
                            menu.SetActive(true);
                        }
                    }
                }
                if(_achContent != null && pageTextGO != null && achList != null && achTextGO != null && _achDisplay.activeSelf)
                {
                    if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
                    {
                        VerticalLayoutGroup vlg = _achContent.GetComponent<VerticalLayoutGroup>();


                        if (pageInt <= RoundUpValue(achList.Count, 0) && pageInt != 0)
                        {
                            for (int i = 0; i < _achContent.transform.childCount; i++)
                            {
                                Destroy(_achContent.transform.GetChild(i).gameObject);
                            }
                            pageInt--;
                            pageTextGO.GetComponent<Text>().text = $"{pageInt + 1}/{RoundUpValue(achList.Count, 0)}";


                            List<string> segment = null;
                            Console.print($"{achList.Count} + {pageInt * 9}");
                            if ((pageInt + 1) * 9 < achList.Count)
                            {
                                segment = achList.GetRange(pageInt * 9, 9);

                            }
                            else
                            {
                                int a = achList.Count - pageInt * 9;
                                Console.print($"{pageInt * 9}-" + $"{9 - a}-" + $"{achList.Count}");
                                segment = achList.GetRange(pageInt * 9, a);
                            }


                            if (segment != null)
                            {
                                achListSorted = new AchStruct[segment.Count];
                                int i = 0;
                                foreach (var ach in segment)
                                {
                                    string[] achievement = ach.Split('.');
                                    AchStruct achStruct = new AchStruct(achievement[0], achievement[1], achievement[2]);
                                    achListSorted[i] = achStruct;
                                    i++;
                                }
                            }


                            ColorBlock colors = new ColorBlock()
                            {
                                normalColor = new Color(0, 0, 0, 0.512f),
                                highlightedColor = new Color(1, 1, 1, 0.502f),
                                pressedColor = new Color(1, 0, 0, 1),
                                selectedColor = new Color(0, 0, 0, 0.512f),
                                disabledColor = new Color(0.7843f, 0.7843f, 0.7843f, 0.502f),
                                colorMultiplier = 1f,
                                fadeDuration = 0.1f
                            };

                            GameObject template = new GameObject("template");
                            template.SetActive(false);
                            GameObject templateText = GameObject.Instantiate(achTextGO);
                            templateText.SetActive(false);

                            for (int i = 0; i < segment.Count; i++)
                            {

                                AchStruct ach = achListSorted[i];

                                GameObject x = GameObject.Instantiate(template, _achContent.transform, true);
                                x.AddComponent<RectTransform>();
                                x.name = $"ach{i}";
                                x.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 5);
                                x.transform.localPosition = new Vector3(0, -36, 1);
                                x.transform.localScale = new Vector3(13.3333f, 13.3333f, 0.6667f);



                                GameObject y = GameObject.Instantiate(templateText, x.transform, true);
                                y.transform.localPosition = new Vector3(-9, 1.5f, 0);
                                y.transform.localScale = new Vector3(0.11f, 0.11f, 1);
                                y.name = $"achText{i}";

                                GameObject z = GameObject.Instantiate(templateText, x.transform, true);
                                z.transform.localPosition = new Vector3(-9, -0.4836f, 0);
                                z.transform.localScale = new Vector3(0.11f, 0.11f, 1);
                                z.name = $"achText{i}";


                                x.AddComponent<Image>();
                                Image sprite = x.GetComponent<Image>();
                                sprite.color = colors.normalColor;

                                int count = 0;
                                foreach (char chr in ach.achName)
                                {
                                    count++;
                                }

                                if (count > 29)
                                {
                                    y.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 30);
                                    y.transform.localPosition = new Vector3(-3, 1.5f, 0);

                                    Text text1 = y.GetComponent<Text>();
                                    text1.fontSize = 12;
                                    text1.text = $"{ach.achName}";
                                    text1.alignment = (TextAnchor)TextAlignment.Left;
                                }
                                else
                                {
                                    Text text1 = y.GetComponent<Text>();
                                    text1.fontSize = 14;
                                    text1.text = $"{ach.achName}";
                                    text1.alignment = (TextAnchor)TextAlignment.Left;
                                }

                                Text text2 = z.GetComponent<Text>();
                                text2.text = $"{ach.achDescrip}";
                                text2.alignment = (TextAnchor)TextAlignment.Left;
                                text2.fontSize = 11;

                                x.SetActive(true);
                                y.SetActive(true);
                                z.SetActive(true);




                            }


                        }

                    }
                    if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
                    {
                        VerticalLayoutGroup vlg = _achContent.GetComponent<VerticalLayoutGroup>();


                        if (pageInt + 2 <= RoundUpValue(achList.Count, 0))
                        {
                            for (int i = 0; i < _achContent.transform.childCount; i++)
                            {
                                Destroy(_achContent.transform.GetChild(i).gameObject);
                            }
                            Console.print("Next Page Works");
                            pageInt++;
                            pageTextGO.GetComponent<Text>().text = $"{pageInt + 1}/{RoundUpValue(achList.Count, 0)}";



                            List<string> segment = null;
                            Console.print($"{achList.Count} + {pageInt*9}");
                            if( (pageInt +1) * 9 < achList.Count)
                            {
                                segment = achList.GetRange(pageInt * 9, 9);

                            }
                            else
                            {
                                int a = achList.Count - pageInt*9;
                                Console.print($"{pageInt * 9}-" + $"{9 - a}-" + $"{achList.Count}");
                                segment = achList.GetRange(pageInt * 9, a);
                            }

                            
                                if (segment != null)
                                {
                                    achListSorted = new AchStruct[segment.Count];
                                    int i = 0;
                                    foreach (var ach in segment)    
                                    {
                                        string[] achievement = ach.Split('.');
                                        AchStruct achStruct = new AchStruct(achievement[0], achievement[1], achievement[2]);
                                        achListSorted[i] = achStruct;
                                        i++;
                                    }
                                }
                            

                            ColorBlock colors = new ColorBlock()
                            {
                                normalColor = new Color(0, 0, 0, 0.512f),
                                highlightedColor = new Color(1, 1, 1, 0.502f),
                                pressedColor = new Color(1, 0, 0, 1),
                                selectedColor = new Color(0, 0, 0, 0.512f),
                                disabledColor = new Color(0.7843f, 0.7843f, 0.7843f, 0.502f),
                                colorMultiplier = 1f,
                                fadeDuration = 0.1f
                            };

                            GameObject template = new GameObject("template");
                            template.SetActive(false);
                            GameObject templateText = GameObject.Instantiate(achTextGO);
                            templateText.SetActive(false);

                            for (int i = 0; i < segment.Count; i++)
                            {

                                AchStruct ach = achListSorted[i];

                                GameObject x = GameObject.Instantiate(template, _achContent.transform, true);
                                x.AddComponent<RectTransform>();
                                x.name = $"ach{i}";
                                x.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 5);
                                x.transform.localPosition = new Vector3(0, -36, 1);
                                x.transform.localScale = new Vector3(13.3333f, 13.3333f, 0.6667f);



                                GameObject y = GameObject.Instantiate(templateText, x.transform, true);
                                y.transform.localPosition = new Vector3(-9, 1.5f, 0);
                                y.transform.localScale = new Vector3(0.11f, 0.11f, 1);
                                y.name = $"achText{i}";

                                GameObject z = GameObject.Instantiate(templateText, x.transform, true);
                                z.transform.localPosition = new Vector3(-9, -0.4836f, 0);
                                z.transform.localScale = new Vector3(0.11f, 0.11f, 1);
                                z.name = $"achText{i}";


                                x.AddComponent<Image>();
                                Image sprite = x.GetComponent<Image>();
                                sprite.color = colors.normalColor;

                                int count = 0;
                                foreach (char chr in ach.achName)
                                { 
                                    count++;
                                }

                                if(count > 29)
                                {
                                    y.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 30);
                                    y.transform.localPosition = new Vector3(-3, 1.5f, 0);

                                    Text text1 = y.GetComponent<Text>();
                                    text1.fontSize = 12;
                                    text1.text = $"{ach.achName}";
                                    text1.alignment = (TextAnchor)TextAlignment.Left;
                                }
                                else
                                {
                                    Text text1 = y.GetComponent<Text>();
                                    text1.fontSize = 14;
                                    text1.text = $"{ach.achName}";
                                    text1.alignment = (TextAnchor)TextAlignment.Left;
                                }


                                Text text2 = z.GetComponent<Text>();
                                text2.text = $"{ach.achDescrip}";
                                text2.alignment = (TextAnchor)TextAlignment.Left;
                                text2.fontSize = 11;

                                x.SetActive(true);
                                y.SetActive(true);
                                z.SetActive(true);




                            }


                        }

                    }
                }
            }

        }


        public static void Prefix(OptionsMenuToManager __instance)
        {
            List<string> GetAchievements()
            {

                List<string> achievements = File.ReadAllLines(path).ToList<string>();


                return achievements;
            }
            List<string> l = GetAchievements();
            if (l.Count > 0)
            {

                int currentPage;
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
                    achivementsButton.GetComponentInChildren<Text>(true).text = "Achievements";
                    achivementsButton.name = "ACHIEVEMENTS";
                    achivementsButton.SetActive(true);

                    //initialise achDisplay
                    GameObject achievementsDisplay = GameObject.Instantiate(__instance.optionsMenu.transform.Find("Gameplay Options").gameObject, __instance.transform, true);
                    achievementsDisplay.name = "achDisplay";
                    achievementsDisplay.SetActive(false);
                    GameObject achivementText = achievementsDisplay.transform.Find("Text").gameObject;
                    achTextGO = achivementText;
                    Text achText = achivementText.gameObject.GetComponent<Text>();
                    achText.text = "--ACHIEVEMENTS--";
                    Transform achArea = achievementsDisplay.transform.Find("Scroll Rect (1)");
                    GameObject achContent = achArea.gameObject.transform.Find("Contents").gameObject;
                    _achContent = achContent;

                    //activate achDisplay
                    int ex = achContent.transform.childCount;
                    for (int i = 0; i < ex; i++)
                    {
                        Destroy(achContent.transform.GetChild(i).gameObject);
                    }


                    Button.ButtonClickedEvent modsButton = achivementsButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
                    modsButton.AddListener(delegate
                    {
                        __instance.CheckIfTutorialBeaten();
                        __instance.pauseMenu.SetActive(false);
                        achievementsDisplay.SetActive(true);
                    });

                    //set achDisplay content



                    List<string> achListUnsorted = GetAchievements();
                    achList = achListUnsorted;


                    void nextPage(int page)
                    {
                        currentPage = page;
                        Console.print("test1");
                        pageInt = 0;
                        for (int i = 0; i < ex; i++)
                        {
                            Destroy(achContent.transform.GetChild(i).gameObject);
                        }
                        if (achListUnsorted != null)
                        {
                            Console.print("test2");

                            List<string> segment;
                            if (achListUnsorted.Count >= 9)
                            {
                                segment = achListUnsorted.GetRange(page * 9, 9);
                            }
                            else segment = achListUnsorted;

                            if (segment != null)
                            {
                                Console.print("test3");

                                if (segment != null)
                                {
                                    Console.print("test4");

                                    achListSorted = new AchStruct[segment.Count];
                                    int i = 0;
                                    foreach (var ach in segment)
                                    {
                                        string[] achievement = ach.Split('.');
                                        AchStruct achStruct = new AchStruct(achievement[0], achievement[1], achievement[2]);
                                        achListSorted[i] = achStruct;
                                        i++;
                                    }
                                }
                            }

                            int achLength = segment.Count;

                            GameObject template = new GameObject("template");
                            template.SetActive(false);
                            GameObject templateText = GameObject.Instantiate(achivementText);
                            templateText.SetActive(false);

                            Console.print("test5");


                            ColorBlock colors = new ColorBlock()
                            {
                                normalColor = new Color(0, 0, 0, 0.512f),
                                highlightedColor = new Color(1, 1, 1, 0.502f),
                                pressedColor = new Color(1, 0, 0, 1),
                                selectedColor = new Color(0, 0, 0, 0.512f),
                                disabledColor = new Color(0.7843f, 0.7843f, 0.7843f, 0.502f),
                                colorMultiplier = 1f,
                                fadeDuration = 0.1f
                            };

                            VerticalLayoutGroup vlg = achContent.GetComponent<VerticalLayoutGroup>();
                            vlg.childAlignment = TextAnchor.UpperCenter;
                            vlg.childScaleHeight = true;


                            for (int i = 0; i < achLength; i++)
                            {
                                AchStruct ach = achListSorted[i];

                                GameObject x = GameObject.Instantiate(template, achContent.transform, true);
                                x.AddComponent<RectTransform>();
                                x.name = $"ach{i}";
                                x.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 5);
                                x.transform.localPosition = new Vector3(0, -36, 1);
                                x.transform.localScale = new Vector3(13.3333f, 13.3333f, 0.6667f);



                                GameObject y = GameObject.Instantiate(templateText, x.transform, true);
                                y.transform.localPosition = new Vector3(-9, 1.5f, 0);
                                y.transform.localScale = new Vector3(0.11f, 0.11f, 1);
                                y.name = $"achText{i}";

                                GameObject z = GameObject.Instantiate(templateText, x.transform, true);
                                z.transform.localPosition = new Vector3(-9, -0.4836f, 0);
                                z.transform.localScale = new Vector3(0.11f, 0.11f, 1);
                                z.name = $"achText{i}";


                                x.AddComponent<Image>();
                                Image sprite = x.GetComponent<Image>();
                                sprite.color = colors.normalColor;
                                int count = 0;
                                foreach (char chr in ach.achName)
                                {
                                    count++;
                                }

                                if (count > 29)
                                {
                                    y.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 30);
                                    y.transform.localPosition = new Vector3(-3, 1.5f, 0);

                                    Text text1 = y.GetComponent<Text>();
                                    text1.fontSize = 12;
                                    text1.text = $"{ach.achName}";
                                    text1.alignment = (TextAnchor)TextAlignment.Left;
                                }
                                else
                                {
                                    Text text1 = y.GetComponent<Text>();
                                    text1.fontSize = 14;
                                    text1.text = $"{ach.achName}";
                                    text1.alignment = (TextAnchor)TextAlignment.Left;
                                }

                                Text text2 = z.GetComponent<Text>();
                                text2.text = $"{ach.achDescrip}";
                                text2.alignment = (TextAnchor)TextAlignment.Left;
                                text2.fontSize = 11;

                                x.SetActive(true);
                                y.SetActive(true);
                                z.SetActive(true);




                            }

                            int RoundUpValue(float value, int decimalpoint)
                            {
                                float value1 = value % 9;
                                int result = 0;
                                if (value1 < 4.5)
                                {
                                    result = (int)Math.Round(value / 9) + 1;
                                    return result;
                                }
                                if (value1 > 4.5)
                                {
                                    result = (int)Math.Round(value / 9);
                                    return result;
                                }
                                return result;
                            }


                            GameObject pageContainer = GameObject.Instantiate(template, achievementsDisplay.transform);
                            pageContainer.AddComponent<VerticalLayoutGroup>();
                            pageContainer.AddComponent<Image>();
                            pageContainer.GetComponent<Image>().color = colors.normalColor;
                            pageContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 40);
                            pageContainer.transform.localPosition = new Vector3(0, 235, 0);
                            VerticalLayoutGroup vlg2 = pageContainer.GetComponent<VerticalLayoutGroup>();
                            vlg2.childAlignment = TextAnchor.MiddleCenter;
                            pageContainer.name = "pageInfo";
                            pageContainer.SetActive(true);

                            GameObject pageGo = GameObject.Instantiate(achText.gameObject, pageContainer.transform);
                            RectTransform pageSize = pageGo.GetComponent<RectTransform>();
                            Text pageText = pageGo.GetComponent<Text>();
                            pageText.text = $"{currentPage + 1}/{RoundUpValue(achListUnsorted.Count, 0)}";
                            pageText.fontSize = 12;
                            pageText.name = "Page Num";
                            pageGo.SetActive(true);
                            pageTextGO = pageGo;

                            GameObject pageInfo = GameObject.Instantiate(achText.gameObject, pageContainer.transform);
                            RectTransform pageInfSize = pageInfo.GetComponent<RectTransform>();
                            Text pageInfText = pageInfo.GetComponent<Text>();
                            pageInfText.fontSize = 12;
                            pageInfText.text = "Use your arrow keys to navigate between pages";
                            pageInfText.name = "pageControls";
                            pageInfo.SetActive(true);




                        }
                    }

                    nextPage(0);
                }

            }

        }
    }
}