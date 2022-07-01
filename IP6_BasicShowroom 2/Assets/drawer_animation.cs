using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class drawer_animation : MonoBehaviour
{

    DatabaseReference reference;
    public float movementSpeed = 0.001f;
    private float count= 0f;
    private bool keyOneIsPressed;

    private string positionX;
    private string positionZ;

    private float rotationX;
    private float rotationZ;

    public KeyCode space = KeyCode.Space;
 
    private Rigidbody rb;
    private Vector3 endPosition = new Vector3(382.7423f, 1.485f, 109.136f);
    private Vector3 startPosition = new Vector3(381.877f, 1.485f, 109.512f);
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        reference = FirebaseDatabase.DefaultInstance.RootReference;  
    }
 
    // Update is called once per frame
    void Update() {

        if(Input.GetKey(space)){
           reference.Child("Body").Child("Animation").Child("drawerPositionX").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    positionX = snapshot.Value.ToString();
                    Debug.Log("position X " +positionX);
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            rotationX = float.Parse(positionX);

            reference.Child("Body").Child("Animation").Child("drawerPositionZ").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    positionZ = snapshot.Value.ToString();
                     Debug.Log("position Z " + positionZ);
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            rotationZ = float.Parse(positionZ);

            Vector3 newPosition = new Vector3(rotationX, 1.485f, rotationZ);
            rb.MovePosition(newPosition);
        }
        else{

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
            reference.Child("Body").Child("Animation").Child("drawerPositionX").SetValueAsync(rb.position.x.ToString());
            reference.Child("Body").Child("Animation").Child("drawerPositionZ").SetValueAsync(rb.position.z.ToString()); 
        }
    }   
}
 