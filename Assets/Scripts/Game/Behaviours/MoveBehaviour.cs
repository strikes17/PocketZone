namespace PocketZone.Game
{
    using UnityEngine;

    public class MoveBehaviour : AbstractBehaviour
    {
        [SerializeField]
        protected float moveSpeed = 10f;

        [SerializeField]
        protected Rigidbody2D rigidbodyToMove = default;

        public virtual void Move(Vector2 direction) => rigidbodyToMove.AddForce(moveSpeed * direction);
    }
}
