using UnityEngine;
using Zenject;

public class SkinProgresChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] _skinPrefabs;


    private ISaveValueService _saveValueService;
    private IGamePlayService _gamePlayService;
    private int _skinLevel;


    [Inject]
    private void Construct(ISaveValueService saveValueService, IGamePlayService gamePlayService)
    {
        _saveValueService = saveValueService;
        _gamePlayService = gamePlayService;
        _skinLevel = _saveValueService.SkinLevel;
     //   _gamePlayService.WinPopupShowEvent
    }

    private void OnDestroy()
    {

    }

    private void RefreshSkin()
    {
        SkinActivator(_saveValueService.SkinLevel);
    }

    private void SkinDeactivator()
    {
        foreach (var go in _skinPrefabs)
        {
            go.SetActive(false);
        }
    }
    private void SkinActivator(int level)
    {
        for (int i = 0; i < _skinPrefabs.Length; i++)
        {
            if (i == level)
            {
                _skinPrefabs[i].SetActive(true);
                _skinLevel = _saveValueService.SkinLevel;
            }
            else
            {
                _skinPrefabs[i].SetActive(false);
            }
        }
    }
}
