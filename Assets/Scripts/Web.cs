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
    public Text ErrorMessage;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetUsers());
        //StartCoroutine(Login("testuser", "12345"));
        //StartCoroutine(RegisterTeacher("testuser2", "12345"));
    }


    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/Unity/GetChildren.php")) {
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

    public IEnumerator Login(string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginEmail", email);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Main.Instance.TeacherInfo.SetCredentials(email, password);
                Main.Instance.TeacherInfo.SetTeacherID(www.downloadHandler.text);

                if (www.downloadHandler.text.Contains("Wrong Credentials"))
                {
                    ErrorMessage.text = "Wrong Credentials";
                }
                else if (www.downloadHandler.text.Contains("Email does not exist"))
                {
                    ErrorMessage.text = "Email does not exist";
                }
                else {
                    //If we logged in correctly
                    Main.Instance.TeacherProfile.SetActive(true);
                    Main.Instance.Login.gameObject.SetActive(false);
                }
            }
        }
    }

    public IEnumerator RegisterTeacher(string name, string surname, string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginName", name);
        form.AddField("loginSurname", surname);
        form.AddField("loginEmail", email);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity/RegisterTeacher.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (!www.downloadHandler.text.Contains("New record created successfully"))
                {
                    ErrorMessage.text = "Teacher could not be created";
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

    public IEnumerator RegisterChild(string name, string surname, string fk_Character, string fk_Teacher)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("surname", surname);
        form.AddField("fk_Character", fk_Character);
        form.AddField("fk_Teacher", fk_Teacher);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity/RegisterChild.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (!www.downloadHandler.text.Contains("New record created successfully"))
                {
                    ErrorMessage.text = "Child could not be created";
                }
                else
                {
                    //If we created the child correctly
                    SceneManager.LoadScene("ChildScene");
                    Main.Instance.TeacherProfile.SetActive(true);
                    Main.Instance.Login.gameObject.SetActive(false);
                }
            }
        }
    }

    public IEnumerator GetChildrenIDs(string PK_Teacher, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("PK_Teacher", PK_Teacher);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity/GetChildrenIDs.php", form))
        {
            yield return www.SendWebRequest();

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

    public IEnumerator GetChild(string PK_Child, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("PK_Child", PK_Child);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity/GetChild.php", form))
        {
            yield return www.SendWebRequest();

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

    public IEnumerator GetSelectedChild(string PK_Child)
    {
        WWWForm form = new WWWForm();
        form.AddField("PK_Child", PK_Child);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity/GetSelectedChild.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show Results as text
                string valuesFromDB = www.downloadHandler.text;
           
                string[] strlist = valuesFromDB.Split(',');

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

                //new infos
                for (int i = 1; i < 5; i++)
                {
                    string[] scoreAlone = strlist[i+1].Split('-');

                    try
                    {
                        superChef.pointsPerLevel.Add(i, new int[] { Int32.Parse(scoreAlone[0]), Int32.Parse(scoreAlone[1]),
                            Int32.Parse(scoreAlone[2]), Int32.Parse(scoreAlone[3]), Int32.Parse(scoreAlone[4])});

                        superChef.infosNiveau.Add(i, new Boolean[] { scoreAlone[0].Equals("0"), scoreAlone[1].Equals("0"),
                            scoreAlone[2].Equals("0"), scoreAlone[3].Equals("0"), scoreAlone[4].Equals("0") });
                    }
                    catch (Exception e)
                    {
                        superChef.pointsPerLevel[i] = new int[] { Int32.Parse(scoreAlone[0]), Int32.Parse(scoreAlone[1]),
                            Int32.Parse(scoreAlone[2]), Int32.Parse(scoreAlone[3]), Int32.Parse(scoreAlone[4])};

                        superChef.infosNiveau[i] = new Boolean[] { scoreAlone[0].Equals("0"), scoreAlone[1].Equals("0"),
                            scoreAlone[2].Equals("0"), scoreAlone[3].Equals("0"), scoreAlone[4].Equals("0") };
                    }
                }
                superChef.level = Int32.Parse(strlist[7]);
                superChef.actualNiveau = Int32.Parse(strlist[8]);
                //change to real version, this switch case is just to try
                switch (strlist[9])
                {
                    case "0":
                        superChef.character = "Astronaut";
                        break;
                    case "1":
                        superChef.character = "explorateur";
                        break;
                    case "2":
                        superChef.character = "HuaYao_01";
                        break;
                    case "3":
                        superChef.character = "trainChief";
                        break;
                    default:
                        superChef.character = "Astronaut";
                        break;
                }
            }
            superChef.dataloaded = true;
        }
    }

    public IEnumerator UpdateChild(string PK_Child, string Name, string Surname, string Score1, string Score2, string Score3, string Score4, string Score5, string Niveau, string Level, string FK_Character)
    {

        Debug.Log("UpdateChild");

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


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity/UpdateChild.php", form))
        {
         
            yield return www.SendWebRequest();
            Debug.Log("DB2");
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
