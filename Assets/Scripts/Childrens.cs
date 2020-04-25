using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class Childrens : MonoBehaviour
{

    Action<string> _createChildrensCallback;

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("json: " + jsonArrayString);
        //DefineCallback
        _createChildrensCallback = (jsonArrayString) => {
            Debug.Log("json: " + jsonArrayString);
            StartCoroutine(CreateChildrensRoutine(jsonArrayString));
        };

        CreateChildrens();
    }

    public void CreateChildrens() {
        string PK_Teacher = Main.Instance.TeacherInfo.PK_Teacher;
        StartCoroutine(Main.Instance.Web.GetChildrenIDs(PK_Teacher, _createChildrensCallback));
    }

    IEnumerator CreateChildrensRoutine(string jsonArrayString) {
        //Pasring json Array string as an array
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        for (int i = 0; i < jsonArray.Count; i++)
        {
            //Create local variables
            bool isDone = false;
            string PK_Child = jsonArray[i].AsObject["PK_Child"];
            JSONObject childInfoJson = new JSONObject();

            //Create a callback to get the information from web.cs
            Action<string> getChildInfoCallback = (childInfo) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(childInfo) as JSONArray;
                childInfoJson = tempArray[0].AsObject;
            };

            //Wait until WEb.cs calls the callback we passed as parameter
            StartCoroutine(Main.Instance.Web.GetChild(PK_Child, getChildInfoCallback));

            //Wait until the vallback is called from WEB
            yield return new WaitUntil(() => isDone == true);

            //Instantiate GameObject (item prefab)
            GameObject item = Instantiate(Resources.Load("Prefabs/Child") as GameObject);
            item.transform.SetParent(this.transform);
            item.transform.localScale = Vector3.one;
            item.transform.localPosition = Vector3.zero;

            //Fill Inromation
            item.transform.Find("Name").GetComponent<Text>().text = childInfoJson["Name"];
            item.transform.Find("Surname").GetComponent<Text>().text = childInfoJson["Surname"];
            item.transform.Find("Character").GetComponent<Text>().text = childInfoJson["Niveau"];
            
            //Fill language
            item.transform.Find("TextName").GetComponent<Text>().text = changeLangage.names[changeLangage.setLanguage, 6];
            item.transform.Find("TextNiveau").GetComponent<Text>().text = changeLangage.names[changeLangage.setLanguage, 0];
            item.transform.Find("PlayButton").GetComponent<Button>().GetComponentInChildren<Text>().text = changeLangage.names[changeLangage.setLanguage, 5];

            //Download Image
            String url = childInfoJson["Picture"];
            Image img = item.transform.Find("Image").GetComponent<Image>();
            WWW www = new WWW(url);
            yield return www;
            img.sprite = Sprite.Create(www.texture, new Rect(0f, 0f, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
            img.SetNativeSize();
            //Listener to the playButton
            item.transform.Find("PlayButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                playButton(PK_Child);
            });

            //do not destroy
            DontDestroyOnLoad(item);
            //continue to the next item

        }
    }

    public void playButton(string PK_Child) {
        SceneManager.LoadScene("ScorePage1");
        superChef.PK_Child = PK_Child;
    }

}
