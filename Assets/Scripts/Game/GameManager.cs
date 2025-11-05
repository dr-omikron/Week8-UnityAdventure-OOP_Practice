using UnityEngine;
using Characters;
using CollectableItems;
using Unity.VisualScripting;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter _characterPrefab;
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private ItemFollower _itemFollower;
        [SerializeField] private CollectableSpawner _collectableSpawner;

        private PlayerCharacter _playerCharacter;
        private SpawnedContainer _spawnedContainer;
        private CollectableCollector _collectableCollector;

        private void Awake()
        {
            _spawnedContainer = new SpawnedContainer();

            _playerCharacter = Instantiate(_characterPrefab, _playerStartPoint.position, Quaternion.identity);
            _collectableCollector = _playerCharacter.AddComponent<CollectableCollector>();
            
            _collectableCollector.Initialize(_spawnedContainer);
            _playerCharacter.Initialize(_playerStartPoint.position, _inputManager, _collectableCollector, _itemFollower);

            _collectableSpawner.Initialize(_spawnedContainer);
            _collectableSpawner.StartSpawning();
        }

        private void Update()
        {
            if (_inputManager.IsRestart)
                RestartGame();
        }

        private void RestartGame()
        {
            _playerCharacter.Restart();
            _spawnedContainer.Clear();
            _collectableSpawner.FreeAllSpawnPoints();
            _collectableSpawner.StartSpawning();
        }
    }
}
