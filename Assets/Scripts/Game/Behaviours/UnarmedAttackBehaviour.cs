namespace PocketZone.Game
{
    using System;
    using System.Collections;
    using UnityEngine;

    [RequireComponent(typeof(DistanceEntityBehaviour))]
    public class UnarmedAttackBehaviour : AbstractBehaviour
    {
        public event Action<AbstractEntityBehaviour> onTargetHit = delegate { };

        [SerializeField]
        protected EntityData entityData = default;

        [SerializeField, Min(0), Header("Set to 0 if you want to set damage from entity data")]
        protected int unarmedDamage = 0;

        [SerializeField, Min(0), Header("Set to 0 if you want to set attack range from entity data")]
        protected float attackRange = 0f;

        [SerializeField, Min(0), Header("Set to 0 if you want to set attack cooldown from entity data")]
        protected float attackCooldownTime = 0f;

        protected WaitForSeconds waitForSeconds = default;

        protected Coroutine attackCoroutine = default;

        protected DistanceEntityBehaviour distanceEntityBehaviour = default;

        [SerializeField]
        protected AbstractEntityBehaviour entityTarget = default;

        protected virtual void Awake()
        {
            distanceEntityBehaviour = GetComponent<DistanceEntityBehaviour>();
            if (unarmedDamage == 0)
            {
                unarmedDamage = entityData.DefaultUnarmedDamage;
            }

            if (attackRange == 0)
            {
                attackRange = entityData.UnarmedAttackRange;
            }

            if (attackCooldownTime == 0)
            {
                attackCooldownTime = entityData.UnarmedAttackCooldownTime;
            }
        }

        protected void OnEnable()
        {
            distanceEntityBehaviour.onTargetNoticed += SetTarget;
            waitForSeconds = new WaitForSeconds(attackCooldownTime);
            attackCoroutine = StartCoroutine(AttackCoroutine());
        }

        protected virtual void SetTarget(AbstractEntityBehaviour entity) => entityTarget = entity;

        protected void OnDisable()
        {
            distanceEntityBehaviour.onTargetNoticed -= SetTarget;
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
            }
        }

        protected virtual IEnumerator AttackCoroutine()
        {
            while (gameObject.activeSelf)
            {
                if (entityTarget == null)
                {
                    yield return null;
                }
                else
                {
                    var targetPosition = entityTarget.transform.position;
                    var distanceToTarget = Vector2.Distance(transform.position, targetPosition);
                    if (distanceToTarget < attackRange)
                    {
                        Hit(entityTarget);
                    }
                    yield return waitForSeconds;
                }
            }
        }

        public virtual void Hit(AbstractEntityBehaviour target)
        {
            if (target == null)
            {
                Debug.LogError("Hit target is null");
                return;
            }

            var targetLife = target.GetComponent<LifeBehaviour>();
            targetLife.HealthValue -= unarmedDamage;
            onTargetHit(entityTarget);
        }
    }
}
