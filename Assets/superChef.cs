﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class superChef : MonoBehaviour
{
    public static string character="nothing";

    public GameObject astronaut;
    public GameObject explorer;
    public GameObject fairy;
    public GameObject train;

    // Start is called before the first frame update
    void Start()
    {
        
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
        SceneManager.LoadScene("Level1");
    }
}
