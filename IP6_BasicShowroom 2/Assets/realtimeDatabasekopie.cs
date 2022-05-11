using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class realtimeDatabasekopie : MonoBehaviour
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

    private Text testPosX; 
    private Text testPosY;
    private Text testPosZ; 
    private Text testVecX; 
    private Text testVecY; 
    private Text testVecZ;  

    private float posX;
    private float posY;
    private float posZ;
    private float vecX;
    private float vecY;
    private float vecZ;


    private Vector3 pos;
    private Vector3 vec;


    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;  
    }

    // Update is called once per frame
    void Update()
    {

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

        transform.position = pos;
        transform.forward = vec;

    }
}

