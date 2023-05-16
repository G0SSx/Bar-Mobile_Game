using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class Game : MonoBehaviour
{
    [Header("Delivery Counters")]
    [SerializeField] private DeliveryCounter[] _deliveryCounters;
    [Header("Menus")]
    [SerializeField] private GameSettingsUI _gameSettings;
    [SerializeField] private HUD _hud;
    [SerializeField] private Button _addTimeButton;
    [SerializeField] private Button _subtractTimeButton;
    [Header("Game objects")]
    [SerializeField] private PlayerMovement _playerMovement;

    private const string _bestScorePrefsKey = "BestScore";
    private const int _mainMenuSceneIndex = 0;

    private InputActions _input;
    private bool _isPlaying;
    private int _currentScore;
    private float _gameTimerSec;

    [Inject]
    private void Constrcut(InputActions input)
    {
        _input = input;
    }

    private void Start()
    {
        PrepareGameUI();
        HandleInput();
        _playerMovement.enabled = false;
        _addTimeButton.onClick.AddListener(() => AddGameTime(new InputAction.CallbackContext()));
        _subtractTimeButton.onClick.AddListener(() => SubtractGameTime(new InputAction.CallbackContext()));

        foreach (DeliveryCounter counter in _deliveryCounters)
            counter.OnOrderAccepted += SuccessfulDelivery;
    }

    private void Update()
    {
        if (_isPlaying)
            UpdateTimer();
    }

    public void StartGame()
    {
        _gameSettings.gameObject.SetActive(false);
        _hud.gameObject.SetActive(true);
        _hud.ResetHud();
        _isPlaying = true;
        _playerMovement.enabled = true;
    }

    private void HandleInput()
    {
        _input.Enable();
        _input.Menu.ArrowUp.performed += AddGameTime;
        _input.Menu.ArrowDown.performed += SubtractGameTime;
    }

    private void AddGameTime(InputAction.CallbackContext context)
    {
        if (_isPlaying || _gameTimerSec == IngameSettings.MaxGameTime)
            return;

        _gameTimerSec = _gameTimerSec + IngameSettings.SecondsInMinute;
        UpdateGameSettingsText();
    }

    private void SubtractGameTime(InputAction.CallbackContext context)
    {
        if (_isPlaying || _gameTimerSec == IngameSettings.MinGameTime)
            return;

        _gameTimerSec -= IngameSettings.SecondsInMinute;
        UpdateGameSettingsText();
    }

    private void PrepareGameUI()
    {
        _gameSettings.gameObject.SetActive(true);
        _gameSettings.ResetUI();
        _gameSettings.GameStarted += StartGame;
        _hud.gameObject.SetActive(false);
        _gameTimerSec = IngameSettings.MinGameTime;
    }

    private void SuccessfulDelivery(int points)
    {
        _currentScore += points;
        _hud.UpdateScore(_currentScore);
        PlayerPrefs.SetInt(_bestScorePrefsKey, _currentScore);
    }

    private void UpdateTimer()
    {
        _gameTimerSec -= Time.deltaTime;
        if (_gameTimerSec < 0)
            FinishGame();

        _hud.UpdateTimer(_gameTimerSec);
    }

    private void FinishGame()
    {
        SceneManager.LoadScene(_mainMenuSceneIndex);
    }

    private void UpdateGameSettingsText()
    {
        _gameSettings.UpdateTimeText(_gameTimerSec);
    }
}