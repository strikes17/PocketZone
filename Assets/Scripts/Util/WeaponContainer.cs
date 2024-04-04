namespace PocketZone.Container
{
    using PocketZone.Game;
    using UnityEngine;

    [CreateAssetMenu(menuName = "PocketZone/New Weapon Container", fileName = "New Weapon Container")]
    public class WeaponContainer : BaseContainer<WeaponItemBehaviour>
    {
        public WeaponItemBehaviour PreviousWeapon => previousWeapon;
        
        protected WeaponItemBehaviour previousWeapon = default;

        protected override void OnPreDataChanged()
        {
            previousWeapon = data;
            base.OnPreDataChanged();
        }
    }
}
