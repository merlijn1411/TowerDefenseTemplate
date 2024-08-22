using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewTower", menuName = "Tower")]
public class TowerData : ScriptableObject
{
    public string TowerName;
    public int Cost;
    public int Damage;
    
    public Sprite TowerIcon;
    public GameObject TowerPrefab;
}
