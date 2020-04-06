using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RewardElements : MonoBehaviour
{
    public float delay = 3f;
    public GameObject cube;
    public Text next;
    int rewardCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", delay, delay);
        //next field
        next.text = changeLangage.names[changeLangage.setLanguage, 4];

    }

    private void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject) Destroy(gameObject);
            }
        }
        */

        /* for 3d
        //Look if the touch and the object is on the same position -> if yes detsroy element
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse2");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Mouse2.2");
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc != null)
                {
                    rewardCounter++;
                    Debug.Log(rewardCounter);
                }
            }
        }*/

        //10 destroyed Elements, go to nxt Scene
        if (rewardCounter == 4)
        {
            StartCoroutine(GoToNextSceneN());
            //SceneManager.LoadScene("ScorePage1");
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
        Instantiate(cube, new Vector3(Random.Range(-6, 6), 10, 0), Quaternion.identity);
    }
}
