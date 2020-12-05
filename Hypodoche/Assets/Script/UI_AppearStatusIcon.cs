using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Hypodoche
{
    public class UI_AppearStatusIcon : MonoBehaviour
    {
        [SerializeField] public List<Sprite> icons;
        [SerializeField] public Sprite stun;
        [SerializeField] public Sprite slow;
        [SerializeField] public Sprite dmgOverTime;
        private Color _color;
    
   
        //public Image enhancedDmg;

        public void Start()
        {
            icons = new List<Sprite>();
            _color = Color.white;
            _color.a = 0;
        }

        public void Update()
        {
            int i = 0;
            foreach (Sprite img in icons)
            {
                gameObject.transform.GetChild(i).GetComponent<Image>().sprite = img;
                gameObject.transform.GetChild(i).GetComponent<Image>().color = Color.white;
                i++;
            }
            for (; i < 3; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<Image>().color = _color;
            }
        }

        public void addIcon(Sprite icon)
        {
            icons.Add(icon);
        }

        public void removeIcon(Sprite icon)
        {
            icons.Remove(icon);
        }

        public void AddStun()
        {
            addIcon(stun);
        }

        public void AddSlow()
        {
            addIcon(slow);
        }
        /*
        public void AddEnhance()
        {
            addIcon(enhancedDmg);
        }*/

        public void AddDmgOverTime()
        {
            addIcon(dmgOverTime);
        }

        public void RemoveStun()
        {
            removeIcon(stun);
        }

        public void RemoveSlow()
        {
            removeIcon(slow);
        }
        /*
            public void RemoveEnhance()
            {
                removeIcon(enhancedDmg);
            }*/

        public void RemoveDmgOverTime()
        {
            removeIcon(dmgOverTime);
        }
    }
}
