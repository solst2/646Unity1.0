using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score1 : MonoBehaviour
{
    public Slider[] scores;
    public GameObject[] levels;
    public GameObject[] characters;
    float maxScore = 50;

    void Start()
    {
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
        for (int j = 0; j < 4; j++)
        {
            levels[0].transform.GetChild(j).gameObject.SetActive(false);
        }
        levels[0].transform.Find(RotateCube.color).gameObject.SetActive(true);
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
        return 40 / maxScore;
        //return superChef.score / maxScore;
    }
}
