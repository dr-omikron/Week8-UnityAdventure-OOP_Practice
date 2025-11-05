using UnityEngine;

namespace CollectableItems
{
    public class SpawnPoint : MonoBehaviour
    {
        private CollectableItem _item;

        public bool IsHold { get; private set; }

        public void Hold()
        {
            IsHold = true;
        }

        public void Free()
        {
            IsHold = false;
        }
    }
}
