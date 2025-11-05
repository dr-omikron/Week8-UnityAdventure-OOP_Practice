using System.Collections.Generic;

namespace CollectableItems
{
    public class SpawnedContainer
    {
        private readonly Dictionary<CollectableItem, SpawnPoint> _collectables = new Dictionary<CollectableItem, SpawnPoint>();

        public void AddItem(CollectableItem item, SpawnPoint spawnPoint) => _collectables.Add(item, spawnPoint);

        public void CollectItem(CollectableItem item)
        {
            _collectables[item].Free();
            _collectables.Remove(item);
        }

        public void Clear()
        {
            foreach (KeyValuePair<CollectableItem, SpawnPoint> collectable in _collectables)
                collectable.Key.DestroyItem();

            _collectables.Clear();
        }

    }
}
