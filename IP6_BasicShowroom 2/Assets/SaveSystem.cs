using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void SaveVector(Vector vector){
        StreamWriter tw = new StreamWriter(Application.persistentDataPath + "/vector.txt");
        VectorD data = new VectorD(vector);

        tw.WriteLine(data);

        tw.Close();

    }
}


    

