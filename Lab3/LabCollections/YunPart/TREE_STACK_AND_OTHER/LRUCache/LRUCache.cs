using System;
using System.Collections.Generic;

namespace Lab3.LabCollections.YunPart.TREE_STACK_AND_OTHER.LRUCache
{
    public class LRUCache
    {
        private class CacheNode
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public CacheNode Prev { get; set; }
            public CacheNode Next { get; set; }

            public CacheNode(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }

        private int capacity;
        private Dictionary<int, CacheNode> cacheMap;
        private CacheNode head;
        private CacheNode tail;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            cacheMap = new Dictionary<int, CacheNode>();
            head = new CacheNode(0, 0);
            tail = new CacheNode(0, 0);
            head.Next = tail;
            tail.Prev = head;
        }

        public int Get(int key)
        {
            if (cacheMap.ContainsKey(key))
            {
                CacheNode node = cacheMap[key];
                Remove(node);
                InsertToHead(node);
                return node.Value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (cacheMap.ContainsKey(key))
            {
                Remove(cacheMap[key]);
            }
            if (cacheMap.Count == capacity)
            {
                Remove(tail.Prev);
            }
            CacheNode newNode = new CacheNode(key, value);
            InsertToHead(newNode);
            cacheMap[key] = newNode;
        }

        private void Remove(CacheNode node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            cacheMap.Remove(node.Key);
        }

        private void InsertToHead(CacheNode node)
        {
            node.Next = head.Next;
            node.Next.Prev = node;
            head.Next = node;
            node.Prev = head;
            cacheMap[node.Key] = node;
        }
    }
}
