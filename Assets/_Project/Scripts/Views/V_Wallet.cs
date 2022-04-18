//
//  Wallet.cs
//
//  Created by FrancescObrador on 24/03/2022
//

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ViewModels;

namespace Views
{
    public class V_Wallet : SingletonMonobehaviour<V_Wallet>
    {
        [SerializeField] TextMeshProUGUI text;

        void Start()
        {
            // Guards
            if (!text) Debug.LogError("There is no" + text.name);

            VM_Wallet.Instance.Start();

            VM_Wallet.Instance.amount.Subscribe(UpdateAmountView);
        }

        public void UpdateAmountView(double value)
        {
            text.text = AaNotationConversor.FormatNumber(value);
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetString("total", VM_Wallet.Instance.amount.ToString());
            Debug.Log("Saved total: " + VM_Wallet.Instance.amount);
        }
    }
}