using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class LoadArena : MonoBehaviour
    {
        [SerializeField] private ArenaTransferSO _arenaTransfer;
        [SerializeField] private Transform _basePoint;
        [SerializeField] private float _horizontalOffset;
        [SerializeField] private float _verticalOffset;

        void Awake()
        {
            int i = 0, j = 0;


            foreach (GameObject prefab in _arenaTransfer._slotArray){       
                if (prefab != null){
                    Debug.Log(prefab.name);
                    Instantiate(prefab, new Vector3(_basePoint.position.x + i * _horizontalOffset, _basePoint.position.y, _basePoint.position.z - j * _verticalOffset), Quaternion.identity);
                }
                i++;
                if(i == 5) {
                    i = 0;
                    j++;
                }
            }
        }
    }
}
    
