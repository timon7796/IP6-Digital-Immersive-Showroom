using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector : MonoBehaviour
{
    public Vector3 cameraPos = new Vector3();
    public Vector3 cameraVec = new Vector3();

    
    public void SaveVector(){
        SaveSystem.SaveVector(this);
    }

    private void Update()
    {
        cameraPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        cameraVec = new Vector3(Camera.main.transform.forward.x, Camera.main.transform.forward.y, Camera.main.transform.forward.z);
        
        SaveVector();

        //Debug.Log("Timon's Camera: " + cameraPos);
       

    }


       
}

