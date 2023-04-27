using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class GameData
{
    public int Money = 10000;
    public int[] BoardNum;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    [SerializeField] private string fileName;
    [SerializeField] private bool encryptData;
    public GameData gameData;
    private FileDataHandler dataHandler;

    [ContextMenu("Delete save file")]
    private void DeleteSavedData()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, encryptData);
        dataHandler.Delete();
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }
    private void Start()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, encryptData);

        if (GameManager.instance._scenePattern == ScenePattern.SINGLE_GAME)
        {
            LoadGame();
        }
    }

    public void LoadGame()
    {
        gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No saved data found!");
            NewGame();
        }

        PlayerManager.instance.PlayerData.Money = gameData.Money;
    }

    public void NewGame()
    {
        gameData = new GameData();
    }
    public void SaveGame()
    {
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

}