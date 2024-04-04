namespace PocketZone.Gui
{
    using UnityEngine;

    public class ButtonCloseWindow : AbstractButton
    {
        [SerializeField]
        protected BaseWindow window = default;

        protected override void OnButtonClicked() => window.gameObject.SetActive(false);
    }
}
