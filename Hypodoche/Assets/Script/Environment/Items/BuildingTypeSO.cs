using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]


    public class BuildingTypeSO : ScriptableObject
    {
        public string _title;
        public string _description;
        public string _itemType;
        public GameObject _prefab;
        public Sprite _sprite;
        public Sprite _spriteParam1;
        public Sprite _spriteParam2;
        public string _valueParam1;
        public string _valueParam2;
    }

