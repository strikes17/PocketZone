using System;
using System.Collections.Generic;
using System.Linq;

namespace PocketZone.Game
{
    public class ItemCollectorBehaviour : AbstractBehaviour
    {
        protected List<AbstractPickableBehaviour> itemsList = new List<AbstractPickableBehaviour>();

        public event Action<AbstractPickableBehaviour> onItemAdded = delegate { };
        public event Action<AbstractPickableBehaviour> onItemRemoved = delegate { };
        public event Action<AbstractPickableBehaviour> onItemQuantityChanged = delegate { };

        public virtual void AddItem(AbstractPickableBehaviour abstractPickableBehaviour)
        {
            var item = itemsList.FirstOrDefault(x => x.ItemData == abstractPickableBehaviour.ItemData);
            bool isItemStacks = abstractPickableBehaviour.ItemData.DefaultQuantity > 1;
            if (item != null && isItemStacks)
            {
                abstractPickableBehaviour.Quantity += item.Quantity;
                onItemQuantityChanged(abstractPickableBehaviour);
            }
            else
            {
                itemsList.Add(abstractPickableBehaviour);
                onItemAdded(abstractPickableBehaviour);
            }
        }

        public virtual void RemoveItem(AbstractPickableBehaviour abstractPickableBehaviour)
        {
            itemsList.Remove(abstractPickableBehaviour);
            onItemRemoved(abstractPickableBehaviour);
            Destroy(abstractPickableBehaviour.gameObject);
        }
    }
}
