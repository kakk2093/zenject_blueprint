using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LosePopup : Popup
{
    [Header("Links")]
    [SerializeField] private Button _restartGameButton;

    private ISceneLoadService _sceneLoadService;

    [Inject]
    private void Construct(ISceneLoadService sceneLoadService)
    {
        _sceneLoadService = sceneLoadService;
    }

    private void Awake()
    {
        _restartGameButton?.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDestroy()
    {
        _restartGameButton?.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void OnRestartButtonClick()
    {
        _sceneLoadService.RestartScene();
        ClosePopup();
    }
}
