namespace PocketZone.Game
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "PocketZone/New Loot Data", fileName = "New Loot Data")]
    public class LootData : ScriptableObject
    {
        [SerializeField]
        protected List<AbstractPickableBehaviour> dropItems = new List<AbstractPickableBehaviour>();

        public IEnumerable Loot => dropItems;
    }
}
