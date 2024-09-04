using UnityEngine;

public class ShopMenuToggler : MonoBehaviour
{
    private Canvas _shopCanvas;

    private bool _isShopOpen;
    private Color startcolor;
    private Renderer _renderer;

    private void Start()
    {
        _shopCanvas = GetComponentInChildren<Canvas>();
        _renderer = GetComponent<Renderer>();
        
        CloseShop();
    }
    private void Update()
    {
        ShopToggle();
    }

    private void ShopToggle()
    {
        if (!Pause_Controller.GameisPaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        if (_isShopOpen)
                            CloseShop();
                        else
                            OpensHop();
                    }
                }
            }
        }
    }

    private void OpensHop()
    {
        _isShopOpen = true;
        _shopCanvas.enabled = true;
    }

    private void CloseShop()
    {
        _isShopOpen = false;
        _shopCanvas.enabled = false;
    }

    private void OnMouseEnter()
    {
        if (!Pause_Controller.GameisPaused)
        {
            startcolor = _renderer.material.color;
            _renderer.material.color = Color.yellow;
        }
        else
            _renderer.material.color = startcolor;
    }
    
    private void OnMouseExit()
    {
        _renderer.material.color = startcolor;
    }
}
