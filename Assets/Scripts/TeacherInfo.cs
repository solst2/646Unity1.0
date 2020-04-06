using UnityEngine;
using UnityEngine.SceneManagement;

public class TeacherInfo : MonoBehaviour
{

    public string PK_Teacher { get; private set; }
    string Username;
    string Password;
    string Email;

    public void SetCredentials(string email, string password) {
        Email = email;
        Password = password;
    }

    public void SetTeacherID(string id) {
        PK_Teacher = id;
    }

    public void CreatChildButton()
    {
        SceneManager.LoadScene("CreateChild");
    }

}
