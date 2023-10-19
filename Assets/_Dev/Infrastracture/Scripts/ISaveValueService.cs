using System;

public interface ISaveValueService
{
    event Action<int> ChangeCoinsCountEvent;
    event Action<int> ChangeSkinLevelEvent;

    int LevelNumber { get; set; }
    int TrueLevelNumber { get; set; }
    int CoinsCount { get; set; }
    int SkinLevel { get; set; }
    float SkinOpenProgres { get; set; }
    int TimeToCircleSkin { get; set; }


    void AddCoins(int value);
    bool TrySpendCoins(int value);
    void LoadLevelNumber();
    void LoadTrueLevelNumber();
    void SaveLevelNumber();
    void LoadCoinsCount();
    void SaveCoinsCount();
    void LoadSkinLevel();
    void SaveSkinLevel();
    void LoadOpenSkinProgres();
    void SaveOpenSkinProgres();
    void LoadTimeToCircleSkin();
    void SaveTimeToCircleSkin();
}
