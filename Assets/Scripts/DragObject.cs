using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private Vector3 positionBase;
    private float mZCoord;
    public GameObject correct;


    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    void OnMouseUp()
    {
        float Distance = Vector3.Distance(this.transform.position, correct.transform.position);

        if (Distance < 20 && (this.transform.name.Equals("1")|| this.transform.name.Equals("2")))
        {
            if (this.transform.name.Equals("1"))
            {
                Level3.eyes = true;
            }
            else
            {
                Level3.arm = true;
            }
            Level3.sonBon1.Play();
            Debug.Log("Yeah");
            Destroy(gameObject);
            correct.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); 
        }
        else
        {
            Level3.sonPasBon1.Play();
            Level3.wrongClicks = Level3.wrongClicks + 0.5;
            Debug.Log("no"+Distance);
            transform.position = positionBase;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    

    // Start is called before the first frame update
    void Start()
    {
        //Register the base position
        positionBase = gameObject.transform.position;

        //At the start we hide the correct eyes
        correct.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
