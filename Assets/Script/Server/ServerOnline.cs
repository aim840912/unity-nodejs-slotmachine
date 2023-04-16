using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerOnline : MonoBehaviour
{
    public GameData gameData;

    int[] board = new int[9];
    void Start()
    {
        StartCoroutine(GetBoardNum());
    }

    IEnumerator GetBoardNum()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:3000/machine");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            gameData = JsonUtility.FromJson<GameData>(www.downloadHandler.text);

            Debug.Log(gameData.BoardNum);
            // Or retrieve results as binary data

        }
    }
}
