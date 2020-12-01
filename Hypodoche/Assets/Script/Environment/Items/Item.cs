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
        
        //public Dictionary<string, int> stats = new Dictionary<string, int>();
        public enum ItemType {
        ElementalZone,
        Trap
        }
        #endregion

        #region Methods
        public Item(int id, string title, string description,string ItemType,Sprite icon,GameObject prefab){
            _id = id;
            _title = title;
            _description = description;
            _icon = icon;
            _prefab = prefab;
            _itemType=(ItemType)Enum.Parse(typeof(ItemType),ItemType,false);
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
        }

        #endregion
    }
}
