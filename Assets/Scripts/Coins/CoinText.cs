using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    Text _text;
    private void Start()
    {
        _text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        CoinManager.OnAddPoints += ChangeText;
    }

    private void OnDisable()
    {
        CoinManager.OnAddPoints -= ChangeText;
    }

    private void ChangeText()
    {
        _text.text = "" + CoinManager.Instance.Amount;
    }
}
