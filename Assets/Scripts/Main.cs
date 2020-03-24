using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
