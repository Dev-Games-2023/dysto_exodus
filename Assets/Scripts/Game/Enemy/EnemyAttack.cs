using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            var shieldController = collision.gameObject.GetComponent<ShieldController>();

            if (shieldController.RemainingShieldPercentage > 0.0)
            {
                var shieldAmount = shieldController.RemainingShield;
                var totalDamage = shieldAmount - _damageAmount;
                if (totalDamage < 0.0) {
                    shieldController.TakeDamage(shieldAmount);
                    healthController.TakeDamage(Math.Abs(totalDamage));
                } else 
                {
                    shieldController.TakeDamage(_damageAmount);
                }
            } else {
                healthController.TakeDamage(_damageAmount);
            }

        }
    }
}
