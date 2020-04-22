using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ChildSceneLanguage : MonoBehaviour
{
    //multi language
    public Text loginTitle;
    public Text loginUsername;
    public Text loginPassword;
    public Text loginLogin;
    public Text loginRegister;
    public Text loginOffline;

    public Text teacherAdd;

    public Text createTitle;
    public Text createName;
    public Text createSurname;
    public Text createCamera;
    public Text createGallery;
    public Text createCreate;

    public Text back;
    public Text back1;
    public Text back2;

    public string[,] loginNames = new string[6, 6] {

         { "Connexion","Entrez votre nom d'utilisateur","Entrez le mot de passe","Connexion","Register", "Offline"}, //French  
         { "Anmeldung","Benutzername eingeben","Passwort eingeben","Anmeldung","Registrieren","Offline"}, //German
         { "Login", "Inserisci nome utente", "Inserisci password", "Login", "Iscriviti","Offline"}, //Italian
         { "Login","Enter username","Enter password","Login","Register","Offline"}, //English 
         { "Ingresa en","Introduzca el nombre de usuario","Introduzca la contraseña","Ingresa en","Registro","Fuera de línea"}, //Spanish
         { "ログイン", "ユーザー名を入力", "パスワードを入力", "ログイン","とうさいする","オフライン"}, //Japanish

    };

    public string[,] teacherProfilNames = new string[6, 1] {

         { "Ajouter un enfant"}, //French  
         { "Neues Kind anlegen"}, //German
         { "Aggiungi un bambino"}, //Italian
         { "Create new Child"}, //English 
         { "Crear un niño"}, //Spanish
         { "子を加える"} //Japanish

    };

    public string[,] createNames = new string[6, 6] {

         { "Inscrire un nouvel enfant", "Entrer le nom", "Entrer le nom de famille", "Appareil photo", "Galerie", "Ajouter un enfant"}, //French  
         { "Neues Kind registrieren", "Name eingeben", "Nachname eingeben", "Kamera", "Galerie", "Neues Kind erstellen"}, //German
         { "Registra nuovo bambino", "Inserisci nome", "Inserisci cognome", "Macchina fotografica", "Galleria", "Crea nuovo bambino"}, //Italian 
         { "Register new Child","Enter name","Enter surname","Camera","Gallery","Create new Child"}, //English 
         { "Registrar nuevo niño", "Introducir nombre", "Introducir apellido", "Cámara", "Galería", "Crear nuevo niño"}, //Spanish
         { "新しい子の登録", "名前を入力", "苗字を入力", "カメラ", "ギャラリー", "新しい子の作成"} //Japanish 

    };

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            loginTitle.text = loginNames[changeLangage.setLanguage, 0];
            loginUsername.text = loginNames[changeLangage.setLanguage, 1];
            loginPassword.text = loginNames[changeLangage.setLanguage, 2];
            loginLogin.text = loginNames[changeLangage.setLanguage, 3];
            back.text = changeLangage.names[changeLangage.setLanguage, 3];
            loginRegister.text = loginNames[changeLangage.setLanguage, 4];
            loginOffline.text = loginNames[changeLangage.setLanguage, 5];
        } catch (Exception e)
        {
            // script is used in several scenes, that is why it is an exception
        }

        try
        {
            back2.text = changeLangage.names[changeLangage.setLanguage, 3];
            teacherAdd.text = teacherProfilNames[changeLangage.setLanguage, 0];
        }
        catch (Exception e)
        {
            // script is used in several scenes, that is why it is an exception
        }

        try
        {
            back1.text = changeLangage.names[changeLangage.setLanguage, 3];
            createTitle.text = createNames[changeLangage.setLanguage, 0];
            createName.text = createNames[changeLangage.setLanguage, 1] + "...";
            createSurname.text = createNames[changeLangage.setLanguage, 2] + "...";
            createCamera.text = createNames[changeLangage.setLanguage, 3];
            createGallery.text = createNames[changeLangage.setLanguage, 4];
            createCreate.text = createNames[changeLangage.setLanguage, 5];
        }
        catch (Exception e)
        {
            // script is used in several scenes, that is why it is an exception
        }

    }

}
