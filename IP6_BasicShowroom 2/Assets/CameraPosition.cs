using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CameraPosition : MonoBehaviour
{
    public float cameraPosX;
    public float cameraPosY;
    public float cameraPosZ;
    public float cameraVecX;
    public float cameraVecY;
    public float cameraVecZ;
    // Update is called once per frame
    void Update()
    {
        cameraPosX = transform.position.x;
        cameraPosY = Camera.main.transform.position.y;
        cameraPosZ = Camera.main.transform.position.z;

        cameraVecX = Camera.main.transform.forward.x;
        cameraVecY = Camera.main.transform.forward.y;
        cameraVecZ = Camera.main.transform.forward.z;
            
         Debug.Log("Pos X" + cameraPosX);
        // Debug.Log("Pos Y" + cameraPosY);
        // Debug.Log("Pos Z" + cameraPosZ);
        // Debug.Log("Vec X" + cameraVecX);
        // Debug.Log("Vec Y" + cameraVecY);
        // Debug.Log("Vec Z" + cameraVecZ);



        
        
    } 

}


