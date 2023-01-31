using TMPro;
using UnityEngine;
using Zenject;

public class CoinCountViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinCountText;
    [SerializeField] private Animator _animator;

    private ISaveValueService _saveValueService;
    private static readonly int CoinPick = Animator.StringToHash("CoinPick");

    [Inject]
    private void Construct(ISaveValueService saveValueService)
    {
        _saveValueService = saveValueService;

        _saveValueService.ChangeCoinsCountEvent += OnCoinsCountChanged;
    }

    private void OnDestroy()
    {
        _saveValueService.ChangeCoinsCountEvent -= OnCoinsCountChanged;
    }

    private void Start()
    {
        ViewValue(_saveValueService.CoinsCount);
    }

    private void OnCoinsCountChanged(int curentCointCount)
    {
        ViewValue(curentCointCount);
        _animator.SetTrigger(CoinPick);
    }

    private void ViewValue(int value)
    {
        _coinCountText.text = AbbrevationUtility.AbbreviateNumber(value);
    }
}
