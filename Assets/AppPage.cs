using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppPage : MonoBehaviour
{

    public GameObject eyes;
    RaycastHit hit;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
   void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log(" You hit the " + hit.transform.name);

                if (hit.transform.name =="App")
                {
                    GoToNextScene();
                }

            }
        }
    }


    void GoToNextScene()
    {
        SceneManager.LoadScene("WelcomePage");
    }
}