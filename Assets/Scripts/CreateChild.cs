using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateChild : MonoBehaviour
{
    public InputField NameInput;
    public InputField SurnameInput;
    public InputField ImageInput;
    public Button SubmitButton;
    string FK_Teacher = "1";
    string FK_Character = "1";

    // Start is called before the first frame update
    void Start()
    {
        SubmitButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.RegisterChild(NameInput.text, SurnameInput.text, FK_Character, FK_Teacher));
        });
    }
}
