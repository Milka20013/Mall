using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private Transform productContainer;
    [SerializeField] private GameObject productPrefab;
    [SerializeField] private List<ProductSO> productSOList = new();
    private List<Product> products = new();

    private void Awake()
    {
        SpawnProductsOnToUI();
    }
    private void SpawnProductsOnToUI()
    {
        foreach (var productSO in productSOList)
        {
            var productObj = Instantiate(productPrefab, productContainer);
            Product productScr = productObj.GetComponent<Product>();
            productScr.Init(productSO);
            products.Add(productScr);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        shopUI.SetActive(true);
    }
}
