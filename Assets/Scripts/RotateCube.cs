﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class RotateCube : MonoBehaviour
{
    //Niveau 1 and 2
    public AudioSource sonBon;
    public AudioSource sonPasBon;
    public GameObject smile;
    public GameObject smileRight;
    public GameObject barEmpty;
    public GameObject barFirst;
    public GameObject jeans;
    public GameObject secondObject;
    public GameObject smileWrong;
    public Text scores;
    public GameObject background;
    Dictionary<int, Vector3> targetZoom = new Dictionary<int, Vector3>();
    int juste = 0;
    int rotate = 0;
    public static string color = "pink";
    int wrongClicks = 0;
    //Niveau 2
    public GameObject figure;

    void Start()
    {
        //Zoom of target level 1
        targetZoom.Add(1, new Vector3(3, 3, 0));
        //Zoom of target level 2
        targetZoom.Add(2, new Vector3(8, 8, 0));
        //Zoom of target level 3
        targetZoom.Add(3, new Vector3(0, 0, 0));
        //Zoom of target level 4
        targetZoom.Add(4, new Vector3(5, 5, 0));
        //Zoom of target level 5
        targetZoom.Add(5, new Vector3(4, 4, 0));

        //number of new level
        superChef.level++;

        //gameobjects activated
        smile.SetActive(true);
        smileRight.SetActive(false);
        barEmpty.SetActive(true);
        barFirst.SetActive(false); 
        smileWrong.SetActive(false);
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
        scores.text = "Score: " + superChef.score;
        //background
        background.GetComponent<Image>().color = superChef.background[color];
        //actual score
        calculateScore();

        //Just for Niveau 2
        if(superChef.actualNiveau == 2)
        {
            //set active depends on gender
            figure.transform.GetChild(0).gameObject.SetActive(false);
            figure.transform.GetChild(1).gameObject.SetActive(false);
            figure.transform.Find(superChef.gender).gameObject.SetActive(true);
            figure.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && rotate == 0)
        {

            //Destroy(gameObject);

            if (juste == 0)
            {
                StartCoroutine(waiterWrong());
            }
            else
            {
                sonBon.Play();
                //just for Niveau 1 -> smile disapear / for Niveau 2 -> the arm should stay
                if (superChef.actualNiveau == 1)
                {
                    smile.SetActive(false);
                }
                smileRight.SetActive(true);
                barEmpty.SetActive(false);
                jeans.SetActive(false);
                //if there is a second object to set false
                if (secondObject)
                {
                    secondObject.SetActive(false);
                }

                //set bar with 1 active in the right color
                barFirst.SetActive(true);
                for (int j = 0; j < 4; j++)
                {
                    barFirst.transform.GetChild(j).gameObject.SetActive(false);
                }
                barFirst.transform.Find(color).gameObject.SetActive(true);

                //Just for Niveau 2
                if(superChef.actualNiveau == 2)
                {
                    figure.SetActive(false);
                    //set active depends on gender
                    smileRight.transform.GetChild(0).gameObject.SetActive(false);
                    smileRight.transform.GetChild(1).gameObject.SetActive(false);
                    smileRight.transform.Find(superChef.gender).gameObject.SetActive(true);
                    smileRight.SetActive(true);
                }


                rotate = 1;

                //make the right image bigger
                Debug.Log("level " + superChef.level);
                transform.localScale += targetZoom[superChef.level];


                //Applique un délai pour changer de scène
                DOVirtual.DelayedCall(3, GoToNextScene);

                // Edit score
                if (wrongClicks ==0)
                {
                    //set the level as done
                    superChef.infosNiveau[superChef.actualNiveau][superChef.level-1] = false;
                    //safe the new value in existing points
                    superChef.pointsPerLevel[superChef.actualNiveau][superChef.level - 1] = 10;
                } 
                else if (wrongClicks <=5)
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
            }

        }
        if (rotate == 1)
        {
            transform.Rotate(0, 3, 0);
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
        scores.text = "Score: " + tempScore;
    }

    IEnumerator waiterWrong()
    {
        smile.SetActive(false);
        smileWrong.SetActive(true);
        sonPasBon.Play();
        //Wait for 4 seconds
        yield return new WaitForSeconds(0.5f);
        smileWrong.SetActive(false);
        smile.SetActive(true);

        wrongClicks++;
    }

    //méthode pour changer de scène
    void GoToNextScene()
    {
        SceneManager.LoadScene("Reward"+ superChef.level);
    }

    void OnMouseOver()
    {
        juste = 1;
    }

    void OnMouseExit()
    {
        juste = 0;
    }
}
