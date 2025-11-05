using Characters;
using UnityEngine;

namespace Effectors
{
    public class DamageZone : MonoBehaviour
    {
        [SerializeField] private float _damagePerSecond;
        [SerializeField] private float _timeBetweenDamageTicks;

        private float _damagePerTick;
        private float _time;

        private void Awake()
        {
            _damagePerTick = _damagePerSecond * _timeBetweenDamageTicks;
        }

        private void OnTriggerStay(Collider other)
        {
            HealthComponent healthComponent = other.GetComponent<HealthComponent>();

            if (healthComponent != null)
            {
                _time += Time.deltaTime;

                if (_time >= _timeBetweenDamageTicks)
                {
                    healthComponent.TakeDamage(_damagePerTick);
                    _time = 0;
                }
            }
        }
    }
}
