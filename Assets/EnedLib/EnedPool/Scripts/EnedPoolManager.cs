using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnedUtil
{
    public class EnedPoolManager : MonoBehaviour
    {
        protected Dictionary<string, List<IPoolable>> pools = new();

        public virtual IPoolable GetObject(string key, Func<IPoolable> structureMethod)
        {
            if (this.pools.ContainsKey(key) == false)
            {
                IPoolable newItem = structureMethod?.Invoke();
                this.pools.Add(key, new());
                this.pools[key].Add(newItem);

                return newItem;
            }
            else
            {
                foreach (IPoolable item in this.pools[key])
                {
                    if (item == null)
                        this.pools[key].Remove(item);
                    else if (item.IsActivating() == false)
                        return item;
                }
                IPoolable newItem = structureMethod?.Invoke();
                this.pools[key].Add(newItem);

                return newItem;
            }
        }

        protected virtual void ClearAll()
        {
            this.pools.Clear();
        }

        protected virtual void Clear(string key)
        {
            if (this.pools.ContainsKey(key))
                this.pools[key].Clear();
        }
    }
}
