using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController _healthController;
    private ShieldController _shieldController;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
        _shieldController = GetComponent<ShieldController>();
    }

    public void StartInvincibility(float invincibilityDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)
    {
        if (_shieldController.RemainingShieldPercentage > 0.0)
        {
            _shieldController.IsInvincible = true;
            yield return new WaitForSeconds(invincibilityDuration);
            _shieldController.IsInvincible = false;
        }
        else
        {
            _healthController.IsInvincible = true;
            yield return new WaitForSeconds(invincibilityDuration);
            _healthController.IsInvincible = false;
        }
    }
}
