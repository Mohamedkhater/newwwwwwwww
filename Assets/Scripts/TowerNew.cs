using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class TowerNew : MonoBehaviour {
    public GameObject []disks=new GameObject[7];
    
    public Vector3[][] path = new Vector3[7][];
    
	private float[] sources = new float[7];
	private float[] destins = new float[7];
    private int i = 0;
    public Button bb;
    public Text buttontext;
    public Canvas mycanvas;
  
    
    
    void towers(int n, float source , float dest, float temp)
    {
      
        if (n == 1)
        {
            
            sources[i] = source;
            
            destins[i] = dest;
            i++;

        }
        else
        {
            towers(n - 1, source, temp, dest);
            towers(1, source, dest, temp);
            towers(n - 1, temp, dest, source);
        }
    }
   
	// Use this for initialization
	void Start () {
    
        towers(3, 0, 20, 10);


        for (int i = 0; i < 7; i++)
        {
            path[i] = new Vector3[3];
            for (int j = 0; j < 3; j++)
            {
                path[i][j].x = 0;
                path[i][j].y = 10;


            }
            path[i][0].y = 10;
            path[i][1].y = 10;
            
            path[i][2].z = destins[i];
            path[i][1].z = path[i][2].z;
            path[i][0].z = sources[i];

        }
        path[0][2].y = 1;
        path[1][2].y = 1;
        path[2][2].y = 2;
        path[3][2].y = 1;
        path[4][2].y = 1;
        path[5][2].y = 2;
        path[6][2].y = 3;
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                print(" X");

                print(path[i][j].x);
                print(" Y");


                print(path[i][j].y);
                print(" Z");


                print(path[i][j].z);
                

            }
            
        }




    }

    int currentDisk = 0;
    int j = 0;
    private float speed = 0.1f;
    public Text tee;
    public void replay()
    {
        
        SceneManager.LoadScene("towersScene");
        print(Application.platform);
        

        /* disks[0].transform.position = new Vector3(0.0f,3.0f,0.0f);
         disks[1].transform.position = new Vector3(0.0f,2.0f,0.0f);
         disks[2].transform.position = new Vector3(0.0f,1.0f,0.0f);*/
      



    }

    public void changeSpeed(float newspeed)
    {
        speed = newspeed;
        tee.fontSize = 40;
        tee.text = "speed: " + System.Convert.ToString(newspeed);


    }
    private Vector3 tempVect;
    // Update is called once per frame
    void Update () {
       /* if (Input.GetKeyDown(KeyCode.E))
        {
            if(mycanvas.enabled==false)
                mycanvas.enabled = true;
            else

                mycanvas.enabled = false;
        }*/
        
      //  bb.onClick.AddListener(replay);
        
        if (currentDisk >= 7)
        {
            speed = 0.0f;
        }
        else
        {

            if (disks[currentDisk].transform.position != new Vector3(path[currentDisk][j].x, path[currentDisk][j].y, path[currentDisk][j].z))
            {
                disks[currentDisk].gameObject.transform.position = Vector3.MoveTowards(disks[currentDisk].gameObject.transform.position, new Vector3(path[currentDisk][j].x, path[currentDisk][j].y, path[currentDisk][j].z), speed);

            }
            else
            {
                j = (j + 1) % 3;
                if (j == 0)
                {
                    currentDisk++;

                }
            }

        }
       
		
	}
}
