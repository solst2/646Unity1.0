using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePage : MonoBehaviour
{
    public Slider[] scores;
    public GameObject[] levels;
    float maxScore = 50;

    void Start()
    {
        //default settings
        foreach (Slider s in scores)
        {
            s.enabled = false;
            s.value = 0;
        }
        foreach (GameObject g in levels)
        {
            g.transform.GetChild(1).gameObject.SetActive(false);
        }
        //for level one
        scores[0].value = CalculateScore();
        levels[0].transform.GetChild(1).gameObject.SetActive(true);
        levels[0].transform.GetChild(0).gameObject.SetActive(false);
    }


    float CalculateScore()
    {
        return 40 / maxScore;
        //return superChef.score / maxScore;
    }
}
