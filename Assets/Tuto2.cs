﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Tuto2 : MonoBehaviour
{
    public static int tutoplayed = 0;

    // Start is called before the first frame update
    void Start()
    {
        DOVirtual.DelayedCall(5, GoToNextScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GoToNextScene()
    {
        tutoplayed = 1;
        //next undone level
        for (int i = superChef.level + 1; i < 7; i++)
        {
            //no more level open -> finish scene
            if (i == 6)
            {
                SceneManager.LoadScene("RewardFinish");
                break;
            }
            //next level or after that is a level open
            if (superChef.infosNiveau[superChef.actualNiveau][i - 1])
            {
                Debug.Log("Level" + superChef.actualNiveau + "_" + i);
                SceneManager.LoadScene("Level2_" + i);
                break;
            } //when it was false, then the global level is +1
            else
            {
                superChef.level++;
            }
        }
    }
}
