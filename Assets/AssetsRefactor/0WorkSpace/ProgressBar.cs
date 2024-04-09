using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Image mask;
    void Start()
    {
    }

    private void OnEnable() {
        ManagerToOutMiddle._updateUIProgressBarCurrentMax += GetCurrentFill;
    }

    void OnDisable(){
        ManagerToOutMiddle._updateUIProgressBarCurrentMax -= GetCurrentFill;
    }

    void GetCurrentFill(float currentAmount, float maxAmount){
        float fillAmount = currentAmount / maxAmount;
        mask.fillAmount = fillAmount;
    }
}
