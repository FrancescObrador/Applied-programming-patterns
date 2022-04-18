using System;
using System.Collections.Generic;
using UnityEngine;

namespace ViewModels
{
    public class OfflineEarnings : MonoBehaviour
    {
        DateTime currentDate;
        DateTime oldDate;

        [SerializeField]
        string exitTimeSaveKey = "exitTime";

        void Start()
        {
            if (!PlayerPrefs.HasKey(exitTimeSaveKey))
            {
                PlayerPrefs.SetString(exitTimeSaveKey, DateTime.Now.ToBinary().ToString());
            }

            currentDate = DateTime.Now;
            long temp = Convert.ToInt64(PlayerPrefs.GetString(exitTimeSaveKey));
            DateTime oldDate = DateTime.FromBinary(temp);
            Debug.Log("oldDate: " + oldDate);

            TimeSpan difference = currentDate.Subtract(oldDate);
            Debug.Log("Difference: " + difference.TotalSeconds);

            var offlineTime = difference.TotalSeconds;

            var earned = VM_Wallet.Instance.GetCurrentValuePerSecond() * offlineTime;

            Debug.Log("You earned = " + earned);

            // Wallet.Instance.Amount += earned;


            InvokeRepeating("ExitDate", 2f, 30f);
        }

        private void OnDestroy()
        {
            ExitDate();
        }

        void ExitDate()
        {
            PlayerPrefs.SetString(exitTimeSaveKey, DateTime.Now.ToBinary().ToString());

            Debug.Log("Saved as exit time: " + DateTime.Now);
        }
    }
}