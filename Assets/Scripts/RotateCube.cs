using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class RotateCube : MonoBehaviour
{
    public AudioSource sonBon;
    public AudioSource sonPasBon;
    public GameObject smile;
    public GameObject smileRight;
    public GameObject barEmpty;
    public GameObject barFirst;
    public GameObject jeans;
    int juste = 0;
    int rotate = 0;

    void Start()
    {
        smile.SetActive(true);
        smileRight.SetActive(false);
        barEmpty.SetActive(true);
        barFirst.SetActive(false);

        AudioSource[] audios = GetComponents<AudioSource>();
        sonBon = audios[0];
        sonPasBon = audios[1];

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && rotate == 0)
        {

            //Destroy(gameObject);
            Debug.Log("click");

            if (juste == 0)
            {
                sonPasBon.Play();
            }
            else
            {
                sonBon.Play();
                smile.SetActive(false);
                smileRight.SetActive(true);
                barEmpty.SetActive(false);
                barFirst.SetActive(true);
                jeans.SetActive(false);

                rotate = 1;


                //Applique un délai pour changer de scène
                DOVirtual.DelayedCall(3, GoToNextScene);
            }

        }
        if (rotate == 1)
        {
            transform.Rotate(0, 3, 0);
        }

    }

    //méthode pour changer de scène
    void GoToNextScene()
    {
        SceneManager.LoadScene("Reward1");
    }

    void OnMouseOver()
    {
        juste = 1;
    }

    void OnMouseExit()
    {
        juste = 0;
    }
}
