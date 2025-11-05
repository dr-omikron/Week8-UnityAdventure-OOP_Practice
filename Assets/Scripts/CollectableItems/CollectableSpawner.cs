using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CollectableItems
{
    public class CollectableSpawner : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints;
        [SerializeField] private List<CollectableItem> _collectablePrefabs;
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private int _maxItemsSpawned;

        private SpawnedContainer _spawnedContainer;

        private float _time;
        private bool _isSpawning;

        private void Update()
        {
            if (_isSpawning == false)
            {
                ResetTime();
                return;
            }

            _time += Time.deltaTime;

            if(_time >= _spawnCooldown)
            {
                List<SpawnPoint> spawnPoints = GetEmptySpawnPoints();

                if (spawnPoints.Count == 0)
                {
                    ResetTime();
                    return;
                }

                CollectableItem collectableItem = GetRandomItemPrefab();
                SpawnToRandomPoint(collectableItem, spawnPoints);
                ResetTime();
            }
        }

        public void Initialize(SpawnedContainer spawnedContainer)
        {
            _spawnedContainer = spawnedContainer;
        }

        public void FreeAllSpawnPoints()
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
                spawnPoint.Free();
        }

        public void StartSpawning() => _isSpawning = true;

        private CollectableItem GetRandomItemPrefab() => _collectablePrefabs[Random.Range(0, _collectablePrefabs.Count)];

        private void SpawnToRandomPoint(CollectableItem collectableItem, List<SpawnPoint> spawnPoints)
        {
            SpawnPoint spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            spawnPoint.Hold();

            CollectableItem item = Instantiate(collectableItem, spawnPoint.transform.position, Quaternion.identity);
            _spawnedContainer.AddItem(item, spawnPoint);
        }

        private List<SpawnPoint> GetEmptySpawnPoints()
        {
            List<SpawnPoint> emptySpawnPoints = new List<SpawnPoint>();
            
            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                if(spawnPoint.IsHold == false)
                    emptySpawnPoints.Add(spawnPoint);
            }

            return emptySpawnPoints;
        }

        private void ResetTime() => _time = 0;
    }
}
