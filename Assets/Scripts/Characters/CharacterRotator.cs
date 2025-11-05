using UnityEngine;

namespace Characters
{
    public class CharacterRotator : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        public void RotateTo(Vector3 direction)
        {
            if (direction.magnitude > 0)
                _target.rotation = Quaternion.LookRotation(direction);
        }
    }
}
