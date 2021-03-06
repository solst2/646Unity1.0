﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Reward_moving : MonoBehaviour
{

    public GameObject canvasExplorer;
    public GameObject canvasTrain;
    public GameObject canvasFairy;
    public GameObject canvasAstronaut;
    public Camera background;
    public string character;


    // Start is called before the first frame update
    void Start()
    {
        canvasAstronaut.SetActive(false);
        canvasExplorer.SetActive(false);
        canvasFairy.SetActive(false);
        canvasTrain.SetActive(false);

        character = superChef.character;

        //Look for the right reward, depending on the character
        switch (character)
        {
            case "Astronaut":
                canvasAstronaut.SetActive(true);
                break;
            case "trainChief":
                canvasTrain.SetActive(true);
                break;
            case "HuaYao_01":
                canvasFairy.SetActive(true);
                break;
            case "explorateur":
                canvasExplorer.SetActive(true);
                break;
        }

        //DOVirtual.DelayedCall(6, GoToNextScene);

        //background
        background.GetComponent<Camera>().backgroundColor = superChef.background[RotateCube.color];

        StartCoroutine(GoToNextSceneN());
    }

    IEnumerator GoToNextSceneN()
    {
        //Wait for 3 seconds
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("RewardFinish");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
