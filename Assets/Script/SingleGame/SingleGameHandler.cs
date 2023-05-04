using System;
using System.Collections;
using UnityEngine;
public class SingleGameHandler
{
    public PlayerData PlayerData { get; private set; }

    [SerializeField] private string _fileName;
    [SerializeField] private bool _encryptData;

    public void LoadGame(FileDataHandler fileDataHandler)
    {
        PlayerData = fileDataHandler.Load();

        if (this.PlayerData == null)
        {
            Debug.Log("No saved data found!");
            NewGame();
            SaveGame(PlayerData, fileDataHandler);
        }

        PlayerManager.instance.UpdatePlayerManager(PlayerData);
    }

    private void NewGame()
    {
        PlayerData = new PlayerData();
    }

    public void SaveGame(PlayerData playerData, FileDataHandler fileDataHandler)
    {
        fileDataHandler.Save(playerData);
    }
}
