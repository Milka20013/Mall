using System.Collections;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private float spawnIntervalSeconds = 5;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform customerContainer;

    private void Start()
    {
        StartCoroutine(SpawnCustomerPeriodically());
    }
    private IEnumerator SpawnCustomerPeriodically()
    {
        for (; ; )
        {
            SpawnCustomer();
            yield return new WaitForSeconds(spawnIntervalSeconds);
        }
    }

    private void SpawnCustomer()
    {
        var customer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);

        if (customerContainer != null)
        {
            customer.transform.SetParent(customerContainer);
        }
        else
        {
            customer.transform.SetParent(transform);
        }
    }
}
