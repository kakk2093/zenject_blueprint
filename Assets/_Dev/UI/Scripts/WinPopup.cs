using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WinPopup : Popup
{

    [Header("Links")]
    [SerializeField] private Button _continueButton;
    [SerializeField] private Text _finalMoneyText;
    [SerializeField] private Text _multiplierText;
    [SerializeField] private AnimationCurve _addingCurve;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _fMultAnimator;


    private static readonly int Change = Animator.StringToHash("Change");
    private static readonly int Scale = Animator.StringToHash("Scale");

    private int _endValue;
    private int _startValue;
    private ISceneLoadService _sceneLoadService;
    private IGamePlayService _gamePlayService;
    private IMoneyService _moneyService;


    [Inject]
    private void Construct(IGamePlayService gamePlayService, ISceneLoadService sceneLoadService, IMoneyService moneyService)
    {
        _sceneLoadService = sceneLoadService;
        _gamePlayService = gamePlayService;
        _moneyService = moneyService;

        _gamePlayService.WinPopupShowEvent += RefreshFinalMonye;
        _gamePlayService.WinPopupShowEvent += ActivateContButton;
    }

    private void Awake()
    {
        _continueButton?.onClick.AddListener(OnContinueButtonClick);
        _continueButton.interactable = false;
    }

    private void ActivateContButton()
    {
        StartCoroutine(ActivateContButtonCorutine());
    }

    private IEnumerator ActivateContButtonCorutine()
    {
        yield return new WaitForSeconds(2f);
        _continueButton.interactable = true;
    }


    private void OnDestroy()
    {
        _gamePlayService.WinPopupShowEvent -= RefreshFinalMonye;
        _gamePlayService.WinPopupShowEvent -= ActivateContButton;
    }

    private void RefreshFinalMonye()
    {
        StartCoroutine(MoneyIncreasCorutine());
    }

    private void OnContinueButtonClick()
    {
        _sceneLoadService.LoadNextScene();
        ClosePopup();
    }

    private IEnumerator MoneyIncreasCorutine()
    {

        _startValue = _moneyService.OnLevelMoneyCount;
        _endValue = _moneyService.FinalMoney;
        _animator.SetTrigger(Change);
        _finalMoneyText.text = _startValue.ToString();
        _multiplierText.text = "X " + _moneyService.MoneyMultiplier.ToString("F1");

        yield return new WaitForSeconds(0.4f);
        _fMultAnimator.SetTrigger(Scale);

        yield return new WaitForSeconds(0.6f);
        float addingTimeDuration = 0.4f;
        float time = 0f;

        while (time < addingTimeDuration)
        {
            time += Time.deltaTime;
            var value = (int)(Mathf.Lerp(_startValue, _endValue, _addingCurve.Evaluate(time / addingTimeDuration)));
            _finalMoneyText.text = value.ToString();
            yield return null;
        }

    }
}
