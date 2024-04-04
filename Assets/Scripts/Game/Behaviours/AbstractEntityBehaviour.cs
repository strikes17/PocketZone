namespace PocketZone.Game
{
    using System;
    using System.Collections.Generic;
    using PocketZone.Util;
    using UnityEngine;

    public abstract class AbstractEntityBehaviour : MonoBehaviour, IPoolable
    {
        protected Dictionary<int, AbstractBehaviour> abstractBehaviours = new Dictionary<int, AbstractBehaviour>();

        public AbstractEntityBehaviour AddBehaviour(AbstractBehaviour abstractBehaviour)
        {
            abstractBehaviours.TryAdd(abstractBehaviour.GetHashCode(), abstractBehaviour);
            return this;
        }

        public T GetBehaviour<T>() where T : AbstractBehaviour
        {
            var values = abstractBehaviours.Values;
            foreach (var behaviour in values)
            {
                if (behaviour.GetType() == typeof(T))
                {
                    return behaviour as T;
                }
            }

            Debug.LogError($"Failed to get behaviour of type {typeof(T)}");
            return null;
        }


        public IPoolable NewInstance => Instantiate(this);

        public bool IsActiveState => gameObject.activeSelf;

        public event Action onStateChanged = delegate { };

        public EntityData EntityData => entityData;

        protected EntityData entityData = default;

        public void Dispose() => SetDisableState();

        public void SetActiveState() => gameObject.SetActive(true);

        public void SetDisableState() => gameObject.SetActive(false);
    }
}
