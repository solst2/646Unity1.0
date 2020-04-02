using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class Level3 : MonoBehaviour
{

    public AudioSource sonBon;
    public AudioSource sonPasBon;
    public GameObject smile;
    public GameObject smileRight;
    public GameObject barEmpty;
    public GameObject barFirst;
    public GameObject target; 
    public GameObject correctEyes;
    public Text scores;
    public Text back;
    public Text niveau;
    public GameObject background;
    public int vec3a;
    public int vec3b;
    int juste = 0;
    int rotate = 0;
    public static string color = "pink";
    int wrongClicks = 0;
    public static Boolean eyes;
    public static Boolean arm;
    public static AudioSource sonBon1;
    public static AudioSource sonPasBon1;

    void Start()
    {
        sonBon1 = sonBon;
        sonPasBon1 = sonPasBon;
        //number of new level
        superChef.level++;

        //gameobjects activated
        smile.SetActive(true);
        smileRight.SetActive(false);
        barEmpty.SetActive(true);
        barFirst.SetActive(false);
        //get character color
        switch (superChef.character)
        {
            case "Astronaut":
                color = "blue";
                break;
            case "explorateur":
                color = "yellow";
                break;
            case "HuaYao_01":
                color = "pink";
                break;
            case "trainChief":
                color = "red";
                break;
            default:
                color = "blue";
                break;
        }
        //bars all deactivate, depends on caracter activate one
        for (int j = 0; j < 4; j++)
        {
            barEmpty.transform.GetChild(j).gameObject.SetActive(false);
        }
        barEmpty.transform.Find(color).gameObject.SetActive(true);
        //audio
        AudioSource[] audios = GetComponents<AudioSource>();
        sonBon = audios[0];
        sonPasBon = audios[1];
        //score field
        scores.text = changeLangage.names[changeLangage.setLanguage, 1] + " " + superChef.score;
        //back field
        back.text = changeLangage.names[changeLangage.setLanguage, 3];
        //niveau field
        niveau.text = changeLangage.names[changeLangage.setLanguage, 0] + " " + superChef.actualNiveau;
        //background
        //background.GetComponent<Image>().color = superChef.background[color];
        //actual score
        //calculateScore();
        //if it is right
        eyes = false;
        arm = false;
    }

    void Update()
    {
        if (eyes && arm)
        {


            sonBon.Play();
            smile.SetActive(false);
            smileRight.SetActive(true);
            barEmpty.SetActive(false);

            //set bar with 1 active in the right color
            barFirst.SetActive(true);
            for (int j = 0; j < 4; j++)
            {
                barFirst.transform.GetChild(j).gameObject.SetActive(false);
            }
            barFirst.transform.Find(color).gameObject.SetActive(true);

            rotate = 1;

            //make the right image bigger
            transform.localScale += new Vector3(vec3a, vec3b, 0);

            //Applique un délai pour changer de scène
            StartCoroutine(GoToNextSceneN());

            // Edit score
            if (wrongClicks == 0)
            {
                //set the level as done
                superChef.infosNiveau[superChef.actualNiveau][superChef.level - 1] = false;
                //safe the new value in existing points
                superChef.pointsPerLevel[superChef.actualNiveau][superChef.level - 1] = 10;
            }
            else if (wrongClicks <= 5)
            {
                //safe the new value in existing points
                superChef.pointsPerLevel[superChef.actualNiveau][superChef.level - 1] = 5;
            }
            else
            {
                //safe the new value in existing points
                superChef.pointsPerLevel[superChef.actualNiveau][superChef.level - 1] = 2;
            }

            calculateScore();
            //delete the eyes
            correctEyes.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0f);
        }    
        if (rotate == 1)
        {
            target.transform.Rotate(0, 3, 0);
        }

    }

    public void calculateScore()
    {
        int tempScore = 0;
        foreach (int i in superChef.pointsPerLevel[superChef.actualNiveau])
        {
            tempScore += i;
        }
        //set score
        scores.text = changeLangage.names[changeLangage.setLanguage, 1] + " " + tempScore;
    }


    IEnumerator GoToNextSceneN()
    {
        //Wait for seconds
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("Reward" + superChef.level);
    }

}
