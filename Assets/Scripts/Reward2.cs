using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class Reward2 : MonoBehaviour
{

    public GameObject canvasTrain;
    public GameObject canvasFairy;
    public GameObject canvasAstronaut;
    public GameObject canvasExplorer;
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

        DOVirtual.DelayedCall(4, GoToNextScene);

        //background
        background.GetComponent<Camera>().backgroundColor = superChef.background[RotateCube.color];

    }

    void GoToNextScene()
    {
        Debug.Log(superChef.level);
        //next level or higher
        for (int i = superChef.level+1; i < 7; i++)
        {
            //no more level open -> finish scene
            if (i == 6)
            {
                SceneManager.LoadScene("RewardFinish");
                break;
            }
            //next level or after that is a level open
            if (superChef.infosNiveau[superChef.actualNiveau][i-1])
            {
                Debug.Log("Level" + superChef.actualNiveau + "_" + i);
                SceneManager.LoadScene("Level" + superChef.actualNiveau + "_" + i);
                break;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
