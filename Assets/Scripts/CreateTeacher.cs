using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateTeacher : MonoBehaviour
{
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
        StartCoroutine(Main.Instance.Web.RegisterTeacher(NameInput.text, SurnameInput.text, EmailInput.text, PasswordInput.text));
    }
}
