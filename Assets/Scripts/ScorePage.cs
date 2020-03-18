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
    public GameObject background;
    float maxScore = 50;
    Dictionary<string, Color32> colors = new Dictionary<string, Color32>();

    void Start()
    {
        //add colors
        colors.Add("blue", new Color32(68, 114, 196, 255));
        colors.Add("yellow", new Color32(232,218,0, 255));
        colors.Add("red", new Color32(228,27,43, 255));
        colors.Add("pink", new Color32(196, 81, 201, 255));
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
        for(int niv = 0;niv < scores.Length; niv++)
        {
            //change the niveau for the calculations
            superChef.actualNiveau = niv+1;
            scores[niv].value = CalculateScore();

            for (int j = 0; j < 6; j++)
            {
                levels[niv].transform.GetChild(j).gameObject.SetActive(false);
            }

            levels[niv].transform.Find(RotateCube.color).gameObject.SetActive(true);
            percent[niv].text = (CalculateScore() * 100) + "%";

            //scorebar right color
            scores[niv].transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color =
                colors[RotateCube.color];
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


    float CalculateScore()
    {
        int tempScore = 0;
        foreach (int i in superChef.pointsPerLevel[superChef.actualNiveau])
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
