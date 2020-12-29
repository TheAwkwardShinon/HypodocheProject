using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Hypodoche
{
    public class InstantiatePlayer : MonoBehaviour
    {
        [SerializeField] private PlayerInstantiateSO _playerPositionSO;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private CinemachineVirtualCamera _vm;
        [SerializeField] private BoardBehaviour _bb;
        private void Awake()
        {
            GameObject player = Instantiate(_playerPrefab, _playerPositionSO.GetPosition(), Quaternion.identity);
            _vm.Follow = player.transform;
            _bb.SetPlayerTransform(player.transform);
        }
    }
}
