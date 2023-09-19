using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Damage;
    public int Worth;

    public void MyWallet()
    {
        PlayerStats.Money += Worth;
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        PlayerStats.lives -= Damage;
        Destroy(gameObject);
    }
}
