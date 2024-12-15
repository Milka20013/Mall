using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceText;


    private ProductSO productData;

    private float currentPrice;
    public void Init(ProductSO productData)
    {
        this.productData = productData;
        currentPrice = productData.price;
        image.sprite = productData.uiSprite;
        nameText.text = productData.name;
        priceText.text = currentPrice.ToString();
    }

    public void SetCurrentPrice(string price)
    {
        if (float.TryParse(price, out float result))
        {
            currentPrice = result;
            UpdatePriceText();
        }
    }


    public void OpenPriceEditMenu()
    {
        PriceChangerInputField.instance.Open(SetCurrentPrice);
    }
    public void UpdatePriceText()
    {
        priceText.text = currentPrice.ToString();
    }

    public float GetCurrentPrice()
    {
        return currentPrice;
    }

    public float GetAcquisitionPrice()
    {
        return productData.acquisitionPrice;
    }
}
