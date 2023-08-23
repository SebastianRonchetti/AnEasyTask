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
    }

    void OnDestroy() {
        
        GameManagerPoV.onUpdateUIBar -= GetCurrentFill;
    }

    void GetCurrentFill(object sender, GameManagerPoV.onUpdateUIBar_eventArgs e){
        if(mask == null){
            mask = gameObject.GetComponent<Image>();
        }
        float fillAmount = e.currentAmount / e.maxAmount;
        mask.fillAmount = fillAmount;
    }
}
