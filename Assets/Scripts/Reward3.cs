using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Reward3 : MonoBehaviour
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

        //DOVirtual.DelayedCall(4, GoToNextScene);

        //background
        background.GetComponent<Camera>().backgroundColor = superChef.backgroundCamera[RotateCube.color];

        StartCoroutine(GoToNextSceneN());
    }

    IEnumerator GoToNextSceneN()
    {
        //Wait for seconds
        yield return new WaitForSeconds(3f);
        Debug.Log(superChef.level);
        //next level or higher
        for (int i = superChef.level + 1; i < 7; i++)
        {
            //no more level open -> finish scene
            if (i == 6)
            {
                SceneManager.LoadScene("RewardFinish");
                break;
            }
            //next level or after that is a level open
            if (superChef.pointsPerLevel[superChef.actualNiveau][i - 1] != 10)
            {
                Debug.Log("Level" + superChef.actualNiveau + "_" + i);
                SceneManager.LoadScene("Level" + superChef.actualNiveau + "_" + i);
                break;
            } //when it was false, then the global level is +1
            else
            {
                superChef.level++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
