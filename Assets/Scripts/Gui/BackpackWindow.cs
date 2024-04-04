using System;
using PocketZone.Game;
using PocketZone.Util;
using UnityEngine;

namespace PocketZone.Gui
{
    public class BackpackWindow : BaseWindow
    {
        [SerializeField]
        protected Transform contentTransform = default;

        [SerializeField]
        protected ItemWidget itemWidgetPrefab = default;

        [SerializeField]
        protected ItemCollectorBehaviour itemCollectorBehaviour = default;

        protected ObjectPool<ItemWidget> widgets = default;

        protected override void Awake()
        {
            base.Awake();
            widgets = new ObjectPool<ItemWidget>(itemWidgetPrefab);
            itemCollectorBehaviour.onItemAdded += AddWidget;
            itemCollectorBehaviour.onItemQuantityChanged += UpdateWidget;
        }

        protected virtual void OnDestroy()
        {
            itemCollectorBehaviour.onItemAdded -= AddWidget;
            itemCollectorBehaviour.onItemQuantityChanged -= UpdateWidget;
        }

        protected virtual void UpdateWidget(AbstractPickableBehaviour abstractPickableBehaviour)
        {
            foreach (ItemWidget widget in widgets.Objects)
            {
                if (widget.TargetItem.ItemData == abstractPickableBehaviour.ItemData)
                {
                    widget.TargetItem = abstractPickableBehaviour;
                }
            }
        }

        protected virtual void AddWidget(AbstractPickableBehaviour abstractPickableBehaviour)
        {
            var widget = widgets.Get();
            widget.transform.SetParent(contentTransform);
            widget.TargetItem = abstractPickableBehaviour;
            widget.onItemRemoved += RemoveWidget;
            widget.SetActiveState();
        }

        private void RemoveWidget(ItemWidget widget)
        {
            widget.onItemRemoved -= RemoveWidget;
            itemCollectorBehaviour.RemoveItem(widget.TargetItem);
            widget.Dispose();
        }
    }
}
