using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardFinish : MonoBehaviour
{

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
}
