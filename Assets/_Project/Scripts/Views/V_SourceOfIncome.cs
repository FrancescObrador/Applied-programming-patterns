//
//  SourceOfIncomeView.cs
//
//  Created by FrancescObrador on 24/03/2022
//

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using ViewModels;

namespace Views
{
    public class V_SourceOfIncome : MonoBehaviour
    {
        [Header("External references")]
        [SerializeField] Image progressBar;
        [SerializeField] Button collectButton;
        [SerializeField] Button automateButton;
        [SerializeField] Button upgradeButton;

        [SerializeField] TextMeshProUGUI cashDisplay;

        [SerializeField]
        public VM_SourceOfIncome source;

        void Start()
        {
            if (source.isAutomated)
            {
                source.Automate();
            }
            else
            {
                collectButton.onClick.AddListener(source.TryToCollect);
                collectButton.interactable = true;

                automateButton.onClick.AddListener(source.Automate);
            }

            source.cash.Subscribe(UpdateAmountView);
            source.progress.Subscribe(UpdateProgressBarView);
        }

        private void Update()
        {
            source.Update();
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
            UpdateAmountView(source.cash.Value);
        }
#endif
    }
}
