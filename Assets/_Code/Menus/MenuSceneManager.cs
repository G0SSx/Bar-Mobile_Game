using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    private const string _bestScorePrefsKey = "BestScore";
    private const int _gameScene = 1;

    private int _bestScore;

    private void Awake()
    {
        _bestScore = PlayerPrefs.GetInt(_bestScorePrefsKey);
    }

    private void Start()
    {
        if (_bestScore > 0)
        {
            _bestScoreText.gameObject.SetActive(true);
            _bestScoreText.text = $"Best score: {_bestScore}";
        }
        else
        {
            _bestScoreText.gameObject.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_gameScene);
    }
}