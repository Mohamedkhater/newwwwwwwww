using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class anyscript : MonoBehaviour {

    private float distance=5f;
    Vector3 objPosition;
    Vector3 initpos;
    private int moveCount=0;
    public static bool isDraged = false;
    //  private GameObject temp;
    public  Camera cam1;
  

	// Use this for initialization
	void Start () {
        initpos = transform.position;
        
        Debug.Log(cam1.gameObject.name);




    }
    private void OnMouseDrag()
    {
        isDraged = true;
        
        
        /* Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y,1);
         Vector3 objectPosition = Camera.main.WorldToScreenPoint(mousePosition);
         transform.position = mousePosition;*/
        
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y,distance);
        //Debug.Log(mousePosition);
        objPosition = cam1.ScreenToWorldPoint(mousePosition);
       // Debug.Log(mousePosition);
        transform.position = objPosition;
    }
    private void OnMouseUp()
    {
       
       
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<AudioManager>().Play("Wood 5");

        if (isDraged)
        {
            


          //  Debug.Log(collision.gameObject.name);
            if (collision.gameObject.name == "floor")
            {
                Debug.Log("Wrong Position");


                Debug.Log("the collider name : " + collision.gameObject.name);
            }
            if (collision.gameObject.tag == "Grab" || collision.gameObject.tag=="roof")
            {/*
                if (temp != collision.gameObject)
                {
                    moveCount++;


                    temp = collision.gameObject;
                    Debug.Log("temp = " + temp.name);

                    Debug.Log("move count: " + moveCount);

                }*/
                
                
                
                if (collision.transform.localScale.magnitude < transform.localScale.magnitude && collision.gameObject.transform.position.y< transform.position.y )
                {
                    if (isDraged)
                    {
                        Debug.Log("Wrong move!");


                    }
                   

                }
            }

        }
       
        
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }

    // Update is called once per frame
    void Update () {
     


    }
    private void OnMouseDown()
    {
        //GetComponent<Renderer>().material.color=Color.yellow;
       // Debug.Log(Input.mousePosition);
    }
}
