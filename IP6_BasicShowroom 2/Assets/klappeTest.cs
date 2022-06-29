using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klappeTest : MonoBehaviour
{

    private Quaternion startQuaternion;
    private float lerpTime = 1;
    private float RotateAmount = 70.27f;
    private float count= 0f;
    private float speed = 0.1f;
 
    private Rigidbody rb;
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        startQuaternion = transform.rotation;
    }
 
    // Update is called once per frame
    void Update() {
        if((count % 2f == 0) && Input.GetKeyDown(KeyCode.Alpha2)){
            transform.Rotate(Vector3.forward * RotateAmount, Space.Self);
            count++;
        }
         else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.Rotate(Vector3.forward * -RotateAmount) ;
            count++;
        }
    }
}
