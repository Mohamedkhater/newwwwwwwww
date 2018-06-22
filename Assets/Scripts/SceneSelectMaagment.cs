using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSelectMaagment : MonoBehaviour {

	
    public void SelectScene()
    {
        switch(this.gameObject.name)
        {
            case "btn_teacher_login":
                SceneManager.LoadScene("Login");
                break;
            case "btn_student_login":
                SceneManager.LoadScene("Login");
                break;
            case "btn_signup":
                SceneManager.LoadScene("Login");
                break;
        }
    }
}
