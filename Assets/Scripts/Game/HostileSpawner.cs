namespace PocketZone.Game
{
    using PocketZone.Util;
    using UnityEngine;

    public class HostileSpawner : EntitySpawner
    {
        [SerializeField]
        private HostileEntity entityPrefab = default;

        [SerializeField]
        private HostileEntityData entityData = default;

        [SerializeField]
        private AliveEntity playerEntity = default;

        protected override void Awake()
        {
            base.Awake();
            entities = new ObjectPool<AliveEntity>(entityPrefab);
        }

        public override AliveEntity SpawnEntity(Vector2 position)
        {
            var entity = base.SpawnEntity(position);
            entity.name = entityData.Title + Random.Range(1, 1000);
            entity.Construct(entityData);
            entity.GetComponent<DistanceEntityBehaviour>().EntityTarget = playerEntity;
            entity.SetActiveState();
            return entity;
        }
    }
}
