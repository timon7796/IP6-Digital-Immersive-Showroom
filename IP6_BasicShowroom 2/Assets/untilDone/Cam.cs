using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using Firebase;
using Firebase.Extensions;
using Firebase.Database;

public class Cam : MonoBehaviour
{
    public float cameraPosX;
    public float cameraPosY;
    public float cameraPosZ;
    public float cameraVecX;
    public float cameraVecY;
    public float cameraVecZ;


    public void SaveCamera(){
        
    }

    private void Update(){
        cameraPosX = Camera.main.transform.position.x;
        cameraPosY = Camera.main.transform.position.y;
        cameraPosZ = Camera.main.transform.position.z;

        cameraVecX = Camera.main.transform.forward.x;
        cameraVecY = Camera.main.transform.forward.y;
        cameraVecZ = Camera.main.transform.forward.z;

        Debug.Log(cameraPosX);

        SaveCamera();
    }
}
