using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ScriptTuto1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOVirtual.DelayedCall(7, GoToNextScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToNextScene()
    {
        SceneManager.LoadScene("Level1_1");
    }
}
