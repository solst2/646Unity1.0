using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class superChef : MonoBehaviour
{
    public static string character="nothing";
    public static int level = 0;
    public static int score = 0;
    public static Dictionary<string, Color32> background = new Dictionary<string, Color32>();

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
        background.Add("red", new Color32(229, 111, 120, 255));
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
        if(ScriptTuto1.tutoplayed==0)
        {

            SceneManager.LoadScene("Tutorial1");
        }
        else
        {
            SceneManager.LoadScene("Level1_1");
        }
    }
}
