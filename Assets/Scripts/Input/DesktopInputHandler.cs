namespace PocketZone.Input
{
    using UnityEngine;

    public class DesktopInputHandler : BaseInputHandler
    {
        protected virtual void Update() => input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }



}
