using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Web : MonoBehaviour
{
    //Errormessage
    public Text ErrorMessageLogin;
    public Text ErrorMessageRegister;

    //Store the id and the mail of the teacher
    public static string idProf = "";
    public static string mailProf = "";

    // Start is called before the first frame update
    void Start()
    {

    }

    //Get all Childrens of the Database
    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://attentionconjointe.p645.hevs.ch/GetChildren.php")) {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else {
                //Show Results as text
                Debug.Log(www.downloadHandler.text);

                //Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    //Call the Login.php File
    public IEnumerator Login(string email, string password)
    {
        //Send attributes
        WWWForm form = new WWWForm();
        form.AddField("loginEmail", email);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://attentionconjointe.p645.hevs.ch/Login.php", form))
        {
            yield return www.SendWebRequest();

            //Check if there is a network error
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //save the informations in variables
                Debug.Log(www.downloadHandler.text);
                idProf = www.downloadHandler.text;
                mailProf = email;
                Main.Instance.TeacherInfo.SetCredentials(email, password);
                Main.Instance.TeacherInfo.SetTeacherID(www.downloadHandler.text);

                //Display the correct errormessage
                if (www.downloadHandler.text.Contains("Wrong Credentials"))
                {
                    ErrorMessageLogin.text = "Wrong Credentials";
                }
                else if (www.downloadHandler.text.Contains("Email does not exist"))
                {
                    ErrorMessageLogin.text = "Email does not exist";
                }
                else {
                    //If we logged in correctly
                    superChef.offline = false;
                    ErrorMessageLogin.text = "";
                    Main.Instance.TeacherProfile.SetActive(true);
                    Main.Instance.Login.gameObject.SetActive(false);
                }
            }
        }
    }

    //Create a new Teacher and save it in the db
    public IEnumerator RegisterTeacher(string name, string surname, string email, string password)
    {
        //Send attributes
        WWWForm form = new WWWForm();
        form.AddField("loginName", name);
        form.AddField("loginSurname", surname);
        form.AddField("loginEmail", email);
        form.AddField("loginPass", password);

        //Check if there is a network error
        using (UnityWebRequest www = UnityWebRequest.Post("https://attentionconjointe.p645.hevs.ch//RegisterTeacher.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Dsiplay the errormessage
                if (!www.downloadHandler.text.Contains("New record created successfully"))
                {
                    ErrorMessageRegister.text = "Teacher could not be created - Email already exists";
                }
                else
                {
                    //If we created the teacher correctly
                    Main.Instance.CreateTeacher.gameObject.SetActive(false);
                    Main.Instance.Login.gameObject.SetActive(true);
                }
            }
        }
    }

    //Create a new child and save it in the db
    public IEnumerator RegisterChild(string name, string surname, string fk_Character, string fk_Teacher)
    {
        //Send attributes
        string extension = PickFromGallery.extentionName;
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("surname", surname);
        form.AddField("fk_Character", fk_Character);
        form.AddField("fk_Teacher", fk_Teacher);
        form.AddField("extension", extension);

        using (UnityWebRequest www = UnityWebRequest.Post("https://attentionconjointe.p645.hevs.ch/RegisterChild.php", form))
        {
            yield return www.SendWebRequest();

            //Check if there is a network error
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Display the errormessage
                if (!www.downloadHandler.text.Contains("New record created successfully"))
                {
                    ErrorMessageRegister.text = "Child could not be created - Child already exist";
                }
                else
                {
                    //If we created the child correctly
                    //that it loads the child overview
                    TeacherInfo.fromWhere = "toTeacherOverview";
                    SceneManager.LoadScene("ChildScene");
                }
            }
        }
    }

    public IEnumerator UploadFileCo(string localFileName)
    {
        Debug.Log("Start UploadFileCo");
        WWW localFile = new WWW("file:///" + localFileName);
        yield return localFile;
        if (localFile.error == null)
            Debug.Log("Loaded file successfully");
        else
        {
            Debug.Log("Open file error: " + localFile.error);
            yield break; // stop the coroutine here
        }
        WWWForm postForm = new WWWForm();
        // version 1
        //postForm.AddBinaryData("theFile",localFile.bytes);
        // version 2
        Debug.Log("localFile.bytes = "+ localFile.bytes);
        Debug.Log("localFileName = "+ localFileName);
        postForm.AddBinaryData("theFile", localFile.bytes, localFileName, "text/plain");
        WWW upload = new WWW("https://attentionconjointe.p645.hevs.ch/UploadImage.php", postForm);
        yield return upload;
        if (upload.error == null)
            Debug.Log("upload done :" + upload.text);
        else
            Debug.Log("Error during upload: " + upload.error);

    }

    //Get all ID's of the childrens of one teacher
    public IEnumerator GetChildrenIDs(string PK_Teacher, System.Action<string> callback)
    {
        //Send attributes
        WWWForm form = new WWWForm();
        form.AddField("PK_Teacher", PK_Teacher);

        using (UnityWebRequest www = UnityWebRequest.Post("https://attentionconjointe.p645.hevs.ch/GetChildrenIDs.php", form))
        {
            yield return www.SendWebRequest();

            //Check if there is a network error
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show Results as text
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                callback(jsonArray);
            }
        }
    }

    //Get the informations of one child -> for the list of children
    public IEnumerator GetChild(string PK_Child, System.Action<string> callback)
    {
        //Send attributes
        WWWForm form = new WWWForm();
        form.AddField("PK_Child", PK_Child);

        using (UnityWebRequest www = UnityWebRequest.Post("https://attentionconjointe.p645.hevs.ch/GetChild.php", form))
        {
            yield return www.SendWebRequest();

            //Check if there is a network error
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show Results as text
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                callback(jsonArray);
            }
        }
    }

    //Get the informations of one single child -> play the game with it
    public IEnumerator GetSelectedChild(string PK_Child)
    {
        //Send attributes
        WWWForm form = new WWWForm();
        form.AddField("PK_Child", PK_Child);

        using (UnityWebRequest www = UnityWebRequest.Post("https://attentionconjointe.p645.hevs.ch/GetSelectedChild.php", form))
        {
            yield return www.SendWebRequest();

            //Check if there is a network error
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show Results as text
                string valuesFromDB = www.downloadHandler.text;
           
                string[] strlist = valuesFromDB.Split(',');

                //Save the informations
                Debug.Log(www.downloadHandler.text);
                superChef.childname = strlist[0];
                superChef.childsurname = strlist[1];
                superChef.score[0] = strlist[2];
                superChef.score[1] = strlist[3];
                superChef.score[2] = strlist[4];
                superChef.score[3] = strlist[5];
                superChef.score[4] = strlist[6];
                superChef.levelDB = strlist[7];
                superChef.niveau = strlist[8];
                superChef.fk_Character = strlist[9];
                Debug.Log("FK.." + strlist[9]);
                //new infos
                for (int i = 1; i < 5; i++)
                {
                    string[] scoreAlone = strlist[i+1].Split('-');

                    try
                    {
                        superChef.pointsPerLevel.Add(i, new int[] { Int32.Parse(scoreAlone[0]), Int32.Parse(scoreAlone[1]),
                            Int32.Parse(scoreAlone[2]), Int32.Parse(scoreAlone[3]), Int32.Parse(scoreAlone[4])});
                    }
                    catch (Exception e)
                    {
                        superChef.pointsPerLevel[i] = new int[] { Int32.Parse(scoreAlone[0]), Int32.Parse(scoreAlone[1]),
                            Int32.Parse(scoreAlone[2]), Int32.Parse(scoreAlone[3]), Int32.Parse(scoreAlone[4])};
                    }
                }

                superChef.level = Int32.Parse(strlist[7]);
                superChef.actualNiveau = Int32.Parse(strlist[8]);

                //Look for the right character
                switch (strlist[9])
                {
                    case "1":
                        superChef.character = "Astronaut";
                        break;
                    case "2":
                        superChef.character = "explorateur";
                        break;
                    case "3":
                        superChef.character = "HuaYao_01";
                        break;
                    case "4":
                        superChef.character = "trainChief";
                        break;
                    default:
                        superChef.character = "Astronaut";
                        break;
                }
            }
            superChef.dataloaded = true;
            CreateChild.loaded = true;
        }
    }

    //Update one child in the DB
    public IEnumerator UpdateChild(string PK_Child, string Name, string Surname, string Score1, string Score2, string Score3, string Score4, string Score5, string Niveau, string Level, string FK_Character)
    {

        Debug.Log("UpdateChild");

        //Send attributes
        WWWForm form = new WWWForm();
        form.AddField("PK_Child", PK_Child);
        form.AddField("Name", Name);
        form.AddField("Surname", Surname);
        form.AddField("Score1", Score1);
        form.AddField("Score2", Score2);
        form.AddField("Score3", Score3);
        form.AddField("Score4", Score4);
        form.AddField("Score5", Score5);
        form.AddField("Niveau", Niveau);
        form.AddField("Level", Level);
        form.AddField("FK_Character", FK_Character);


        using (UnityWebRequest www = UnityWebRequest.Post("https://attentionconjointe.p645.hevs.ch/UpdateChild.php", form))
        {
         
            yield return www.SendWebRequest();

            //Check if there is a network error
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show Results as text
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
