using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    /*/
    public static Action<Enemy> OnEnemyKilled;
    public static Action<Enemy> OnEnemyHit;
    /*/

    [SerializeField] private GameObject HealthBarPrefab;
    [SerializeField] private Transform barPosition;
    [SerializeField] private float initiaHealth;
    [SerializeField] private float maxHealth;

    public float CurrenHealth { get; set; }

    private Image _healthBar;
    private EnemyHealth _enemy;
    void Start()
    {
        CreateHealthBar();
        CurrenHealth = initiaHealth;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DealDamage(5f);
        }
        _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, CurrenHealth / maxHealth, Time.deltaTime * 10f);
    }

    private void CreateHealthBar()
    {
        GameObject newHealthbar = Instantiate(HealthBarPrefab, barPosition.position, Quaternion.identity);
        newHealthbar.transform.SetParent(transform);
        EnemyHealthContainer container = newHealthbar.GetComponent<EnemyHealthContainer>();
        _healthBar = container.FillAmountImage;
    }

    public void DealDamage(float damageReceived)
    {
        CurrenHealth -= damageReceived;
        if (CurrenHealth < 0)
        {
            CurrenHealth = 0;
            
        }
        else
        {
            
        }
    }
}
