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
    public GameObject WrongSmile;
    public Text scores;
    public Text back;
    public Text niveau;
    public GameObject background;
    public int vec3a;
    public int vec3b;
    int juste = 0;
    int rotate = 0;
    public static string color = "pink";
    public static double wrongClicks = 0;
    public static Boolean eyes;
    public static Boolean arm;
    public static AudioSource sonBon1;
    public static AudioSource sonPasBon1;
    public static GameObject smile1;
    public static GameObject smileRight1;
    Boolean updateDone = false;

    void Start()
    {
        wrongClicks = 0;
        sonBon1 = sonBon;
        sonPasBon1 = sonPasBon;
        smile1 = WrongSmile; //smile wrong for level4
        smileRight1 = smile;
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
        //back field
        back.text = changeLangage.names[changeLangage.setLanguage, 3];
        //niveau field
        niveau.text = changeLangage.names[changeLangage.setLanguage, 0] + " " + superChef.actualNiveau;
        //background
        background.GetComponent<Image>().color = superChef.background[color];
        //actual score
        calculateScore();
        //if it is right
        eyes = false;
        arm = false;
        //Just for Niveau 4
        if (superChef.actualNiveau == 4)
        {
            //set active depends on gender
            smile.transform.GetChild(0).gameObject.SetActive(false);
            smile.transform.GetChild(1).gameObject.SetActive(false);
            smile.transform.Find(superChef.gender).gameObject.SetActive(true);
            //set active depends on gender
            smileRight.transform.GetChild(0).gameObject.SetActive(false);
            smileRight.transform.GetChild(1).gameObject.SetActive(false);
            smileRight.transform.Find(superChef.gender).gameObject.SetActive(true);
            //set active depends on gender
            WrongSmile.transform.GetChild(0).gameObject.SetActive(false);
            WrongSmile.transform.GetChild(1).gameObject.SetActive(false);
            WrongSmile.transform.Find(superChef.gender).gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if ((eyes && arm && !updateDone) || (superChef.actualNiveau == 4 && eyes && !updateDone))
        {
            //just go ones through this
            updateDone = true;

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

            Debug.Log("wrongClicks" + wrongClicks);
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
            if(superChef.actualNiveau == 3)
            {
                //delete the eyes
                correctEyes.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0f);
            } else
            {
                //actual niveau = 4

            }
        }    
        if (rotate == 1)
        {
            target.transform.Rotate(0, 3, 0);
        }

    }

    public void calculateScore()
    {
        //PrintArray();
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

        for (int i = 1; i < 5; i++)
        {
            //create String to safe in db
            String temp = "";
            int tempNumber = 0;
            foreach (int j in superChef.pointsPerLevel[i])
            {
                if (tempNumber == 0)
                {
                    tempNumber = 1;
                    temp = temp + j;
                }
                else
                {
                    temp = temp + "-" + j;
                }
            }
            superChef.score[i - 1] = temp;
        }

        superChef.levelDB = "" + superChef.level;
        superChef.niveau = "" + superChef.actualNiveau;
        PrintArray();
        try
        {
            StartCoroutine(Main.Instance.Web.UpdateChild(superChef.PK_Child, superChef.childname, superChef.childsurname, superChef.score[0], superChef.score[1], superChef.score[2], superChef.score[3], superChef.score[4], superChef.niveau, superChef.levelDB, superChef.fk_Character));
        } catch (Exception e)
        {
            //offline game, can not be safed
        }
        Debug.Log("Update");
        superChef.dataloaded = true;
        //load new scene -> niveau 4 has just one level -> directly to the reward Finish
        if (superChef.actualNiveau == 4)
        {
            SceneManager.LoadScene("RewardFinish");
        }
        else
        {
            //Level 3 -> to the next Reward
            SceneManager.LoadScene("Reward" + superChef.level);
        }
    }

    public void PrintArray()
    {
        for (int i = 1; i < 5; i++)
        {
            Debug.Log("niveau" + i);
            for (int j = 0; j < 5; j++)
            {

                Debug.Log("level" + j);
                Debug.Log(superChef.pointsPerLevel[i][j]);
            }
        }
    }

}
