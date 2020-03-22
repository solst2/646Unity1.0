using UnityEngine;
using UnityEngine.UI;

public class CreateChild : MonoBehaviour
{
    public string nameChild;
    public string surnameChild;
    public GameObject inputName;
    public GameObject inputSurname;
    public GameObject textDisplay;

    public void StoreName()
    {
        nameChild = inputName.GetComponent<Text>().text;
        surnameChild = inputSurname.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Welcome " + nameChild + " " + surnameChild + " to the game";
    }

}

