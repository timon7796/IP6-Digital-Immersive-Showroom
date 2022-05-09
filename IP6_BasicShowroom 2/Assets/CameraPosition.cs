using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CameraPosition : MonoBehaviour
{
    public Vector3 cameraPos = new Vector3();
        public Vector3 cameraVec = new Vector3();
    // Update is called once per frame
    void Update()
    {
           cameraPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
           cameraVec = new Vector3(Camera.main.transform.forward.x, Camera.main.transform.forward.y, Camera.main.transform.forward.z);
            Debug.Log("Timon's Camera: " + cameraPos);
            Debug.Log("Camera Vector: " + cameraVec);
        
    } 

}


