using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePage : MonoBehaviour
{
    public Slider[] scores;
    public GameObject[] levels;
    public GameObject[] characters;
    public Text[] percent;
    float maxScore = 50;
    Dictionary<string, Color32> colors = new Dictionary<string, Color32>();

    void Start()
    {
        //add colors
        colors.Add("blue", new Color32(68, 114, 196, 255));
        colors.Add("bege", new Color32(192, 163, 75, 255));
        colors.Add("green", new Color32(62, 165, 60, 255));
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
        //for level one
        scores[0].value = CalculateScore();
        for (int j = 0; j < 6; j++)
        {
            levels[0].transform.GetChild(j).gameObject.SetActive(false);
        }
        levels[0].transform.Find(RotateCube.color).gameObject.SetActive(true);
        percent[0].text = (CalculateScore()*100) + "%";
        //scorebar right color
        scores[0].transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = 
            colors[RotateCube.color];
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
    }


    float CalculateScore()
    {
        //return 40 / maxScore;
        return superChef.score / maxScore;
    }
}
