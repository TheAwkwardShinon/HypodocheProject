using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class DisableInputOnMouseOver : MonoBehaviour
    {
        [SerializeField] private BuildManager _manager;
        [SerializeField] private ShopManager _shopManager;
        public void OnMouseEnter(){
            _shopManager.SetActiveInput(false);
            _manager.SetActiveInput(false);
        }
        public void OnMouseExit()
        {
            _shopManager.SetActiveInput(true);
            _manager.SetActiveInput(true);
        }
    }
}
