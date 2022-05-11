using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using Firebase;
using Firebase.Extensions;
using Firebase.Database;

[System.Serializable]

public class CamData
{
    public float cameraPosX;
    public float cameraPosY;
    public float cameraPosZ;

    public float cameraVecX;
    public float cameraVecY;
    public float cameraVecZ;

     public CamData (Cam cam){
         cameraPosX = cam.cameraPosX;
         cameraPosY = cam.cameraPosY;
         cameraPosZ = cam.cameraPosZ;

         cameraVecX = cam.cameraVecX;
         cameraVecY = cam.cameraVecY;
         cameraVecZ = cam.cameraVecZ;
     }
}
