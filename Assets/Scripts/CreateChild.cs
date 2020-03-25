using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateChild : MonoBehaviour
{
    public InputField NameInput;
    public InputField SurnameInput;
    public Image ImageChild;
    public Button SubmitButton;

    //Sound sources
   // public AudioSource FairySound;
   // public AudioSource AstronautSound;
   // public AudioSource ExplorateurSound;
   // public AudioSource TrainSound;

    //Select the right Character
    public Button FairyButton;
    public Button AstronautButton;
    public Button ExplorateurButton;
    public Button TrainButton;
    string FK_Teacher = "1";
    string FK_Character = "1";

    // Start is called before the first frame update
    void Start()
    {
        SubmitButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.RegisterChild(NameInput.text, SurnameInput.text, FK_Character, FK_Teacher));
            //Main.Instance.TeacherProfile.SetActive(true);
            //Main.Instance.CreateChild.gameObject.SetActive(false);
        });
    }

    public void Fairy() {
        Debug.Log("1");
        FK_Character = "1";
        //FairySound.Play();
    }

    public void Astronaut()
    {
        Debug.Log("2");
        FK_Character = "2";
        //AstronautSound.Play();
    }

    public void Explorateur()
    {
        Debug.Log("3");
        FK_Character = "3";
        //ExplorateurSound.Play();
    }

    public void Train()
    {
        Debug.Log("4");
        FK_Character = "4";
        //TrainSound.Play();
    }
}
