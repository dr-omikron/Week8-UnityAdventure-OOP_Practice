using Characters;
using UnityEngine;

namespace CollectableItems
{
    public class SpeedPotionItem : CollectableItem
    {
        [SerializeField] private float _speedBoostValue;

        public override void Use(Character character)
        {
            character.Mover.AddSpeed(_speedBoostValue);
            base.Use(character);
        }
    }
}
