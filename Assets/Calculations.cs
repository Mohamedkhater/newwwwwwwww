using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculations : MonoBehaviour {
    public List<GameObject> disksAsColliders;
    private int n = 0;

	// Use this for initialization
	void Start () {
        disksAsColliders = new List<GameObject>();
        
		
	}
    private void OnTriggerEnter(Collider other)
    {
        n++;
        other.GetComponent<Renderer>().material.color = Color.cyan;
        disksAsColliders.Add(other.gameObject);
        Debug.Log("current capacity: "+disksAsColliders.Capacity);
        
            Debug.Log("fe elgoal: "+ n);
        if (n == 3)
        {
            Debug.Log("GameOver!");
            FindObjectOfType<AudioManager>().Stop("Tribal Rumble");

            FindObjectOfType<AudioManager>().Play("Game Over");
            Destroy(this.gameObject);
            
            
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
       
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        n--;
        Debug.Log("felgoal"+n);
        disksAsColliders.Remove(other.gameObject);
        Debug.Log(disksAsColliders.Capacity);
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
