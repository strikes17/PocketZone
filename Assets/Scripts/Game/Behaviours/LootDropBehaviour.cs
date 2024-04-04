using UnityEngine;

namespace PocketZone.Game
{
    public class LootDropBehaviour : AbstractBehaviour
    {
        [SerializeField]
        protected LootData lootData = default;

        [SerializeField]
        protected LifeBehaviour lifeBehaviour = default;

        protected virtual void OnEnable() => lifeBehaviour.onLifeEnded += DropLoot;

        protected virtual void OnDisable() => lifeBehaviour.onLifeEnded -= DropLoot;

        protected virtual void DropLoot()
        {
            var loot = lootData.Loot;
            foreach (AbstractPickableBehaviour item in loot)
            {
                AbstractPickableBehaviour instance = Instantiate(item, Vector2.zero, Quaternion.identity, transform);
                instance.transform.localPosition = Vector2.zero + new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
                instance.transform.SetParent(null);
            }
        }
    }
}
