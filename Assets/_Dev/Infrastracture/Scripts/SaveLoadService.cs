using System.Collections.Generic;
using System;
using UnityEngine;

public class SaveLoadService : MonoBehaviour, ISaveLoadService
{
    public void SaveInt(string saveKey, int value)
    {
        PlayerPrefs.SetInt(saveKey, value);
        PlayerPrefs.Save();
    }

    public bool TryLoadInt(string saveKey, out int value)
    {
        if (PlayerPrefs.HasKey(saveKey))
        {
            value = PlayerPrefs.GetInt(saveKey);
            return true;
        }
        else
        {
            value = 0;
            return false;
        }
    }

    public int LoadInt(string saveKey, int defaultValue)
    {
        return PlayerPrefs.GetInt(saveKey, defaultValue);
    }


    public void SaveFloat(string saveKey, float value)
    {
        PlayerPrefs.SetFloat(saveKey, value);
        PlayerPrefs.Save();
    }

    public bool TryLoadFloat(string saveKey, out float value)
    {
        if (PlayerPrefs.HasKey(saveKey))
        {
            value = PlayerPrefs.GetFloat(saveKey);
            return true;
        }
        else
        {
            value = 0f;
            return false;
        }
    }

    public float LoadFloat(string saveKey, float defaultValue)
    {
        return PlayerPrefs.GetFloat(saveKey, defaultValue);
    }


    public void SaveString(string saveKey, string value)
    {
        PlayerPrefs.SetString(saveKey, value);
        PlayerPrefs.Save();
    }

    public bool TryLoadString(string saveKey, out string value)
    {
        if (PlayerPrefs.HasKey(saveKey))
        {
            value = PlayerPrefs.GetString(saveKey);
            return true;
        }
        else
        {
            value = "";
            return false;
        }
    }

    public string LoadString(string saveKey, string defaultValue)
    {
        return PlayerPrefs.GetString(saveKey, defaultValue);
    }


    public void SaveBool(string saveKey, bool value)
    {
        var temp = value ? 1 : 0;

        PlayerPrefs.SetInt(saveKey, temp);
        PlayerPrefs.Save();
    }

    public bool TryLoadBool(string saveKey, out bool value)
    {
        if (!PlayerPrefs.HasKey(saveKey))
        {
            value = false;
            return false;
        }

        var temp = PlayerPrefs.GetInt(saveKey);
        value = (temp == 1);
        return true;

    }

    public bool LoadBool(string saveKey, bool defaultValue)
    {
        var defaultTemp = defaultValue ? 1 : 0;
        var temp = PlayerPrefs.GetInt(saveKey, defaultTemp);
        return (temp == 1);
    }

    public void DeleteData(params string[] saveKeys)
    {
        foreach (var data in saveKeys)
        {
            PlayerPrefs.DeleteKey(data);
        }
    }
    public void DeleteData(params string[][] saveKeys)
    {
        for (int i = 0; i < saveKeys.Length; i++)
        {
            for (int k = 0; k < saveKeys[i].Length; k++)
            {
                PlayerPrefs.DeleteKey(saveKeys[i][k]);
            }
        }
    }

    public List<int> GetItemsIDs(string value)
    {
        string itemToUnlock = value;

        List<int> itemsIDs = new List<int>();

        if (!string.IsNullOrEmpty(itemToUnlock))
        {
            string[] unlockIDArray = itemToUnlock.Split(";");

            foreach (var ids in unlockIDArray)
            {
                if (String.IsNullOrEmpty(ids))
                    continue;

                if (!int.TryParse(ids, out int id))
                {
                    Debug.LogError($"Failed to parse unlock id {ids}");
                    continue;
                }

                itemsIDs.Add(id);
            }
        }

        return itemsIDs;
    }
}
