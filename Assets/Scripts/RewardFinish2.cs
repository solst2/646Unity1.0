using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RewardFinish2 : MonoBehaviour
{

    public GameObject element;
    public AudioSource sound;
    public Text next;
    public float delay = 3f;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", delay, delay);
        //next field
        next.text = changeLangage.names[changeLangage.setLanguage, 4];
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("left mouse");
            count++;
            Vector3 mousePosition = Input.mousePosition;
            sound.Play();
            mousePosition.z = 10;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            System.Random r = new System.Random();
            Instantiate(element, mousePosition, Quaternion.identity);
            mousePosition.x += r.Next(0, 5);
            Instantiate(element, mousePosition, Quaternion.identity);
            mousePosition.x -= r.Next(0, 5);
            Instantiate(element, mousePosition, Quaternion.identity);
            mousePosition.y -= r.Next(0, 5);
            mousePosition.x += r.Next(0, 5);
            Instantiate(element, mousePosition, Quaternion.identity);
            mousePosition.y += r.Next(0, 5);
            Instantiate(element, mousePosition, Quaternion.identity);
            Debug.Log("Erstellt");
        }

        if (count >= 10)
        {
            StartCoroutine(GoToNextSceneN());
        }
    }

    IEnumerator GoToNextSceneN()
    {
        //Wait for seconds
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("ScorePage1");
    }

    //Create new Vector
    void Spawn()
    {
        Instantiate(element, new Vector3(Random.Range(-6, 6), 10, 0), Quaternion.identity);
    }
}
