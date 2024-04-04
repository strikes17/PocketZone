namespace PocketZone.Gui
{
    using System;
    using UnityEngine;

    public class BaseWindow : MonoBehaviour
    {
        [SerializeField]
        protected bool shouldCloseOnAwake = true;

        public event Action onWindowOpened = delegate { };
        public event Action onWindowClosed = delegate { };

        public virtual void Open()
        {
            gameObject.SetActive(true);
            onWindowOpened();
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
            onWindowClosed();
        }

        protected virtual void Awake() => gameObject.SetActive(!shouldCloseOnAwake);
    }
}
