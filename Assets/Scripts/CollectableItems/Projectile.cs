using UnityEngine;

namespace CollectableItems
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private ParticleSystem _hitEffectPrefab;

        private bool _isStarted;

        private void Update()
        {
            if (_isStarted == false)
                return;

            Move();
        }

        public void StartProjectile()
        {
            _isStarted = true;
        }

        private void Move()
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision other)
        {
            ParticleSystem hitEffect = Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);
            float timeToDestroyEffect = hitEffect.main.duration;
            Destroy(hitEffect.gameObject, timeToDestroyEffect);
            Destroy(gameObject);
        }
    }
}
