using CollectableItems;
using Game;
using UnityEngine;

namespace Characters
{
    public class PlayerCharacter : Character
    {
        [SerializeField] private Transform _itemFollowPoint;

        private ItemFollower _itemFollower;
        private InputManager _inputManager;
        private CollectableCollector _collectableCollector;

        private bool _isItemAttached;

        protected override void Update()
        {
            ProcessMove();
            CheckUserInput();

            if(IsItemCollect() && _isItemAttached == false)
                AttachCollected();
            
            if(_isItemAttached)
                _itemFollower.UpdateFollowPosition(_itemFollowPoint.position);

            base.Update();
        }

        public void Initialize(Vector3 startPoint, InputManager inputManager, CollectableCollector collectableCollector, ItemFollower itemFollower)
        {
            StartPoint = startPoint;
            _inputManager = inputManager;
            _collectableCollector = collectableCollector;
            _itemFollower = itemFollower;
            Restart();
        }

        protected override void Die()
        {
            if(IsItemCollect())
            {
                _collectableCollector.CollectedItem.DestroyItem();
                _collectableCollector.RemoveItem();
                _isItemAttached = false;
            }

            base.Die();
        }

        private void CheckUserInput()
        {
            if (_inputManager.IsUsing)
                UseCollected();
        }

        private void UseCollected()
        {
            if (IsItemCollect() == false)
            {
                Debug.Log("You don't have any item attached");
                return;
            }

            _collectableCollector.CollectedItem.Use(this);
            _collectableCollector.RemoveItem();
            _isItemAttached = false;
        }

        private void AttachCollected()
        {
            CollectableItem collectableItem = _collectableCollector.CollectedItem;

            _itemFollower.Follow(collectableItem);
            _isItemAttached = true;
        }

        private void ProcessMove()
        {
            float xDirection = _inputManager.XMovementInput;
            float zDirection = _inputManager.ZMovementInput;

            Vector3 direction = new Vector3(xDirection, 0, zDirection).normalized;

            Mover.MoveTo(direction);
            Rotator.RotateTo(direction);
        }

        private bool IsItemCollect() => _collectableCollector.CollectedItem !=null;
    }
}
