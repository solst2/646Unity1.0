using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Reward2 : MonoBehaviour
{

    public GameObject canvasExplorer;
    public GameObject canvasAstronaut;
    public GameObject canvasFairy;
    public GameObject canvasTrain;

    public string character;


    // Start is called before the first frame update
    void Start()
    {
        canvasAstronaut.SetActive(true);
        canvasExplorer.SetActive(true);
        canvasFairy.SetActive(false);
        canvasTrain.SetActive(true);

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

        DOVirtual.DelayedCall(3, GoToNextScene);

    }

    void GoToNextScene()
    {
        SceneManager.LoadScene("Level1_3");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
