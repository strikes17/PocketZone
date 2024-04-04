namespace PocketZone.Container
{
    using System;
    using UnityEngine;

    public class BaseContainer<T> : ScriptableObject
    {
        public event Action<T> onDataChanged = delegate { };
        public event Action<T> onPreDataChanged = delegate { };

        public virtual T Data
        {
            get => data;
            set
            {
                if (value != null)
                {
                    OnPreDataChanged();
                    data = value;
                    OnDataChanged();
                }
                else
                {
                    Debug.LogError("Data cannot be null");
                }
            }
        }

        public virtual void Clear() => data = default;

        protected virtual void OnDataChanged() => onDataChanged(data);
        protected virtual void OnPreDataChanged() => onPreDataChanged(data);

        [SerializeField]
        protected T data = default;

    }
}
