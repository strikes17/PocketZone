namespace PocketZone.Game
{
    using System.Linq;
    using System.Xml.Schema;
    using PocketZone.Container;
    using UnityEngine;

    public abstract class AbstractShootBehaviour : AbstractBehaviour
    {
        [SerializeField]
        protected WeaponContainer currentWeaponContainer = default;

        [SerializeField]
        protected AmmoHandler ammoHandler = default;

        public virtual void Shoot(Vector2 direction)
        {
            if (currentWeaponContainer.Data == null)
            {
                Debug.LogError("currentWeaponContainer data null");
                return;
            }

            var weaponData = currentWeaponContainer.Data.ItemData as WeaponData;
            if (weaponData == null)
            {
                Debug.LogError("Failed to get weapon data");
                return;
            }
            var ammoData = weaponData.AmmoData;
            if (ammoData == null)
            {
                Debug.LogError("Failed to get ammo data");
                return;
            }

            var raycast2D = Physics2D.RaycastAll(transform.position, direction, 100f);
            foreach (var hit in raycast2D)
            {
                if (hit.collider.gameObject == gameObject)
                    continue;
                var hitEntity = hit.collider.GetComponent<AliveEntity>();
                if (hitEntity == null)
                {
                    Debug.Log("No entity on shot!");
                    continue;
                }

                var entityLife = hitEntity.GetComponent<LifeBehaviour>();
                if (entityLife != null)
                {
                    entityLife.HealthValue -= (currentWeaponContainer.Data.ItemData as WeaponData).AmmoData.Damage;
                }
                break;
            }
        }

        public abstract void TryMakeShot();
    }
}
