```csharp
[ContextMenu("Reset file")]
private void ResetSavedData()
{
    PlayerManager.instance.PlayerData.Money = 10000;
    _singleGameHandler.SaveGame(PlayerManager.instance.PlayerData, _fileDataHandler);
}
```