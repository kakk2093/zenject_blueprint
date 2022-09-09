using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SkinProgresManager : MonoBehaviour
{

    [SerializeField] private Image[] _fillImage;
    [SerializeField] private float _fillingValue = 99;
    [SerializeField] private float _filingValueAfterGrass = 25;
    [SerializeField] private float _fillingValueAfterRandomize = 10;
    [SerializeField] private float _addingDuration = 2f;
    [SerializeField] AnimationCurve _addingCurve;
    [SerializeField] private Text[] _persetnageText;


    private IGamePlayService _gamePlayService;
    private ISaveValueService _saveValueService;
    private float _curentProgress;
    private float _endProgress;
    private float _stepProgress;


    [Inject]
    private void Construct(IGamePlayService gamePlayService, ISaveValueService saveValueService)
    {
        _gamePlayService = gamePlayService;
        _saveValueService = saveValueService;

        _gamePlayService.WinPopupShowEvent += AddPersentageProgres;
        _gamePlayService.WinPopupShowEvent += SetCurentFillImage;
    }

    private void Awake()
    {
        SetCurrentSkinProgress();
        SetStepProgres(_saveValueService.TimeToCircleSkin);
    }

    private void OnDestroy()
    {
        _gamePlayService.WinPopupShowEvent -= AddPersentageProgres;
        _gamePlayService.WinPopupShowEvent -= SetCurentFillImage;
    }

    private void SetStepProgres(int value)
    {
        if (value == 0)
            _stepProgress = _fillingValue;
        if (value == 1)
            _stepProgress = _filingValueAfterGrass;
        if (value >= 2)
            _stepProgress = _fillingValueAfterRandomize;

    }

    private void SetCurrentSkinProgress()
    {
        _curentProgress = _saveValueService.SkinOpenProgres;
    }

    private void SetCurentFillImage()
    {
        foreach (var image in _fillImage)
        {
            if (image.gameObject.activeInHierarchy)
            {
                image.fillAmount = _curentProgress / 100;
            }
        }
    }

    private void AddPersentageProgres()
    {
        if (gameObject.activeInHierarchy)
            StartCoroutine(AddPersettageCorutine());
    }

    private IEnumerator AddPersettageCorutine()
    {
        _endProgress = _curentProgress + _stepProgress;

        Debug.Log("filing corutine");
        var time = 0f;

        while (time < _addingDuration)
        {
            time += Time.deltaTime;

            _curentProgress = Mathf.Lerp(_curentProgress, _endProgress, _addingCurve.Evaluate(time / _addingDuration));
            foreach (var image in _fillImage)
            {
                if (image.gameObject.activeInHierarchy)
                {
                    image.fillAmount = Mathf.Lerp(_curentProgress, _endProgress, _addingCurve.Evaluate(time / _addingDuration)) / 100;
                }
            }
            foreach (var text in _persetnageText)
            {
                if (text.gameObject.activeInHierarchy)
                {
                    text.text = Mathf.Lerp(_curentProgress, _endProgress, _addingCurve.Evaluate(time / _addingDuration)).ToString("F0") + " %";
                }
            }

            _saveValueService.SkinOpenProgres = _curentProgress;

            yield return null;
        }

        if (_endProgress > 97)
        {
            _curentProgress = 100;
            _saveValueService.SkinLevel++;

            _saveValueService.SkinOpenProgres = 0;
            if (_saveValueService.SkinLevel > 0)//remove from here
            {
                _saveValueService.TimeToCircleSkin = 1;
            }
            if (_saveValueService.SkinLevel > 2)
            {
                _saveValueService.TimeToCircleSkin = 2;
            }
        }
        else
        {
            _curentProgress = _endProgress;
            _saveValueService.SkinOpenProgres = _curentProgress;
        }
    }

}
