using System;
using System.Collections.Generic;
using UnityEngine;

namespace PocketZone.Game
{
    public sealed class AmmoHandler : MonoBehaviour
    {
        [SerializeField]
        private ItemCollectorBehaviour _itemCollectorBehaviour = default;

        private Dictionary<AbstractAmmoItemData, AmmoItemBehaviour> _allAmmo = new Dictionary<AbstractAmmoItemData, AmmoItemBehaviour>();

        private void OnEnable()
        {
            _itemCollectorBehaviour.onItemAdded += TryAddAmmo;
            _itemCollectorBehaviour.onItemRemoved += TryRemoveAmmo;
            _itemCollectorBehaviour.onItemQuantityChanged += UpdateAmmoQuantity;
        }

        private void UpdateAmmoQuantity(AbstractPickableBehaviour behaviour)
        {
            var values = _allAmmo.Values;
            foreach (AmmoItemBehaviour ammoItem in values)
            {
                ammoItem.Quantity = behaviour.Quantity;
            }
        }

        private void OnDisable()
        {
            _itemCollectorBehaviour.onItemAdded -= TryAddAmmo;
            _itemCollectorBehaviour.onItemRemoved -= TryRemoveAmmo;
            _itemCollectorBehaviour.onItemQuantityChanged -= UpdateAmmoQuantity;
        }

        public AmmoItemBehaviour TryGetAmmo(AbstractAmmoItemData ammoItemData)
        {
            if (_allAmmo.TryGetValue(ammoItemData, out AmmoItemBehaviour ammoItemBehaviour))
            {
                return ammoItemBehaviour;
            }
            Debug.LogError("Failed to get ammo!");
            return null;
        }

        private void TryAddAmmo(AbstractPickableBehaviour behaviour)
        {
            var ammoBehaviour = behaviour as AmmoItemBehaviour;
            if (ammoBehaviour != null)
            {
                _allAmmo.TryAdd(ammoBehaviour.ItemData as AbstractAmmoItemData, ammoBehaviour);
            }
        }

        private void TryRemoveAmmo(AbstractPickableBehaviour behaviour)
        {
            var ammoBehaviour = behaviour as AmmoItemBehaviour;
            if (ammoBehaviour != null)
            {
                _allAmmo.Remove(ammoBehaviour.ItemData as AbstractAmmoItemData);
            }
        }
    }
}
