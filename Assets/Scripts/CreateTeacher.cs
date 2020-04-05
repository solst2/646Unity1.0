using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTeacher : MonoBehaviour
{
    public InputField NameInput;
    public InputField SurnameInput;
    public InputField EmailInput;
    public InputField PasswordInput;
    public Button SubmitButton;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void call()
    {
        /*
        SubmitButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.RegisterTeacher(UsernameInput.text, PasswordInput.text));
        });
        */
        StartCoroutine(Main.Instance.Web.RegisterTeacher(NameInput.text, SurnameInput.text, EmailInput.text, PasswordInput.text));
        Debug.Log("Test");
    }
}
