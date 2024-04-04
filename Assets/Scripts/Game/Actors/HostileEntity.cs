namespace PocketZone.Game
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(DistanceEntityBehaviour), typeof(MoveBehaviour), typeof(Rigidbody2D))]
    public class HostileEntity : AliveEntity
    {
        [SerializeField]
        protected HostileEntityData hostileEntityData = default;

        [SerializeField, Min(0f)]
        protected float stopDistance = 0.5f;

        protected Rigidbody2D rigidbody2DMain = default;

        protected DistanceEntityBehaviour distanceEntityBehaviour = default;
        protected MoveBehaviour moveBehaviour = default;

        protected AbstractEntityBehaviour targetEntity = default;

        protected const int HUGE_MASS = 1000;
        protected const int DEFAULT_MASS = 1;

        protected override void Awake()
        {
            base.Awake();
            rigidbody2DMain = GetComponent<Rigidbody2D>();
            distanceEntityBehaviour = GetComponent<DistanceEntityBehaviour>();
            moveBehaviour = GetComponent<MoveBehaviour>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            distanceEntityBehaviour.onTargetNoticed += SetTarget;
            distanceEntityBehaviour.onTargetLost += ResetTarget;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            distanceEntityBehaviour.onTargetNoticed -= SetTarget;
            distanceEntityBehaviour.onTargetLost -= ResetTarget;
        }

        protected virtual void SetTarget(AbstractEntityBehaviour behaviour) => targetEntity = behaviour;
        protected virtual void ResetTarget(AbstractEntityBehaviour behaviour) => targetEntity = null;

        protected virtual void Update()
        {
            if (targetEntity != null)
            {
                var direction = (targetEntity.transform.position - transform.position).normalized;
                if (Vector2.Distance(transform.position, targetEntity.transform.position) > stopDistance)
                {
                    moveBehaviour.Move(direction);
                    rigidbody2DMain.mass = DEFAULT_MASS;
                }
                else
                {
                    //Чтобы когда враг достигал игрока, игрок не мог его сдвинуть с места
                    rigidbody2DMain.mass = HUGE_MASS;
                }
            }
        }
    }

    [Serializable]
    public class SerializableAliveEntity
    {
        public string DataName;
        public bool IsAlive;
        public int Health;
        public Vector2 Position;
    }

    [Serializable]
    public class SaveFile
    {
        public List<SerializableAliveEntity> Entities = new List<SerializableAliveEntity>();
    }
}
