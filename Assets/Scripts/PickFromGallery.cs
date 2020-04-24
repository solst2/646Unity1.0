using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NativeGallery;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;



public class PickFromGallery : MonoBehaviour
{

    public Image image;
    public static string extentionName;

    void Start()
    {
        image.gameObject.SetActive(false);
    } 

    public void PickImage(int maxSize)
    {
        Debug.Log("Click");

        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
                image.gameObject.SetActive(true);

                Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                image.sprite = sprite;
                Debug.Log("The path is " + path);

                StartCoroutine(UploadFileCo(path,CreateChild.nameEnter, CreateChild.surnameEnter));

            }
        });
    }

    public IEnumerator UploadFileCo(string localFileName,string name, string surname)
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
        Debug.Log("localFile.bytes = " + localFile.bytes);
        Debug.Log("localFileName = " + localFileName);
        extentionName = localFileName.Substring(localFileName.Length - 4);
        postForm.AddBinaryData("theFile", localFile.bytes, name+surname+ localFileName.Substring(localFileName.Length - 4), "text/plain");
        WWW upload = new WWW("https://attentionconjointe.p645.hevs.ch/UploadImage.php", postForm);
        yield return upload;
        if (upload.error == null)
            Debug.Log("upload done :" + upload.text);
        else
            Debug.Log("Error during upload: " + upload.error);

    }

    /* void UploadFile(string localFileName, string uploadURL)
     {
         StartCoroutine(UploadFileCo(localFileName, uploadURL));
     }*/
    /* void OnGUI()
     {
         GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
         m_LocalFileName = GUILayout.TextField(m_LocalFileName);
         m_URL = GUILayout.TextField(m_URL);
         if (GUILayout.Button("Upload"))
         {
             UploadFile(m_LocalFileName, m_URL);
         }
         GUILayout.EndArea();
     }*/
}
