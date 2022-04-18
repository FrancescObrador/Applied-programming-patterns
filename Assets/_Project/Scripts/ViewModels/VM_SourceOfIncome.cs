//
//  VM_SourceOfIncome.cs
//
//  Created by FrancescObrador on 17/04/2022
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observables;
using System;

namespace ViewModels
{
    public class VM_SourceOfIncome
    {
        [Header("Attributes")]
        public NumericObservable cash = new NumericObservable();
        public NumericObservable progress = new NumericObservable();
        [Min(0)]
        public float waitTime = 0f;
        public TimeSpan time;
        public bool isAutomated = false;

        // Properties
        public bool IsCompleted => progress >= 1f;
        public bool IsAutomated => isAutomated;
        public double CashPerSecond => (cash / waitTime);

        // Private Attributes
        float currentTime = 0f;

        public void TryToCollect()
        {
            if (IsCompleted)
            {
                VM_Wallet.Instance.amount += cash;

                progress.Value = 0f;
                currentTime = 0f;
            }
        }

        public void Automate()
        {
            isAutomated = true;
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

        public string GetTimeSpanText()
        {
           
            var result = time.ToString(@"h\h\ mm\m\ ss\s");

            result.TrimStart('h', 'm', 's', '0');

            return result;
        }
    }
}