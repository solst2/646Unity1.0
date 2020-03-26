using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSound : MonoBehaviour
{

    public  GameObject explo;
    public  GameObject train;
    public  GameObject fairy;
    public  GameObject astro;

    

    // Start is called before the first frame update
    void Start()
    {
        explo.SetActive(false);
        train.SetActive(false);
        astro.SetActive(false);
        fairy.SetActive(false);

        string character = superChef.character;

        switch (character)
        {
            case "Astronaut":
               
                astro.SetActive(true);
                break;
            case "trainChief":
                
                train.SetActive(true);
                break;
            case "HuaYao_01":
                
                fairy.SetActive(true);
                break;
            case "explorateur":
                
                explo.SetActive(true);
                break;
        }
    }

  
    private static KeepSound instance = null;
    public static KeepSound Instance
    {
        get { return instance; }
        
        

    }

    void Awake()
    {
        if(instance !=null && instance!=this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        string character = superChef.character;

        switch (character)
        {
            case "Astronaut":

                DontDestroyOnLoad(astro);
                break;
            case "trainChief":

                DontDestroyOnLoad(train);
                break;
            case "HuaYao_01":

                DontDestroyOnLoad(fairy);
                break;
            case "explorateur":

                DontDestroyOnLoad(explo);
                break;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
