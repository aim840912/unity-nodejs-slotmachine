// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Linq;


// public class SaveManager : MonoBehaviour
// {
//     public static SaveManager instance;
//     public ServerReturnData ServerReturnData;
//     [SerializeField] private string fileName;
//     [SerializeField] private bool encryptData;

//     private FileDataHandler dataHandler;

//     [ContextMenu("Delete save file")]
//     private void DeleteSavedData()
//     {
//         dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, encryptData);
//         dataHandler.Delete();
//     }

//     private void Awake()
//     {
//         if (instance != null)
//             Destroy(instance.gameObject);
//         else
//             instance = this;
//     }
//     private void Start()
//     {
//         dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, encryptData);

//         if (GameManager.instance._scenePattern == ScenePattern.SINGLE_GAME)
//         {
//             Debug.Log("loadGame()");
//             LoadGame();
//         }
//     }

//     public void LoadGame()
//     {
//         ServerReturnData = dataHandler.Load();

//         if (this.ServerReturnData == null)
//         {
//             Debug.Log("No saved data found!");
//             NewGame();
//         }

//         PlayerManager.instance.PlayerData.Money = ServerReturnData.Money;
//     }

//     public void NewGame()
//     {
//         ServerReturnData = new ServerReturnData();
//     }
//     public void SaveGame()
//     {
//         dataHandler.Save(ServerReturnData);
//     }

//     private void OnApplicationQuit()
//     {
//         SaveGame();
//     }

// }