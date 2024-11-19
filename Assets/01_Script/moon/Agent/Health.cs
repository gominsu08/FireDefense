using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IAgentComponent
{
    public float _maxHealth = 3;
    private float _currentHealth;
    private Agent _agent;
    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
    }
    public void Initialize(Agent agent)
    {
        _agent = agent;
    }
    private void Start()
    {
        ResetHealth();
    }
    public void ResetHealth()
    {
        _maxHealth = _agent.DataCompo.health;
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            _agent.Dead();
            return;
        }
    }
}
