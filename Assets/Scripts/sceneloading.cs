using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneloading : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            SceneManager.LoadScene("LAB");

        }
        else if (other.CompareTag("door_01"))
        {
            SceneManager.LoadScene("Classroom");

        }
    }

}