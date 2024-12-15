using UnityEngine;

[CreateAssetMenu(menuName = "Product")]
public class ProductSO : ScriptableObject
{
    public string productName;
    public float price;
    public float acquisitionPrice;
    public Sprite uiSprite;
}
