using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class JsonCreater
{
    public static string directory = "/SaveVector/";
    public static string fileName = "Vectors.txt"; 

    public static void Save(SaveVector cameraPos){
        string dir = Application.persistentDataPath + directory;

        if(!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string jsonPos = JsonUtility.ToJson(cameraPos);
        File.WriteAllText(dir + fileName, jsonPos);

    }
    

}
