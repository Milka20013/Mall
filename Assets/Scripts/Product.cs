using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    private ProductSO productData;

    public void Init(ProductSO productData)
    {
        this.productData = productData;
    }

    private void Start()
    {
        var image = GetComponent<Image>();
        image.sprite = productData.uiSprite;
    }

    public float GetCurrentPrice()
    {
        return productData.price;
    }

    public float GetAcquisitionPrice()
    {
        return productData.acquisitionPrice;
    }
}
