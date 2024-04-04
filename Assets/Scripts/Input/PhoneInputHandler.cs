namespace PocketZone.Input
{
    using UnityEngine;

    public class PhoneInputHandler : BaseInputHandler
    {
        [SerializeField]
        protected JoystickBehaviour joystickBehaviour = default;

        protected virtual void Update() => input = joystickBehaviour.JoystitckDelta.normalized;
    }
}
