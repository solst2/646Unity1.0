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
        //Look if the touch and the object is on the same position -> if yes detsroy element
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc != null)
                {
                    rewardCounter++;
                    Debug.Log(rewardCounter);
                }
            }
        }

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
