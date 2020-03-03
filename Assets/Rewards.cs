using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewards : MonoBehaviour
{

    public GameObject astronaut;
    public GameObject fairy;
    public GameObject train;
    public GameObject explorer;

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

    }

    // Update is called once per frame
    void Update()
    {
        astronaut.SetActive(false);
        explorer.SetActive(false);
        fairy.SetActive(false);
        train.SetActive(false);
    }
}
