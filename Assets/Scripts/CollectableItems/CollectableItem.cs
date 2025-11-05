using Characters;
using UnityEngine;

namespace CollectableItems
{
    public abstract class CollectableItem : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _destroyEffectPrefab;
        [SerializeField] private ParticleSystem _useEffectPrefab;
 
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _frequency;
        [SerializeField] private float _amplitude;

        private Vector3 _startPosition;
        private float _time;
        private bool _isUpdateAnimation = true;

        private void Awake()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            if (_isUpdateAnimation == false)
                return;

            UpdateIdleAnimation();
        }

        public virtual void Use(Character character)
        {
            PlayEffect(_useEffectPrefab, character.transform.position, character.transform.rotation);
            DestroyItem();
        }

        public void StopAnimation() => _isUpdateAnimation = false;

        public void DestroyItem()
        {
            PlayEffect(_destroyEffectPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        private void UpdateIdleAnimation()
        {
            transform.Rotate(Vector3.up, Time.deltaTime * _rotateSpeed);

            _time += Time.deltaTime * _frequency;
            transform.position = _startPosition + Vector3.up * Mathf.Sin(_time) / _amplitude;
        }

        private void PlayEffect(ParticleSystem effectPrefab, Vector3 position, Quaternion rotation)
        {
            ParticleSystem effect = Instantiate(effectPrefab, position, rotation);
            float timeToDestroyEffect = effect.main.duration;
            Destroy(effect.gameObject, timeToDestroyEffect);
        }
    }
}
