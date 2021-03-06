﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeacherInfo : MonoBehaviour
{
    //Attributes
    public string PK_Teacher { get; private set; }
    string Password;
    string Email;
    public Text email;
    public Text name;
    public static string fromWhere = "";
    public GameObject Profil;
    public GameObject Login;
    public GameObject CreateTeacher;

    void Start()
    {
        Debug.Log(fromWhere);
        //Navigation 
        if (fromWhere.Equals("ScorePage")|| fromWhere.Equals("toTeacherOverview"))
        {
            //activate teacherProfil
            PK_Teacher = Web.idProf;
            email.text = Web.mailProf;
            name.text = Web.nameProf + " "+Web.surnameProf;
            Profil.SetActive(true);
            Login.SetActive(false);
            CreateTeacher.SetActive(false);
        }

        if (fromWhere.Equals("Profil") || fromWhere.Equals("ScorePageOffline"))
        {
            //activate teacherLogin aktiviäru
            Profil.SetActive(false);
            Login.SetActive(true);
            CreateTeacher.SetActive(false);
        }
    }

    //Display the email of the teacher on the screen
    public void SetCredentials(string emailDB, string password) {
        Email = emailDB;
        Password = password;
        try
        {
            email.text = emailDB;
        }
        catch (System.Exception)
        {
        }
        
    }

    //Display the email of the teacher on the screen
    public void SetCredentialsName(string nameProf)
    {
        try
        {
            name.text = nameProf;
        }
        catch (System.Exception)
        {
        }

    }

    public void SetTeacherID(string id) {
        PK_Teacher = id;
    }

    public void CreatChildButton()
    {
        SceneManager.LoadScene("CreateChild");
    }
}
