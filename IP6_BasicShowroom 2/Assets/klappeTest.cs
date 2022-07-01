using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class klappeTest : MonoBehaviour
{
    DatabaseReference reference;
    private Quaternion startQuaternion;
    private float lerpTime = 1;
    private float RotateAmount = 70.27f;
    private float count= 0f;
    private float speed = 0.1f;
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
    }
 
    // Update is called once per frame
    void Update() {   

        if(Input.GetKey(space)){
           reference.Child("Body").Child("Animation").Child("klappeRotationZ").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsCompleted)
                {
                    //Debug.Log("retrived");
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log(snapshot.Value.ToString());
                    eulerAngelZ = snapshot.Value.ToString();
                    
                }
                else
                {
                    Debug.Log("not retrived");
                }
                
            }); 
            rotationZ = float.Parse(eulerAngelZ);

            transform.localEulerAngles = new Vector3(0f, -65.99f, rotationZ);
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                keyTwoIsPressed = true;
            }

            if((count % 2f == 0) && keyTwoIsPressed){
                transform.Rotate(Vector3.forward * RotateAmount, Space.Self);
                count++;
                keyTwoIsPressed = false;
                isOpen = false;
            }
            else if(keyTwoIsPressed)
            {
                transform.Rotate(Vector3.forward * -RotateAmount) ;
                count++;
                keyTwoIsPressed = false;
                isOpen = true;
            }    
            reference.Child("Body").Child("Animation").Child("klappeRotationZ").SetValueAsync(transform.eulerAngles.z.ToString()); 

        }
                
    }
}
