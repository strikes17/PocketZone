
namespace PocketZone.Game
{
    using UnityEngine;

    public sealed class CameraFollowBehaviour : BaseFollowBehaviour
    {
        public override void FollowTarget() => transform.position = new Vector3(followTargetTransform.position.x, followTargetTransform.position.y, transform.position.z);

        private void Update() => FollowTarget();
    }
}
