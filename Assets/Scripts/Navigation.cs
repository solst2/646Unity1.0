using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{

    //Back to the Character Scene
    public void BackButton()
    {
        superChef.level = 0;
        SceneManager.LoadScene("Character");
        //make default
        //default values to the infosNiveau
        Boolean[] trueValues = { true, true, true, true, true };
        for (int i = 0; i < 5; i++)
        {
            superChef.infosNiveau.Add(i, trueValues);
        }
        //default Values level
        int[] zero = { 0, 0, 0, 0, 0 };
        for (int i = 0; i < 5; i++)
        {
            superChef.pointsPerLevel.Add(i, zero);
        }
        //Niveau 2 Gender -> default girl
        superChef.gender = "girl";
        System.Random r = new System.Random();
        int random = r.Next(0, 1);
        Debug.Log("random: " + random);
        if (random == 1)
        {
            superChef.gender = "boy";
        }
    }
}
