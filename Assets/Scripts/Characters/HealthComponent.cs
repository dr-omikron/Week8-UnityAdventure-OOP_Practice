using UnityEngine;

namespace Characters
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;

        private float _health;

        public bool IsDead {  get; private set; }
        public float MaxHealth => _maxHealth;
        public float Health => _health;

        public void TakeDamage(float damage)
        {
            if(IsDead)
                return;

            if (damage < 0)
            {
                Debug.Log("Damage negative");
                return;
            }

            _health -= damage;

            if (_health <= 0)
                IsDead =  true;
        }

        public void AddHealth(float healthToAdd)
        {
            if (healthToAdd < 0)
            {
                Debug.Log("Negative health added");
                return;
            }
            
            _health += healthToAdd;

            if(_health > _maxHealth)
                _health = _maxHealth;
        }

        public void Revive()
        {
            _health = _maxHealth;
            IsDead =  false;
        }
    }
}
