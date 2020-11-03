using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject slots;
    public List<GameObject> Slots = new List<GameObject>();
    public List<Item> Items = new List<Item>();
    private ItemDatabase database;
    private int x = -110;
    private int y = 110;
    public GameObject toolTip;
    
    // Start is called before the first frame update
    void Start()
    {
        int slotAmount = 0;
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        for (int i = 1; i < 6; i++)
        {
            for (int k = 1; k < 6; k++)
            {
                GameObject slot = (GameObject) Instantiate(slots);
                Slots.Add(slot);
                Items.Add(new Item());
                addItem(slotAmount);
                slot.transform.SetParent(this.gameObject.transform);
                slot.AddComponent<SlotScript>();
                slot.GetComponent<SlotScript>().slotNumber = slotAmount;
                slot.name = "Slot" + i + "," + k;
                slot.GetComponent<RectTransform>().localPosition = new Vector2(x, y);
                
                /*GameObject obj = new GameObject();
                obj.transform.SetParent(slot.transform);
                obj.AddComponent<RectTransform>();
                obj.GetComponent<RectTransform>().localPosition = new Vector2(x, y);
                obj.AddComponent<Image>();*/

                x = x + 55;
                if (k == 5)
                {
                    x = -110;
                    y = y - 55;
                }

                slotAmount++;
            }

        }

    }

    public void showToolTip(Vector2 toolPosition, Item item)
    {
        toolTip.SetActive(true);
        toolTip.GetComponent<RectTransform>().localPosition = new Vector2(toolPosition.x + 360, toolPosition.y);
        toolTip.transform.GetChild(0).GetComponent<Text>().text = item.title;
        toolTip.transform.GetChild(1).GetComponent<Text>().text = item.description;
        Debug.Log(toolTip.transform.GetChild(1).GetComponent<Text>().text);
    }

    public void closeToolTip()
    {
        toolTip.SetActive(false);
    }

    void addItem(int id)
    {
        for (int i = 0; i < database.items.Count; i++)
        {
            if (database.items[i].id == id)
            {
                Item item = database.items[i];
                //Items.Add(item);
                addItemAtEmptySlot(item);
                break;
            }
        }
    }

    void addItemAtEmptySlot(Item item)
    {
        //Debug.Log(Items.Count);
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].title == null)
            {
                Items[i] = new Item(item);
                
                //Debug.Log(Items[i].title + " added at pos "+ i + "" + Items[i].description);
                break;
            }
        }
    }
    
}
