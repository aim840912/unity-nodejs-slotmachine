using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SingleGameLogin : BaseServerAction
{
    private PlayerData _playerData;
    [SerializeField] private int _machineSceneIndex;

    protected override IEnumerator PostServerData()
    {
        PlayerManager.instance.PlayerData.UserId = "Single Game";
        PlayerManager.instance.PlayerData.Name = "SingleGame User";
        PlayerManager.instance.PlayerData.Money = PlayerPrefs.GetInt("playerMoney");

        yield return null;

        SceneManager.LoadScene(_machineSceneIndex);

    }
}
