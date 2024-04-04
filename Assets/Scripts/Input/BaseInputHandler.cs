namespace PocketZone.Input
{
    using System;
    using UnityEngine;

    public abstract class BaseInputHandler : MonoBehaviour
    {
        public Vector2 InputAxis => input;

        protected Vector2 input = default;

        public event Action<MouseAction> onLmbAction = delegate { };

        protected virtual void OnLmbAction(MouseAction action) => onLmbAction(action);
    }
}
