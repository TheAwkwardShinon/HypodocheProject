using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class DisableInputOnMouseOver : MonoBehaviour
    {
        [SerializeField] private BuildManager _manager;
        public void OnMouseEnter(){
            _manager.SetActiveInput(false);
        }
        public void OnMouseExit()
        {
            _manager.SetActiveInput(true);
        }
    }
}
