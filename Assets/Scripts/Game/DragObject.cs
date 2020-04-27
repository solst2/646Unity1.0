using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragObject : MonoBehaviour
{
    //Attributes
    private Vector3 mOffset;
    private Vector3 positionBase;
    private float mZCoord;
    public GameObject correct;

    //Select object
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    //Move object
    void OnMouseDrag()
    {
        //Set the position of the object to the Mouse position
        transform.position = GetMouseWorldPos() + mOffset;
    }

    //Place object
    void OnMouseUp()
    {
        float Distance = Vector3.Distance(this.transform.position, correct.transform.position);

        //Check if it is in the distance and it is the right object
        //"1" and "2" are for level 3 and the correct one in level 4 is number "3"
        if ((Distance < 20 && (this.transform.name.Equals("1"))|| (Distance < 50 && this.transform.name.Equals("2"))|| (Distance < 30 && this.transform.name.Equals("3"))))
        {
            if (this.transform.name.Equals("2"))
            {
                Level3.arm = true;
            }
            else
            {
                //in level 3 eyes and level 4 we use the eyes variable
                Level3.eyes = true;
            }
            Level3.sonBon1.Play();
            Debug.Log("Yeah");
            Destroy(gameObject);
            //show the correct object on the right place
            correct.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); 
        }
        else
        {
            //not right
            Level3.sonPasBon1.Play();
            Level3.wrongClicks = Level3.wrongClicks + 0.5;
            Debug.Log("no" + Distance);
            transform.position = positionBase;
            if (superChef.actualNiveau == 4)
            {
                StartCoroutine(waiterWrong());
            }
        }
    }
    
    IEnumerator waiterWrong()
    {
        Level3.smileRight1.SetActive(false);
        Level3.smile1.SetActive(true);
        Level3.sonPasBon1.Play();
        //Wait for 0.5 seconds
        yield return new WaitForSeconds(0.5f);
        Level3.smile1.SetActive(false);
        Level3.smileRight1.SetActive(true);

        //with niveau 4, we do the no part twice
        if (superChef.actualNiveau == 4)
        {
            Debug.Log("no part twice");
            yield return new WaitForSeconds(0.3f);
            Level3.smileRight1.SetActive(false);
            Level3.smile1.SetActive(true);
            Level3.sonPasBon1.Play();
            //Wait for 0.5 seconds
            yield return new WaitForSeconds(0.5f);
            Level3.smile1.SetActive(false);
            Level3.smileRight1.SetActive(true);
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
}
