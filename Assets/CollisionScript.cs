using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
//[RequireComponent(typeof(anyscript))]

public class CollisionScript : MonoBehaviour {
    private float t;
    private float hours;
    private float seconds;
    private float minutes;
    private float temp;
    private float seconds2;
    private Text timerText;
    private List<GameObject> mylist=new List<GameObject>();

    
    

  //  private int n = 0;
    private Vector3[] initpos = new Vector3[3];

	// Use this for initialization
	void Start () {
      /*  initpos[0] = GameObject.Find("disk1").transform.position;
        initpos[1] = GameObject.Find("disk2").transform.position;
        initpos[2] = GameObject.Find("disk2").transform.position;*/
        if( gameObject.name== "Iron_Rod")
        {
            GetComponent<BoxCollider>().isTrigger = false;
        }



    }
    private void OnCollisionEnter(Collision collision)
    {
       /* if (!mylist.Contains(collision.gameObject))
        {
            mylist.Add(collision.gameObject);
            Debug.Log("In our list: "+ collision.gameObject);
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        mylist.Add(other.gameObject);
        Debug.Log("added: "+other.gameObject.name);
        
    }
    private void OnTriggerStay(Collider other)
    {
        
         //   if (other.transform.position != initpos[0] && other.transform.position!=initpos[1] &&  other.transform.position!=initpos[2])
          //  {
              //  n++;
            //    Debug.Log(n);
                //other.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
           /*     if (anyscript.isDraged)
        {
            other.GetComponent<Renderer>().material.color = Color.cyan;


        }*/
        //  }



        /*  if (n >= 7)
          {
              Debug.Log("the game should ends now");
          }*/

    }
    private void OnTriggerExit(Collider other)
    {
        //other.GetComponent<Renderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update () {
        timerText= GameObject.FindGameObjectWithTag("timer").GetComponent<Text>();
        t = Time.time;
        hours = t / (60 * 60);
        temp = t % (60 * 60);
        minutes = temp / 60;
        seconds = temp % 60;
        
       
        timerText.text =Convert.ToString((int)hours)+" : " + Convert.ToString((int)minutes)+" : "+ Convert.ToString((int)seconds);
        
        
       
      //  Debug.Log((int)hours +" : "+ (int)minutes+" : " + (int)seconds);

		
	}
}
