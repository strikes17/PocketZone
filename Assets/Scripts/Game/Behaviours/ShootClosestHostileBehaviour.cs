namespace PocketZone.Game
{
    using UnityEngine;

    [RequireComponent(typeof(ClosestEntitySelectBehaviour))]
    public class ShootClosestHostileBehaviour : AbstractShootBehaviour
    {
        [SerializeField]
        protected ClosestEntitySelectBehaviour entitySelectBehaviour = default;

        public override void TryMakeShot()
        {
            var ammo = ammoHandler.TryGetAmmo((currentWeaponContainer.Data.ItemData as WeaponData).AmmoData);

            if (ammo == null)
            {
                return;
            }

            if (ammo.Quantity == 0)
            {
                return;
            }
            var closestEntity = entitySelectBehaviour.SelectedEntity;
            if (closestEntity == null)
                return;
            Shoot(closestEntity.transform.position - transform.position);
            ammo.Quantity--;
        }
    }
}
