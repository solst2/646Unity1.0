using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeLangage : MonoBehaviour
{

    public enum language { French, English, German };
    public language setLanguage;

    public enum word { Niveau, Score, Options, Retour }
    public word setWord;

    //Here is the liste of words
    string[,] names = new string[3, 4] {

         { "Niveau","Score","Options","Retour"}, //French  
         { "Level", "Score", "Options", "Exit" }, //English  
         { "Niveau de","Score de","Options de","Retour de"} //German
    };

    // Start is called before the first frame update
  /*  void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = names[(int)setLanguage, (int)setWord];
    }
}
