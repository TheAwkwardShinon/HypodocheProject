using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class StartingSetup : MonoBehaviour
    {
        #region Variables
        [SerializeField] private TrapInventory _playerInventory;
        [SerializeField] private TrapShop _shopInventory;
        [SerializeField] private int _startingPlayerCoins;
        [SerializeField] private ArenaTransferSO _arenaTransferSO;
        [SerializeField] private List<TrapItem> _shopList;
        [SerializeField] private PlayerInstantiateSO _playerPosition;
        [SerializeField] private OracleDialogueProgression _odp;
        [SerializeField] private CampaignProgressionManager _cpm;
        #endregion

        #region Methods
        void Start()
        {
            _cpm.Setup();
            _playerPosition.SetPosition(new Vector3(0, 0.01f, -13));
            _playerInventory.Reset();
            _shopInventory.Reset(_shopList);
            _arenaTransferSO.Reset();
            _playerInventory.SetPlayerCoins(_startingPlayerCoins);
            _playerInventory.Setup();
            _shopInventory.Setup();
            _odp.ResetIndex();
            _cpm.Advance(true);
        }
        #endregion
    }
}
