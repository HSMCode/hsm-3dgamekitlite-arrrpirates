using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Gamekit3D
{
    public class InventoryController : MonoBehaviour
    {
        [System.Serializable]
        public class InventoryEvent
        {
            public string key;
            public UnityEvent OnAdd, OnRemove;
        }
        [System.Serializable]
        public class InventoryChecker
        {

            public string[] inventoryItems;
            public UnityEvent OnHasItem, OnDoesNotHaveItem;

            public bool CheckInventory(InventoryController inventory)
            {

                if (inventory != null)
                {
                    for (var i = 0; i < inventoryItems.Length; i++)
                    {
                        if (!inventory.HasItem(inventoryItems[i]))
                        {
                            OnDoesNotHaveItem.Invoke();
                            return false;
                        }
                    }
                    OnHasItem.Invoke();
                    return true;
                }
                return false;
            }
        }


        public InventoryEvent[] inventoryEvents;

        HashSet<string> m_inventoryItems = new HashSet<string>();

        public void AddItem(string key)
        {
            if (!m_inventoryItems.Contains(key))
            {
                m_inventoryItems.Add(key);
                var ev = GetInventoryEvent(key);
                if (ev != null) ev.OnAdd.Invoke();
            }
        }

        public void RemoveItem(string key)
        {
            if (m_inventoryItems.Contains(key))
            {
                var ev = GetInventoryEvent(key);
                if (ev != null) ev.OnRemove.Invoke();
                m_inventoryItems.Remove(key);
            }
        }

        public bool HasItem(string key)
        {
            return m_inventoryItems.Contains(key);
        }

        public void Clear()
        {
            m_inventoryItems.Clear();
        }

        InventoryEvent GetInventoryEvent(string key)
        {
            foreach (var iv in inventoryEvents)
            {
                if (iv.key == key) return iv;
            }
            return null;
        }
    }

}