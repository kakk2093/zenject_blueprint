using System;
using UnityEngine;

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


    private const int DefaultCoinsCount = 0;
    private const int DefaultOpenLevelNumber = 1;
    private const int DefaultSkinLevel = 0;
    private const float DefaultSkinProgresLevel = 0;
    private const int DefaultTimeToCicleSkin = 0;
    private const int DefaultTrueLevelNumber = 1;


    public event Action<int> ChangeCoinsCountEvent;
    public event Action<int> ChangeSkinLevelEvent;

   
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
        PlayerPrefs.SetInt(SaveKey, SaveValue);
        PlayerPrefs.Save();
    }
    private void SaveFloatValue(string saveKey, float saveValue)
    {
        PlayerPrefs.SetFloat(saveKey, saveValue);
        PlayerPrefs.Save();
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
        if (PlayerPrefs.HasKey(TrueLevelNumberSaveKey))
            TrueLevelNumber = PlayerPrefs.GetInt(TrueLevelNumberSaveKey);
        else
            TrueLevelNumber = DefaultTrueLevelNumber;
    }

    public void LoadCoinsCount()
    {
        if (PlayerPrefs.HasKey(CoinsCountSaveKey))
            CoinsCount = PlayerPrefs.GetInt(CoinsCountSaveKey);
        else
            CoinsCount = DefaultCoinsCount;
    }

    public void LoadSkinLevel()
    {
        if (PlayerPrefs.HasKey(SkinLevelNumberSaveKey))
            SkinLevel = PlayerPrefs.GetInt(SkinLevelNumberSaveKey);
        else
            SkinLevel = DefaultSkinLevel;
    }

    public void LoadLevelNumber()
    {
        if (PlayerPrefs.HasKey(LevelNumberSaveKey))
            LevelNumber = PlayerPrefs.GetInt(LevelNumberSaveKey);
        else
            LevelNumber = DefaultOpenLevelNumber;
    }

    public void LoadTimeToCircleSkin()
    {
        if (PlayerPrefs.HasKey(TimeToCicleSkinSaveKey))
            TimeToCircleSkin = PlayerPrefs.GetInt(TimeToCicleSkinSaveKey);
        else
            TimeToCircleSkin = DefaultTimeToCicleSkin;
    }

    public void LoadOpenSkinProgres()
    {
        if (PlayerPrefs.HasKey(SkinOpenProgresSaveKey))
            SkinOpenProgres = PlayerPrefs.GetFloat(SkinOpenProgresSaveKey);
        else
            SkinOpenProgres = DefaultSkinProgresLevel;
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
