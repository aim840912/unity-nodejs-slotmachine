using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _winMoneyText;
    [SerializeField] private TMP_Text _playerMoneyText;
    [SerializeField] private GameObject[] _panel;

    private void Start()
    {
        _playerMoneyText.text = $"{PlayerManager.instance.PlayerMoney}";
    }

    public void UpdatedPlayerUI(BackendData backendData)
    {
        _winMoneyText.text = $"Win: {backendData.WinMoney}";
        _playerMoneyText.text = $"{backendData.Money}";
    }

    public void SetWinToZero()
    {
        _winMoneyText.text = $"Win: {0}";
    }

    public void CloseAllPanel()
    {
        for (int i = 0; i < _panel.Length; i++)
        {
            _panel[i].SetActive(false);
        }
    }

    public void OnlyOpenOnePanel(GameObject gameObject)
    {
        CloseAllPanel();
        gameObject.SetActive(true);
    }
}
