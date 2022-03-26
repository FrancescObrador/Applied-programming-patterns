//
//  Wallet.cs
//
//  Created by FrancescObrador on 24/03/2022
//

using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance;

    [SerializeField] TextMeshProUGUI text;

    double total = 0d;

    public double Total
    {
        get => total;
        set => total = value;
    }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (!text) Debug.LogError("There is no" + text.name);

        if (!PlayerPrefs.HasKey("total"))
        {
            PlayerPrefs.SetString("total", total.ToString());
        }

        var saved = double.Parse(PlayerPrefs.GetString("total"));

        Debug.Log(saved);

        UpdateValue(saved);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetString("total", total.ToString());
        Debug.Log("Saved total: " + total);
    }

    public void UpdateValue(double value)
    {
        total += value;
        UpdateView();
    }

    void UpdateView()
    {
        text.text = AaNotationConversor.FormatNumber(total);
    }
}
