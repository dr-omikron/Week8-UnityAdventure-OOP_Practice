using UnityEngine;

namespace CollectableItems
{
    public class CollectableCollector : MonoBehaviour
    {
        public CollectableItem CollectedItem { get; private set; }
        private SpawnedContainer _spawnedContainer;

        public void Initialize(SpawnedContainer spawnedContainer)
        {
            _spawnedContainer = spawnedContainer;
        }

        public void RemoveItem() => CollectedItem = null;

        private void OnTriggerEnter(Collider other)
        {
            CollectableItem collidedItem = other.GetComponent<CollectableItem>();

            if (collidedItem == null || CollectedItem != null) 
                return;

            CollectedItem = collidedItem;
            CollectedItem.StopAnimation();
            _spawnedContainer.CollectItem(CollectedItem);
        }
    }
}
