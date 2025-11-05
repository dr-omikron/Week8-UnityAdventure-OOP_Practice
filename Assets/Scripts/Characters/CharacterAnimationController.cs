using UnityEngine;

namespace Characters
{
    public class CharacterAnimationController : MonoBehaviour
    {
        private readonly int _isMoving = Animator.StringToHash("IsMoving");
        private readonly int _isDead = Animator.StringToHash("IsDead");

        [SerializeField] private Animator _animator;
        [SerializeField] private Character _character;

        private void Update()
        {
            UpdateAnimationFlags();
        }

        private void UpdateAnimationFlags()
        {
            bool isMoving = _character.Mover.IsMoving();
            bool isDead = _character.Health.IsDead;

            SetIsMoving(isMoving);
            SetIsDead(isDead);
        }

        private void SetIsMoving(bool value) => _animator.SetBool(_isMoving, value);

        private void SetIsDead(bool value) => _animator.SetBool(_isDead, value);
    }
}
