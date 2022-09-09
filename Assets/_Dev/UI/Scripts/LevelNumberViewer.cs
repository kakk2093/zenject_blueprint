using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelNumberViewer : MonoBehaviour
{
    [SerializeField] private Text _lvlText;

    private ISaveValueService _saveValueService;

    [Inject]
    private void Construct(ISaveValueService saveValueService)
    {
        _saveValueService = saveValueService;
    }

    private void Start()
    {
        SetLevelText();
    }

    private void SetLevelText()
    {
        _lvlText.text = "LVL " + _saveValueService.TrueLevelNumber.ToString();
    }
}
