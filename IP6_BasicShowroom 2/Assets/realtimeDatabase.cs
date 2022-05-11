using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class realtimeDatabase : MonoBehaviour
{
    DatabaseReference reference;

    private string zwischenSpeicherX;
    private string zwischenSpeicherY;
    private string zwischenSpeicherZ;
    private string zwischenSpeicherVecX;
    private string zwischenSpeicherVecY;
    private string zwischenSpeicherVecZ;

    private object fzwischenSpeicherX;
    private object fzwischenSpeicherY;
    private object fzwischenSpeicherZ;
    // private float fzwischenSpeicherVecX;
    // private float fzwischenSpeicherVecY;
    // private float fzwischenSpeicherVecZ;

    public Text testPosX; 
    public Text testPosY;
    public Text testPosZ; 
    public Text testVecX; 
    public Text testVecY; 
    public Text testVecZ;  

    public float posX;
    public float posY;
    public float posZ;
    public float vecX;
    public float vecY;
    public float vecZ;


    public Vector3 pos;
    public Vector3 vec;


    [SerializeField] float cameraPosX; 
    [SerializeField] float cameraPosY; 
    [SerializeField] float cameraPosZ; 
    [SerializeField] float cameraVecX; 
    [SerializeField] float cameraVecY; 
    [SerializeField] float cameraVecZ; 

    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;  
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Camera.main.transform.position.y);
        cameraPosX = Camera.main.transform.position.x;   
        cameraPosY = 1.488f;
        cameraPosZ = Camera.main.transform.position.z;

        cameraVecX = Camera.main.transform.forward.x;
        cameraVecY = Camera.main.transform.forward.y;
        cameraVecZ = Camera.main.transform.forward.z;

        string json = JsonUtility.ToJson(cameraPosX);
        reference.Child("Camera").Child("Position").Child("cameraPosX").SetValueAsync(cameraPosX).ContinueWith(task => {
            if(task.IsCompleted){
                //Debug.Log("successfully added user data to firebas");
            }
            else{
                Debug.Log("user data not successfull");
            }
        });

        reference.Child("Camera").Child("Position").Child("cameraPosY").SetValueAsync(cameraPosY);

        reference.Child("Camera").Child("Position").Child("cameraPosZ").SetValueAsync(cameraPosZ);
        
        reference.Child("Camera").Child("Vector").Child("cameraVecX").SetValueAsync(cameraVecX);

        reference.Child("Camera").Child("Vector").Child("cameraVecY").SetValueAsync(cameraVecY);

        reference.Child("Camera").Child("Vector").Child("cameraVecZ").SetValueAsync(cameraVecZ);




        reference.Child("Camera").Child("Position").Child("cameraPosX").GetValueAsync().ContinueWith(task =>
        {
            if(task.IsCompleted)
            {
                //Debug.Log("retrived");
                DataSnapshot snapshot = task.Result;
                //Debug.Log(snapshot.Value.ToString());
                zwischenSpeicherX = snapshot.Value.ToString();
                fzwischenSpeicherX = snapshot.Value;
            }
            else
            {
                Debug.Log("not retrived");
            }
            
        }); 
        testPosX.text = zwischenSpeicherX;
        posX = float.Parse(testPosX.text);
        //Camera.main.transform.position.x = zwischenSpeicher;
        
        reference.Child("Camera").Child("Position").Child("cameraPosY").GetValueAsync().ContinueWith(task =>
        {
            if(task.IsCompleted)
            {
                //Debug.Log("retrived");
                DataSnapshot snapshot = task.Result;
                //Debug.Log(snapshot.Value.ToString());
                zwischenSpeicherY = snapshot.Value.ToString();
                fzwischenSpeicherY = snapshot.Value;
            }
            else
            {
                Debug.Log("not retrived");
            }
            
        }); 
        testPosY.text = zwischenSpeicherY;
        posY = float.Parse(testPosY.text);
        //Camera.main.transform.position.x = zwischenSpeicher;

        reference.Child("Camera").Child("Position").Child("cameraPosZ").GetValueAsync().ContinueWith(task =>
        {
            if(task.IsCompleted)
            {
                //Debug.Log("retrived");
                DataSnapshot snapshot = task.Result;
                //Debug.Log(snapshot.Value.ToString());
                zwischenSpeicherZ = snapshot.Value.ToString();
                fzwischenSpeicherZ = snapshot.Value;
            }
            else
            {
                Debug.Log("not retrived");
            }
            
        }); 
        testPosZ.text = zwischenSpeicherZ;
        posZ = float.Parse(testPosX.text);
        //Camera.main.transform.position.x = zwischenSpeicher;

        reference.Child("Camera").Child("Vector").Child("cameraVecX").GetValueAsync().ContinueWith(task =>
        {
            if(task.IsCompleted)
            {
                //Debug.Log("retrived");
                DataSnapshot snapshot = task.Result;
                //Debug.Log(snapshot.Value.ToString());
                zwischenSpeicherVecX = snapshot.Value.ToString();
            }
            else
            {
                Debug.Log("not retrived");
            }
            
        }); 
        testVecX.text = zwischenSpeicherVecX;
        vecX = float.Parse(testVecX.text);
        //Camera.main.transform.position.x = zwischenSpeicher;

        reference.Child("Camera").Child("Vector").Child("cameraVecY").GetValueAsync().ContinueWith(task =>
        {
            if(task.IsCompleted)
            {
                //Debug.Log("retrived");
                DataSnapshot snapshot = task.Result;
                //Debug.Log(snapshot.Value.ToString());
                zwischenSpeicherVecY = snapshot.Value.ToString();
            }
            else
            {
                Debug.Log("not retrived");
            }
            
        }); 
        testVecY.text = zwischenSpeicherVecY;
        vecY = float.Parse(testVecY.text);
        //Camera.main.transform.position.x = zwischenSpeicher;

        reference.Child("Camera").Child("Vector").Child("cameraVecZ").GetValueAsync().ContinueWith(task =>
        {
            if(task.IsCompleted)
            {
                //Debug.Log("retrived");
                DataSnapshot snapshot = task.Result;
                //Debug.Log(snapshot.Value.ToString());
                zwischenSpeicherVecZ = snapshot.Value.ToString();
            }
            else
            {
                Debug.Log("not retrived");
            }
            
        }); 
        testVecZ.text = zwischenSpeicherVecZ;
        vecZ = float.Parse(testVecZ.text);
        //Camera.main.transform.position.x = zwischenSpeicher;

        pos = new Vector3(posX, posY, posZ);
        vec = new Vector3(vecX, vecY, vecZ);

        //Debug.Log("pos: " + pos);
        //Debug.Log("vec: " + vec);

        //transform.position = pos;

    }
}

