using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeacherInfo : MonoBehaviour
{

    public string PK_Teacher { get; private set; }
    string Username;
    string Password;
    string Email;
    public Text email;

    void Start()
    {
    }

    public void SetCredentials(string emailDB, string password) {
        Email = emailDB;
        Password = password;
        //email.text = emailDB;
    }

    public void SetTeacherID(string id) {
        PK_Teacher = id;
    }

    public void CreatChildButton()
    {
        SceneManager.LoadScene("CreateChild");
    }

}
