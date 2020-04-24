using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CreateChild : MonoBehaviour
{
    public InputField NameInput;
    public InputField SurnameInput;
    public Image ImageChild;
    public Button SubmitButton;

    public static string nameEnter;
    public static string surnameEnter;

    //Sound sources
    public AudioSource FairySound;
    public AudioSource AstronautSound;
    public AudioSource ExplorateurSound;
    public AudioSource TrainSound;

    //buttons
    public GameObject [] notActive;
    public GameObject [] active;

    //Select the right Character
    public Button FairyButton;
    public Button AstronautButton;
    public Button ExplorateurButton;
    public Button TrainButton;
    string FK_Teacher = "1";
    string FK_Character = "1";

    public Text backButton;

    int activated = 4;

    // Start is called before the first frame update
    void Start()
    {
        backButton.text = changeLangage.names[changeLangage.setLanguage, 3];
        /*SubmitButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.RegisterChild(NameInput.text, SurnameInput.text, FK_Character, FK_Teacher));
        });*/
    }

    void Update()
    {
        nameEnter = NameInput.text;
        surnameEnter = SurnameInput.text;
    }

    public void CreatChild() {
        //StartCoroutine(Main.Instance.Web.UploadFileCo(PickFromGallery.filename));
        StartCoroutine(Main.Instance.Web.RegisterChild(NameInput.text, SurnameInput.text, FK_Character, Web.idProf));
        
    }

    public void Fairy() {
        Debug.Log("1");
        FK_Character = "1";
        FairySound.Play();
        active[0].SetActive(true);
        notActive[0].SetActive(false);
        diableOldOne();
        activated = 0;
    }

    public void Astronaut()
    {
        Debug.Log("2");
        FK_Character = "2";
        AstronautSound.Play();
        active[1].SetActive(true);
        notActive[1].SetActive(false);
        diableOldOne();
        activated = 1;
    }

    public void Explorateur()
    {
        Debug.Log("3");
        FK_Character = "3";
        ExplorateurSound.Play();
        active[2].SetActive(true);
        notActive[2].SetActive(false);
        diableOldOne();
        activated = 2;
    }

    public void Train()
    {
        Debug.Log("4");
        FK_Character = "4";
        TrainSound.Play();
        active[3].SetActive(true);
        notActive[3].SetActive(false);
        diableOldOne();
        activated = 3;
    }

    public void diableOldOne()
    {

        //disable the old one
        if (activated != 4)
        {
            active[activated].SetActive(false);
            notActive[activated].SetActive(true);
        }
    }
}
