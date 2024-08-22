using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerMenuSpawner : MonoBehaviour
{
    [SerializeField] private List<TowerData> towerList;
    private Button[] _menuButtons;
    private void Start()
    {
        InizializeButtons();
    }

    private void InizializeButtons()
    {
        _menuButtons = GetComponentsInChildren<Button>();
        
        _menuButtons[0].onClick.AddListener(SetMenuData(towerList[0].TowerPrefab, 0);
        _menuButtons[1].onClick.AddListener(SetMenuData(towerList[1].TowerPrefab,1));
    }

    private void SetMenuData(GameObject tower,int towerIndex)
    {
        
    }
}
