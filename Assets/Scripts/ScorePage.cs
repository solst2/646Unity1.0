using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScorePage : MonoBehaviour
{
    public Slider[] scores;
    public GameObject[] levels;
    public GameObject[] characters;
    public Text[] percent;
    public Text[] repeat;
    public Text[] level;
    public Text back;
    public Text next;
    public GameObject background;
    float maxScore = 50;
    Dictionary<string, Color32> colors = new Dictionary<string, Color32>();
    public GameObject canvas;

    private void Start()
    {
        canvas.SetActive(false);
    }

    void Update()
    {
        if (superChef.dataloaded == true)
        {
            canvas.SetActive(true);
            //depents on language, change repeat value
            for (int i = 0; i < 4; i++)
            {
                //if the level can not be repeated, the name will be "";
                // 1  ->  all is done || 0  -> nothing is done in that level
                if (CalculateScore() == 1 || CalculateScore() == 0)
                {
                    repeat[i].text ="";
                }
                else
                {
                    repeat[i].text = changeLangage.names[changeLangage.setLanguage, 2];
                }
                level[i].text = changeLangage.names[changeLangage.setLanguage, 0] + " " + (i + 1);
            }
            back.text = changeLangage.names[changeLangage.setLanguage, 3];
            next.text = changeLangage.names[changeLangage.setLanguage, 4];
            //add colors
            try
            {
                colors.Add("blue", new Color32(68, 114, 196, 255));
                colors.Add("yellow", new Color32(232, 218, 0, 255));
                colors.Add("red", new Color32(228, 27, 43, 255));
                colors.Add("pink", new Color32(196, 81, 201, 255));
            }
            catch (Exception e)
            {
                //colors allready added
            }
            //default settings
            foreach (Slider s in scores)
            {
                s.enabled = false;
                s.value = 0;
            }
            //deactivate temporarely the done level points
            foreach (GameObject g in levels)
            {
                g.transform.GetChild(1).gameObject.SetActive(false);
            }
            //for levels
            for (int niv0 = 0; niv0 < scores.Length; niv0++)
            {
                //change the niveau for the calculations
                //superChef.actualNiveau = niv0+1;
                scores[niv0].value = CalculateScore(niv0 + 1);

                //disable all
                for (int j = 0; j < 6; j++)
                {
                    levels[niv0].transform.GetChild(j).gameObject.SetActive(false);
                }

                //if the level is done
                if (scores[niv0].value != 0)
                {

                    levels[niv0].transform.Find(RotateCube.color).gameObject.SetActive(true);
                    percent[niv0].text = (CalculateScore(niv0 + 1) * 100) + "%";

                    //scorebar right color
                    scores[niv0].transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color =
                        colors[RotateCube.color];
                }
                else  //when the level is not done, just activate grey rondel
                {
                    levels[niv0].transform.GetChild(0).gameObject.SetActive(true);
                }

            }
            //characters
            foreach (GameObject g in characters)
            {
                g.SetActive(false);
            }
            switch (superChef.character)
            {
                case "Astronaut":
                    characters[0].SetActive(true);
                    break;
                case "explorateur":
                    characters[1].SetActive(true);
                    break;
                case "HuaYao_01":
                    characters[2].SetActive(true);
                    break;
                case "trainChief":
                    characters[3].SetActive(true);
                    break;
                default:
                    characters[0].SetActive(true);
                    break;
            }
            //background
            background.GetComponent<Image>().color = superChef.background[RotateCube.color];
        }
        superChef.dataloaded = false;
    }

    public void PrintArray()
    {
        for(int i = 1; i < 5; i++)
        {
            Debug.Log("niveau"+i);
            for(int j = 0; j < 5; j++)
            {

                Debug.Log("level" + j);
                Debug.Log(superChef.pointsPerLevel[i][j]);
            }
        }
    }

    public float CalculateScore()
    {
        int tempScore = 0;
        foreach (int i in superChef.pointsPerLevel[superChef.actualNiveau])
        {
            tempScore += i;
        }
        return tempScore / maxScore;
    }

    public float CalculateScore(int niv)
    {
        int tempScore = 0;
        foreach (int i in superChef.pointsPerLevel[niv])
        {
            tempScore += i;
        }
        return tempScore / maxScore;
    }

    public void repeat1(int niveau)
    {
        superChef.actualNiveau = niveau;
        // 1  ->  all is done || 0  -> nothing is done in that level
        if (CalculateScore() == 1 || CalculateScore() == 0)
        {
            return;
        }
        int level = 0;
        //check the points
        foreach(Boolean i in superChef.infosNiveau[superChef.actualNiveau])
        {
            level++;
            if (i)
            {
                SceneManager.LoadScene("Level" + superChef.actualNiveau + "_" + level);
                superChef.level = level - 1;
                break;
            }
        }
    }
}
