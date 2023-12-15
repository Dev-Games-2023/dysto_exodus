using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float _currentHealth;

    [SerializeField] private float _maximumHealth;
    [SerializeField] FloatingHealthBar healthBar; 

    public UnityEvent OnDied;

    public bool IsInvincible { get; set; }
    public bool IsDead { get; set; }

    public UnityEvent OnDamaged;

    public UnityEvent OnHealthChanged;

    [Header("Events")] public GameEvent onPlayerDied;
    [Header("Events")] public GameEvent onEnemyKilled;

    void Start()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        _currentHealth -= damageAmount;
        OnHealthChanged.Invoke();

        if (healthBar) healthBar.UpdateHealthBar(_currentHealth, _maximumHealth);

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if (_currentHealth == 0)
        {
            if (!healthBar) {
                onPlayerDied.Raise(this, true);
                OnDied.Invoke();
            } else {
                OnDied.Invoke();
                onEnemyKilled.Raise(this, true);
            }
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maximumHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;
        OnHealthChanged.Invoke();

        if (_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }
    }
}
