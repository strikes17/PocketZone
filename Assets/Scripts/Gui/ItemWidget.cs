using System;
using PocketZone.Game;
using PocketZone.Util;
using UnityEngine;
using UnityEngine.UI;

namespace PocketZone.Gui
{
    public class ItemWidget : MonoBehaviour, IPoolable
    {
        [SerializeField]
        protected Image image = default;

        [SerializeField]
        protected Text quantityText = default;

        public event Action<ItemWidget> onItemWidgetUpdated = delegate { };
        public event Action<ItemWidget> onItemRemoved = delegate { };

        public AbstractPickableBehaviour TargetItem
        {
            get => abstractPickable;
            set
            {
                if (value != null)
                {
                    abstractPickable = value;
                    abstractPickable.onQuantityChanged += UpdateQuantityText;
                    var data = abstractPickable.ItemData;
                    image.sprite = data.Sprite;
                    UpdateQuantityText();
                }
                else
                {
                    abstractPickable.onQuantityChanged -= UpdateQuantityText;
                    onItemRemoved(this);
                    abstractPickable = null;
                }
                onItemWidgetUpdated(this);
            }
        }

        private void UpdateQuantityText()
        {
            if (abstractPickable.Quantity == 1)
            {
                quantityText.text = string.Empty;
            }
            else
            {
                quantityText.text = abstractPickable.Quantity.ToString();
            }
        }

        protected AbstractPickableBehaviour abstractPickable = default;

        public IPoolable NewInstance => Instantiate(this);

        public bool IsActiveState => gameObject.activeSelf;

        public event Action onStateChanged = delegate { };

        public void Dispose() => gameObject.SetActive(false);

        public void SetActiveState() => gameObject.SetActive(true);

        public void SetDisableState() => gameObject.SetActive(false);
    }
}
