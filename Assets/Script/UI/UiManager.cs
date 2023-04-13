using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _winMoneyText;
    [SerializeField] private TMP_Text _playerMoneyText;

    public void UpdatedPlayerUI(Server server)
    {
        int winMoney = server.WinMoney;
        // int playerMoney = server.GetPlayerMoney();

        _winMoneyText.text = $"{winMoney}";
        // _playerMoneyText.text = $"{playerMoney}";
    }
}
