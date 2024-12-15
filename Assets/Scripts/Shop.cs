using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shop : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private Transform productContainer;
    [SerializeField] private TextMeshProUGUI balanceText;
    [SerializeField] private GameObject productPrefab;
    [SerializeField] private List<ProductSO> productSOList = new();

    [Header("Thief managing")]
    [SerializeField] private Button thiefConverterButton;
    private List<Product> products = new();

    private List<Product> soldProducts = new();
    private List<Product> stolenProducts = new();

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

    public void OnProductStolen(object productObj)
    {
        Product product = (Product)productObj;
        stolenProducts.Add(product);
        UpdateBalance();
    }

    public void OnThiefEntered(float reactionTime, Action convertAction)
    {
        thiefConverterButton.gameObject.SetActive(true);
        thiefConverterButton.onClick.AddListener(new(convertAction));
        StartCoroutine(CloseThiefConvertWindow(reactionTime));
    }

    IEnumerator CloseThiefConvertWindow(float reactionTime)
    {
        yield return new WaitForSeconds(reactionTime);
        thiefConverterButton.onClick.RemoveAllListeners();
        thiefConverterButton.gameObject.SetActive(false);
    }

    private void UpdateBalance()
    {
        balance = soldProducts.Sum(x => x.GetCurrentPrice());
        balance -= stolenProducts.Sum(x => x.GetAcquisitionPrice());
        balanceText.text = balance.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        shopUI.SetActive(true);
    }
}
