using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private Image _card;
    [SerializeField] private Image _object;
    [SerializeField] private TextMeshProUGUI _description;

    private UpgradeData _data;
    private Action<UpgradeProperty, int> _onUpgrade;

    public void Init(UpgradeData data, Action<UpgradeProperty, int> onUpgrade)
    {
        _data = data;
        _card.sprite = _data.CardSprite;
        _object.sprite = _data.ObjectSprite;
        _description.text = _data.Description;
        _onUpgrade = onUpgrade;
    }

    public void OnSelect()
    {
        _onUpgrade(_data.UpgradeProperty, _data.Boost);
    }
}
