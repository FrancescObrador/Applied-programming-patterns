//
//  VM_Wallet.cs
//
//  Created by FrancescObrador on 17/04/2022
//
	
using System.Collections.Generic;
using UnityEngine;
using FO.Utilities;

namespace FO.ViewModels
{
    [System.Serializable]
	public class VM_Wallet : Singleton<VM_Wallet>
	{
        [SerializeField] public NumericObservable cash = new NumericObservable();

        

		public void Init()
        {
            //TODO: Make a better save system
			if (!PlayerPrefs.HasKey("total"))
			{
				PlayerPrefs.SetString("total", cash.ToString());
			}
			var saved = double.Parse(PlayerPrefs.GetString("total", "0"));

			Debug.Log("Loaded from playerprefs: " + saved);

			cash += saved;

            cash += VM_OfflineEarnings.GetOfflineEarnings(GetCurrentTotalValuePerSecond());
		}

        public void AddCash(double amount)
        {
            cash += amount;
        }

        // TODO: Move this to another script
        public double GetCurrentTotalValuePerSecond()
        {
            //The wallet needs a reference to the viewmodels (?)

            List<VM_SourceOfIncome> viewModels = new List<VM_SourceOfIncome>();

            /*
            foreach (var vm in sourcesOfIncomeViews)
            {
                viewModels.Add(vm.source);
            }
            */

            double result = 0d;

            foreach (var source in viewModels)
            {
                if (source.IsAutomated)
                {
                    result += source.CashPerSecond;
                }
            }

            return result;
        }
    }
}
