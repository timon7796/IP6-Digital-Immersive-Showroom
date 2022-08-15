using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class drawer_animation : MonoBehaviour
{

    DatabaseReference reference;
    private float movementSpeed = 10f;
    private float count= 0f;
    private bool keyOneIsPressed;

    private string positionX;
    private string positionZ;

    private float rotationX;
    private float rotationZ;

    public KeyCode space = KeyCode.Space;
 
    private Rigidbody rb;
    private Vector3 endPosition = new Vector3(382.1877f, 1.145f, 109.9784f);
    private Vector3 startPosition = new Vector3(381.179f, 1.145f, 110.474f);
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

            Vector3 newPosition = new Vector3(rotationX, 1.146f, rotationZ);
            rb.MovePosition(newPosition);
        }
        /* This is the code that is used to move the drawer back and forth. */
        else{

            /* This is checking if the key 1 is pressed. If it is pressed, then the keyOneIsPressed is
            set to true. */
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                keyOneIsPressed = true;
            }

            /* This is checking if the count is even and if the keyOneIsPressed is true. If it is true,
            then the drawer will move to the endPosition. */
            if((count % 2f == 0) && keyOneIsPressed){
                if(rb.position != endPosition) {
                    Vector3 newPosition = Vector3.MoveTowards(rb.position, endPosition, movementSpeed);
                    rb.MovePosition(newPosition);
                    count++;
                    keyOneIsPressed = false;
                }
            }   
            /// <summary>
            /// If the player presses the key that corresponds to the first position, the player will
            /// move to the first position
            /// </summary>
            /// <param name="keyOneIsPressed">This is a boolean that is set to true when the player
            /// presses the key.</param>
            else if(keyOneIsPressed)
            {
                /* This is checking if the position of the drawer is not equal to the startPosition. If
                it is not equal, then the drawer will move to the startPosition. */
                if(rb.position != startPosition) {
                    Vector3 newPosition = Vector3.MoveTowards(rb.position, startPosition, movementSpeed);
                    rb.MovePosition(newPosition);
                    count++;
                    keyOneIsPressed = false;
                }

              
            }  
            /* This is setting the value of the drawerPositionX and drawerPositionZ to the position of
            the drawer. */
            reference.Child("Body").Child("Animation").Child("drawerPositionX").SetValueAsync(rb.position.x.ToString());
            reference.Child("Body").Child("Animation").Child("drawerPositionZ").SetValueAsync(rb.position.z.ToString()); 
        }
    }   
}
 