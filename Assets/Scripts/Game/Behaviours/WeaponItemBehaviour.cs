using PocketZone.Container;
using UnityEngine;

namespace PocketZone.Game
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class WeaponItemBehaviour : AbstractPickableBehaviour
    {
        [SerializeField]
        protected WeaponData weaponData = default;

        [SerializeField]
        protected WeaponContainer currentWeaponContainer = default;

        [SerializeField]
        protected SpriteRenderer spriteRenderer = default;

        public SpriteRenderer SpriteRenderer => spriteRenderer;

        public override AbstractItemData ItemData => weaponData;

        protected virtual void Awake() => spriteRenderer.sprite = weaponData.Sprite;

        public override void Equip()
        {
            currentWeaponContainer.Data = this;
            Debug.Log("Weapon changed to {name}");
        }

        protected override void OnPickedUp()
        {
            base.OnPickedUp();
            isPicked = true;
        }
    }
}
