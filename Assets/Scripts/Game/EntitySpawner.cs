namespace PocketZone.Game
{
    using System;
    using PocketZone.Container;
    using PocketZone.Util;
    using UnityEngine;

    public abstract class EntitySpawner : MonoBehaviour
    {
        public event Action<AliveEntity> onEntitySpawned = delegate { };

        [SerializeField]
        protected EntitiesContainer entitiesContainer = default;

        protected ObjectPool<AliveEntity> entities = default;

        protected virtual void Awake() => entitiesContainer.Clear();

        public virtual AliveEntity SpawnEntity(Vector2 position)
        {
            var entity = entities.Get();
            entity.transform.position = position;
            entitiesContainer.AddData(entity);
            onEntitySpawned(entity);
            return entity;
        }
    }
}
