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
        public ItemType _itemType;
        
        //public Dictionary<string, int> stats = new Dictionary<string, int>();
        public enum ItemType {
        ElementalZone,
        Trap
        }
        #endregion

        #region Methods
        public Item(int id, string title, string description,string ItemType){ 
            _id = id;
            _title = title;
            _description = description;
            _icon = Resources.Load<Sprite>("Sprites/Items/" + title );
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
            _itemType = item._itemType;
        }

        #endregion
    }
}
