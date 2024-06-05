using System;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private UpgradeData[] _upgradesData;
    [SerializeField] private Upgrade[] _upgradeButtons;
    [SerializeField] private GameObject _ui; 

    private Action<UpgradeProperty, int> _upgradeAction;

    public void Init(Action<UpgradeProperty, int> upgradeAction)
    {
        _upgradeAction = upgradeAction;
    }

    public void Show()
    {
        _ui.SetActive(true);
        for (int i = 0; i < _upgradeButtons.Length; i++)
        {
            _upgradeButtons[i].Init(_upgradesData[i], _upgradeAction);
        }
    }
}
