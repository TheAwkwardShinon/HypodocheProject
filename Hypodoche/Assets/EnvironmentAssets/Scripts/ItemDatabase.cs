using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    
    void Start()
    {
        buildDatabase();
    }

    public void buildDatabase()
    {
        items = new List<Item>()
        {
            new Item(0, "fire", "A zone of fire","ElementalZone"),
            new Item(1, "wind", "A zone of wind","ElementalZone"),
            new Item(2, "water", "A zone of water","ElementalZone"),
            new Item(3, "earth", "A zone of earth","ElementalZone")
        };
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }
    
}
