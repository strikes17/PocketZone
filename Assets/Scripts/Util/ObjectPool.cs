namespace PocketZone.Util
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ObjectPool<T> where T : IPoolable
    {
        protected T poolHost = default;

        protected List<T> poolObjects = new List<T>();

        public ObjectPool(T poolHost) => this.poolHost = poolHost;

        public IEnumerable Objects => poolObjects.Where(x => x.IsActiveState);

        public virtual T Get()
        {
            T poolObject = default;

            poolObjects.ForEach(x =>
            {
                if (!x.IsActiveState)
                {
                    poolObject = x;
                    return;
                }
            });

            if (poolObject == null)
            {
                poolObject = (T)poolHost.NewInstance;
                poolObjects.Add(poolObject);
            }
            return poolObject;
        }
    }
}
