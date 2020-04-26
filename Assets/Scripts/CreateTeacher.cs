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

    // Start is called before the first frame update
    void Start()
    {
    }

    public void call()
    {
        //Call the function to create a new teacher in the DB
        StartCoroutine(Main.Instance.Web.RegisterTeacher(NameInput.text, SurnameInput.text, EmailInput.text, PasswordInput.text));
    }
}
