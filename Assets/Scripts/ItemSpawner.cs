using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private int itemCount = 10;

    [Header("Spawn Area")]
    [SerializeField] private Vector3 areaSize = new Vector3(30, 0, 30);
    [SerializeField] private float spawnHeight = 0.5f;

    private void Start()
    {
       

        
        DestroyItem.Instance.SetTotal(itemCount);

        SpawnItems();
    }

    private void SpawnItems()
    {
        for (int i = 0; i < itemCount; i++)
        {
            Vector3 randomPos = GetRandomPosition();
            Instantiate(itemPrefab, randomPos, Quaternion.identity);
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(
            Random.Range(-areaSize.x / 2, areaSize.x / 2),
            spawnHeight,
            Random.Range(-areaSize.z / 2, areaSize.z / 2)
        ) + transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.25f);
        Gizmos.DrawCube(transform.position, areaSize);
    }
}
