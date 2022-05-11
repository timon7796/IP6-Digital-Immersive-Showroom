using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using UnityEngine.Networking;

public class googleSheets : MonoBehaviour
{

    public Text outputArea;
    List<string> eachrow;
    string[] lines;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(ObtainSheetData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator ObtainSheetData(){
        UnityWebRequest www = UnityWebRequest.Get("https://sheets.googleapis.com/v4/spreadsheets/1s-ia5OdGS-67cP-NNf-GBtzbxTcgQZAksAASUIRCZYA/values/webUnity?key=AIzaSyAG4Dh_BQwxTFjWc23aFspHtfhDHb93f88");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("error" + www.error);
        }
        else
        {
          string updateText = "";
          
          string json = www.downloadHandler.text;
          var o = JSON.Parse(json);
          

          foreach (var item in eachrow)
          {
              var itemo = JSON.Parse(item.ToString());
              eachrow = itemo[0].AsStringList;
              Debug.Log(itemo[0]);

              foreach (var bro in eachrow)
              {
                updateText += item + ",";   
              }
            
            updateText += "\n";
          }
          



          outputArea.text = updateText;
          

        }
    }
}
