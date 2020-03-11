using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject secondObject;
    public GameObject smileWrong;
    public Text scores;
    public GameObject background;
    int juste = 0;
    int rotate = 0;
    public static string color = "pink";
    int wrongClicks = 0;

    void Start()
    {
        //gameobjects activated
        smile.SetActive(true);
        smileRight.SetActive(false);
        barEmpty.SetActive(true);
        barFirst.SetActive(false); 
        smileWrong.SetActive(false);
        //get character color
        switch (superChef.character)
        {
            case "Astronaut":
                color = "blue";
                break;
            case "explorateur":
                color = "yellow";
                break;
            case "HuaYao_01":
                color = "pink";
                break;
            case "trainChief":
                color = "red";
                break;
            default:
                color = "blue";
                break;
        }
        //number of new level
        superChef.level++;
        //bars all deactivate, depends on caracter activate one
        for (int j = 0; j < 4; j++)
        {
            barEmpty.transform.GetChild(j).gameObject.SetActive(false);
        }
        barEmpty.transform.Find(color).gameObject.SetActive(true);
        //audio
        AudioSource[] audios = GetComponents<AudioSource>();
        sonBon = audios[0];
        sonPasBon = audios[1];
        //score field
        scores.text = "Score: " + superChef.score;
        //background
        background.GetComponent<Image>().color = superChef.background[color];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && rotate == 0)
        {

            //Destroy(gameObject);

            Debug.Log(superChef.character);
            if (juste == 0)
            {
                StartCoroutine(waiterWrong());
            }
            else
            {
                sonBon.Play();
                smile.SetActive(false);
                smileRight.SetActive(true);
                barEmpty.SetActive(false);
                jeans.SetActive(false);
                //if there is a second object to set false
                if (secondObject)
                {
                    secondObject.SetActive(false);
                }

                //set bar with 1 active in the right color
                barFirst.SetActive(true);
                for (int j = 0; j < 4; j++)
                {
                    barFirst.transform.GetChild(j).gameObject.SetActive(false);
                }
                barFirst.transform.Find(color).gameObject.SetActive(true);

                rotate = 1;

                //make the right image bigger
                transform.localScale += new Vector3(10, 10, 0);


                //Applique un délai pour changer de scène
                DOVirtual.DelayedCall(3, GoToNextScene);

                // Edit score
                if (wrongClicks ==0)
                {
                    superChef.score += 10;
                } 
                else if (wrongClicks <=5)
                {
                    superChef.score += 5;
                }
                else
                {
                    superChef.score += 2;
                }
                scores.text = "Score: " + superChef.score;
            }

        }
        if (rotate == 1)
        {
            transform.Rotate(0, 3, 0);
        }

    }

    IEnumerator waiterWrong()
    {
        smile.SetActive(false);
        smileWrong.SetActive(true);
        sonPasBon.Play();
        //Wait for 4 seconds
        yield return new WaitForSeconds(0.5f);
        smileWrong.SetActive(false);
        smile.SetActive(true);

        wrongClicks++;
    }

    //méthode pour changer de scène
    void GoToNextScene()
    {
        SceneManager.LoadScene("Reward"+ superChef.level);
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
