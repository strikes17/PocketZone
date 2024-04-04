using UnityEngine;

namespace PocketZone.Game
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class AmmoItemBehaviour : AbstractPickableBehaviour
    {
        [SerializeField]
        protected AbstractAmmoItemData ammoItemData = default;

        public override AbstractItemData ItemData => ammoItemData;

        public override void Equip()
        {
            
        }
    }
}
