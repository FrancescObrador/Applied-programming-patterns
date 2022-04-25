//
//  SourceOfIncomeView.cs
//
//  Created by FrancescObrador on 24/03/2022
//

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FO.Utilities;

using FO.ViewModels;

namespace FO.Views
{
    public class V_SourceOfIncome : MonoBehaviour
    {
        [Header("External references")]
        [SerializeField] Image progressBar;
        [SerializeField] Button collectButton;
        [SerializeField] Button automateButton;
        [SerializeField] Button upgradeButton;

        [SerializeField] TextMeshProUGUI cashDisplay;

        public VM_SourceOfIncome vmSource;

        void Start()
        {
            if (vmSource.isAutomated)
            {
                vmSource.Automate();
            }
            else
            {
                collectButton.onClick.AddListener(vmSource.TryToCollect);
                collectButton.interactable = true;

                automateButton.onClick.AddListener(vmSource.Automate);
            }

            upgradeButton.onClick.AddListener(vmSource.Upgrade);

            vmSource.cash.Subscribe(UpdateAmountView);
            vmSource.progress.Subscribe(UpdateProgressBarView);
        }

        private void Update()
        {
            vmSource.Update();
        }

        private void UpdateAmountView(double value)
        {
            cashDisplay.text = AaNotationConversor.FormatNumber(value);
        }

        private void UpdateProgressBarView(double value)
        {
            progressBar.fillAmount = (float)value;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            UpdateAmountView(vmSource.cash.Value);
        }
#endif
    }
}
