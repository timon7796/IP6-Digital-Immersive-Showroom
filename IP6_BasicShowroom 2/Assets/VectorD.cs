using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class VectorD
{
    public Vector3 cameraPos;
    public Vector3 cameraVec;

     public VectorD (Vector vector){
         cameraPos = vector.cameraPos;
         cameraVec = vector.cameraVec;
        Debug.Log(cameraPos);
     }


}
