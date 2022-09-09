using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradePowerPanel : UpgradePanel
{
    [Inject]
    new private void Construct(ISaveValueService saveValueService)
    {
        _saveValueService = saveValueService;
    }

    private void Start()
    {//   SetCostByLevel(_saveValueService.PowerLevel);
        // _upgradeButton.onClick.AddListener(() => UpgradeLevel());
        _upgradeButton.onClick.AddListener(UpgradeLevel);
        //  _saveValueService.PowerLevelChangeEvent += SetCostByLevel;
        RefreshView();
    }

    private void OnDestroy()
    {
        _upgradeButton.onClick.RemoveListener(UpgradeLevel);
        //  _saveValueService.PowerLevelChangeEvent -= SetCostByLevel;
    }

    protected override void UpgradeLevel()
    {
        if (_saveValueService.TrySpendCoins(_costUpgradeUp))
        {

        }
        //    _saveValueService.PowerLevel++;
    }


    protected override void RefreshView()
    {
        //   SetLevelText(_saveValueService.PowerLevel);
        //   RefreshUpgradeUpCostText(_saveValueService.PowerLevel);
        //   UpgradeButtonActivator(_saveValueService.CoinsCount, _saveValueService.PowerLevel);
    }

}
