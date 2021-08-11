using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject EnemyPrefab;

    void Start()
    {
        InvokeRepeating("InstantiateEnemy", 1f, Random.Range(8, 12));
    }

    public void InstantiateEnemy()
    {
        Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
    }
}
