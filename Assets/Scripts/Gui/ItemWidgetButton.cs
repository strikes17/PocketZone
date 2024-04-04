using UnityEngine;

namespace PocketZone.Gui
{
    public class ItemWidgetButton : AbstractButton
    {
        [SerializeField]
        protected ItemWidget itemWidget = default;

        protected override void OnButtonClicked() => itemWidget.TargetItem.Equip();
    }
}
