using System;
using UnityEngine;

namespace PocketZone.Game
{
    public abstract class AbstractPickableBehaviour : MonoBehaviour
    {
        [SerializeField, Min(1)]
        protected int quantity = 1;

        public event Action onQuantityChanged = delegate { };

        public event Action onPickedUp = delegate { };

        public abstract AbstractItemData ItemData { get; }

        public bool IsPicked => isPicked;

        protected bool isPicked = false;

        public int Quantity
        {
            get => quantity;
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    onQuantityChanged();
                }
            }
        }

        public abstract void Equip();

        protected virtual void OnPickedUp() => onPickedUp();

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (isPicked)
                return;
            var collector = other.GetComponent<ItemCollectorBehaviour>();
            if (collector != null)
            {
                collector.AddItem(this);
                gameObject.SetActive(false);
                OnPickedUp();
            }
        }
    }
}
