﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeacherInfo : MonoBehaviour
{

    public string PK_Teacher { get; private set; }
    string Username;
    string Password;
    string Email;
    public Text email;
    public static string fromWhere = "";
    public GameObject Profil;
    public GameObject Login;
    public GameObject CreateTeacher;

    void Start()
    {
        //Navigation 
        if (fromWhere.Equals("ScorePage"))
        {
            // teacherProfil aktiviäru
            Profil.SetActive(true);
            Login.SetActive(false);
            CreateTeacher.SetActive(false);
        }
        if (fromWhere.Equals("Profil"))
        {
            // teacherLogin aktiviäru
            Profil.SetActive(false);
            Login.SetActive(true);
            CreateTeacher.SetActive(false);
        }
        


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
