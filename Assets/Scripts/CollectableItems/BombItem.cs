using Characters;
using UnityEngine;

namespace CollectableItems
{
    public class BombItem : CollectableItem
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private float _startPositionYOffset;

        public override void Use(Character character)
        {
            Vector3 startPosition = character.transform.position;
            Quaternion startRotation = character.transform.rotation;
            startPosition.y += _startPositionYOffset;

            Projectile projectile = Instantiate(_projectilePrefab, startPosition, startRotation);
            projectile.StartProjectile();

            base.Use(character);
        }
    }
}
