using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    Vector2 velocity;
    Vector2 frameVelocity;


    DatabaseReference reference;
    [SerializeField] float velocityY;
    [SerializeField] float vecRightX;
    [SerializeField] float vecRightY;
    [SerializeField] float vecRightZ;
    [SerializeField] float velocityX;
    [SerializeField] float vecUpX;
    [SerializeField] float vecUpY;
    [SerializeField] float vecUpZ;

     float velocityYkopie;
     float vecRightXkopie;
     float vecRightYkopie;
     float vecRightZkopie;
     float velocityXkopie;
     float vecUpXkopie;
     float vecUpYkopie;
     float vecUpZkopie;

    private string speicherVelY;
    private string speicherRightX;
    private string speicherRightY;
    private string speicherRightZ;
    private string speicherVelX;
    private string speicherUpX;
    private string speicherUpY;
    private string speicherUpZ;

    public KeyCode space = KeyCode.Space;

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
        reference = FirebaseDatabase.DefaultInstance.RootReference;  

    }

    void Update()
    {
        


        if(Input.GetKey(space))
        {


            reference.Child("Body").Child("Look").Child("velocityY").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    speicherVelY = snapshot.Value.ToString();
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            //velocityYkopie = float.Parse(speicherVelY);
            velocityYkopie = float.Parse(speicherVelY);

            reference.Child("Body").Child("Look").Child("velocityX").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    speicherVelX = snapshot.Value.ToString();
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            velocityXkopie = float.Parse(speicherVelX);


            reference.Child("Body").Child("Look").Child("vecRightX").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    speicherRightX = snapshot.Value.ToString();
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            vecRightXkopie = float.Parse(speicherRightX);

            reference.Child("Body").Child("Look").Child("vecRightY").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    speicherRightY = snapshot.Value.ToString();
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            vecRightYkopie = float.Parse(speicherRightY);

            reference.Child("Body").Child("Look").Child("vecRightZ").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    speicherRightZ = snapshot.Value.ToString();
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            vecRightZkopie = float.Parse(speicherRightZ);

            reference.Child("Body").Child("Look").Child("vecUpX").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    speicherUpX = snapshot.Value.ToString();
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            vecUpXkopie = float.Parse(speicherUpX);

            reference.Child("Body").Child("Look").Child("vecUpY").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    speicherUpY = snapshot.Value.ToString();
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            vecUpYkopie = float.Parse(speicherUpY);

            reference.Child("Body").Child("Look").Child("vecUpZ").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    speicherUpZ = snapshot.Value.ToString();
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            vecUpZkopie = float.Parse(speicherUpZ);

            // Get smooth velocity.
            // Rotate camera up-down and controller left-right from velocity.
            transform.localRotation = Quaternion.AngleAxis(-velocityYkopie, new Vector3(vecRightXkopie, vecRightYkopie, vecRightZkopie));
            character.localRotation = Quaternion.AngleAxis(velocityXkopie, new Vector3(vecUpXkopie, vecUpYkopie, vecUpZkopie));


        }
        else{

            // Get smooth velocity.
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
            frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
            velocity += frameVelocity;
            velocity.y = Mathf.Clamp(velocity.y, -90, 90);

            // Rotate camera up-down and controller left-right from velocity.
            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);

            velocityY = velocity.y;
            vecRightX = Vector3.right.x;
            vecRightY = Vector3.right.y;
            vecRightZ = Vector3.right.z;
            velocityX = velocity.x;
            vecUpX = Vector3.up.x;
            vecUpY = Vector3.up.y;
            vecUpZ = Vector3.up.z;

            reference.Child("Body").Child("Look").Child("velocityY").SetValueAsync(velocityY.ToString());
            reference.Child("Body").Child("Look").Child("vecRightX").SetValueAsync(vecRightX.ToString());
            reference.Child("Body").Child("Look").Child("vecRightY").SetValueAsync(vecRightY.ToString());
            reference.Child("Body").Child("Look").Child("vecRightZ").SetValueAsync(vecRightZ.ToString());
            reference.Child("Body").Child("Look").Child("velocityX").SetValueAsync(velocityX.ToString());
            reference.Child("Body").Child("Look").Child("vecUpX").SetValueAsync(vecUpX.ToString());
            reference.Child("Body").Child("Look").Child("vecUpY").SetValueAsync(vecUpY.ToString());
            reference.Child("Body").Child("Look").Child("vecUpZ").SetValueAsync(vecUpZ.ToString());

        }

        
        
    }
}
