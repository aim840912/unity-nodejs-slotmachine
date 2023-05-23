using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public GameMode GameMode { get; set; } = GameMode.ONLINE;
    public UrlData UrlData;

    [SerializeField] private GameObject _errorMessagePanel;
    [SerializeField] private TMP_Text _message;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singleton = new GameObject();

                _instance = singleton.AddComponent<GameManager>();
                singleton.name = "[Singleton]" + typeof(GameManager).ToString();

                DontDestroyOnLoad(singleton);
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OpenErrorMessagePanel(string message)
    {
        _errorMessagePanel.SetActive(true);
        _message.text = message;
    }

    public bool CheckHasInternet()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            OpenErrorMessagePanel("No internet");
            return false;
        }
        return true;
    }
}
