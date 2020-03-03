using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //if astronaut -> 2
    //if explorer -> 1
    //if fairy -> 3
    //if train -> 4
    public static int character;


    public GameObject astronaut;
    public GameObject explorer;
    public GameObject fairy;
    public GameObject train;

    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;

                if (bc != null)
                {
                    string name = bc.gameObject.name;
                    Debug.Log(name);
                }
            }
        }*/
        
    }
}
