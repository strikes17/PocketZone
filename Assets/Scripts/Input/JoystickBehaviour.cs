namespace PocketZone.Input
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    public sealed class JoystickBehaviour : MonoBehaviour, IEndDragHandler, IDragHandler
    {
        [SerializeField]
        private Transform startTransform = default;

        [SerializeField]
        private float outerCircleLimitDistance = 1f;

        public Vector2 JoystitckDelta => joystickDelta;

        private Vector2 joystickDelta = default;

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 targetPosition = eventData.position - new Vector2(startTransform.position.x, startTransform.position.y);
            transform.localPosition = Vector2.ClampMagnitude(targetPosition, outerCircleLimitDistance);
            joystickDelta = new Vector2(transform.position.x - startTransform.position.x,
             transform.position.y - startTransform.position.y);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.localPosition = joystickDelta = Vector2.zero;
        }
    }
}
