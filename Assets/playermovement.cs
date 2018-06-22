using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class playermovement : MonoBehaviour {
    private float speed=5f;
    public Camera cam;
    private Rigidbody rb;
    private float xmov;
    private float zmov;
    private Vector3 velocity=Vector3.zero;
    private Vector3 movhorizontal;
    private Vector3 movevertical;
    private float looksensitivity=1.6f;
    private Vector3 _rotation;
    private Vector3 camerarotation = Vector3.zero;
    

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }
       
	
	// Update is called once per frame
	void Update () {
        rb.MovePosition(rb.position + velocity* Time.fixedDeltaTime);
        /* transform.Translate(new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"))*Time.deltaTime* speed);
         transform.Rotate(new Vector3(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0f));*/
        float xrot = Input.GetAxisRaw("Mouse Y");
        float yrot = Input.GetAxisRaw("Mouse X");
            xmov = Input.GetAxisRaw("Horizontal");
            zmov = Input.GetAxisRaw("Vertical");
            movevertical = Vector3.forward * zmov;
            movhorizontal = Vector3.right * xmov;
            velocity = (movevertical + movhorizontal).normalized * speed;
         _rotation = new Vector3(0f,yrot, 0f)* looksensitivity;
        camerarotation = new Vector3(xrot,0f, 0f)*looksensitivity;
       
        

    }
   
    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity*Time.fixedDeltaTime);
        }
        rb.MoveRotation(rb.rotation*Quaternion.Euler(_rotation));
        cam.transform.Rotate(-camerarotation);
      

        
    }
    private void LateUpdate()
    {
       // cam = Camera.main;
        //cam.transform.position = cam.transform.position + (transform.position - transform.position)* Time.deltaTime;
        //  cam.transform.position = transform.position + new Vector3(0,2,-3);
       // cam.transform.Translate(new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"))* Time.deltaTime* speed);
        //cam.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f) * speed);
       // cam.transform.position = transform.position;
        
    }
}
