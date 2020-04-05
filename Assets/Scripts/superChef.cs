using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class superChef : MonoBehaviour
{
    public static string character="Astronaut";
    public static int level = 0;
    public static int score = 0;
    public static Dictionary<string, Color32> background = new Dictionary<string, Color32>();
    public static Dictionary<string, Color32> backgroundCamera = new Dictionary<string, Color32>();
    public static int actualNiveau = 1;
    public static String gender = "boy";
    public static Dictionary<int, Boolean[]> infosNiveau = new Dictionary<int, Boolean[]>();
    public static Dictionary<int, int[]> pointsPerLevel = new Dictionary<int, int[]>();

    public GameObject astronaut;
    public GameObject explorer;
    public GameObject fairy;
    public GameObject train;
    public GameObject language;

    public String nextLevel = "1";
    public GameObject levels;

    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        //smile depends on language
        for (int j = 0; j < 4; j++)
        {
            language.transform.GetChild(j).gameObject.SetActive(false);
        }
        language.transform.Find(changeLangage.setLanguage.ToString()).gameObject.SetActive(true);
        //levels
        levels.transform.Find("level2").gameObject.SetActive(true);
        levels.transform.Find("level2g").gameObject.SetActive(false);
        levels.transform.Find("level3").gameObject.SetActive(true);
        levels.transform.Find("level3g").gameObject.SetActive(false);

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
        //default values to the infosNiveau
        for(int i = 1; i < 5; i++)
        {
            infosNiveau.Add(i, new Boolean[] { true, true, true, true, true });
        }
        //default Values level
        for (int i = 1; i < 5; i++)
        {
            pointsPerLevel.Add(i, new int[] { 0, 0, 0, 0, 0 });
        }
        //Niveau 2 Gender -> default girl
        System.Random r = new System.Random();
        int random = r.Next(0, 2);
        Debug.Log("random: " + random);
        if(random == 1)
        {
            gender = "boy";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("click");
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //chartere controller
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
               // StartCoroutine(ScaleMe(hit.transform));
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                if (hit.transform.name.Trim().Equals("level2"))
                {
                    nextLevel = "2";
                    levels.transform.Find("level2g").gameObject.SetActive(true);
                    levels.transform.Find("level2").gameObject.SetActive(false);
                    return;
                }
                if (hit.transform.name.Trim().Equals("level2g"))
                {
                    nextLevel = "1";
                    levels.transform.Find("level2g").gameObject.SetActive(false);
                    levels.transform.Find("level2").gameObject.SetActive(true);
                    return;
                }
                if (hit.transform.name.Trim().Equals("level3"))
                {
                    nextLevel = "3";
                    levels.transform.Find("level3g").gameObject.SetActive(true);
                    levels.transform.Find("level3").gameObject.SetActive(false);
                    return;
                }
                if (hit.transform.name.Trim().Equals("level3g"))
                {
                    nextLevel = "1";
                    levels.transform.Find("level3g").gameObject.SetActive(false);
                    levels.transform.Find("level3").gameObject.SetActive(true);
                    return;
                }
                character = hit.transform.name;
                GoToNextScene();
            }
        }

 
    }

    void GoToNextScene()
    {/*
        actualNiveau = 2;
        SceneManager.LoadScene("Level2_1");
        */
        if (hit.transform.name.Trim().Equals("0") || hit.transform.name.Trim().Equals("1") ||
            hit.transform.name.Trim().Equals("2") || hit.transform.name.Trim().Equals("3"))
        {
            SceneManager.LoadScene("Language");
        }
        else if (nextLevel.Equals("3"))
        {
            actualNiveau = 3;
            /*if (Tuto3.tutoplayed == 0)
            {
                SceneManager.LoadScene("Tutorial3");
                return;
            }*/
            SceneManager.LoadScene("Level3_1");
        }
        else if (nextLevel.Equals("2"))
        {
            actualNiveau = 2;
            if (Tuto2.tutoplayed == 0)
            {
                SceneManager.LoadScene("Tutorial2");
                return;
            }
            SceneManager.LoadScene("Level2_1");
        }
        else if (ScriptTuto1.tutoplayed == 0)
        {
            SceneManager.LoadScene("Tutorial1");
        }
        else
        {
            SceneManager.LoadScene("Level1_1");
        }
    }
}
