namespace PocketZone.Game
{
    using PocketZone.Input;
    using UnityEngine;

    public class PlayerMoveBehaviour : MoveBehaviour
    {
        [SerializeField]
        protected BaseInputHandler baseInputHandler = default;

        protected virtual void Update() => Move(baseInputHandler.InputAxis);
    }
}
