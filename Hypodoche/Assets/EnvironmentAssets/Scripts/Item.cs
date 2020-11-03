using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public string title;
    public string description;
    public Sprite icon;

    public ItemType itemType;

    public enum ItemType
    {
        ElementalZone,
        Trap
    }
    //public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item(int id, string title, string description,string ItemType)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + title );
        this.itemType=(ItemType)Enum.Parse(typeof(ItemType),ItemType,false);
        //Debug.Log(this.icon);
    }

    public Item()
    {
        
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.icon = item.icon;
        this.itemType = item.itemType;
    }
    
}
