using UnityEngine;

namespace CollectableItems
{
    public class ItemFollower : MonoBehaviour
    {
        [SerializeField] private float _followOffset;

        private CollectableItem _followItem;

        public void Follow(CollectableItem followItem) => _followItem = followItem;

        public void UpdateFollowPosition(Vector3 position)
        {
            Vector3 itemPosition = _followItem.gameObject.transform.position;
            _followItem.gameObject.transform.position = Vector3.Lerp(itemPosition, position, _followOffset * Time.deltaTime);
        }
    }
}
