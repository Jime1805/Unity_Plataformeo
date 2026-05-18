using UnityEngine;

public class Spawner : MonoBehaviour
{  
    float _elapsedTime = 0f;
    float _spawnTime = 0.2f;
    int _spawnCount = 0;
    [SerializeField] private int quantity;

    public GameObject prefabToSpawn;

    private void Update()
    {
        if(_spawnCount > quantity) return;

        _elapsedTime = Time.deltaTime;
        
        if (_elapsedTime >= _spawnTime)
        {
            _elapsedTime = 0;
            GameObject spawnedPrefab = Instantiate(prefabToSpawn);
            if (spawnedPrefab.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
            {
                
            }
            
        }
    }

}
