using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class SerializableMap<K,V>
{
    [SerializeField]
    private List<Pair> _contents;
    
    public SerializableMap()
    {
        _contents = new List<Pair>();
    }

    public void add(K key, V value)
    {
        _contents.Add(new Pair(key, value));
    }

    public V get(K key)
    {
        return _contents.Find(pair => pair.key.Equals(key)).value;
    }

    public List<Pair> getList()
    {
        return new List<Pair>(_contents);
    }

    [Serializable]
    public class Pair
    {
        public K key;
        public V value;

        public Pair(K _key, V _value)
        {
            key = _key;
            value = _value;
        }
    }
}
