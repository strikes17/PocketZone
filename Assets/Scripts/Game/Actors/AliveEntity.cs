namespace PocketZone.Game
{
    using System;
    using PocketZone.Util;
    using UnityEngine;

    [RequireComponent(typeof(LifeBehaviour))]
    public class AliveEntity : AbstractEntityBehaviour
    {
        public virtual void Construct(EntityData entityData) => this.entityData = entityData;

        protected virtual void Awake() => lifeBehaviour = GetComponent<LifeBehaviour>();

        public LifeBehaviour LifeBehaviour => lifeBehaviour;

        protected LifeBehaviour lifeBehaviour = default;

        protected virtual void OnEnable() => lifeBehaviour.onLifeEnded += Dispose;

        protected virtual void OnDisable() => lifeBehaviour.onLifeEnded -= Dispose;
    }
}
