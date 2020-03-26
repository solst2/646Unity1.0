using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardElements : MonoBehaviour
{
    public float delay = 3f;
    public GameObject cube;
    int rewardCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", delay, delay);
        
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
        if (rewardCounter == 7)
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
