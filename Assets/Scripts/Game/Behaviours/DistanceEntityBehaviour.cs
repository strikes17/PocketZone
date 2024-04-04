namespace PocketZone.Game
{
    using System;
    using System.Collections;
    using UnityEngine;

    public class DistanceEntityBehaviour : AbstractBehaviour
    {
        [SerializeField]
        protected AbstractEntityBehaviour entityTarget = default;

        [SerializeField, Min(0f)]
        protected float targetNoticeDistance = 10f;

        [SerializeField, Min(0f)]
        protected float noticeCheckInterval = 0.5f;

        protected float distanceToTarget = 0f;

        protected WaitForSeconds waitForSeconds = default;

        public event Action<AbstractEntityBehaviour> onTargetNoticed = delegate { };
        public event Action<AbstractEntityBehaviour> onTargetLost = delegate { };

        protected Coroutine noticeCheckCoroutine = default;

        public AbstractEntityBehaviour EntityTarget
        {
            get => entityTarget;
            set => entityTarget = value;
        }

        protected void OnEnable()
        {
            waitForSeconds = new WaitForSeconds(noticeCheckInterval);
            noticeCheckCoroutine = StartCoroutine(NoticeCheckCoroutine());
        }

        protected void OnDisable()
        {
            if (noticeCheckCoroutine != null)
            {
                StopCoroutine(noticeCheckCoroutine);
            }
        }

        protected virtual IEnumerator NoticeCheckCoroutine()
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
                    distanceToTarget = Vector2.Distance(transform.position, targetPosition);
                    if (distanceToTarget < targetNoticeDistance)
                    {
                        onTargetNoticed(entityTarget);
                    }
                    else
                    {
                        onTargetLost(entityTarget);
                    }
                    yield return waitForSeconds;
                }
            }
        }
    }
}
