using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Damage;
    public int Worth;

    public void MyWallet()
    {
        PlayerStats.Main.Money += Worth;
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        PlayerStats.Main.Lives -= Damage;
        Destroy(gameObject);
    }
}
