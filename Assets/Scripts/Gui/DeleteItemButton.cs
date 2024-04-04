using System;
using UnityEngine;

namespace PocketZone.Gui
{
    public class DeleteItemButton : AbstractButton
    {
        [SerializeField]
        protected ItemWidget itemWidget = default;
        
        protected override void OnButtonClicked()
        {
            itemWidget.TargetItem = null;
        }
    }
}
