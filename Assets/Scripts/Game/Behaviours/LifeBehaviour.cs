
namespace PocketZone.Game
{
    using System;
    using UnityEngine;

    public class LifeBehaviour : AbstractBehaviour
    {
        public event Action onHealthValueChanged = delegate { };
        public event Action onLifeEnded = delegate { };

        [SerializeField]
        protected EntityData entityData = default;

        [SerializeField, Header("Set to 0 if you want to set health points from entity data"), Min(0)]
        protected int currentHealthValue = 0;

        public int MaxHealthValue => entityData.DefaultHealthValue;

        public int HealthValue
        {
            get => currentHealthValue;
            set
            {
                if (currentHealthValue != value)
                {
                    currentHealthValue = Math.Clamp(value, 0, int.MaxValue);
                    Debug.Log($"{name} health: {currentHealthValue}");
                    onHealthValueChanged();

                    if (currentHealthValue == 0)
                    {
                        onLifeEnded();
                    }
                }
            }
        }

        protected virtual void Awake()
        {
            if (currentHealthValue == 0)
            {
                currentHealthValue = entityData.DefaultHealthValue;
            }
        }
    }
}
