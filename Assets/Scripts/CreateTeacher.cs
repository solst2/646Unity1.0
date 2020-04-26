using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateTeacher : MonoBehaviour
{
    //Attributes
    public InputField NameInput;
    public InputField SurnameInput;
    public InputField EmailInput;
    public InputField PasswordInput;
    public Button SubmitButton;
    public GameObject Login;
    public GameObject Register;

    //Errormessage
    public Text ErrorMessageRegister;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void call()
    {
        //Call the function to create a new teacher in the DB
        if (SurnameInput.text.Equals("") || NameInput.text.Equals("") || EmailInput.text.Equals("") || PasswordInput.text.Equals(""))
        {
            ErrorMessageRegister.text = "Please fill in all fields";
        }
        else
        {
            ErrorMessageRegister.text = "";
            StartCoroutine(Main.Instance.Web.RegisterTeacher(NameInput.text, SurnameInput.text, EmailInput.text, PasswordInput.text));
        }
    }
}
