using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health;
    public float MoveSpeed;
    
    public int Damage;
    public int Coins;

    public void MyWallet()
    {
        PlayerStats.Main.Money += Coins;
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        PlayerStats.Main.Lives -= Damage;
        Destroy(gameObject);
    }
}
