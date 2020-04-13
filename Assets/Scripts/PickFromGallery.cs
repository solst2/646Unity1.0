using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NativeGallery;
using UnityEngine.UI;



public class PickFromGallery : MonoBehaviour
{

    public Image image;

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

            }
        });
    }
}
