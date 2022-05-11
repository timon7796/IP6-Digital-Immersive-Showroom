using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TileDecider : MonoBehaviour
{
    // Start is called before the first frame update

    //public AudioClip[] Tilesaudio;
    //public AudioSource speaker;
    public int[] order_of_tiles;
    //public TextAsset CSVfile;
    string[] notes;
    public Text display;
    //string[] row;
    int i = 0;
    //int starter = -1;
    int levelno = 1;
    //AudioClip[] temp=new AudioClip[12];
    
    //public Animator levelcompanim;

    string rowsjson="";
    string[] lines;
    List<string> eachrow;
    public GameObject networkerror;
    //public gameConroller gamecontroller;
    //public Animator aim;

    void Start()
    {
        /*row = CSVfile.text.Split(new char[] { '\n' });
        if (!PlayerPrefs.HasKey("levelno"))
        {
            PlayerPrefs.SetInt("levelno", 1);
            levelno = PlayerPrefs.GetInt("levelno");
        }
        else
        {
            levelno = PlayerPrefs.GetInt("levelno");
        }
        aim.speed = 0.5f + (levelno*0.01f);
        takefromCSV();
        */
    }

    // Update is called once per frame
    void Update()
    {
         StartCoroutine(ObtainSheetData());
        /*
        if (starter == 11)
        {
            levelno++;
            if (levelno > PlayerPrefs.GetInt("levelopened"))
            {
                PlayerPrefs.SetInt("levelopened", levelno);
            }
            takefromCSV();
            starter = -1;
            gamecontroller.levelwon(levelno-1);
            Debug.Log("levelno: " + levelno);
        }*/
    }


    IEnumerator ObtainSheetData()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://sheets.googleapis.com/v4/spreadsheets/1s-ia5OdGS-67cP-NNf-GBtzbxTcgQZAksAASUIRCZYA/values/webUnity?key=AIzaSyAG4Dh_BQwxTFjWc23aFspHtfhDHb93f88");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError || www.timeout>2)
        {
            Debug.Log("error" + www.error);
            //networkerror.SetActive(true);
            //takerandomvalues();
            Debug.Log("Offline");
        }
        else
        {
            //networkerror.SetActive(false);
            string json = www.downloadHandler.text;
            var o = JSON.Parse(json);
            foreach (var item in o["values"])
            {
                var itemo = JSON.Parse(item.ToString());
                eachrow = itemo[0].AsStringList;
                foreach (var bro in eachrow)
                {
                    rowsjson += bro+",";
                }
                rowsjson += "\n";
            }
            lines = rowsjson.Split(new char[] { '\n' });
            notes = lines[levelno].Split(new char[] { ',' });
            for (i = 0; i < notes.Length-1; i++)
            {
                display.text += ", " + notes[i];
                //temp[i - 1] = Tilesaudio[i - 1];
            }
            /*
            for (i = 1; i < notes.Length-1; i++)
            {
                //Tilesaudio[i - 1] = temp[int.Parse(notes[i]) - 1];
                Tilesaudio[int.Parse(notes[i]) - 1] = temp[i - 1];
            }*/
        }
    }
}
