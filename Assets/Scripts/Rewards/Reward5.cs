﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Reward5 : MonoBehaviour
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

        //display the right reward, depending on the character
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

        //DOVirtual.DelayedCall(2, GoToNextScene);

        //background
        background.GetComponent<Camera>().backgroundColor = superChef.backgroundCamera[RotateCube.color];

        StartCoroutine(GoToNextSceneN());
    }

    IEnumerator GoToNextSceneN()
    {
        //Wait for seconds
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Reward_moving");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
