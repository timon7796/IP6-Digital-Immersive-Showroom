using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using Firebase;
using Firebase.Extensions;
using Firebase.Database;
using System.Threading.Tasks;

public class SaveSystem : MonoBehaviour {


    private const string Vector_Key = "Vector_Key";
    private FirebaseDatabase  _database;

    private void Start(){

        _database = FirebaseDatabase.DefaultInstance;

    }

    public static void SaveVector(Vector vector){
       // _database.GetReference(Vector_Key).SetRawJsonValueAsync(JsonUtility.ToJson(vector));

    } 

    public async Task<bool> SaveExists(){
        var dataSnapshot = await _database.GetReference(Vector_Key).GetValueAsync();
        return dataSnapshot.Exists;
    }
}


    

