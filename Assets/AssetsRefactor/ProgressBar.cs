using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    int maxAmount;
    float currentAmount;
    [SerializeField] Image mask;
    void Start()
    {
        // += GetCurrentFill;
        mask = gameObject.GetComponent<Image>();
    }

    private void OnEnable() {
        if(mask == null){
            mask = gameObject.GetComponent<Image>();
        }
        ManagerToOutMiddle._updateUIProgressBarCurrentMax += GetCurrentFill;
    }

    void OnDisable(){
        ManagerToOutMiddle._updateUIProgressBarCurrentMax -= GetCurrentFill;
    }

    void GetCurrentFill(float currentAmount, float maxAmount){
        if(mask == null){
            mask = gameObject.GetComponent<Image>();
        }
        float fillAmount = currentAmount / maxAmount;
        mask.fillAmount = fillAmount;
    }
}
