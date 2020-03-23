﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeLangage : MonoBehaviour
{

    public enum language { French, German, English, Spanish };
    public static int setLanguage=0;

    public enum word { Level, Score, Repeat, Exit }
    public word setWord;

    //Here is the liste of words from 0 to 3 
    public static string[,] names = new string[4, 4] {

         { "Niveau","Score","Répéter","Retour"}, //French  
         { "Ebene","Punktzahl","Wiederholen","Zurück"}, //German
         { "Level", "Score", "Repeat", "Back" }, //English 
         { "Nivel","Puntuación ","Repita","Volver"} //Spanish
         
    };

    // Start is called before the first frame update
  /*  void Start()
    {
        
    }*/

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
                

                switch (hit.transform.name)
                {
                    case "fr":
                        setLanguage = 0;
                        break;
                    case "de":
                        setLanguage = 1;
                        break;
                    case "uk":
                        setLanguage = 2;
                        break;
                    case "es":
                        setLanguage = 3;
                        break;
                        
                }

                Debug.Log("Language is " + hit.transform.name); // ensure you picked right object
                Debug.Log("word is " + names[(int)setLanguage, 0]); // ensure you picked right object
                //setLanguage = hit.transform.name;
                GoToNextScene();
            }
        }

        //this.GetComponent<Text>().text = names[(int)setLanguage, (int)setWord];
    }

    void GoToNextScene()
    {
        SceneManager.LoadScene("Character");
    }
}
