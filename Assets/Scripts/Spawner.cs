using UnityEngine;

  public class Spawner : MonoBehaviour
  {
      float _elapsedTime = 0f;
      float _spawnTime = 0.2f;
      int _spawnCount = 0;
      bool _isSpawning = false;
      [SerializeField] private int quantity;
      [SerializeField] private Transform spawnParent;

      [Header("Side spawn")]
      [SerializeField] private float horizontalOffset = 0.5f;
      [SerializeField] private float sideForceMin = 2f;
      [SerializeField] private float sideForceMax = 5f;
      [SerializeField] private float upwardForce = 3f;

      public GameObject prefabToSpawn;

      public void StartSpawning()
      {
          if (_isSpawning) return;
          _isSpawning = true;
          _spawnCount = 0;
          _elapsedTime = 0f;
      }

      private void Update()
      {
          if (!_isSpawning) return;
          if (_spawnCount > quantity)
          {
              _isSpawning = false;
              return;
          }

          _elapsedTime += Time.deltaTime;

          if (_elapsedTime >= _spawnTime)
          {
              _elapsedTime = 0f;

              float dir = (_spawnCount % 2 == 0) ? 1f : -1f;
              Vector3 spawnPos = transform.position + new Vector3(dir * horizontalOffset, 0f, 0f);

              Transform parent = spawnParent != null ? spawnParent : transform.parent;
              GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity, parent);
              _spawnCount++;

              if (spawnedPrefab.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
              {
                  float sideForce = Random.Range(sideForceMin, sideForceMax) * dir;
                  rb.linearVelocity = new Vector2(sideForce, upwardForce);
              }
          }
      }
  }