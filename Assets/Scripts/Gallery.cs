using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gallery : MonoBehaviour
{
    public Texture2D pickedImage;

    public void PickImageFromGallery(int maxSize = 1024)
    {
        NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                // Create Texture from selected image
                pickedImage = NativeGallery.LoadImageAtPath(path, maxSize);
            }
        }, maxSize: maxSize);
    }
}
