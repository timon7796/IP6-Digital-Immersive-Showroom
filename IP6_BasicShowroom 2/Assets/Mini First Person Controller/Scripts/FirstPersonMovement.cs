using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class FirstPersonMovement : MonoBehaviour
{
    private float speed = 5;

    DatabaseReference reference;
    [SerializeField] private float rigidbodyX;
    [SerializeField] private float rigidbodyY;
    [SerializeField] private float rigidbodyZ;

    private float rigidbodyXkopie;
    private float rigidbodyYkopie;
    private float rigidbodyZkopie;

    private string speicherX;
    private string speicherY;
    private string speicherZ;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    public KeyCode space = KeyCode.Space;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

     void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;  
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

      //Listen if spacebar is pressed
     if(Input.GetKey(space))
        {
            
            /* Getting the value of the rigidbodyX from the database and storing it in a variable. */
            reference.Child("Body").Child("Position").Child("rigidbodyX").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    speicherX = snapshot.Value.ToString();
                    
                }
                else
                {
                    Debug.Log("not retrived");  
                }
            
            }); 
            rigidbodyXkopie = float.Parse(speicherX); 
            
            /* Getting the value of the rigidbodyY from the database and storing it in a variable. */
            reference.Child("Body").Child("Position").Child("rigidbodyY").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    speicherY = snapshot.Value.ToString();
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            rigidbodyYkopie = (float)float.Parse(speicherY);

           /* Getting the value of the rigidbodyZ from the database and storing it in a variable. */
            reference.Child("Body").Child("Position").Child("rigidbodyZ").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    speicherZ = snapshot.Value.ToString();
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            rigidbodyZkopie = float.Parse(speicherZ);
            
            // Apply movement.
            rigidbody.velocity = transform.rotation * new Vector3(rigidbodyXkopie, rigidbodyYkopie, rigidbodyZkopie);
        }

        else

        {
            // Get targetVelocity from input.
           Vector2 targetVelocity = new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

           
           /* Getting the position of the rigidbody and storing it in a variable. */
            rigidbodyX = GameObject.Find("First Person Controller Minimal").transform.position.x;
            rigidbodyY = GameObject.Find("First Person Controller Minimal").transform.position.y;
            rigidbodyZ = GameObject.Find("First Person Controller Minimal").transform.position.z;
            
            /* Pushing the position of the rigidbody to the database. */
            reference.Child("Body").Child("Position").Child("rigidbodyX").SetValueAsync(rigidbodyX);
            reference.Child("Body").Child("Position").Child("rigidbodyY").SetValueAsync(rigidbodyY);
            reference.Child("Body").Child("Position").Child("rigidbodyZ").SetValueAsync(rigidbodyZ);

         

            // Apply movement.
            rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
        }
        
    }
}