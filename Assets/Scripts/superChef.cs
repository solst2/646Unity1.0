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
    public static String gender = "girl";
    public static Dictionary<int, Boolean[]> infosNiveau = new Dictionary<int, Boolean[]>();
    public static Dictionary<int, int[]> pointsPerLevel = new Dictionary<int, int[]>();

    public GameObject astronaut;
    public GameObject explorer;
    public GameObject fairy;
    public GameObject train;
    


    // Start is called before the first frame update
    void Start()
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
        //default values to the infosNiveau
        Boolean[] trueValues = {true,true,true,true,true };
        for(int i = 1; i < 5; i++)
        {
            infosNiveau.Add(i, trueValues);
        }
        //default Values level
        int[] zero = { 0, 0, 0, 0, 0 };
        for (int i = 1; i < 5; i++)
        {
            pointsPerLevel.Add(i, zero);
        }
        //Niveau 2 Gender -> default girl
        System.Random r = new System.Random();
        int random = r.Next(0, 1);
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
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //chartere controller
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
               // StartCoroutine(ScaleMe(hit.transform));
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object

                character = hit.transform.name;
                GoToNextScene();
            }
        }

 
    }

    void GoToNextScene()
    {
        actualNiveau = 2;
        SceneManager.LoadScene("Level2_1");
        /*
        if (ScriptTuto1.tutoplayed==0)
        {

            SceneManager.LoadScene("Tutorial1");
        }
        else
        {
            SceneManager.LoadScene("Level1_1");
        }*/
    }
}
