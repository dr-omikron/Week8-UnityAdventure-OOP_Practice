using UnityEngine;

namespace Characters
{
    public class CharacterMover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _moveSpeed;

        private float _defaultSpeed;

        private void Awake()
        {
            _defaultSpeed = _moveSpeed;
        }

        public void MoveTo(Vector3 direction)
        {
            if(IsEnable() == false)
                return;

            _characterController.Move(direction * _moveSpeed * Time.deltaTime);
        }

        public void AddSpeed(float speed)
        {
            if(speed < 0)
            {
                Debug.LogError("Speed cannot be less than 0");
                return;
            }

            _moveSpeed += speed;
        }

        public void SetDefaultSpeed() => _moveSpeed = _defaultSpeed;

        public void TeleportTo(Vector3 position)
        {
            DisableMoving();
            _characterController.transform.position = position;
            EnableMoving();
        }

        public void DisableMoving() => _characterController.enabled = false;

        public bool IsMoving() => _characterController.velocity.magnitude > 0;

        private void EnableMoving() => _characterController.enabled = true;

        private bool IsEnable() => _characterController.enabled;
    }
}
