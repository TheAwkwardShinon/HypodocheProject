using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche {
    public class ButtonUI : MonoBehaviour {
        //[SerializeField] private List<ButtonTypeSO> buttonTypeSOList;
        //private BuildingManager buildingManager;
        //private List<Transform> buildingBtn;
        private BuildingManager _buildingManager;
        private void Start() {
            _buildingManager = GameObject.FindGameObjectWithTag("BuildingManager").GetComponent<BuildingManager>();
            _buildingManager.DeselectArena();
            Transform btn1 = transform.Find("Button1");
            btn1.GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log("button1"); 
                _buildingManager.SelectArena();
            });
            Transform btn2 = transform.Find("Button2");
            btn2.GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log("button2");
                _buildingManager.LoadArena();
                if (_buildingManager._isArenaOn)
                {
                    _buildingManager.DeselectArena();
                }
                else
                {
                    _buildingManager.DeselectInventory();
                }
            });
        }
    }
}
