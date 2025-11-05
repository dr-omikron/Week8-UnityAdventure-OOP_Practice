using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(CharacterMover))]
    [RequireComponent(typeof(CharacterRotator))]
    [RequireComponent(typeof(HealthComponent))]

    public abstract class Character : MonoBehaviour
    {
        protected CharacterRotator Rotator;

        public CharacterMover Mover { get; private set; }
        public HealthComponent Health { get; private set; }
        public abstract Vector3 StartPoint { get; protected set; }

        private void Awake()
        {
            Rotator = GetComponent<CharacterRotator>();
            Mover = GetComponent<CharacterMover>();
            Health = GetComponent<HealthComponent>();
        }

        protected virtual void Update()
        {
            CheckIsDie();
        }

        protected virtual void Die()
        {
            Mover.DisableMoving();
        }

        public void Restart()
        {
            Health.Revive();
            Mover.TeleportTo(StartPoint);
            Mover.SetDefaultSpeed();
        }

        private void CheckIsDie()
        {
            if (Health.IsDead)
                Die();
        }
    }
}
