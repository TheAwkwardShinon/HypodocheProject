using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche {
    public class ButtonUI : MonoBehaviour {
        private BuildingManager _buildingManager;
        private GameObject _oracle;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                BuildArena();
            }
            
            if (Input.GetKeyDown(KeyCode.R)) {
                LoadArena();
            }
            
            if (Input.GetKeyDown(KeyCode.T)) {
                Oracle();
            }
        }
        

        private void Start()
        {
            _buildingManager = GameObject.FindGameObjectWithTag("BuildingManager").GetComponent<BuildingManager>();
            _oracle = GameObject.FindGameObjectWithTag("Oracle");
            _buildingManager.DeselectArena();
            Transform btn1 = transform.Find("Button1");
            btn1.GetComponent<Button>().onClick.AddListener(() =>    // build arena 
            {
                _buildingManager.SelectArena();
                _oracle.SetActive(false);
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
            
            Transform btn3 = transform.Find("Button3");
            btn3.GetComponent<Button>().onClick.AddListener(() => {
                if (_buildingManager._isArenaOn)
                {
                    _buildingManager.DeselectArena();
                }
                else
                {
                    _buildingManager.DeselectInventory();
                }
                _oracle.SetActive(true);
            });
        }


        private void BuildArena()
        {
            _buildingManager.SelectArena();
            _buildingManager._isArenaOn = true;
            _oracle.SetActive(false);
        }

        private void LoadArena()
        {
            _buildingManager.LoadArena();
            if (_buildingManager._isArenaOn)
            {
                _buildingManager.DeselectArena();
            }
            if (_buildingManager._isInventoryOn)
            {
                _buildingManager.DeselectInventory();
            }
        }

        private void Oracle()
        {
            if (_buildingManager._isArenaOn)
            {
                _buildingManager.DeselectArena();
            }
            if (_buildingManager._isInventoryOn)
            {
                _buildingManager.DeselectInventory();
            }
            _buildingManager.CloseToolTip();
            _oracle.SetActive(true);
        }
        
    }
}
