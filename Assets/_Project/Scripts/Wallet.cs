//
//  Wallet.cs
//
//  Created by FrancescObrador on 24/03/2022
//

using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Observables;

public class Wallet : SingletonMonobehaviour<Wallet>
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] private NumericObservable amount;

    public double Amount
    {
        get => amount;
        set => amount.Value = value;
    }

    void Start()
    {
        // Guards
        if (!text) Debug.LogError("There is no" + text.name);

        if (!PlayerPrefs.HasKey("total"))
        {
            PlayerPrefs.SetString("total", amount.ToString());
        }
        var saved = double.Parse(PlayerPrefs.GetString("total", "0"));

        Debug.Log("Loaded from playerprefs: " + saved);

        amount = new NumericObservable(saved, UpdateAmountView);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetString("total", amount.ToString());
        Debug.Log("Saved total: " + amount);
    }

    public void UpdateAmountView(double value)
    {
        text.text = AaNotationConversor.FormatNumber(value);
    }

    public double GetCurrentValuePerSecond()
    {
        var sourcesOfIncome = new List<SourceOfIncome>(FindObjectsOfType<SourceOfIncome>());

        double result = 0d;

        foreach (var source in sourcesOfIncome)
        {
            if (source.IsAutomated)
            {
                result += source.ValuePerSecond;
            }
        }

        return result;
    }
}
