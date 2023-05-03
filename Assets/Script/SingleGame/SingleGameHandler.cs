using System;
using System.Collections;
using UnityEngine;
public class SingleGameHandler : MonoBehaviour
{
    public PlayerData PlayerData { get; private set; }
    private FileDataHandler _fileDataHandler;
    [SerializeField] private string _fileName;
    [SerializeField] private bool _encryptData;

    [ContextMenu("Delete save file")]
    private void DeleteSavedData()
    {
        _fileDataHandler = new FileDataHandler(Application.persistentDataPath, _fileName, _encryptData);
        _fileDataHandler.Delete();
    }


    public void ClickToGetPlayer()
    {
        _fileDataHandler = new FileDataHandler(Application.persistentDataPath, _fileName, _encryptData);

        Debug.Log("loadGame()");
        LoadGame();
    }

    private void LoadGame()
    {
        PlayerData = _fileDataHandler.Load();

        if (this.PlayerData == null)
        {
            Debug.Log("No saved data found!");
            NewGame();
            SaveGame(PlayerData);
        }

        PlayerManager.instance.UpdatePlayerManager(PlayerData);
    }

    private void NewGame()
    {
        PlayerData = new PlayerData();
    }

    public void SaveGame(PlayerData playerData)
    {
        _fileDataHandler = new FileDataHandler(Application.persistentDataPath, _fileName, _encryptData);
        _fileDataHandler.Save(playerData);
    }
}
