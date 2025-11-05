using Characters;
using UnityEngine;

namespace CollectableItems
{
    public class HealPotionItem : CollectableItem
    {
        [SerializeField] private float _healAmount;

        public override void Use(Character character)
        {
            character.Health.AddHealth(_healAmount);
            base.Use(character);
        }
    }
}
