using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShieldController : MonoBehaviour
{
    [SerializeField]
    private float _currentShield;
    
    [SerializeField]
    private float _maximumShield;

    public UnityEvent OnDied;

    public bool IsInvincible { get; set; }

    public UnityEvent OnDamaged;

    public UnityEvent OnShieldChanged;

    public float RemainingShieldPercentage
    {
        get
        {
            return _currentShield / _maximumShield;
        }
    }

    public float RemainingShield
    {
        get
        {
            return _currentShield;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentShield == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        _currentShield -= damageAmount;
        OnShieldChanged.Invoke();

        if (_currentShield < 0)
        {
            _currentShield = 0;
        }

        OnDamaged.Invoke();
    }

    public void AddShield(float amountToAdd)
    {
        if (_currentShield == _maximumShield)
        {
            return;
        }

        _currentShield += amountToAdd;
        OnShieldChanged.Invoke();
        
        if (_currentShield > _maximumShield)
        {
            _currentShield = _maximumShield;
        }
    }
}
