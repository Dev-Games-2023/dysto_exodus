using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBarUI : MonoBehaviour
{

    [SerializeField]
    private UnityEngine.UI.Image _shieldBarForegroundImage;

    public void UpdateShieldBar(ShieldController shieldController)
    {
        _shieldBarForegroundImage.fillAmount = shieldController.RemainingShieldPercentage;
    }
}
