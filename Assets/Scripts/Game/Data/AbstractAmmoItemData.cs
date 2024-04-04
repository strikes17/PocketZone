namespace PocketZone.Game
{
    using UnityEngine;

    public abstract class AbstractAmmoItemData : AbstractItemData
    {
        [SerializeField, Min(1)]
        protected int damage = 1;

        public int Damage => damage;
    }
}
