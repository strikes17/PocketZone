namespace PocketZone.Game
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "PocketZone/New Weapon Data", fileName = "New Weapon Data")]
    public class WeaponData : AbstractItemData
    {
        [SerializeField]
        protected AbstractAmmoItemData abstractAmmoItemData = default;

        public AbstractAmmoItemData AmmoData => abstractAmmoItemData;
    }
}
