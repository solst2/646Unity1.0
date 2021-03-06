﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionRewardElement : MonoBehaviour
{
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Destroy(gameObject);
                    create(gameObject);
                    sound.Play();
                }
  
            }
        }

        /*
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
                    Destroy(bc.gameObject);
                    create(bc.gameObject);
                    sound.Play();

                }
            }
        }
        */


        //Destroy object after 4seconds
        Object.Destroy(gameObject, 4.0f);
    }

    //Create at this position new stars
    private void create(GameObject element)
    {
        element.gameObject.transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f);
        Instantiate(element, element.transform.position, Quaternion.identity);
        Debug.Log("Erstellt");
    }
}

