using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static Main Instance;

    public Web Web;
    public TeacherInfo TeacherInfo;
    public Login Login;

    public GameObject TeacherProfile;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        Web = GetComponent<Web>();
        TeacherInfo = GetComponent<TeacherInfo>();

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Language");
    }
}
