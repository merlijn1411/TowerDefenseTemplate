using Mono.CompilerServices.SymbolWriter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;
using System;

public class ShopDoor : MonoBehaviour
{
    private GameObject shopCanvas;
    public GameObject uiPrefab;

    private bool isShopOpen;
    private Color startcolor;
    private Renderer _renderer;


    void Start()
    {
        isShopOpen = false;
        _renderer = GetComponent<Renderer>();
    }
    void Update()
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
                    Debug.Log("closed!");
                    CloseShop();
                }
            }
        }
    }

    void OpensHop()
    {
        isShopOpen = true;

        shopCanvas = Instantiate(uiPrefab, transform.position, Quaternion.identity);
    }

    void CloseShop()
    {
        isShopOpen = false;

        if (shopCanvas != null)
        {
            Destroy(shopCanvas);
        }
    }

    void OnMouseEnter()
    {
        startcolor = _renderer.material.color;
        _renderer.material.color = Color.yellow;
    }
    private void OnMouseExit()
    {
        _renderer.material.color = startcolor;
    }
}
