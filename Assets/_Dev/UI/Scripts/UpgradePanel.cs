using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private int[] _costValue;
    [SerializeField] protected Button _upgradeButton;
    [SerializeField] private Text _costText;
    [SerializeField] private Text _levelText;

    protected int _costUpgradeUp;

    protected ISaveValueService _saveValueService;

    [Inject]
    protected void Construct(ISaveValueService saveValueService)
    {
        _saveValueService = saveValueService;
    }

    virtual protected void UpgradeLevel()
    {

    }
    virtual protected void RefreshView()
    {

    }

    protected void SetLevelText(int value)
    {
        var trueLevel = value + 1;
        _levelText.text = trueLevel.ToString();
    }

    protected void SetCostByLevel(int level)
    {
        if (level < _costValue.Length)
        {
            _costUpgradeUp = _costValue[level];
            RefreshView();
        }
        else
        {
            _costUpgradeUp = _costValue[_costValue.Length - 1];
            RefreshView();
        }
    }

    protected void RefreshUpgradeUpCostText(int value)
    {
        _costText.text = _costText.ToString();

        if (value >= _costValue.Length)
            _costText.text = "Max";
        else
            _costText.text = AbbrevationUtility.AbbreviateNumber(_costUpgradeUp);
    }

    protected void UpgradeButtonActivator(int coinCount, int level)
    {
        if (level >= _costValue.Length)
            _upgradeButton.interactable = false;
        else
            _upgradeButton.interactable = _costUpgradeUp <= coinCount;
    }
}

