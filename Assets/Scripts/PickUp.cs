using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class PickUp : MonoBehaviour {

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    private Vector2 touchpad;

    private GameObject player;


    private float sensitivityX = 1.5F;
    private Vector3 playerPos;

    //First thing to load
    private void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    private void FixedUpdate()
    {
        
       
    }

    //check if one collider is touching another

    private void OnTriggerStay(Collider col)
    {
        device = SteamVR_Controller.Input((int)trackedObject.index);

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("TOUCHED" + col.name);
            //stop physics 3shan msh m7tgenha ..we need our controller
            col.attachedRigidbody.isKinematic = true;
            col.gameObject.transform.SetParent(gameObject.transform);

        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            col.gameObject.transform.SetParent(null);
            col.attachedRigidbody.isKinematic = false;
            col.attachedRigidbody.useGravity = true;

            TossObject(col.attachedRigidbody);

        }

    }

   private void TossObject(Rigidbody rigidbody)
    {
        rigidbody.velocity = device.velocity;
        rigidbody.angularVelocity = device.angularVelocity;
    }
}
