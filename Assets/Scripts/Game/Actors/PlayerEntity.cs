namespace PocketZone.Game
{
    using UnityEngine;

    [RequireComponent(typeof(EquipmentBehaviour))]
    public class PlayerEntity : AliveEntity
    {
        [SerializeField]
        protected EquipmentBehaviour equipmentBehaviour = default;
    }
}
