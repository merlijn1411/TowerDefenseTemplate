using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName = "Tower")]
public class TowerData : ScriptableObject
{
    public string TowerName;
    public int Cost;

    public float AttackRange;
    public float AttackCooldown;
    
    public Sprite TowerIcon;
    public GameObject TowerPrefab;
    public GameObject ProjectillePrefab;
}
