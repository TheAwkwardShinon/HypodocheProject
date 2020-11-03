using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler
{

    private Image itemImage;
    public int slotNumber;
    private Inventory inventory;
    
    
    // Start is called before the first frame update
    void Start()
    {
         inventory=GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
         
         itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
         

    }

    // Update is called once per frame
    void Update()
    {
       
       
        if (inventory.Items[slotNumber].title != null)
        {
            itemImage.enabled = true;
            itemImage.sprite = inventory.Items[slotNumber].icon;
 
        }
        else
        {
            itemImage.enabled = false;

        }
        
          
    }

    public void OnPointerDown(PointerEventData data)
    {
        
        Debug.Log(inventory.Items[slotNumber].title);
    }

    public void OnPointerEnter(PointerEventData data)
    {

        if (inventory.Items[slotNumber].title != null)
        {
            float x = inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition.x;
            float y = inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition.y;
            inventory.showToolTip(new Vector2(x,y),inventory.Items[slotNumber]);
            Debug.Log(x+" "+y);
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (inventory.Items[slotNumber].title != null)
        {
            inventory.closeToolTip(); 
        }
     
    }
}
