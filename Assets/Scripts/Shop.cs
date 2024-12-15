using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private Transform productContainer;
    [SerializeField] private TextMeshProUGUI balanceText;
    [SerializeField] private GameObject productPrefab;
    [SerializeField] private List<ProductSO> productSOList = new();

    private List<Product> products = new();

    private List<Product> soldProducts = new();
    private float balance;

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

    public List<Product> GetProducts()
    {
        return products;
    }

    public void OnProductSold(object productObj)
    {
        Product product = (Product)productObj;
        soldProducts.Add(product);
        UpdateBalance();
    }

    private void UpdateBalance()
    {
        balance = soldProducts.Sum(x => x.GetCurrentPrice());
        balanceText.text = balance.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        shopUI.SetActive(true);
    }
}
