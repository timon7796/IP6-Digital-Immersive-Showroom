using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Firebase;
using Firebase.Extensions;


public class fireBase : MonoBehaviour
{
    public UnityEvent OnFireBaeInitialized = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread( task => {
            if (task.Exception !=  null){
                Debug.LogError($"Failed to initialize FireBase with {task.Exception}");
                return;
            }

            OnFireBaeInitialized.Invoke();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
