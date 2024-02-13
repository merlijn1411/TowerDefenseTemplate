using UnityEngine;

public class Blueprint : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;
    [SerializeField] private int[] towerCosts;

    private GameObject _selectedTower;

    public void TowerSelected(int towerIndex)
    {
        if (towerIndex < 0 || towerIndex >= towers.Length)
        {
            return;
        }

        int cost = towerCosts[towerIndex];

        if (PlayerStats.Money < cost)
        {
            Debug.Log("Can't afford it");
            return;
        }

        PlayerStats.Money -= cost;

        _selectedTower = towers[towerIndex];
        ReplaceBuildPlatform();
    }

    private void ReplaceBuildPlatform()
    {
        if (_selectedTower == null)
        {
            return;
        }

        Vector3 position = gameObject.transform.position;
        Quaternion rotation = gameObject.transform.rotation;

        GameObject newObject = Instantiate(_selectedTower, position, rotation);
        newObject.transform.parent = gameObject.transform.parent;
        newObject.transform.localScale = gameObject.transform.localScale;

        Destroy(gameObject);
    }
}