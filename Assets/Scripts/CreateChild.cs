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
    public Button UpdateButton;
    public GameObject gallery;

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

    public static Boolean loaded = false;

    // Start is called before the first frame update
    void Start()
    {
        backButton.text = changeLangage.names[changeLangage.setLanguage, 3];
    }

    void Update()
    {
        nameEnter = NameInput.text;
        surnameEnter = SurnameInput.text;
        if (superChef.edit && loaded)
        {
            NameInput.text = superChef.childname;
            Debug.Log("Childname: " + superChef.childname);
            SurnameInput.text = superChef.childsurname;
            //get character
            switch (superChef.character)
            {
                case "Astronaut":
                    Astronaut();
                    break;
                case "explorateur":
                    Explorateur();
                    break;
                case "HuaYao_01":
                    Fairy();
                    break;
                case "trainChief":
                    Train();
                    break;
                default:
                    Astronaut();
                    break;
            }

            //disable create button
            SubmitButton.gameObject.SetActive(false);
            UpdateButton.gameObject.SetActive(true);
            gallery.SetActive(false);

            loaded = false;
        }
    }

    public void CreatChild() {
        //StartCoroutine(Main.Instance.Web.UploadFileCo(PickFromGallery.filename));
        StartCoroutine(Main.Instance.Web.RegisterChild(NameInput.text, SurnameInput.text, FK_Character, Web.idProf));
    }
    public void updateChild()
    {
        superChef.childname = NameInput.text;
        superChef.childsurname = SurnameInput.text;
        superChef.fk_Character = FK_Character;

        StartCoroutine(Main.Instance.Web.UpdateChild(superChef.PK_Child, NameInput.text, SurnameInput.text, superChef.score[0], superChef.score[1], superChef.score[2], superChef.score[3], superChef.score[4], superChef.niveau, superChef.levelDB, FK_Character));
        superChef.edit = false;
        // that is redirects to the profile
        TeacherInfo.fromWhere = "toTeacherOverview";
        SceneManager.LoadScene("ChildScene");
    }

    public void Fairy() {
        Debug.Log("3");
        FK_Character = "3";
        FairySound.Play();
        active[0].SetActive(true);
        notActive[0].SetActive(false);
        diableOldOne();
        activated = 0;
    }

    public void Astronaut()
    {
        Debug.Log("1");
        FK_Character = "1";
        AstronautSound.Play();
        active[1].SetActive(true);
        notActive[1].SetActive(false);
        diableOldOne();
        activated = 1;
    }

    public void Explorateur()
    {
        Debug.Log("2");
        FK_Character = "2";
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
