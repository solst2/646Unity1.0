using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardFinish : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("start");
        StartCoroutine(waiterFinish());
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("Click");

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Juut");
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc != null)
                {
                    Destroy(bc.gameObject);
                }
            }
        }
    }
    
    IEnumerator waiterFinish()
    {
        Debug.Log("Wait 10 seconds");
        //Wait for 10 seconds
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("ScorePage1");
    }
}
