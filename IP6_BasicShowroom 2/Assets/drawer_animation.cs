using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawer_animation : MonoBehaviour
{
    public float movementSpeed = 0.001f;
    private float count= 0f;
    private bool keyOneIsPressed;
 
    private Rigidbody rb;
    private Vector3 endPosition = new Vector3(382.7423f, 1.485f, 109.136f);
    private Vector3 startPosition = new Vector3(381.877f, 1.485f, 109.512f);
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }
 
    // Update is called once per frame
    void Update() {

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            keyOneIsPressed = true;
        }

        if((count % 2f == 0) && keyOneIsPressed){
            if(rb.position != endPosition) {
                Vector3 newPosition = Vector3.MoveTowards(rb.position, endPosition, movementSpeed);
                rb.MovePosition(newPosition);
                count++;
                keyOneIsPressed = false;
            }
        }
        else if(keyOneIsPressed)
        {
            if(rb.position != startPosition) {
                Vector3 newPosition = Vector3.MoveTowards(rb.position, startPosition, movementSpeed);
                rb.MovePosition(newPosition);
                count++;
                keyOneIsPressed = false;
            }
        }   
    }   
}
 