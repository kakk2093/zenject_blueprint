using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _mainCameara;
    [SerializeField] private GameObject _startCamera;
    [SerializeField] private GameObject _finisherCamera;
    [SerializeField] private GameObject _winCamera;

    private IGamePlayService _gamePlayService;

    [Inject]
    private void Construct(IGamePlayService gamePlayService)
    {
        _gamePlayService = gamePlayService;
        _gamePlayService.GameStartEvent += ActiveMainCamera;
        _gamePlayService.MiniGameEndEvent += ActiveWinCamera;
        _gamePlayService.FinisherStartEvent += ActivateFinisherCanera;
    }

    private void Awake()
    {
        ActiveStartCamera();
    }

    private void OnDestroy()
    {
        _gamePlayService.GameStartEvent -= ActiveMainCamera;
        _gamePlayService.MiniGameEndEvent -= ActiveWinCamera;
        _gamePlayService.FinisherStartEvent -= ActivateFinisherCanera;
    }

    private void ActiveStartCamera()
    {
        _finisherCamera.SetActive(false);
        _startCamera.SetActive(true);
        _mainCameara.SetActive(false);
        _winCamera.SetActive(false);

    }

    private void ActiveMainCamera()
    {
        _finisherCamera.SetActive(false);
        _startCamera.SetActive(false);
        _mainCameara.SetActive(true);
        _winCamera.SetActive(false);

    }

    private void ActivateFinisherCanera()
    {
        _finisherCamera.SetActive(true);
        _startCamera.SetActive(false);
        _mainCameara.SetActive(false);
        _winCamera.SetActive(false);
    }

    private void ActiveWinCamera()
    {
        _finisherCamera.SetActive(false);
        _startCamera.SetActive(false);
        _mainCameara.SetActive(false);
        _winCamera.SetActive(true);
    }
}
