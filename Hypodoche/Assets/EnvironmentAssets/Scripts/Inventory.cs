using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using Hypodoche;

namespace Hypodoche{
    public class Inventory : MonoBehaviour
    {

        #region Variables
        [SerializeField] public List<BuildingTypeSO> _buildingTypeSOList;
        public List<Item> _items = new List<Item>();
        #endregion

        #region Methods
        void Start() {
            BuildInventory();
        }
        public void BuildInventory()
        {
            int id = 0;
            foreach (BuildingTypeSO buildingTypeSO in _buildingTypeSOList){ 
                Item item = new Item(id, _buildingTypeSOList[id]._title, _buildingTypeSOList[id]._description,
                    _buildingTypeSOList[id]._itemType, _buildingTypeSOList[id]._sprite, _buildingTypeSOList[id]._prefab);
                _items.Add(item);
                id++;
            }
        }
        public Item GetItem(int id)
        {
            return _items.Find(item => item._id == id);
        }
        #endregion
    }
}
