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
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    ShopDoorSwitch();
                }
            }
        }
        
    }

    private void ShopDoorSwitch()
    {
        shopCanvas.SetActive(!shopCanvas.activeSelf);
    }

    private void OnMouseEnter()
    {
        if (_gameState == GameSate.Paused)
        {
            return;
        }
        
        _renderer.material.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}
