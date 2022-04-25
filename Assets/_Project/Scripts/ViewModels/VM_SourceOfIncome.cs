//
//  VM_SourceOfIncome.cs
//
//  Created by FrancescObrador on 17/04/2022
//

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using FO.Utilities;

namespace FO.ViewModels
{
    [Serializable]
    public class VM_SourceOfIncome
    {
        [Header("Attributes")]
        public NumericObservable  cash = new NumericObservable();
        public NumericObservable progress = new NumericObservable();

        [Tooltip("In seconds")]
        public int waitTime;
        public bool isAutomated = false;

        // Properties
        public bool IsCompleted => progress >= 1f;
        public bool IsAutomated => isAutomated;
        public double CashPerSecond => (cash / waitTime);
        public string TimeSpanText => TimeSpanNotationConversor.FormatSecondsToTime(waitTime);

        // Private Attributes
        float currentTime = 0f;

        public void TryToCollect()
        {
            if (IsCompleted)
            {
                VM_Wallet.Instance.AddCash(cash);

                progress.Value = 0f;
                currentTime = 0f;
            }
        }

        public void Automate()
        {
            isAutomated = true;
        }

        public void Upgrade()
        {
            //TODO: Level-up the source (faster and/or cheaper)
            cash.Value *= 2.5f;
        }

        public void Update()
        {
            if (!IsCompleted)
            {
                currentTime += Time.deltaTime;
                progress.Value = currentTime / waitTime;
            }

            if (IsAutomated)
            {
                TryToCollect();
            }
        }
    }
}