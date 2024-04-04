using System;
using PocketZone.Container;
using UnityEngine;

namespace PocketZone.Game
{
    public class EquipmentBehaviour : AbstractBehaviour
    {
        [SerializeField]
        protected WeaponContainer currentWeaponContainer = default;

        [SerializeField]
        protected Transform rightHandTransform = default;

        [SerializeField, Min(0)]
        protected int weaponOrderInLayer = 12;

        private void OnEnable() => currentWeaponContainer.onDataChanged += SetWeaponInHand;

        private void OnDisable() => currentWeaponContainer.onDataChanged -= SetWeaponInHand;

        private void SetWeaponInHand(WeaponItemBehaviour behaviour)
        {
            if (currentWeaponContainer.PreviousWeapon != null)
            {
                currentWeaponContainer.PreviousWeapon.gameObject.SetActive(false);
            }
            behaviour.SpriteRenderer.sortingOrder = weaponOrderInLayer;
            behaviour.transform.SetParent(rightHandTransform);
            behaviour.transform.localPosition = Vector3.zero;
            behaviour.gameObject.SetActive(true);
        }
    }
}
