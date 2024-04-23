using UnityEngine;
using System;
using TMPro;

public class ScrollerUIManager : MonoBehaviour {
    
    TextMeshProUGUI pointDisplay;
    private void Awake() {
        ScrollerMiddlemanSO.displayHealth += displayHealth;
    }

    void displayPoints(){
        //pointDisplay.text = points.ToString();
    }

    void displayHealth(int _currentHealth){

    }
}