using System.Collections.Generic;

interface ISaveLoadService
{
    public void SaveInt(string saveKey, int value);


    public bool TryLoadInt(string saveKey, out int value);

    public int LoadInt(string saveKey, int defaultValue);



    public void SaveFloat(string saveKey, float value);


    public bool TryLoadFloat(string saveKey, out float value);


    public float LoadFloat(string saveKey, float defaultValue);


    public void SaveString(string saveKey, string value);


    public bool TryLoadString(string saveKey, out string value);


    public string LoadString(string saveKey, string defaultValue);


    public void SaveBool(string saveKey, bool value);


    public bool TryLoadBool(string saveKey, out bool value);


    public bool LoadBool(string saveKey, bool defaultValue);


    public void DeleteData(params string[] saveKeys);

    public void DeleteData(params string[][] saveKeys);


    public List<int> GetItemsIDs(string value);

}
