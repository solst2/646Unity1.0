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
    public CreateTeacher CreateTeacher;
    public CreateChild CreateChild;

    public GameObject TeacherProfile;

    // Use this for initialization
    void Start()
    {
        if(Web??true)
        {
            Web = GameObject.Find("Web").GetComponent<Web>();
            Debug.Log("Web is added to main");
        }
        TeacherInfo = GetComponent<TeacherInfo>();
        Instance = this;

    }

}
