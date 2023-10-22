using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float CurrentHealth;

    public Image HealthBar;

    void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        CurrentHealth -= dmg;

        HealthBar.fillAmount = CurrentHealth / maxHealth;

        Enemy EnemyPocket = GetComponent<Enemy>();

        if (CurrentHealth <= 0) 
        {
            EnemyPocket.MyWallet();
        }
    }
}
