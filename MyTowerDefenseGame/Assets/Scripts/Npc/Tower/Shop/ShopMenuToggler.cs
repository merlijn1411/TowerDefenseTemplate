using UnityEngine;

public class ShopMenuToggler : MonoBehaviour
{
    [SerializeField] private GameObject shopCanvas;
    
    private GameSate _gameState;
    private Color _startColor;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
    }
    private void Update()
    {
        ShopToggle();
    }

    private void ShopToggle()
    {
        if (GameManager.Instance.gameState != GameSate.Playing) return;
        if (!Input.GetMouseButtonDown(0)) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit)) return;
        if (hit.collider.gameObject == gameObject)
            ShopDoorSwitch();
    }

    private void ShopDoorSwitch()
    {
        shopCanvas.SetActive(!shopCanvas.activeSelf);
    }

    private void OnMouseEnter()
    {
        if (GameManager.Instance.gameState != GameSate.Playing)
            return;
            
        _renderer.material.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}
