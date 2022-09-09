using UnityEngine;
using System.Collections;
using Zenject;

public class UIManager : MonoBehaviour
{
  
    [SerializeField] private Popup _startPopup;
    [SerializeField] private Popup _losePopup;
    [SerializeField] private Popup _winPopup;
    [SerializeField] private GameObject _levelProgresViewer;


    private IGamePlayService _gamePlayService;

    [Inject]
    private void Construct(IGamePlayService gamePlayService)
    {
        _gamePlayService = gamePlayService;

        _gamePlayService.GameOverEvent += OnGameOver;
        _gamePlayService.GameStartEvent += OnGameStart;
        _gamePlayService.MiniGameEndEvent += OnMiniGameEnd;
        _gamePlayService.FinisherStartEvent += OnFinisherStart;
    }

    private void Awake()
    {
        _levelProgresViewer.SetActive(false);
        _startPopup.OpenPopup();
    }

    private void OnDestroy()
    {
        _gamePlayService.GameOverEvent -= OnGameOver;
        _gamePlayService.GameStartEvent -= OnGameStart;
        _gamePlayService.MiniGameEndEvent -= OnMiniGameEnd;
        _gamePlayService.FinisherStartEvent -= OnFinisherStart;
    }

    private void OnMiniGameEnd()
    {
        _winPopup.OpenPopup();
        StartCoroutine(OnMinigameEndCorutine());
    }

    private IEnumerator OnMinigameEndCorutine()
    {
        yield return new WaitForSeconds(2f);
        _gamePlayService.WinPopupShow();
    }

    private void OnGameStart()
    {
        _startPopup.ClosePopup();
        _levelProgresViewer.SetActive(true);
    }

    private void OnGameOver()
    {
 
        _losePopup.OpenPopup();
    }

    private void OnFinisherStart()
    {
        _levelProgresViewer.SetActive(false);
    }
}
