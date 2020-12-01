using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{

    public class Item {
        
        #region Variables
        public int _id; 
        public string _title;
        public string _description;
        public Sprite _icon;
        public GameObject _prefab;
        public ItemType _itemType;
        public int _numParams;
        public Sprite _spriteParam1;
        public Sprite _spriteParam2;
        public string _valueParam1;
        public string _valueParam2;
        
        //public Dictionary<string, int> stats = new Dictionary<string, int>();
        public enum ItemType {
        ElementalZone,
        Trap
        }
        #endregion

        #region Methods
        
        public Item(int id, string title, string description,string ItemType,Sprite icon,GameObject prefab,
            int numParams,Sprite spriteParam1,string valueParam1){
            _id = id;
            _title = title;
            _description = description;
            _icon = icon;
            _prefab = prefab;
            _itemType = (ItemType)Enum.Parse(typeof(ItemType),ItemType,false);
            _numParams = numParams;
            _spriteParam1 = spriteParam1;
            _valueParam1 = valueParam1;
        }
        
        public Item(int id, string title, string description,string ItemType,Sprite icon,GameObject prefab,
                    int numParams,Sprite spriteParam1,string valueParam1,Sprite spriteParam2,string valueParam2){
            _id = id;
            _title = title;
            _description = description;
            _icon = icon;
            _prefab = prefab;
            _itemType = (ItemType)Enum.Parse(typeof(ItemType),ItemType,false);
            _numParams = numParams;
            _spriteParam1 = spriteParam1;
            _valueParam1 = valueParam1;
            _spriteParam2 = spriteParam2;
            _valueParam2 = valueParam2;
        }
        
        public Item() {
            
        }

        public Item(Item item)
        {
            _id = item._id;
            _title = item._title;
            _description = item._description;
            _icon = item._icon;
            _prefab = item._prefab;
            _itemType = item._itemType;
            _numParams = item._numParams;
            _spriteParam1 = item._spriteParam1;
            _spriteParam2 = item._spriteParam2;
            _valueParam1 = item._valueParam1;
            _valueParam2 = item._valueParam2;
        }

        #endregion
    }
}
