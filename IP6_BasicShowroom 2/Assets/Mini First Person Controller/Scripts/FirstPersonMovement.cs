using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    DatabaseReference reference;
    [SerializeField] float rigidbodyX;
    [SerializeField] float rigidbodyY;
    [SerializeField] float rigidbodyZ;

    float rigidbodyXkopie;
    float rigidbodyYkopie;
    float rigidbodyZkopie;

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

        if(Input.GetKey(space))

        {

            reference.Child("Body").Child("Position").Child("rigidbodyX").GetValueAsync().ContinueWith(task =>
            {
            if(task.IsCompleted)
            {
                //Debug.Log("retrived");
                DataSnapshot snapshot = task.Result;
                //Debug.Log(snapshot.Value.ToString());
                speicherX = snapshot.Value.ToString();
                
            }
            else
            {
                Debug.Log("not retrived");
            }
            
            }); 
            rigidbodyXkopie = float.Parse(speicherX);

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
            rigidbodyYkopie = float.Parse(speicherY);

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
        //rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
            rigidbody.velocity = transform.rotation *  new Vector3(rigidbodyXkopie, rigidbodyYkopie, rigidbodyZkopie);

            Debug.Log("Kopie X" + rigidbodyXkopie);
            Debug.Log("Kopie Y" + rigidbodyXkopie);
            Debug.Log("Kopie Z" + rigidbodyXkopie);

        }

        else

        {
            // Get targetVelocity from input.
            Vector2 targetVelocity = new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

            rigidbodyX = targetVelocity.x;
            rigidbodyY = rigidbody.velocity.y;
            rigidbodyZ = targetVelocity.y;

            reference.Child("Body").Child("Position").Child("rigidbodyX").SetValueAsync(rigidbodyX.ToString());
            Debug.Log("string X: " + rigidbodyX.ToString());
            reference.Child("Body").Child("Position").Child("rigidbodyY").SetValueAsync(rigidbodyY.ToString());
            Debug.Log("string Y: " + rigidbodyY.ToString());
            reference.Child("Body").Child("Position").Child("rigidbodyZ").SetValueAsync(rigidbodyZ.ToString());
            Debug.Log("string Z: " + rigidbodyZ.ToString());

            // Apply movement.
            rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
            //rigidbody.velocity = transform.rotation *  new Vector3(rigidbodyX, rigidbodyY, rigidbodyZ);
        }
        
    }
}