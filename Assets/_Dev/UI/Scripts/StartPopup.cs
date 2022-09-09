using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartPopup : Popup
{
    [Header("Links")]
    [SerializeField] private Button _startGameButton;

    private IGamePlayService _gamePlayService;

    [Inject]
    private void Construct(IGamePlayService gamePlayService)
    {
        _gamePlayService = gamePlayService;
    }

    private void Awake()
    {
        _startGameButton?.onClick.AddListener(OnStartButtonClick);
    }

    private void OnDestroy()
    {
        _startGameButton?.onClick.RemoveListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        _gamePlayService.GameStart();
        ClosePopup();
    }
}
