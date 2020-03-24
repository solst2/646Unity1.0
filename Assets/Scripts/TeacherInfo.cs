using UnityEngine;

public class TeacherInfo : MonoBehaviour
{

    public string PK_Teacher { get; private set; }
    string Username;
    string Password;
    string Email;

    public void SetCredentials(string username, string password) {
        Username = username;
        Password = password;
    }

    public void SetTeacherID(string id) {
        PK_Teacher = id;
    }
}
