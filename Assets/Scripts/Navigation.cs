using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{

    //Back to the Character Scene
    public void BackButton()
    {
        superChef.level = 0;
        SceneManager.LoadScene("Character");
    }
}
