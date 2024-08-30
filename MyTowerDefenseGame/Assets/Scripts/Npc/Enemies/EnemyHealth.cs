using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    private float _maxHealth;
    private Enemy _enemy;

    [SerializeField] private Image healthBar;

    public void Start()
    {
        _enemy = GetComponent<Enemy>();
        _maxHealth = _enemy.Health;
    }

    public void TakeDamage(float damage)
    {
        _enemy.Health -= damage;

        healthBar.fillAmount = _enemy.Health / _maxHealth;
        
        if (_enemy.Health <= 0) 
        {
            _enemy.MyWallet();
        }
    }
    
    
}
