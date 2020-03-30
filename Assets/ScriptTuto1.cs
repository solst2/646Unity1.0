using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ScriptTuto1 : MonoBehaviour
{
    public static int tutoplayed = 0;

    // Start is called before the first frame update
    void Start()
    {
        DOVirtual.DelayedCall(5, GoToNextScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToNextScene()
    {
        tutoplayed = 1;
        SceneManager.LoadScene("Level1_1");
    }
}
