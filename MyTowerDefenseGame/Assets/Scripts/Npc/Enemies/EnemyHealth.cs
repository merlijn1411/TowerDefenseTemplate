using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public float maxHealth = 100;
    public float CurrentHealth;

    public Image HealthBar;

    void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        HealthBar.fillAmount = CurrentHealth / maxHealth;

        var EnemyPocket = GetComponent<Enemy>();

        if (CurrentHealth <= 0) 
        {
            EnemyPocket.MyWallet();
        }
    }
    
    
}
