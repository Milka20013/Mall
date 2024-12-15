using UnityEngine;

public class Customer : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private LayerMask shopLayer;
    [SerializeField] private float maxShopDistance;
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance = 0.75f;
    private bool isTargetReached;

    private Transform moveTarget;

    private float minAmountOfMoney = 50;
    private float maxAmountOfMoney = 200;

    private float minPriceDeviation = 0.7f;
    private float maxPriceDeviation = 1.2f;


    private float currentMoney;

    private void Start()
    {
        currentMoney = Random.Range(minAmountOfMoney, maxAmountOfMoney);
        FindNearbyShop();
    }

    private void Update()
    {
        if (moveTarget != null)
        {
            MoveTowardsTarget(moveTarget);
        }
    }

    private void InspectShop(Shop shop)
    {
        var products = shop.GetProducts();
        foreach (var product in products)
        {
            InspectProduct(product);
        }
        StartLeaving();
    }
    private void InspectProduct(Product product)
    {
        float price = product.GetCurrentPrice();

        if (price > currentMoney)
        {
            //or refuse
            return;
        }

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

    private void StartLeaving()
    {
        moveTarget = transform.parent;
        isTargetReached = false;
    }

    private void FindNearbyShop()
    {
        Collider[] colliders = new Collider[5];
        int objCount = Physics.OverlapSphereNonAlloc(transform.position, maxShopDistance, colliders, shopLayer);
        Shop shop = null;
        for (int i = 0; i < objCount; i++)
        {
            if (colliders[i].TryGetComponent(out shop))
            {
                break;
            }
        }
        moveTarget = shop.transform;
    }

    private void MoveTowardsTarget(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        if (direction.magnitude <= stoppingDistance)
        {
            OnTargetReached(target);
            return;
        }
        transform.Translate(speed * Time.deltaTime * direction.normalized);
    }

    private void OnTargetReached(Transform target)
    {
        if (isTargetReached == true)
        {
            return;
        }
        isTargetReached = true;
        if (target.TryGetComponent(out Shop shop))
        {
            InspectShop(shop);
            return;
        }
        if (target == transform.parent)
        {
            Destroy(gameObject);
        }
    }
}
