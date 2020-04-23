using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class superChef : MonoBehaviour
{
    //Child info
    public static string PK_Child;
    public static string childname;
    public static string childsurname;
    public static string[] score = new string[5];
    public static string levelDB;
    public static string niveau;
    public static string fk_Character;
    public static Boolean dataloaded = false;

    //old
    public static int level = 0;
    public static int actualNiveau = 1;
    public static string character = "Astronaut";


    public static Dictionary<string, Color32> background = new Dictionary<string, Color32>();
    public static Dictionary<string, Color32> backgroundCamera = new Dictionary<string, Color32>();
    public static String gender = "boy";
    public static Dictionary<int, int[]> pointsPerLevel = new Dictionary<int, int[]>();

    /*public GameObject astronaut;
    public GameObject explorer;
    public GameObject fairy;
    public GameObject train;
    public GameObject language;
    public GameObject levels;*/

    public String nextLevel = "1";
    public GameObject levels;

    RaycastHit hit;

    public static Boolean offline = false;


    // Start is called before the first frame update
    void Start()
    {
        try
        {
            StartCoroutine(Main.Instance.Web.GetSelectedChild(PK_Child));
        }
        catch (Exception e)
        {
            // when all is offline, this will not work
        }
        /*
        //smile depends on language
        for (int j = 0; j < 6; j++)
        {
            language.transform.GetChild(j).gameObject.SetActive(false);
        }
        language.transform.Find(changeLangage.setLanguage.ToString()).gameObject.SetActive(true);
        //levels
        levels.transform.Find("level2").gameObject.SetActive(true);
        levels.transform.Find("level2g").gameObject.SetActive(false);
        levels.transform.Find("level3").gameObject.SetActive(true);
        levels.transform.Find("level3g").gameObject.SetActive(false);
        */
        try
        {
            //add backgroundcolors
            background.Add("blue", new Color32(190, 234, 250, 255));
            background.Add("pink", new Color32(190, 234, 250, 255));
            background.Add("yellow", new Color32(243, 237, 158, 255));
            background.Add("red", new Color32(251, 210, 202, 255));
            //add backgroundcolors for the camera settings
            backgroundCamera.Add("blue", new Color32(159, 196, 210, 255));
            backgroundCamera.Add("pink", new Color32(159, 196, 210, 255));
            backgroundCamera.Add("yellow", new Color32(204, 199, 133, 255));
            backgroundCamera.Add("red", new Color32(211, 176, 169, 255));
        } 
        catch (Exception e)
        {
            //the colors are allready added
        }
        
        //Niveau 2 and 4 Gender -> default girl
        System.Random r = new System.Random();
        int random = r.Next(0, 2);
        Debug.Log("random: " + random);
        if (random == 1)
        {
            gender = "boy";
        }
        else
        {
            gender = "girl";
        }
    }

}
