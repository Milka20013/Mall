using UnityEngine;

public class Customer : MonoBehaviour
{
    private float minAmountOfMoney = 50;
    private float maxAmountOfMoney = 200;

    private float minPriceDeviation = 0.7f;
    private float maxPriceDeviation = 1.2f;


    private float currentMoney;

    private void Start()
    {
        currentMoney = Random.Range(minAmountOfMoney, maxAmountOfMoney);
    }

    private void InspectProduct(Product product)
    {
        float price = product.GetCurrentPrice();
        float acquisitionPrice = product.GetAcquisitionPrice();

        float priceDeviation = Random.Range(minPriceDeviation, maxPriceDeviation);
        if (price < acquisitionPrice * priceDeviation)
        {
            BuyProduct(product);
            return;
        }
        RefuseProduct(product);
    }

    private void BuyProduct(Product product)
    {

    }

    private void RefuseProduct(Product product)
    {

    }
}
