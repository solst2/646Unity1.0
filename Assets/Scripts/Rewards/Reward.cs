using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class Reward : MonoBehaviour
{

    public GameObject astronaut;
    public GameObject explorer;
    public GameObject fairy;
    public GameObject train;
    public Camera background;

    public string characterChosen;

    // Start is called before the first frame update
    void Start()
    {
        characterChosen = superChef.character;

        astronaut.SetActive(false);
        explorer.SetActive(false);
        fairy.SetActive(false);
        train.SetActive(false);

        //display the right reward, depending on the character
        switch (characterChosen)
        {
            case "Astronaut":
                astronaut.SetActive(true);
                break;
            case "trainChief":
                train.SetActive(true);
                break;
            case "HuaYao_01":
                fairy.SetActive(true);
                break;
            case "explorateur":
                explorer.SetActive(true);
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
