using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CashRegister : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI profitText;
    [SerializeField] private TextMeshProUGUI refusedProductsText;


    private List<Product> boughtProducts = new();
    private List<Product> refusedProducts = new();

    public void OnProductBought(object productObj)
    {
        Product product = (Product)productObj;
        boughtProducts.Add(product);
        UpdateProfit();
    }
    public void OnProductRefused(object productObj)
    {
        Product product = (Product)productObj;
        refusedProducts.Add(product);
        UpdateRefusedProducts();
    }

    private float GetProfit()
    {
        return boughtProducts.Sum(x => x.GetCurrentPrice() - x.GetAcquisitionPrice());
    }

    private void UpdateProfit()
    {
        profitText.text = GetProfit().ToString();
    }

    private void UpdateRefusedProducts()
    {
        refusedProductsText.text = refusedProducts.Count.ToString();
    }
}
