
namespace PocketZone.Game
{
    using UnityEngine;

    public abstract class BaseFollowBehaviour : AbstractBehaviour
    {
        [SerializeField]
        protected Transform followTargetTransform = default;

        public abstract void FollowTarget();
    }
}
