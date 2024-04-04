namespace PocketZone.Gui
{
    using UnityEngine;

    public class OpenWindowButton : AbstractButton
    {
        [SerializeField]
        protected BaseWindow window = default;

        protected override void OnButtonClicked() => window.gameObject.SetActive(true);
    }
}
