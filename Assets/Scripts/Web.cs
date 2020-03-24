using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetUsers());
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

    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
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
                Main.Instance.TeacherInfo.SetCredentials(username, password);
                Main.Instance.TeacherInfo.SetTeacherID(www.downloadHandler.text);

                if (www.downloadHandler.text.Contains("Wrong Credentials") || www.downloadHandler.text.Contains("Username does not exist"))
                {
                    Debug.Log("TryAgain");
                }
                else {
                    //If we logged in correctly
                    Main.Instance.TeacherProfile.SetActive(true);
                    Main.Instance.Login.gameObject.SetActive(false);
                }
            }
        }
    }

    /*public IEnumerator RegisterTeacher(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
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
                Debug.Log(www.downloadHandler.text);
            }
        }
    }*/

    public IEnumerator RegisterChild(string name, string surname, string fk_Character, string fk_Teacher)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("surname", surname);
        //form.AddField("fk_Character", fk_Character);
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
                Debug.Log(www.downloadHandler.text);
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
}
