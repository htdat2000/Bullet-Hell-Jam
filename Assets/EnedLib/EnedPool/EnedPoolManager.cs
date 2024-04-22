using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnedUtil
{
    public class EnedPoolManager : MonoBehaviour
    {
        private Dictionary<string, List<IPoolable>> pools = new();

        public IPoolable GetObject(string key, Func<IPoolable> structureMethod)
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

        private void ClearAll()
        {
            this.pools.Clear();
        }

        private void Clear(string key)
        {
            if (this.pools.ContainsKey(key))
                this.pools[key].Clear();
        }
    }
}
