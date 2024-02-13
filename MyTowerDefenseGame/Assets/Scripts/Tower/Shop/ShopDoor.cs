using UnityEngine;

public class ShopDoor : MonoBehaviour
{
    public Canvas shopCanvas;
    public GameObject uiPrefab;

    private bool isShopOpen;
    private Color startcolor;
    private Renderer _renderer;


    private void Start()
    {
        shopCanvas.enabled = false;
        isShopOpen = false;
        _renderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        if (!Pause_Controller.GameisPaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        if (isShopOpen)
                        {
                            CloseShop();
                        }
                        else
                        {
                            OpensHop();
                        }
                    }
                    else if (isShopOpen)
                    {
                        CloseShop();
                    }
                }
            }
        }
        else if (Pause_Controller.GameisPaused)
        {
            Debug.Log("kan niet interacten");
        }

    }

    public void OpensHop()
    {
        isShopOpen = true;
        shopCanvas.enabled = true;
        //shopCanvas = Instantiate(uiPrefab, transform.position, Quaternion.identity);
    }

    public void CloseShop()
    {
        isShopOpen = false;
        shopCanvas.enabled = false;
        //if (shopCanvas != null)
        //{
        //    Destroy(shopCanvas);
        //}
    }

    void OnMouseEnter()
    {
        if (!Pause_Controller.GameisPaused)
        {
            startcolor = _renderer.material.color;
            _renderer.material.color = Color.yellow;
        }
        else if (Pause_Controller.GameisPaused)
        {
            Debug.Log("kan niet interacten");
        }

    }
    private void OnMouseExit()
    {
        _renderer.material.color = startcolor;
    }
}
