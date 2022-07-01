using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class klappe_heck : MonoBehaviour
{
    DatabaseReference reference;
    private Quaternion startQuaternion;
    private float lerpTime = 1;
    private float RotateAmount = 70.27f;
    private float count= 0f;
    private float speed = 0.1f;
    private string eulerAngelX;
    private float rotationX;

    private string eulerAngelY;
    private float rotationY;

    private string eulerAngelZ;
    private float rotationZ;

    private bool isOpen;
    private string isOpenFetched;
    public KeyCode space = KeyCode.Space;
    private Rigidbody rb;

  

    private float position;

    bool keyTwoIsPressed;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        startQuaternion = transform.rotation;
        reference = FirebaseDatabase.DefaultInstance.RootReference;  
         reference.Child("Body").Child("Animation").Child("heckKlappeRotationX").SetValueAsync("");
            reference.Child("Body").Child("Animation").Child("heckKlappeRotationY").SetValueAsync("");
            reference.Child("Body").Child("Animation").Child("heckKlappeRotationZ").SetValueAsync(""); 
    }
 
    // Update is called once per frame
    void Update() {   

        if(Input.GetKey(space)){
           reference.Child("Body").Child("Animation").Child("heckKlappeRotationX").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    eulerAngelX = snapshot.Value.ToString();
                    Debug.Log("euler X " +eulerAngelX);
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            rotationX = float.Parse(eulerAngelX);

            reference.Child("Body").Child("Animation").Child("heckKlappeRotationY").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    eulerAngelY = snapshot.Value.ToString();
                    Debug.Log("euler Y " +eulerAngelY);
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            rotationY = float.Parse(eulerAngelY);

            reference.Child("Body").Child("Animation").Child("heckKlappeRotationZ").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    eulerAngelZ = snapshot.Value.ToString();
                    Debug.Log("euler Z " +eulerAngelZ);
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            rotationZ = float.Parse(eulerAngelZ);

            transform.localEulerAngles = new Vector3(rotationX, rotationY, rotationZ);
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                keyTwoIsPressed = true;
            }

            if((count % 2f == 0) && keyTwoIsPressed){
                transform.localEulerAngles = new Vector3(0f, 24.76f, -1.6f);
                count++;
                keyTwoIsPressed = false;
                isOpen = false;
            }
            else if(keyTwoIsPressed)
            {
                transform.localEulerAngles = new Vector3(0f, 24.76f, -91.65f);
                count++;
                keyTwoIsPressed = false;
                isOpen = true;
            }    

            reference.Child("Body").Child("Animation").Child("heckKlappeRotationX").SetValueAsync(transform.eulerAngles.x.ToString());
            reference.Child("Body").Child("Animation").Child("heckKlappeRotationY").SetValueAsync(transform.eulerAngles.y.ToString());
            reference.Child("Body").Child("Animation").Child("heckKlappeRotationZ").SetValueAsync(transform.eulerAngles.z.ToString()); 

        }
                
    }
}
