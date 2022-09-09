using UnityEngine;
using Zenject;

public class MoneyService : MonoBehaviour, IMoneyService
{
    private int _onLevelMoneyCount = 0;
    private float _moneyMultiplier = 0;
    private int _finalMoney;
    private int _valueMoneyViewer;

    private ISaveValueService _saveValueService;
    private IGamePlayService _gamePlayService;

    public int FinalMoney { get => _finalMoney; set => _finalMoney = value; }
    public float MoneyMultiplier { get => _moneyMultiplier; set => _moneyMultiplier = value; }
    public int OnLevelMoneyCount { get => _onLevelMoneyCount; set => _onLevelMoneyCount = value; }
    public int ValueMoneyViewer { get => _valueMoneyViewer; set => _valueMoneyViewer = value; }

    [Inject]
    private void Construct(ISaveValueService saveValueService, IGamePlayService gamePlayService)
    {
        _saveValueService = saveValueService;
        _gamePlayService = gamePlayService;

        _saveValueService.ChangeCoinsCountEvent += MoneyAdd;
        _gamePlayService.MiniGameEndEvent += OnGameWin;
        _gamePlayService.SceneLoadEvent += OnLoadLevel;
    }

    private void OnDestroy()
    {
        _saveValueService.ChangeCoinsCountEvent -= MoneyAdd;
        _gamePlayService.MiniGameEndEvent -= OnGameWin;
        _gamePlayService.SceneLoadEvent -= OnLoadLevel;
    }

    private void OnLoadLevel()
    {
        OnLevelMoneyCount = 0;
        MoneyMultiplier = 2f;
        _saveValueService.AddCoins(_finalMoney);
        _finalMoney = 0;
    }

    private void MoneyAdd(int value)
    {
        OnLevelMoneyCount++;
    }

    private void OnGameWin()
    {
        FinalMoney = Mathf.RoundToInt(MoneyMultiplier * OnLevelMoneyCount);
    }
}
