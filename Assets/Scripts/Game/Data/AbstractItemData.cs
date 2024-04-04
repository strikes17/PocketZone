using UnityEngine;

namespace PocketZone.Game
{
    public abstract class AbstractItemData : ScriptableObject
    {
        [SerializeField]
        protected string title = string.Empty;

        [SerializeField]
        protected string description = string.Empty;

        [SerializeField]
        protected Sprite sprite = default;

        [SerializeField, Min(1)]
        protected int defaultQuantity = 1;

        public string Title => title;
        public string Description => description;

        public Sprite Sprite => sprite;

        public int DefaultQuantity => defaultQuantity;
    }
}
