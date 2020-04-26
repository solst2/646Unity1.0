using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateChildLanguage : MonoBehaviour
{
    //multi language
    public Text title;
    public Text name;
    public Text surname;
    public Text register;

    public string[,] names = new string[4, 4] {

         { "Ajouter un nouvel enfant","Entrez le nom","Entrez le nom de famille","Enregistrer"}, //French  
         { "Ein neues Kind hinzufügen","Geben Sie den Namen","Nachname eingeben","Registrieren Sie"}, //German
         { "Add a new child","Enter the name","Enter last name","Register"}, //English 
         { "Añadir un nuevo niño","Introduzca el nombre","Introduzca el apellido","Registrarse"} //Spanish

    };
    // Start is called before the first frame update
    void Start()
    {
        title.text = names[changeLangage.setLanguage, 0];
        name.text = names[changeLangage.setLanguage, 1]+"...";
        surname.text = names[changeLangage.setLanguage, 2]+"...";
        register.text = names[changeLangage.setLanguage, 3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
