using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Reward : MonoBehaviour
{

    public GameObject astronaut;
    public GameObject explorer;
    public GameObject fairy;
    public GameObject train;

    public string characterChosen;

    // Start is called before the first frame update
    void Start()
    {
        characterChosen = superChef.character;

        astronaut.SetActive(false);
        explorer.SetActive(false);
        fairy.SetActive(false);
        train.SetActive(false);

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

        DOVirtual.DelayedCall(4, GoToNextScene);

    }

    void GoToNextScene()
    {
        SceneManager.LoadScene("Level1_2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
