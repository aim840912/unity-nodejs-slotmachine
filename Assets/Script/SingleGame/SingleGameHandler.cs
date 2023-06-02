using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleGameHandler : MonoBehaviour
{
    public PlayerData PlayerData { get; private set; }
    private FileDataHandler _fileDataHandler;
    [SerializeField] private string _fileName = "slotMachine";
    [SerializeField] private bool _encryptData = true;
    [SerializeField] private string _filePath = "idbfs/aim841104fsdfsdfsdagf";
    [SerializeField] private SceneEnum _nextScene;

    private bool _isGetData;

    public void ClickToSingleGameMachine()
    {
        GameManager.Instance.GameMode = GameMode.SINGLE_GAME;
        StartCoroutine(GetSingleGameData());
    }

    private IEnumerator GetSingleGameData()
    {
        _fileDataHandler = new FileDataHandler(_filePath, _fileName, _encryptData);

        LoadGame(_fileDataHandler);

        yield return new WaitUntil(() => _isGetData == true);

        LoadToNextScene(_nextScene);
    }

    public void LoadGame(FileDataHandler fileDataHandler)
    {
        _isGetData = false;

        PlayerData = fileDataHandler.Load();

        if (this.PlayerData == null)
        {
            Debug.Log("No saved data found!");
            NewGame(fileDataHandler);
            SaveGame(PlayerData, fileDataHandler);
        }

        _isGetData = true;

        PlayerManager.instance.SetPlayerData(PlayerData);
    }

    private void NewGame(FileDataHandler fileDataHandler)
    {
        PlayerData = new PlayerData();
        SaveGame(PlayerData, fileDataHandler);
    }

    public void SaveGame(PlayerData playerData, FileDataHandler fileDataHandler)
    {
        fileDataHandler.Save(playerData);
    }

    private void LoadToNextScene(SceneEnum sceneEnum)
    {
        SceneManager.LoadScene((int)sceneEnum);
    }
}
