//
//  SourceOfIncome.cs
//
//  Created by FrancescObrador on 24/03/2022
//

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SourceOfIncome : MonoBehaviour
{
    [Header("External references")]
    [SerializeField] Image progressBar;
    [SerializeField] Button collectButton;
    [SerializeField] Button automateButton;
    [SerializeField] Button UpgradeButton;
    [SerializeField] TextMeshProUGUI valueDisplay;

    [Header("Attributes")]
    [Min(0)]
    [SerializeField] float value = 0f;
    [Min(0)]
    [SerializeField] float waitTime = 0f;
    [SerializeField] bool isAutomated = false;

    // Properties
    public bool IsCompleted => progress >= 1f;

    public float ValuePerSecond => (value/waitTime);

    public bool IsAutomated => isAutomated;

    // Private Attributes
   
    float currentTime = 0f;
    float progress = 0f;
    Coroutine processCoroutine;

    private void Start()
    {
        if (isAutomated)
        {
            Automate();
        }
        else
        {
            collectButton.onClick.AddListener(Collect);
            collectButton.interactable = true;

            automateButton.onClick.AddListener(Automate);
        }
        
        StartCoroutine(Process());
    }

    public void Collect()
    {
        if (IsCompleted)
        {
            Debug.Log("Adding: " + value + " from " + this.name);
            Wallet.Instance.UpdateValue(value);

            progress = 0f;
            currentTime = 0f;

            if(processCoroutine == null)
            {
               processCoroutine = StartCoroutine(Process());
            }
        }
    }

    public void Automate()
    {
        isAutomated = true;
        collectButton.interactable = false;
        automateButton.gameObject.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(AutomatedProcess());
    }

    public IEnumerator Process()
    {
        while(!IsCompleted)
        {
            currentTime += Time.deltaTime;
            progress = currentTime / waitTime;
            progressBar.fillAmount = progress;
            yield return new WaitForEndOfFrame();
        }

        processCoroutine = null;
    }

    public IEnumerator AutomatedProcess()
    {
        while (isAutomated)
        {
            if(IsCompleted)
            {
                Collect();
            }
            yield return null;
        }
    }

    void OnValidate()
    {
        valueDisplay.text = AaNotationConversor.FormatNumber(value);
    }
}

