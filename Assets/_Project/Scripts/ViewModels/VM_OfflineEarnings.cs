using System;
using System.Collections.Generic;
using UnityEngine;


namespace FO.ViewModels
{
    public class VM_OfflineEarnings
    {
        [SerializeField]
        static string exitTimeSaveKey = "exitTime";

        public static double GetOfflineEarnings(double currentCashPerSecond)
        {
            if (!PlayerPrefs.HasKey(exitTimeSaveKey))
            {
                PlayerPrefs.SetString(exitTimeSaveKey, DateTime.Now.ToBinary().ToString());
            }

            var currentDate = DateTime.Now;
            long temp = Convert.ToInt64(PlayerPrefs.GetString(exitTimeSaveKey));
            DateTime oldDate = DateTime.FromBinary(temp);
            Debug.Log("oldDate: " + oldDate);

            TimeSpan difference = currentDate.Subtract(oldDate);

            var offlineTime = difference.TotalSeconds;

            var earned = currentCashPerSecond * offlineTime;
            Debug.Log("Earned = " + earned + " offline time = " + offlineTime);

            return earned;
        }

        public static void ExitDate()
        {
            PlayerPrefs.SetString(exitTimeSaveKey, DateTime.Now.ToBinary().ToString());

            Debug.Log("Saved as exit time: " + DateTime.Now);
        }
    }
}