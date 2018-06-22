using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testinput : MonoBehaviour
{

    public GameObject light;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("light"))
        {

            //   Debug.Log("YES");
            light.SetActive(!light.activeSelf);

        }
    }
}
