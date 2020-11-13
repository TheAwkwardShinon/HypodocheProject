using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

namespace Hypodoche{
    public class Inventory : MonoBehaviour
    {

        #region Variables
        public List<Item> _items = new List<Item>();
        #endregion

        #region Methods
        void Start()
        {
            BuildInventory();
        }
        public void BuildInventory()
        {
            _items = new List<Item>()
            {
                new Item(0, "fire", "A zone of fire", "ElementalZone"),
                new Item(1, "wind", "A zone of wind", "ElementalZone"),
                new Item(2, "water", "A zone of water", "ElementalZone"),
                new Item(3, "earth", "A zone of earth", "ElementalZone")
            };
        }
        public Item GetItem(int id)
        {
            return _items.Find(item => item._id == id);
        }
        #endregion
    }
}
