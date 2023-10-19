using System;
using UnityEngine;
using Zenject;

public class SaveValueService : MonoBehaviour, ISaveValueService
{
    private int _openLevelNumber;
    private int _coinsCount;
    private int _skinLevel;
    private float _skinOpenProgres;
    private int _timeToCicleSkin;
    private int _trueLevelNumber;


    private const string CoinsCountSaveKey = "CoinsCaunt";
    private const string LevelNumberSaveKey = "OpenLevelNumber";
    private const string SkinLevelNumberSaveKey = "SkinLevel";
    private const string SkinOpenProgresSaveKey = "SkinProgres";
    private const string TimeToCicleSkinSaveKey = "SkinCicle";
    private const string TrueLevelNumberSaveKey = "TrueLevel";


    public event Action<int> ChangeCoinsCountEvent;
    public event Action<int> ChangeSkinLevelEvent;

    private ISaveLoadService _saveLoadService;

    [Inject]
    private void Constrict(ISaveLoadService saveLoadService)
    {
        _saveLoadService = saveLoadService;
    }

    private void LoadAllValues()
    {
        LoadCoinsCount();
        LoadLevelNumber();
        LoadSkinLevel();
        LoadOpenSkinProgres();
        LoadTimeToCircleSkin();
        LoadTrueLevelNumber();
    }

    private void Start()
    {
        LoadAllValues();
    }

    public bool TrySpendCoins(int value)
    {
        if (value <= CoinsCount)
        {
            CoinsCount -= value;
            return true;
        }
        return false;
    }

    public void AddCoins(int value)
    {
        CoinsCount += value;
    }

    private void SaveIntValue(string SaveKey, int SaveValue)
    {
        _saveLoadService.SaveInt(SaveKey, SaveValue);
    }
    private void SaveFloatValue(string saveKey, float saveValue)
    {
        _saveLoadService.SaveFloat(saveKey, saveValue);
    }

    private void SaveBoolValue(string saveKey, bool saveValue)
    {
        _saveLoadService.SaveBool(saveKey, saveValue);
    }

    private void LoadIntValue(string saveKey, int defaultValue)
    {
        _saveLoadService.LoadInt(saveKey, defaultValue);
    }
    private void LoadFloatValue(string saveKey, float defaultValue)
    {
        _saveLoadService.LoadFloat(saveKey, defaultValue);
    }
    private void LoadBoolValue(string saveKey, bool defaultValue)
    {
        _saveLoadService.LoadBool(saveKey, defaultValue);
    }

    #region PROPERTIES

    public int TimeToCircleSkin
    {
        get => _timeToCicleSkin;
        set
        {
            _timeToCicleSkin = value;
            SaveTimeToCircleSkin();
        }
    }

    public int TrueLevelNumber
    {
        get => _trueLevelNumber;

        set
        {
            _trueLevelNumber = value;
            SaveTrueLevel();
        }
    }

    public int LevelNumber
    {
        get => _openLevelNumber;
        set
        {
            _openLevelNumber = value;
            SaveLevelNumber();
        }
    }

    public float SkinOpenProgres
    {
        get => _skinOpenProgres;
        set
        {
            _skinOpenProgres = value;
            SaveOpenSkinProgres();
        }
    }

    public int SkinLevel
    {
        get => _skinLevel;
        set
        {
            ResetSkin(value);
            SaveSkinLevel();
            ChangeSkinLevelEvent?.Invoke(SkinLevel);

            void ResetSkin(int value)
            {
                int skinCount = 4;

                if (value > skinCount)
                    _skinLevel = 0;
                else
                    _skinLevel = value;
            }
        }
    }



    public int CoinsCount
    {
        get => _coinsCount;
        set
        {
            _coinsCount = value;
            SaveCoinsCount();
            ChangeCoinsCountEvent?.Invoke(CoinsCount);
        }
    }

    #endregion

    #region SAVE

    public void SaveTrueLevel()
    {
        SaveIntValue(TrueLevelNumberSaveKey, TrueLevelNumber);
    }

    public void SaveCoinsCount()
    {
        SaveIntValue(CoinsCountSaveKey, CoinsCount);
    }

    public void SaveSkinLevel()
    {
        SaveIntValue(SkinLevelNumberSaveKey, SkinLevel);
    }
    public void SaveTimeToCircleSkin()
    {
        SaveIntValue(TimeToCicleSkinSaveKey, TimeToCircleSkin);
    }

    public void SaveOpenSkinProgres()
    {
        SaveFloatValue(SkinOpenProgresSaveKey, SkinOpenProgres);
    }


    public void SaveLevelNumber()
    {
        SaveIntValue(LevelNumberSaveKey, LevelNumber);
    }
    #endregion

    #region LOAD
    public void LoadTrueLevelNumber()
    {

        SaveIntValue(TrueLevelNumberSaveKey, 1);
    }

    public void LoadCoinsCount()
    {
     
        LoadIntValue(CoinsCountSaveKey, 100);
    }

    public void LoadSkinLevel()
    {
        LoadIntValue(SkinLevelNumberSaveKey, 0);
    }

    public void LoadLevelNumber()
    {
        LoadIntValue(LevelNumberSaveKey, 0);
    }

    public void LoadTimeToCircleSkin()
    {
        LoadIntValue(TimeToCicleSkinSaveKey, 0);
    }

    public void LoadOpenSkinProgres()
    {

        LoadFloatValue(SkinOpenProgresSaveKey, 0);
    }
    #endregion

    #region DEBUG
    private void DeleteSaveData()
    {
        Debug.Log("All saves was deleted");
        PlayerPrefs.DeleteAll();
    }

    private void AddCoinDebug()
    {
        Debug.Log("add coins");
        AddCoins(10000);
        TrueLevelNumber++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            DeleteSaveData();
        if (Input.GetKeyDown(KeyCode.P))
            AddCoinDebug();
    }
    #endregion
}
