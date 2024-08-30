using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerMenuManager : MonoBehaviour
{
    [SerializeField] private List<TowerData> towerList;
    [SerializeField] private GameObject menuParent;
    private Button[] _menuButtons;
    
    private void Start()
    {
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        _menuButtons = GetComponentsInChildren<Button>();
        
        _menuButtons[0].onClick.AddListener(() => SetTowerData(towerList[0].TowerPrefab, 0));
        _menuButtons[1].onClick.AddListener(() => SetTowerData(towerList[1].TowerPrefab, 1));
    }

    private void SetTowerData(GameObject tower, int towerIndex)
    {
        if (!CheckBalance(towerIndex)) return;
        var position = gameObject.transform.position;
        var rotation = gameObject.transform.rotation;
        
        Instantiate(tower, position, rotation);
        Destroy(menuParent);

    }

    private bool CheckBalance(int towerIndex)
    {
        if (PlayerStats.Money < towerList[towerIndex].Cost)
        {
            Debug.Log("Can't Afford Building");
            return false;
        }
        
        PlayerStats.Money -= towerList[towerIndex].Cost;
        return true;
    }
}
