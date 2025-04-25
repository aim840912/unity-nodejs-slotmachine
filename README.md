## 專案內容與特色
# 遊戲功能
* 拉霸機核心玩法：玩家透過按鈕啟動輪盤旋轉，依圖案組合給予獎勵。
* 單機模式：本地端儲存玩家資料，無需網路也能遊玩。
* 線上模式：透過後端 API 儲存與同步玩家金錢資料。
* 金錢初始化：提供一鍵重設金錢的功能，便於測試。
```csharp
[ContextMenu("Reset file")]
private void ResetSavedData()
{
    PlayerManager.instance.PlayerData.Money = 10000;
    _singleGameHandler.SaveGame(PlayerManager.instance.PlayerData, _fileDataHandler);
}
```
## 技術與結構
* 前端 (Unity)：
**  使用 C# 編寫遊戲邏輯。
** 結合 Unity UI、ShaderLab、HLSL 製作拉霸視覺效果。
* 後端 (Node.js)：
** 提供玩家資料處理與遊戲邏輯服務端功能。
* 資料儲存機制：
** 單機模式下透過 FileDataHandler 將遊戲資料儲存在本機檔案系統。
