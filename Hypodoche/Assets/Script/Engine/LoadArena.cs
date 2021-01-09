using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche
{
    public class LoadArena : MonoBehaviour
    {
        #region Variables
        [SerializeField] private ArenaTransferSO _arenaTransfer;
        [SerializeField] private Transform _basePoint;
        [SerializeField] private float _horizontalOffset;
        [SerializeField] private float _verticalOffset;
        [SerializeField] private List<GameObject> _bossList;
        [SerializeField] private Transform _spawnBossPosition;
        [SerializeField] private GameObject _debuffArea;
        [SerializeField] private Image _healthFill;
        [SerializeField] private Text _nameText;

        [SerializeField] private Image _firstMinionFill;
        [SerializeField] private Image _secondMinionFill;

        [SerializeField] private GameObject _firstMinionCanvas;
        [SerializeField] private GameObject _secondMinionCanvas;

        [SerializeField] private IceCrow _firstMinion;
        [SerializeField] private WaterCrow _secondMinion;






        #endregion

        #region Methods
        void Awake()
        {
            SpawnBoss();
            int i = 0, j = 0;
            try{
                foreach (GameObject prefab in _arenaTransfer.GetSlotArray()){       
                    if (prefab != null){
                        Debug.Log("the prefab["+i+"] is not null: "+prefab.name);
                        Instantiate(prefab, new Vector3(_basePoint.position.x + i * _horizontalOffset, 0, _basePoint.position.z - j * _verticalOffset), Quaternion.identity);
                    }
                    else{
                        Debug.Log("the prefab["+i+"] is null");
                    }
                    i++;
                    if(i == 5) {
                        i = 0;
                        j++;
                    }
                }
            }catch(NullReferenceException e){
                if(_arenaTransfer.GetSlotArray() == null){
                    Debug.Log("yep, is null getSlotArray()");
                }else{
                    Debug.Log("somthing went wrong, but the array is not null");
                }
                return;
            }
        }

        private void SpawnBoss()
        {
            int index = UnityEngine.Random.Range(0, _bossList.Count);
            GameObject boss = _bossList[index];
            //BOSS SETUP
            boss.GetComponent<Entity>()._ui = _debuffArea;
            boss.GetComponent<Enemy>().SetFill(_healthFill);
            if(boss.GetComponent<LiYan>() != null)
                _nameText.text = "Li Yan";
            if(boss.GetComponent<Halja>() != null){
                _nameText.text = "Halja";
                /*boss.GetComponent<Halja>().setIceCrow(_firstMinion);
                boss.GetComponent<Halja>().setWaterCrow(_secondMinion);*/
                //boss.GetComponent<Halja>().GetIceCrowGO().GetComponent<WaterCrow>().setIceCrow(_firstMinion);
                //boss.GetComponent<Halja>().GetIceCrowGO().GetComponent<IceCrow>().setWaterCrow(_secondMinion);
                boss.GetComponent<Halja>().GetIceCrowGO().GetComponent<Enemy>().SetFill(_firstMinionFill);
                boss.GetComponent<Halja>().GetWaterCrowGO().GetComponent<Enemy>().SetFill(_secondMinionFill);
                boss.GetComponent<Halja>().GetIceCrowGO().GetComponent<IceCrow>().setCanvas(_firstMinionCanvas);
                boss.GetComponent<Halja>().GetWaterCrowGO().GetComponent<WaterCrow>().setCanvas(_secondMinionCanvas);
            }
            if(boss.GetComponent<Caputmallei>() != null){
                _nameText.text = "Caput Mallei";
            }

            Instantiate(boss, _spawnBossPosition.position, Quaternion.identity);
        }
        #endregion
    }
}
    
